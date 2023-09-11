using CodeBase.UI.Services.Factories;
using CodeBase.UI.Services.PopUps;
using CodeBase.UI.Services.Window;
using Zenject;

namespace CodeBase.UI
{
    public class UIInstaller : Installer<UIInstaller>
    {
        public override void InstallBindings()
        {
            UIFactoryInstaller.Install(Container);

            Container.BindInterfacesAndSelfTo<WindowService>().AsSingle();

            Container.BindInterfacesAndSelfTo<PopUpService>().AsSingle();
        }
    }
}