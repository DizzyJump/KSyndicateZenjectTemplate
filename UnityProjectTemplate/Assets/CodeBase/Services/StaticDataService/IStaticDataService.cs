using CodeBase.Services.ServerConnectionService;

namespace CodeBase.Services.StaticDataService
{
    public interface IStaticDataService
    {
        void Initialize();
        ServerConnectionConfig ServerConnectionConfig { get; }
    }
}