using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public class Operator
    {
        public string Name { get; set; }

        public int Priority { get; set; }

        public bool IsRightAssociative { get; set; }
                
    }
}
