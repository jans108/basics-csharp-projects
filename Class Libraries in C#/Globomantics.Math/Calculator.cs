﻿using System;

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
#elif NET461_OR_GREATER
            return $"{hex} from .NET Framework 4.6.1 or greater";
#elif NETSTANDARD2_0
            return $"{hex} from .NET Standard 2.0";
#endif

        }

        public static void WriteAsHex(int a)
        {
            string hex = a.ToString("X");

#if NET8_0
            Console.WriteLine($"{hex} from .NET 8");
#elif NET461_OR_GREATER
            Console.WriteLine($"{hex} from .NET Framework 4.6.1 or greater");
#elif NETSTANDARD2_0
            Console.WriteLine($"{hex} from .NET Standard 2.0");
#else
            throw new System.PlatformNotSupportedException();
#endif

        }
    }
}
