﻿using System.Collections.Generic;

namespace Patterns.FactoryMethod
{
    public class AscendingSortStrategy : ISortStrategy
    {
        public void Sort(List<string> list)
        {
            list.Sort();
        }
    }
}