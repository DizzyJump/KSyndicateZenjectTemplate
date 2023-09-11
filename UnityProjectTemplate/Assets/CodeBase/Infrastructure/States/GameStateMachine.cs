namespace CodeBase.Infrastructure.States
{
    // Global state machine that switch globas states of the game.
    // Bind in project context to be available globaly
    // Game bootstraper fill this FSM by states
    public class GameStateMachine : StateMachine
    {
<<<<<<< HEAD
        
=======
        private Dictionary<System.Type, IExitableState> registeredStates;
        private IExitableState currentState;

        public GameStateMachine(
            BootstrapState.Factory bootstrapStateFactory,
            LoadPlayerProgressState.Factory loadGameSaveStateFactory,
            LoadLevelState.Factory loadLevelStateFactory)
        {
            registeredStates = new Dictionary<Type, IExitableState>();
            
            RegisterState(bootstrapStateFactory.Create(this));
            RegisterState(loadGameSaveStateFactory.Create(this));
            RegisterState(loadLevelStateFactory.Create(this));
        }

        protected void RegisterState<TState>(TState state) where TState : IExitableState =>
            registeredStates.Add(typeof(TState), state);

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

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            currentState?.Exit();
      
            TState state = GetState<TState>();
            currentState = state;
      
            return state;
        }
    
        private TState GetState<TState>() where TState : class, IExitableState => 
            registeredStates[typeof(TState)] as TState;
>>>>>>> cd5a0c5e8441ed44b4ae22846f163895da3a96f9
    }
}