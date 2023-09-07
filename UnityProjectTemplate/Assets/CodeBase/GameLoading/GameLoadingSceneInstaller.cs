using Zenject;

namespace CodeBase.Infrastructure.GameLoading
{
    public class GameLoadingSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameLoadingSceneBootstraper>().AsSingle();
            
            
        }
    }
}