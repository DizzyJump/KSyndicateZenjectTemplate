namespace CodeBase.Services.PlayerProgressService
{
    public interface IProgressSaver : IProgressReader
    {
        void UpdateProgress(Data.PlayerProgress progress);
    }
}