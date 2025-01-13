using System;
using System.Collections.Generic;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public struct Token
    {
        public Token(TokenType type, string value)
        {
            this.Type = type;
            this.Value = value;
        }

        public TokenType Type { get; }

        public string Value { get; }

        public override string ToString()
        {
            return $"{this.Type}: {this.Value}";
        }
    }
}
