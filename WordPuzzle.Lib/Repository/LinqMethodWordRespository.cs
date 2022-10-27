﻿using WordPuzzle.Lib.Load;
using WordPuzzle.Lib.Query;

namespace WordPuzzle.Lib.Repository;

public class LinqMethodWordRespository :
    WordModelRepository<LinqMethod, ProperSubset>,
    IWordModelRepository
{
}