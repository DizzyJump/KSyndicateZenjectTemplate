using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Factories;
using CodeBase.UI.HUD;
using UnityEngine;
using Zenject;

public class GameFactoryInstaller : Installer<GameFactoryInstaller>
{
    public override void InstallBindings()
    {
        Container.BindFactory<HUDRoot, HUDRoot.Factory>().FromComponentInNewPrefabResource(InfrastructureAssetPath.HUDRoot);
        
        Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
    }
}