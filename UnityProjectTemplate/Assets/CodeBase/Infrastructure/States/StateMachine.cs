using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure.States
{
    public abstract class StateMachine : IStateMachine
    {
        private Dictionary<System.Type, IExitableState> registeredStates;
        private IExitableState currentState;

        public StateMachine() => 
            registeredStates = new Dictionary<Type, IExitableState>();

        public void Enter<TState>() where TState : class, IState
        {
            TState newState = ChangeState<TState>();
            newState.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPaylodedState<TPayload>
        {
            TState newState = ChangeState<TState>();
            newState.Enter(payload);
        }

        public void RegisterState<TState>(TState state) where TState : IExitableState =>
            registeredStates.Add(typeof(TState), state);

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            currentState?.Exit();
      
            TState state = GetState<TState>();
            currentState = state;
      
            return state;
        }
    
        private TState GetState<TState>() where TState : class, IExitableState => 
            registeredStates[typeof(TState)] as TState;
    }
}