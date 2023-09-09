using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure
{
    public interface ISceneLoader
    {
        UniTask Load(string nextScene);
    }
}