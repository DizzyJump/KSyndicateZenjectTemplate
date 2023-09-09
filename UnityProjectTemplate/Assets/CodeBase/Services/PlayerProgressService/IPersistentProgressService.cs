namespace CodeBase.Services.PlayerProgressService
{
    public interface IPersistentProgressService
    {
        Data.PlayerProgress Progress { get; set; }
    }
}