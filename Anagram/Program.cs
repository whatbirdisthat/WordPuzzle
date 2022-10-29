// See https://aka.ms/new-console-template for more information

using WordPuzzle.Lib;
using WordPuzzle.Lib.Load;
using WordPuzzle.Lib.Query;
using WordPuzzle.Lib.Repository;
using static System.String;

if (args.Length > 0)
{
    var sourceWord = args[0];
    var theRepository = new WordModelRepository<InlineMethod, ProperSubset>();
    var results = sourceWord.Anagrams(theRepository);
    Console.WriteLine(
        $"""
--- Anagrams for '{ sourceWord}' ---
{ Join(Environment.NewLine, results)}  
"""
    );
}
else
{
    Console.WriteLine($"""
Usage: { typeof(Program).Assembly.GetName().Name} <word>
"""
    );
}