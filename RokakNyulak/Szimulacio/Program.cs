using RokakNyulak;



/*Field mezo = new();
mezo.DrawField();*/

int[] MaxSize = { 30, 90 };
Fields fields = new Fields(MaxSize);
Table table = new Table(fields.GetFields, MaxSize);

table.DrawFields();