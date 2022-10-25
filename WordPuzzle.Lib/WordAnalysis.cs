using System.Collections;

namespace WordPuzzle.Lib;

public static class WordAnalysis
{
    private const char CharOffset = 'a';
    public static uint WordKey(this string word)
    {
        var bitArray = new BitArray(32);
        bitArray.SetAll(false);

        foreach (var c in word)
        {
            bitArray[c - CharOffset] = true;
        }

        var results = new uint[1];
        bitArray.CopyTo(results, 0);
        return results[0];
    }
}