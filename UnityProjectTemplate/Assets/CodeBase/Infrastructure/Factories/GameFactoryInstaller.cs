using CodeBase.UI.HUD;
using Zenject;

namespace CodeBase.Infrastructure.Factories
{
    public class GameFactoryInstaller : Installer<GameFactoryInstaller>
    {
        public override void InstallBindings()
        {
            // bind sub-factories here
            Container.BindFactory<HUDRoot, HUDRoot.Factory>().FromComponentInNewPrefabResource(InfrastructureAssetPath.HUDRoot);
        
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
        }
    }
}