using CodeBase.Data;

namespace CodeBase.Services.PlayerProgressService
{
    public interface IPlayerProgressService
    {
        PlayerProgress Progress { get; set; }
    }
}