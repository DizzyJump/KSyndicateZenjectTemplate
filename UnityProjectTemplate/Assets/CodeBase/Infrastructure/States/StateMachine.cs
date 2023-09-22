using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public abstract class StateMachine : IStateMachine
    {
        private readonly Dictionary<System.Type, IExitableState> registeredStates;
        private IExitableState currentState;

        public StateMachine() => 
            registeredStates = new Dictionary<Type, IExitableState>();

        public async UniTask Enter<TState>() where TState : class, IState
        {
            TState newState = await ChangeState<TState>();
            await newState.Enter();
        }

        public async UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPaylodedState<TPayload>
        {
            TState newState = await ChangeState<TState>();
            await newState.Enter(payload);
        }

        public void RegisterState<TState>(TState state) where TState : IExitableState =>
            registeredStates.Add(typeof(TState), state);

        private async UniTask<TState> ChangeState<TState>() where TState : class, IExitableState
        {
            if(currentState != null)
                await currentState.Exit();
      
            TState state = GetState<TState>();
            currentState = state;
      
            return state;
        }
    
        private TState GetState<TState>() where TState : class, IExitableState => 
            registeredStates[typeof(TState)] as TState;
    }
}