using CodeBase.Infrastructure;
using Cysharp.Threading.Tasks;

namespace CodeBase.UI.Overlays
{
    public class AwaitingOverlayProxy : IAwaitingOverlay
    {
        private AwaitingOverlay.Factory factory;
        private IAwaitingOverlay impl;

        public AwaitingOverlayProxy(AwaitingOverlay.Factory factory) => 
            this.factory = factory;

        public async UniTask InitializeAsync() => 
            impl = await factory.Create(InfrastructureAssetPath.AwaitingOverlay);

        public void Show(string withMessage) => impl.Show(withMessage);

        public void Hide() => impl.Hide();
    }
}