using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RokakNyulak
{
    public class Field
    {
        public int[,] field;
        private Random? random;
        public List<Fox> foxes = new();
        public List<Rabbit> rabbits = new();

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
                case 31: Console.BackgroundColor = ConsoleColor.Black; break;
                case 12:
                case 22:
                case 32: Console.BackgroundColor = ConsoleColor.Red; break;
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
                }
            }
            for (int i = 0; i < 13; i++)
            {
                int row = random.Next(0, field.GetLength(0));
                int col = random.Next(0, field.GetLength(1));

                if (field[row, col] == 10 || field[row, col] == 20 || field[row, col] == 30)
                {
                    field[row, col] += 2;
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
                    if (currentState == 10 || currentState == 20)
                    {
                        field[i, j] += 10;
                    }
                }
            }
        }

        public async Task UpdateAsync()
        {
            List<Fox> newFoxes = new(foxes);
            List<Rabbit> newRabbits = new(rabbits);

            var foxTasks = new List<Task>();
            var rabbitTasks = new List<Task>();

            foreach (var fox in newFoxes)
            {
                foxTasks.Add(fox.ReproductionAsync());
                foxTasks.Add(fox.MoveAsync());
            }
            await Task.Delay(100);
            foreach (var rabbit in newRabbits)
            {
                rabbitTasks.Add(rabbit.ReproductionAsync());
                rabbitTasks.Add(rabbit.MoveAsync());
            }
            
            await Task.Delay(100);

            await Task.WhenAll(foxTasks);
            await Task.WhenAll(rabbitTasks);

            foxes.RemoveAll(fox => fox == null || fox.Hunger == 0);
            rabbits.RemoveAll(rabbit => rabbit == null || rabbit.Hunger == 0);

            GrowGrass();
        }

        public async Task SimulationAsync()
        {
            int simCount = 1000;
            while (simCount > 0)
            {
                Console.Clear();

                Console.WriteLine($"A rókák jelenlegi száma: {foxes.Count}");
                Console.WriteLine($"A nyulak jelenlegi száma: {rabbits.Count}");

                Console.WriteLine($"Hátralévő körök: {simCount}");

                DrawField();

                await UpdateAsync();

                Console.Clear();

                Console.WriteLine($"A rókák jelenlegi száma: {foxes.Count}");
                Console.WriteLine($"A nyulak jelenlegi száma: {rabbits.Count}");

                Console.WriteLine($"Hátralévő körök: {simCount}");

                DrawField();

                await Task.Delay(1200);

                simCount--;
            }
        }
    }
}
