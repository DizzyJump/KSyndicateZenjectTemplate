using CodeBase.UI.HUD;

namespace CodeBase.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private HUDRoot.Factory hudFactory;

        public GameFactory(HUDRoot.Factory hudFactory)
        {
            this.hudFactory = hudFactory;
        }

        public IHUDRoot CreateHUD() => hudFactory.Create();

        public void Cleanup()
        {
            
        }
    }
}