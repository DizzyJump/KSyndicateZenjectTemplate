using CodeBase.Infrastructure.States;

namespace CodeBase.GameMode1.States
{
    public class StartGameMode1State : IState
    {
        private SceneStateMachine sceneStateMachine;

        public StartGameMode1State(SceneStateMachine sceneStateMachine) => 
            this.sceneStateMachine = sceneStateMachine;

        public void Enter()
        {
            // you can use states like this for showing starting cut scenes, objectives on the level, explaining game rules and so on
            sceneStateMachine.Enter<PlayGameMode1State>();
        }

        public void Exit()
        {
            
        }
    }
}