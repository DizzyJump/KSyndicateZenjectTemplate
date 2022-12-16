using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Factories;
using CodeBase.UI.HUD;
using UnityEngine;
using Zenject;

public class UIFactoryInstaller : Installer<UIFactoryInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
    }
}