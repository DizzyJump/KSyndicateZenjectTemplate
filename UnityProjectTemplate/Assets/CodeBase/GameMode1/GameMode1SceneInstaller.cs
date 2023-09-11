using CodeBase.Infrastructure.States;
using CodeBase.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.GameMode1
{
    public class GameMode1SceneInstaller : MonoInstaller
    {
        // Here we bind dependencies that make sense only in gameplay scene.
        // If we need some dependencies from scene for our game mode
        // we can link it on scene right here for binding and use it in scene context
        
        public override void InstallBindings()
        {
            Debug.Log("Start game scene installer");
            
            Container.BindInterfacesAndSelfTo<GameMode1SceneBootstraper>().AsSingle().NonLazy(); // non lazy due to it's not injected anywhere but we still need to instanciate it

            Container.BindInterfacesAndSelfTo<StatesFactory>().AsSingle();

            Container.Bind<SceneStateMachine>().AsSingle();
            
            UIInstaller.Install(Container);
        }
    }
}