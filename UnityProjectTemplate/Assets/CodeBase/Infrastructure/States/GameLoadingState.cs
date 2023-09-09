using System.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public class GameLoadingState : IState
    {
        private readonly ILoadingCurtain loadingCurtain;

        public GameLoadingState(ILoadingCurtain loadingCurtain) => 
            this.loadingCurtain = loadingCurtain;

        public void Exit()
        {
            loadingCurtain.Show();
        }

        public void Enter()
        {
            loadingCurtain.Hide();
        }
    }
}