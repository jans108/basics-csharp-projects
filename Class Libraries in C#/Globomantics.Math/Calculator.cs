namespace Globomantics.Math
{
    public static class Calculator
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }


        public static string AsHex(int a)
        {
            var hex = a.ToString("X");
#if NET8_0
            return $"{hex} from .NET 8";
#elif NET461
            return $"{hex} from .NET Framework 4.6.1";
#else
            return $"{hex} from .NET Standard 2.0";
#endif

        }
    }
}
