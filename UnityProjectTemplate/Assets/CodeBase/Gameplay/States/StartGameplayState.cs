using CodeBase.Infrastructure.States;
using Cysharp.Threading.Tasks;

namespace CodeBase.Gameplay.States
{
    public class StartGameplayState : IState
    {
        private readonly SceneStateMachine sceneStateMachine;

        public StartGameplayState(SceneStateMachine sceneStateMachine) => 
            this.sceneStateMachine = sceneStateMachine;

        public async UniTask Enter()
        {
            // you can use states like this for showing starting cut scenes, objectives on the level, explaining game rules and so on
            sceneStateMachine.Enter<PlayGameplayState>().Forget();
        }

        public UniTask Exit()
        {
            return default;
        }
    }
}