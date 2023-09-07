namespace CodeBase.Infrastructure.States
{
    public class GameLoadingState : IState
    {
        private LoadingCurtain loadingCurtain;

        public GameLoadingState(LoadingCurtain loadingCurtain) => 
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