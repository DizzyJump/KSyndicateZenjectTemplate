using CodeBase.Infrastructure.AssetManagement;
using CodeBase.UI.PopUps.PolicyAcceptPopup;
using Cysharp.Threading.Tasks;
using Zenject;

namespace CodeBase.UI.Services.Factories
{
    public class UIFactoryInstaller : Installer<UIFactoryInstaller>
    {
        public override void InstallBindings()
        {
            // bind ui sub-factories here
            
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();

            // that an example of making zenject factories working in async way
            Container
                .BindFactory<string, UniTask<PolicyAcceptPopup>, PolicyAcceptPopup.Factory>()
                .FromFactory<PrefabFactoryAsync<PolicyAcceptPopup>>();
        }
    }
}