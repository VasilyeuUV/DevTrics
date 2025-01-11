using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using DevTricks.Domain.Collections;

namespace DevTricks.Infrastructure.Collections;

/// <summary>
///  Коллекция, которая поддерживает ротацию элементов
/// </summary>
internal class RotatableCollection<TItem> : IRotatableCollection<TItem>
{
    private readonly int _capacity;                 // - емкость коллекции. 
    private ObservableCollection<TItem> _items;     // - внутреннее хранилище.


    /// <summary>
    /// CTOR
    /// </summary>
    /// <param name="capacity">Ёмкость коллекции.</param>
    public RotatableCollection(int capacity)
    {
        _capacity = capacity;
        _items = new ObservableCollection<TItem>();
    }


    //######################################################################################################################
    #region IRotatableCollection<TItem>

    public event NotifyCollectionChangedEventHandler? CollectionChanged         // - перенаправялем все подписки из внешнего события во внутренний
    {
        add => _items.CollectionChanged += value;
        remove => _items.CollectionChanged -= value;
    }


    public void Add(TItem item)
    {
        if (_items.Count == _capacity)          // - если коллекция заполнена до установленного объема
        {
            _items.RemoveAt(0);                 // - удаляем нулевой элемент.
        }

        _items.Add(item);
    }


    public void Clear()
    {
        _items.Clear();
    }


    /// <summary>
    /// Создать новый энуменатор коллекции (принадлежит IEnumerable)
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerator<TItem> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion // IRotatableCollection<TItem>
}
