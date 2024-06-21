namespace DataProcessing;

internal class FailedSalesDataInspector
{
    private readonly ILogger _logger;

    public FailedSalesDataInspector(ProcessingOptions options) => _logger = options.LoggerFactory.CreateLogger<FailedSalesDataInspector>();

    public void InspectAll(IEnumerable<string> failedRows)
    {
        foreach (var failedRow in failedRows)
            Inspect(failedRow);
    }

    public void Inspect(string failedRow)
    {
        ArgumentNullException.ThrowIfNull(failedRow);

        var seperatorCount = failedRow.Count(c => c.Equals('|'));

        if (seperatorCount < 6)
        {
            _logger.LogWarning("'{FailedRow}' has too few elements.", failedRow);
            return;
        }

        if (seperatorCount > 6)
        {
            _logger.LogWarning("'{FailedRow}' has too many elements.", failedRow);
            return;
        }

        var lastSeparatorIndex = failedRow.LastIndexOf("|");
        var categoryColonIndex = failedRow.IndexOf(':', lastSeparatorIndex);

        if (categoryColonIndex == -1)
        {
            _logger.LogWarning("'{FailedRow}' category element is " +
                "invalid due to missing colon.", failedRow);
            return;
        }

        if (categoryColonIndex == failedRow.Length - 1)
        {
            _logger.LogWarning("'{FailedRow}' category code was " +
                "expected to be followed by a description.", failedRow);
            return;
        }

        var codeLength = 0;
        for (var index = lastSeparatorIndex + 1;
            index < categoryColonIndex; index++)
        {
            if (!char.IsWhiteSpace(failedRow[index]))
                codeLength++;
        }

        if (codeLength != 6)
        {
            _logger.LogWarning("'{FailedRow}' category code " +
                "has invalid length '{length}'.", failedRow, codeLength);
            return;
        }

        var hasDescription = false;
        for (var index = categoryColonIndex + 1;
            index < failedRow.Length; index++)
        {
            if (!char.IsWhiteSpace(failedRow[index]))
            {
                hasDescription = true;
                break;
            }
        }

        if (!hasDescription)
        {
            _logger.LogWarning("'{FailedRow}' category description " +
                "contained only whitespace.", failedRow);
            return;
        }
    }
}