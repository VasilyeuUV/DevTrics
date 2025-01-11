namespace DevTricks.Domain.Collections;


/// <summary>
/// Контракт коллекции, которая поддерживает ротацию элементов
/// </summary>
public interface IRotatableCollection<TItem> : IRotatebleReadOnlyCollection<TItem>
{
    /// <summary>
    /// Добавить элемент.
    /// </summary>
    /// <param name="item"></param>
    void Add(TItem item);

    /// <summary>
    /// Очистить коллекцию.
    /// </summary>
    void Clear();
}
