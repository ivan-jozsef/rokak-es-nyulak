namespace RokakNyulak
{
    public class Field
    {
        public int[,] field;
        private Random random;
        public List<Fox> foxes = new List<Fox>();
        public List<Rabbit> rabbits = new List<Rabbit>();


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

                    //Console.Write($"{field[row, col]} ");
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


        public Tuple<List<Fox>, List<Rabbit>> FieldGenerator()
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
                    Rabbit rabbit = new Rabbit(row, col, this);
                    rabbits.Add(rabbit);
                    //new Rabbit osztály a megfelelő koordinátákkal
                }
            }
            for (int i = 0; i < 13; i++)
            {
                int row = random.Next(0, field.GetLength(0));
                int col = random.Next(0, field.GetLength(1));

                if (field[row, col] == 10 || field[row, col] == 20 || field[row, col] == 30)
                {
                    field[row, col] += 2;
                    //new Fox osztály, a megfelelő koordinátákkal
                    Fox fox = new Fox(row, col, this);
                    foxes.Add(fox);
                }
            }
            return Tuple.Create(foxes, rabbits);
        }

        public void GrowGrass()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    int currentState = field[i, j];
                    //Console.WriteLine(currentState);
                    if (currentState == 10 || currentState == 20)
                    {
                        field[i,j] += 10;
                    }
                }
            }
        }

        public void Update()
        {
            List<Fox> newFoxes = new List<Fox>(foxes);
            List<Rabbit> newRabbits = new List<Rabbit>(rabbits);

            foreach (var fox in newFoxes)
            {
                fox.Reproduction();
                fox.Move();
            }

            foreach (var rabbit in newRabbits)
            {
                rabbit.Reproduction();
                rabbit.Move();
            }

            foxes.RemoveAll(fox => fox == null || fox.Hunger == 0);
            rabbits.RemoveAll(rabbit => rabbit == null || rabbit.Hunger == 0);

            GrowGrass();
        }

        public void Simulation()
        {
            int simCount = 1000;
            while (simCount > 0)
            {
                Console.Clear();

                Console.WriteLine($"A rókák jelenlegi száma: {foxes.Count}");
                Console.WriteLine($"A nyulak jelenlegi száma: {rabbits.Count}");

                Console.WriteLine($"Hátralévő körök: {simCount}");


                DrawField();

                Update();

                Console.Clear();

                Console.WriteLine($"A rókák jelenlegi száma: {foxes.Count}");
                Console.WriteLine($"A nyulak jelenlegi száma: {rabbits.Count}");

                Console.WriteLine($"Hátralévő körök: {simCount}");

                DrawField();

                Update();

                Thread.Sleep(1200);
                //while (!Console.KeyAvailable)
                //{
                //    Thread.Sleep(1000);
                //}
                //Console.ReadKey(true);


                simCount--;


            }

        }
    }
}

