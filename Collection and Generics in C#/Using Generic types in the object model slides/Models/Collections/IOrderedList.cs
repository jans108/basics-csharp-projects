namespace Models.Collections;

public interface IOrderedList<T> : IReadOnlyList<T>
{
    IOrderedList<T> GetRange(int index, int count);
}
