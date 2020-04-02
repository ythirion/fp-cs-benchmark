using System;
using BenchmarkDotNet.Running;

namespace language_ext.benchmark.app
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<UserRepository>();
        }
    }
}