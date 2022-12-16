namespace CodeBase.Infrastructure.Observables
{
    public interface IPublisher<TSubject>
    {
        TSubject Value { get; set; }
        event System.Action<TSubject> OnChange;
    }
}