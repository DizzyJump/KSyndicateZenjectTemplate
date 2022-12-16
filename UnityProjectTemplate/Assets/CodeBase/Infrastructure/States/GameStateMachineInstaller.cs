using CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;

public class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
{
    public override void InstallBindings()
    {
        Container.BindFactory<IGameStateMachine, BootstrapState, BootstrapState.Factory>();
        Container.BindFactory<IGameStateMachine, LoadGameSaveState, LoadGameSaveState.Factory>();
        Container.BindFactory<IGameStateMachine, LoadLevelState, LoadLevelState.Factory>();

        Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
        
        Debug.Log("GameStateMachineInstaller");
    }
}