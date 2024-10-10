namespace Models.Common.Shuffling;

internal class SequenceShuffle<T> : IEnumerator<T>
{
    public SequenceShuffle(IEnumerable<T> sequence)
    {
        Data = sequence.ToArray();
    }

    public T Current => Data[Position];

    private T[] Data { get; }
    private Random RandomNumbers { get; } = new Random(new Guid().GetHashCode());
    private int Position { get; set; } = -1;

    object? IEnumerator.Current => Current;

    public void Dispose() { }

    public IEnumerable<T> GetShuffledContent() => Enumerable.Empty<T>();

    public bool MoveNext()
    {
        if (Position >= Data.Length - 1) return false;
        Position += 1;
        int pick = RandomNumbers.Next(Position, Data.Length);
        (Data[Position], Data[pick]) = (Data[pick], Data[Position]);
        return true;
    }

    public void Reset()
    {
        Position = -1;
    }
}
