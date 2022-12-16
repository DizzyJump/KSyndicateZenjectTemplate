using UnityEngine;

namespace CodeBase.Infrastructure.Observables
{
    [System.Serializable]
    public class Publisher<TSubject> : IPublisher<TSubject>
    {
        [SerializeField] private TSubject subject;

        public event System.Action<TSubject> OnChange;
        
        public TSubject Value
        {
            get => subject;
            set
            {
                subject = value;
                OnChange?.Invoke(subject);
            }
        }
    }
}