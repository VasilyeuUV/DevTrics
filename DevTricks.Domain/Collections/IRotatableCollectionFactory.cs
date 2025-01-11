namespace DevTricks.Domain.Collections;

/// <summary>
/// Контракт для фабрики Коллекции, которая поддерживает ротацию элементов
/// </summary>
public interface IRotatableCollectionFactory
{
    /// <summary>
    /// Создать перезаписываемую коллекцию.
    /// </summary>
    /// <typeparam name="Titem"></typeparam>
    /// <param name="capacity"></param>
    /// <returns></returns>
    IRotatableCollection<TItem> Create<TItem>(int capacity);
}
