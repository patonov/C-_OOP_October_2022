using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ShuntingYardAlgorithm
{
    public class SYParser
    {
        private Dictionary<string, Operator> operators = new Dictionary<string, Operator>
        {
            ["+"] = new Operator { Name = "+", Priority = 1 },
            ["-"] = new Operator { Name = "-", Priority = 1 },
            ["*"] = new Operator { Name = "*", Priority = 2 },
            ["/"] = new Operator { Name = "/", Priority = 2 },
            ["^"] = new Operator { Name = "/", Priority = 3, IsRightAssociative = true }
        };

        private bool CompareOperators(Operator firstOperator, Operator secondOperator)
        {
            return firstOperator.IsRightAssociative ? firstOperator.Priority < secondOperator.Priority : firstOperator.Priority <= secondOperator.Priority;
        }

        private bool CompareOperators(string firstOperator, string secondOperator) 
            => CompareOperators(operators[firstOperator], operators[secondOperator]);

        private TokenType TokenTypeIdentifier(char ch)
        {
            if (char.IsLetter(ch))
            {
                return TokenType.Variable;
            }
            else if (char.IsDigit(ch))
            {
                return TokenType.Number;
            }
            else if (char.IsWhiteSpace(ch))
            {
                return TokenType.WhiteSpace;
            }
            else if (ch == ',')
            {
                return TokenType.Comma;
            }
            else if (ch == '(' || ch == ')')
            {
                return TokenType.Parenthesis;
            }
            else if (operators.ContainsKey(Convert.ToString(ch)))
            {
                return TokenType.Operator;
            }
            else
            {
                throw new ArgumentException("The character is not identified.");
            }
        }

        public IEnumerable<Token> Tokenizer(TextReader txtReader)  
        {
            StringBuilder token = new StringBuilder();

            int current;

            while ((current = txtReader.Read()) != -1)
            {
                var ch = (char)current;

                var currentType = TokenTypeIdentifier(ch);

                if (currentType == TokenType.WhiteSpace)
                {
                    continue;
                }

                token.Append(ch);

                var nextCharReturnedInt = txtReader.Peek();

                var typeOfNextCharReturnedInt = nextCharReturnedInt != -1 ? TokenTypeIdentifier((char)nextCharReturnedInt) : TokenType.WhiteSpace;
                
                if (currentType != typeOfNextCharReturnedInt)
                {
                    if (nextCharReturnedInt == '(')
                    {
                        yield return new Token(TokenType.Function, token.ToString());
                    }
                    else
                    {
                        yield return new Token(currentType, token.ToString());
                    }
                    token.Clear();
                }
            }
        }








    }
}
