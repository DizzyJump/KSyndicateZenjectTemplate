using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<StatesFactory>().AsSingle();

            Container.Bind<GameStateMachine>().AsSingle();
        
            Debug.Log("GameStateMachineInstaller");
        }
    }
}