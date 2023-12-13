using RokakNyulak;
using System.Text;



/*Field mezo = new();
mezo.DrawField();*/

Console.OutputEncoding = Encoding.UTF8;

int[] MaxSize = { 20, 30 };

Fields fields = new Fields(MaxSize);
Table table = new Table(fields);
table.StartGame();
    
