using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.UI.LoadingCurtain
{
    public class LoadingCurtainProxy : ILoadingCurtain
    {
        private LoadingCurtain.Factory factory;
        private ILoadingCurtain impl;

        public LoadingCurtainProxy(LoadingCurtain.Factory factory) => 
            this.factory = factory;

        public async UniTask InitializeAsync() => 
            impl = await factory.Create(InfrastructureAssetPath.CurtainPath);

        public void Show() => impl.Show();

        public void Hide() => impl.Hide();
    }
}