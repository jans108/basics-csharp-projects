﻿using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace DataProcessor;

public class CsvFileProcessor
{
    public string InputFilePath { get; }
    public string OutputFilePath { get; }

    public CsvFileProcessor(string inputFilePath, string outputFilePath)
    {
        InputFilePath = inputFilePath;
        OutputFilePath = outputFilePath;
    }

    public void Process()
    {
        using StreamReader inputReader = File.OpenText(InputFilePath);

        var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture);
        using CsvReader csvReader = new CsvReader(inputReader, csvConfiguration);

        IEnumerable<dynamic> records = csvReader.GetRecords<dynamic>();

        foreach(var record in records)
        {
            Console.WriteLine(record.OrderNumber);
            Console.WriteLine(record.CustomerNumber);
            Console.WriteLine(record.Decription);
            Console.WriteLine(record.Quantity);
        }
    }
}
