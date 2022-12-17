using CodeBase.UI.HUD;
using Zenject;

namespace CodeBase.Infrastructure.Factories
{
    public class GameFactoryInstaller : Installer<GameFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<HUDRoot, HUDRoot.Factory>().FromComponentInNewPrefabResource(InfrastructureAssetPath.HUDRoot);
        
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
        }
    }
}