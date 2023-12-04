namespace RokakNyulak
{
    /*public class Field
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
                int row = random.Next(0, field.GetLength(0) - 1);
                int col = random.Next(0, field.GetLength(1) - 1);

                if (field[row, col] == 10 || field[row, col] == 20 || field[row, col] == 30)
                {
                    field[row, col] += 2;
                    //new Fox osztály, a megfelelő koordinátákkal
                }
            }

        }
    }*/

    public class Field : IField
    {
        /// <summary>
        /// The entity
        /// </summary>
        //Entitás neve (fajtája?!)
        private string? _Entity;
        public string Entity { 
            get 
            {
                return _Entity ?? "undefinied";
            } 
            set
            {
                if (value == String.Empty) throw new ArgumentException("A mező fajtája nem lehet üres!");
                else _Entity = value;
            }
        }

        /// <summary>
        /// The position of entity
        /// </summary>
        //A Field (entitás) pozíciója mely 2 elemű int tömb [y - sor, x - oszlop].
        private int[] _Pos = new int[2];
        public int[] Pos
        {
            get
            {
                return _Pos;
            }
            set
            {
                if (value.Length > 2) throw new ArgumentOutOfRangeException("Csak sor és oszlop létezik!");
                else _Pos = value;
            }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        //A Field (entitás?!) színe. ConsoleColor a típusa.
        public ConsoleColor Color { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Field"/> class.
        /// </summary>
        /// <param name="pos">The position. Type is int[]</param>
        /// <param name="color">The color. Type is ConsoleColor </param>
        //Konstruktor a Field osztályhoz, 2 paramétere van, az első az egy int tömb [y - sor, x - oszlop].
        //A második egy ConsoleColor, amely a Field színét határozza meg.
        public Field(int[] pos, ConsoleColor color)
        {
            this.Pos = pos;
            this.Color = color;
        }
    }
}

