using System.Text.RegularExpressions;

namespace DataProcessing;

internal sealed class CustomerDataProcessor : Processor<ProcessedCustomerData>
{

    public CustomerDataProcessor(ProcessingOptions processingOptions) : base(processingOptions)
    {
    }

    public override async Task<ProcessedCustomerData> ProcessAsync(string filename, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(filename);

        var dataReader = new DataReader(Path.Combine(BaseInputPath, filename));

        var priorityCustomers = new List<HistoricalCustomerData>();
        var regularCustomers = new List<HistoricalCustomerData>();

        await foreach (var row in dataReader.ReadRowsAsync(cancellationToken))
        {
            var matches = Regex.Matches(row, @"\[(?<data>.*?)\]");

            if(matches.Count == 4)
            {
                var customerCode = matches[0].Groups["data"].Value;
            }
        }

        return new ProcessedCustomerData(priorityCustomers, regularCustomers);
    }
}
