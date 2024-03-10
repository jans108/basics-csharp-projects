using System.Threading.Tasks;

namespace StockAnalyzer.Windows;

public class StateMachineDemo
{
    public Task<string>Run()
    {
        var result = Compute();

        return result;
    }

    public Task<string>Compute()
    {
        var result = Load();

        return result;
    }

    public  Task<string>Load()
    {
        return Task.Run(() => "StateMachine test");
    }
}
