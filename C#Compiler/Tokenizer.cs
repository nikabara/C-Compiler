using System.Runtime.CompilerServices;

namespace CS_Compiler
{
    public static class Tokenizer
    {
        public enum TokenType
        {
            ID, Int, Plus, Minus, Mul, Div, LParen, RParen, Eql, Assign, Eof
        }

        public struct Token 
        {
            public TokenType Type { get; set; }
            public string? Str { get; set; }
            public int Value { get; set; }
            public int Line { get; set; }

            public Token() { }
            public Token(TokenType Type, string Str, int Value, int Line)
            {
                this.Type = Type;
                this.Str = Str;
                this.Value = Value;
                this.Line = Line;
            }
        }

        private static string ConsumeWhitespace(string input)
        {
            string newInput = input;
            int i = 0;

            while (newInput[0] == ' ')
            {
                newInput = newInput[1..];
                i++;
            }

            return newInput;
        }

        public static List<Token>? GetSpecialToken(this string input, List<Token> tokenList)
        {
            foreach (char sToken in input)
            {
                switch (sToken)
                {
                    case '+':
                        tokenList.Add(new Token(TokenType.Plus, "+", 0, 0));
                        break;
                    case '-':
                        tokenList.Add(new Token(TokenType.Minus, "-", 0, 0));
                        break;
                    case '*':
                        tokenList.Add(new Token(TokenType.Mul, "*", 0, 0));
                        break;
                    case '/':
                        tokenList.Add(new Token(TokenType.Div, "/", 0, 0));
                        break;
                    case '(':
                        tokenList.Add(new Token(TokenType.LParen, "(", 0, 0));
                        break;
                    case ')':
                        tokenList.Add(new Token(TokenType.RParen, ")", 0, 0));
                        break;
                }
            }

            return tokenList;
        }

        public static List<Token>? GetNextToken(this string input, List<Token> tokenList)
        {
            string myInput = ConsumeWhitespace(input);

            string subString = string.Empty;

            if (char.IsLetter(myInput[0]))
            {
                while (char.IsLetter(myInput[0]) || char.IsNumber(myInput[0]) || myInput[0] == '_') 
                {
                    subString += myInput[0];
                    myInput = myInput[1..];
                }

                tokenList.Add(new Token(TokenType.ID, (string)subString, 0, 0));
            }

            if (char.IsNumber(myInput[0]))
            {
                while (char.IsNumber(myInput[0]))
                {
                    subString += myInput[0];
                    myInput = myInput[1..];
                }

                tokenList.Add(new Token(TokenType.Int, string.Empty, Convert.ToInt32(subString), 0));
            }

            tokenList = GetSpecialToken(input, tokenList);

            return tokenList;
        }

        public static List<Token> Tokenize(string input)
        {
            List<Token> tokenList = new();

            input = input.Trim();

            tokenList = GetNextToken(input, tokenList);

            return tokenList;
        }

    }
}
