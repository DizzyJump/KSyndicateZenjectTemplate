using CodeBase.Infrastructure.GameLoading.States;
using CodeBase.Infrastructure.States;
using CodeBase.Services.LocalizationService;
using CodeBase.UI;
using CodeBase.UI.Windows.PrivatePolicyAccept;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace CodeBase.Infrastructure.GameLoading
{
    public class GameLoadingSceneInstaller : MonoInstaller
    {
        // Here we bind dependencies that make sense only in scene.
        // If we need some dependencies from scene for our game mode
        // we can link it on scene right here for binding and use it in scene context

        public override void InstallBindings()
        {
            Debug.Log("Start loading scene installer");
            
            Container.BindInterfacesAndSelfTo<GameLoadingSceneBootstraper>().AsSingle().NonLazy(); // non lazy due to it's not injected anywere but we still need to instanciate it

            Container.BindInterfacesAndSelfTo<StatesFactory>().AsSingle();

            Container.Bind<SceneStateMachine>().AsSingle();
            
            UIInstaller.Install(Container);

            BindPopupConfigs();
        }

        private void BindPopupConfigs()
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
        }
    }
}