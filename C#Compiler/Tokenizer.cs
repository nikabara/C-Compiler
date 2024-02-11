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

        public static Token? GetSpecialToken(this char input)
        {
            switch (input)
            {
                case '+':
                    return new Token(TokenType.Plus, "+", 0, 0);
                case '-':
                    return new Token(TokenType.Minus, "-", 0, 0);
                case '*':
                    return new Token(TokenType.Mul, "*", 0, 0);
                case '/':
                    return new Token(TokenType.Div, "/", 0, 0);
                case '(':
                    return new Token(TokenType.LParen, "(", 0, 0);
                case ')':
                    return new Token(TokenType.RParen, ")", 0, 0);
                default:
                    return null;
            }
        }

        public static Token? GetNextToken(this string input)
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

                if (subString.ToLower().Equals("id"))
                {
                    return new Token(TokenType.ID, "ID", 0, 0);
                }
            }

            return null;
        }

    }
}
