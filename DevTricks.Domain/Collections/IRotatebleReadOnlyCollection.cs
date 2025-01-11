using System.Collections.Specialized;

namespace DevTricks.Domain.Collections;

/// <summary>
/// Контракт неизменяемой коллекции (только для чтения), которая поддерживает ротацию элементов
/// (при заполнении выделенного объема памяти, может удалять старые записи и дописывать новые)
/// </summary>
/// <typeparam name="TItem"></typeparam>
public interface IRotatebleReadOnlyCollection<out TItem> : IEnumerable<TItem>, INotifyCollectionChanged
{
}
