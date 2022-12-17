using Zenject;

namespace CodeBase.UI.Factories
{
    public class UIFactoryInstaller : Installer<UIFactoryInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
        }
    }
}