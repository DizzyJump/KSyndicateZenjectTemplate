using System;
using CodeBase.Infrastructure.States;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Elements
{
    public class GameStateSwitchButton : MonoBehaviour
    {
        [SerializeField][ValueDropdown("statesValues")] private int targetMode;
        [SerializeField] private Button button;

        private GameStateMachine gameStateMachine;

        [Inject]
        void Construct(GameStateMachine gameStateMachine) =>
            this.gameStateMachine = gameStateMachine;
        
        private void OnEnable() => 
            button.onClick.AddListener(OnClick);

        private void OnDisable() => 
            button.onClick.RemoveListener(OnClick);

        private void OnClick()
        {
            switch (targetMode)
            {
                case 0: gameStateMachine.Enter<GameLoadingState>(); break;
                case 1: gameStateMachine.Enter<GameHubState>(); break;
                case 2: gameStateMachine.Enter<GameMode1State>(); break;
                default: Debug.LogError("Not valid option"); break;
            }
        }

        // The selectable values for the dropdown, with custom names.
        private ValueDropdownList<int> statesValues = new ValueDropdownList<int>()
        {
            {"Loading",	0	},
            {"GameHub",	1	},
            {"GameMode1",2	},
        };
    }
}