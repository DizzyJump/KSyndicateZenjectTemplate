using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure
{
    public interface ISceneProvider
    {
        UniTask Load(string nextScene);
        UniTask Unload(string scene);
    }
}