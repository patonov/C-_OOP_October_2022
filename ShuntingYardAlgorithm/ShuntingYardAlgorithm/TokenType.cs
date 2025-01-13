using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public enum TokenType
    {
        Number, 
        Variable, 
        Function, 
        Parenthesis, 
        Operator, 
        Comma, 
        WhiteSpace
    }
}
