using CodeBase.Services.WindowsService;
using CodeBase.UI.Factories;
using CodeBase.UI.Services.PopUps;
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