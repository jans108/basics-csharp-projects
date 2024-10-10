namespace Models.Common.Formatting;

public class GridFormatter<T>
{
    public GridFormatter(IEnumerable<T> data)
    {
        Data = new List<string>();
        foreach (T item in data)
            Data.Add(item?.ToString() ?? string.Empty);
    }

    private IList<string> Data { get; }

    public IEnumerable<string> Format(int width, int gap) =>
        FormatRows(GetColumnsCount(width, gap), gap);

    private int GetRowsCount(int columnsCount) =>
        (Data.Count + columnsCount - 1) / columnsCount;

    private int GetColumnsCount(int width, int gap)
    {
        int columnsCount = GetColumnsCountUpperBound(width, gap);
        while (columnsCount > 1 && GetTotalWidth(columnsCount, width, gap) > width)
        {
            columnsCount--;
        }
        return columnsCount;
    }

    private int GetTotalWidth(int columnsCount, int width, int gap) =>
        GetColumns(columnsCount, width, gap, true).totalWidth;

    private int GetColumnsCountUpperBound(int width, int gap)
    {
        int currentWidth = Data.Count > 0 ? Data[0].Length : 0;
        int columnsCount = 1;
        foreach (string item in Data.Skip(1))
        {
            int nextWidth = currentWidth + gap + item.Length;
            if (nextWidth > width) break;
            currentWidth = nextWidth;
            columnsCount++;
        }
        return columnsCount;
    }


    private IEnumerable<string> FormatRows(int columnsCount, int gap) =>
       FormatRows(GetColumnWidths(columnsCount), gap);


    private IEnumerable<string> FormatRows(int[] columnWidths, string gap)
    {
        int rowsCount = GetRowsCount(columnWidths.Length);
        for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
        {
            yield return string.Join(gap, GetCells(rowIndex, columnWidths)).Trim();
        }
    }

    private IEnumerable<string> GetCells(int rowIndex, int[] columnWidths)
    {
        int index = rowIndex * columnWidths.Length;
        int count = Math.Min(columnWidths.Length, Data.Count - index);
        for (int i = 0; i < count; i++)
        {
            yield return Data[index + i].PadRight(columnWidths[i]);
        }
    }

    private int GetColumnWidths(int columnsCount) =>
        throw new NotImplementedException();

    private (int[] columnWidths, int totalWidth) GetColumns(
        int columnsCount, int width, int gap, bool preempt)
    {
        int[] columnWidths = new int[columnsCount];
        int totalWidth = (Math.Min(columnsCount, Data.Count) - 1) * gap;
        int columnIndex = 0;
        foreach (string item in Data)
        {
            int increase = Math.Max(item.Length - columnWidths[columnIndex], 0);
            columnWidths[columnIndex] += increase;
            totalWidth += increase;
            if (preempt && totalWidth > width) return (columnWidths, totalWidth);
            columnIndex = (columnIndex + 1) % columnsCount;
        }
        return (columnWidths, totalWidth);
    }
}
