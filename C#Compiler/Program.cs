using CS_Compiler;
using static CS_Compiler.Tokenizer;

string msStr = "Id = ( 15 + 20 ) / 2 * 10";

var res = GetTokenArray(msStr);

Console.ReadKey();