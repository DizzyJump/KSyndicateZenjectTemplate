using CodeBase.UI.HUD;

namespace CodeBase.Infrastructure.Factories
{
    public interface IGameFactory
    {
        IHUDRoot CreateHUD();
        void Cleanup();
    }
}