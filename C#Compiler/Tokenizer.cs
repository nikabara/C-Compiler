namespace CS_Compiler
{
    public static class Tokenizer
    {
        public enum TokenType
        {
            ID, Int, Plus, Minus, Mul, Div, LParen, RParen, Eql, Assign
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

        private static string[] SubdivideString(this string input)
        {
            return input.Split(' ');
        }

        private static Token? GetSpecialToken(char inputChar)
        {
            switch (inputChar)
            {
                case '+':
                    return new Token(TokenType.Plus, "+", 0, 0);
                case '-':
                    return new Token(TokenType.Minus, "-", 0, 0);
                case '*':
                    return new Token(TokenType.Mul, "*", 0, 0);
                case '/':
                    return new Token(TokenType.Div, "/", 0, 0);
                case '=':
                    return new Token(TokenType.Eql, "=", 0, 0);
                case '(':
                    return new Token(TokenType.LParen, "(", 0, 0);
                case ')':
                    return new Token(TokenType.RParen, ")", 0, 0);
                default:
                    return null;
            }
        }

        private static Token? GetLiteralToken(string input)
        {
            string subString = string.Empty;

            foreach (char item in input)
            {
                if (char.IsLetter(item))
                {
                    int i = 0;
                    foreach (char item2 in input)
                    {
                        subString += item2;
                        i++;
                    }

                    return new Token(TokenType.ID, subString, 0, 0);
                }
                if (char.IsNumber(item))
                {
                    int i = 0;
                    foreach (char item2 in input)
                    {
                        subString += item2;
                        i++;
                    }

                    return new Token(TokenType.Int, string.Empty, Convert.ToInt32(subString), 0);
                }
            }

            return null;
        }

        public static List<Token> GetTokenArray(string input)
        {
            string[] inputArray = input.SubdivideString();

            List<Token> tokenList = new();

            for (int i = 0; i < inputArray.Length; i++)
            {
                foreach (char item in inputArray[i])
                {
                    Token? tokenWithItem = GetSpecialToken(item);

                    Token? tokenWithInpArray = GetLiteralToken(inputArray[i]);

                    if (tokenWithItem != null)
                    {
                        tokenList.Add((Token)tokenWithItem);
                    }
                    if (tokenWithInpArray != null)
                    {
                        tokenList.Add((Token)tokenWithInpArray);
                        break;
                    }
                }
            }

            return tokenList;
        }
    }
}
