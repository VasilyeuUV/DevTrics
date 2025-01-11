using DevTricks.Domain.Collections;

namespace DevTricks.Infrastructure.Collections;

/// <summary>
/// Фабрика для создания перезаписываемой коллекции.
/// </summary>
internal class RotatableCollectionFactory : IRotatableCollectionFactory
{
    //######################################################################################################################
    #region IRotatableCollectionFactory

    public IRotatableCollection<TItem> Create<TItem>(int capacity)
        => new RotatableCollection<TItem>(capacity);

    #endregion // IRotatableCollectionFactory
}
