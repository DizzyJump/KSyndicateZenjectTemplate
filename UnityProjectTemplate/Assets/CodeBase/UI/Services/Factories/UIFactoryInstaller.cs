using CodeBase.UI.Windows.PrivatePolicyAccept;
using Zenject;

namespace CodeBase.UI.Factories
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