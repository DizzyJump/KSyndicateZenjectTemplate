using CodeBase.Infrastructure.States;
using CodeBase.Services.LogService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Elements
{
    public class GameStateSwitchButton : MonoBehaviour
    {
        public enum TargetStates
        {
            None = 0,
            Loading = 1,
            GameHub = 2,
            Gameplay = 3 ,
        }
        
        [SerializeField] private TargetStates targetState = 0;
        [SerializeField] private Button button;

        private GameStateMachine gameStateMachine;
        private ILogService log;

        [Inject]
        void Construct(GameStateMachine gameStateMachine, ILogService log)
        {
            this.gameStateMachine = gameStateMachine;
            this.log = log;
        }

        private void OnEnable() => 
            button.onClick.AddListener(OnClick);

        private void OnDisable() => 
            button.onClick.RemoveListener(OnClick);

        private void OnClick()
        {
            switch (targetState)
            {
                case TargetStates.Loading: gameStateMachine.Enter<GameLoadingState>(); break;
                case TargetStates.GameHub: gameStateMachine.Enter<GameHubState>(); break;
                case TargetStates.Gameplay: gameStateMachine.Enter<GameplayState>(); break;
                default: log.LogError("Not valid option"); break;
            }
        }
    }
}