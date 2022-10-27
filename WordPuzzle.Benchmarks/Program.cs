// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using WordPuzzle.Benchmarks;

Console.WriteLine("Hello, World!");

// BenchmarkRunner.Run<AnagramBenchmarksFind>();
BenchmarkRunner.Run<AnagramBenchmarksLoad>();

// BenchmarkRunner.Run(typeof(Program).Assembly);
