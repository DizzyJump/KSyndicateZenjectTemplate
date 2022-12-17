using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<IGameStateMachine, BootstrapState, BootstrapState.Factory>();
            Container.BindFactory<IGameStateMachine, LoadPlayerProgressState, LoadPlayerProgressState.Factory>();
            Container.BindFactory<IGameStateMachine, LoadLevelState, LoadLevelState.Factory>();

            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
        
            Debug.Log("GameStateMachineInstaller");
        }
    }
}