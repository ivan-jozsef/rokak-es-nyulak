namespace RokakNyulak
{
    public class Field
    {
        public int[,] field;
        private Random random;
        public Field()
        {
            field = new int[20, 50];

            FieldGenerator();
        }

        public void DrawField()
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    SetCellColor(row, col);
                    Console.Write("  ");
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        public void SetCellColor(int row, int col)
        {
            int life = field[row, col];
            switch (life)
            {
                case 10: Console.BackgroundColor = ConsoleColor.Yellow; break;
                case 11:
                case 21:
                case 31:
                    Console.BackgroundColor = ConsoleColor.Black; break;
                case 12:
                case 22:
                case 32:
                    Console.BackgroundColor = ConsoleColor.Red; break;
                case 20: Console.BackgroundColor = ConsoleColor.Green; break;
                case 30: Console.BackgroundColor = ConsoleColor.DarkGreen; break;
                default: Console.ForegroundColor = ConsoleColor.White; break;
            }
        }


        public void FieldGenerator()
        {
            int[] allapotok = new int[] { 10, 20, 30 };
            random = new Random();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = allapotok[random.Next(0, allapotok.Length)];
                }
            }
            for (int i = 0; i < 20; i++)
            {
                int row = random.Next(0, field.GetLength(0));
                int col = random.Next(0, field.GetLength(1));

                if (field[row, col] == 10 || field[row, col] == 20 || field[row, col] == 30)
                {
                    field[row, col] += 1;
                    //new Rabbit osztály a megfelelő koordinátákkal
                }
            }
            for (int i = 0; i < 5; i++)
            {
                int row = random.Next(1, field.GetLength(0) - 1);
                int col = random.Next(1, field.GetLength(1) - 1);

                if (field[row, col] == 10 || field[row, col] == 20 || field[row, col] == 30)
                {
                    field[row, col] += 2;
                    //new Fox osztály, a megfelelő koordinátákkal
                }
            }

        }
    }
}

