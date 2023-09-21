using CodeBase.GameLoading.States;
using CodeBase.Infrastructure.States;
using CodeBase.UI;
using CodeBase.UI.PopUps.PolicyAcceptPopup;
using UnityEngine;
using Zenject;

namespace CodeBase.GameLoading
{
    public class GameLoadingSceneInstaller : MonoInstaller
    {
        // Here we bind dependencies that make sense only in loading scene.
        // If we need some dependencies from scene for our game mode
        // we can link it on scene right here for binding and use it in scene context

        public override void InstallBindings()
        {
            Debug.Log("Start loading scene installer");
            
            Container.BindInterfacesAndSelfTo<GameLoadingSceneBootstraper>().AsSingle().NonLazy(); // non lazy due to it's not injected anywhere but we still need to instanciate it

            Container.BindInterfacesAndSelfTo<StatesFactory>().AsSingle();

            Container.Bind<SceneStateMachine>().AsSingle();
            
            UIInstaller.Install(Container);

            //BindPopupConfigs();
        }

        /*private void BindPopupConfigs()
        {
            Container
                .Bind<PolicyAcceptPopupConfig>()
                .FromScriptableObjectResource("Configs/UI/PolicyPopups/PrivatePolicy")
                .AsTransient()
                .WhenInjectedInto<PrivatePolicyState>();

            Container
                .Bind<PolicyAcceptPopupConfig>()
                .FromScriptableObjectResource("Configs/UI/PolicyPopups/GDPRPolicy")
                .AsTransient()
                .WhenInjectedInto<GDPRState>();
        }*/
    }
}