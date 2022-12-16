using System.Collections;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
    {
        public CanvasGroup Curtain;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            Curtain.alpha = 1;
        }
    
        public void Hide() => StartCoroutine(DoFadeIn());
    
        private IEnumerator DoFadeIn()
        {
            while (Curtain.alpha > 0)
            {
                Curtain.alpha -= 0.03f;
                yield return new WaitForSeconds(0.03f);
            }
      
            gameObject.SetActive(false);
        }

        public class Factory : PlaceholderFactory<LoadingCurtain>
        {
        }
    }
}