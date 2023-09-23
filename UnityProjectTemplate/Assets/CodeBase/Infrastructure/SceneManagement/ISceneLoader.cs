using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.SceneManagement
{
    public interface ISceneLoader
    {
        UniTask Load(string nextScene);
    }
}