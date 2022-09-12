namespace Core.Persistence.Paging;

/// <ÖZET>
/// Sayfalama ile ilgili metod imzaları tanımlandı.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IPaginate<T>
{
    int From { get; }
    int Index { get; }
    int Size { get; }
    int Count { get; }
    int Pages { get; }
    IList<T> Items { get; }
    bool HasPrevious { get; }
    bool HasNext { get; }
}