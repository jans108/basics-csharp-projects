using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor;

static internal class FilesToProcess
{
    public static ConcurrentDictionary<string, string> Files = new();
}
