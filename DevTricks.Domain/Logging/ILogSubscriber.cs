namespace DevTricks.Domain.Logging
{
    /// <summary>
    /// Контракт для вьюмоделей, который будет уведомлять посредника о появлении новых логов
    /// </summary>
    public interface ILogSubscriber
    {
        event Action<LogArgs> LogAdded;
    }
}
