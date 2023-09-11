using CodeBase.UI.PopUps.PolicyAcceptPopup;
using Zenject;

namespace CodeBase.UI.Services.Factories
{
    public class UIFactoryInstaller : Installer<UIFactoryInstaller>
    {
        public override void InstallBindings()
        {
            // bind ui sub-factories here
            
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();

            Container.BindFactory<PolicyAcceptPopup, PolicyAcceptPopup.Factory>().FromComponentInNewPrefabResource("Prefabs/UI/Popups/PolicyPopup");
        }
    }
}