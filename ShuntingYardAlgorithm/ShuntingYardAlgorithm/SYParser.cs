using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Token> Tokenizer(string input)  
        {
            StringBuilder token = new StringBuilder();             

            for (int i = 0; i < input.Length; i++) 
            { 
                char ch = input[i];

                var currentCharType = TokenTypeIdentifier(ch);

                if (currentCharType == TokenType.WhiteSpace)
                {
                    continue;
                }

                token.Append(ch);

                int nextCharInt;
                if ((i + 1) < input.Length)
                {
                    char nextChar = input[i + 1];
                    nextCharInt = (int)nextChar;
                }
                else 
                {
                    nextCharInt = -1;
                }

                var typeOfNextCharReturnedInt = nextCharInt != -1 ? TokenTypeIdentifier((char)nextCharInt) 
                    : TokenType.WhiteSpace;


                if (currentCharType != typeOfNextCharReturnedInt)
                {
                    if (nextCharInt == '(')
                    {
                        yield return new Token(TokenType.Function, token.ToString());
                    }
                    else
                    {
                        yield return new Token(currentCharType, token.ToString());
                    }
                    token.Clear();
                }
            }

        }
        

        public IEnumerable<Token> MarshallingYardMethod(IEnumerable<Token> tokens) 
        {
            Stack<Token> stack = new Stack<Token>(); 

            foreach (var token in tokens)
            {
                switch (token.Type)
                {
                    case TokenType.Number:
                    case TokenType.Variable:
                        yield return token; break;
                    case TokenType.Function:
                        stack.Push(token); break;
                    case TokenType.Comma:
                        while (stack.Peek().Value != "(")
                        {
                            yield return stack.Pop();
                        }
                        break;
                    case TokenType.Operator:
                        while (stack.Any() && stack.Peek().Type == TokenType.Operator
                            && CompareOperators(token.Value, stack.Peek().Value))
                        {
                            yield return stack.Pop();
                        }
                        stack.Push(token); break;
                    case TokenType.Parenthesis:
                        if (token.Value == "(")
                        {
                            stack.Push(token);
                        }
                        else
                        {
                            while (stack.Peek().Value != "(")
                            {
                                yield return stack.Pop();
                            }
                            stack.Pop();
                            if (stack.Peek().Type == TokenType.Function)
                            {
                                yield return stack.Pop();
                            }
                        }
                        break;
                    default:
                        throw new ArgumentException("The token is not recognized by the parser.");
                }
            }
            while (stack.Any())
            {
                var token = stack.Pop();
                if (token.Type == TokenType.Parenthesis)
                {
                    throw new ArgumentException("The parentheses are not in corect order.");
                }
                yield return token;
            }
        }

    }
}
