using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RokakNyulak
{
    public class Rabbit
    {
        //csak zsenge vagy kifejlett fűvel táplálkoznak
        //ha nincs tápérték a mezőn, akkor egy üresre mozog, ahol lehetőleg kifejlett fűcsomót talál, több megfelelő mező esetén random választ
        //két nyúl egymás mellett szaporodik, a következő körben egy új nyúl kerül egy üres mezőre
        //a zsenge fű tápértéke 1, kifejlett fűcsomónak 2, fűkezdenmény 0
        //ha nincs nyúl/róka az adott mezőn, akkor egy állapottal feljebb kerül

        public int Row;
        public int Col;
        public int Hunger;
        public Field rabbit_on;

        private static Random random = new Random();

        public Rabbit(int row, int col, Field field)
        {
            Row = row;
            Col = col;
            Hunger = 5;      //max jóllakottsági szint 5
            rabbit_on = field;
        }

        //public void Eat()
        //{
        //    Hunger--;         //minden körben eggyel csökken a jóllakottsági szint
        //    if (Hunger == 0) //0 jóllakottsági szintet elérve a nyúl elpusztul
        //    {
        //        rabbit_on.field[Row, Col] -= 1;
        //    }
        //}
        public void Move()
        {
            int newRow = Row;
            int newCol = Col;

            if (rabbit_on.field[Row, Col] == 31 && Hunger <= 3)
            {
                rabbit_on.field[Row, Col] -= 10;
                Hunger += 2;
                return;
            }
            else if (rabbit_on.field[Row, Col] == 21 && Hunger <= 4)
            {
                rabbit_on.field[Row, Col] -= 10;
                Hunger += 1;
                return;
            }

            List<(int, int)> possibleMoves = new List<(int, int)>();

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int targetRow = Row + i;
                    int targetCol = Col + j;

                    if (targetRow >= 0 && targetRow < rabbit_on.field.GetLength(0) &&
                        targetCol >= 0 && targetCol < rabbit_on.field.GetLength(1))
                    {
                        if (!(i == 0 && j == 0))
                        {
                            if (rabbit_on.field[targetRow, targetCol] == 30 && Hunger <= 4)
                            {
                                possibleMoves.Add((targetRow, targetCol));
                                //rabbit_on.field[Row, Col] -= 1; // nyulat eltávolítjuk a jelenlegi mezőről
                                //rabbit_on.field[targetRow, targetCol] += 1; // nyulat elhelyezzük a grass mezejére
                                //Row = targetRow;
                                //Col = targetCol;
                                //return;
                            }
                            else if (rabbit_on.field[targetRow, targetCol] == 20 && Hunger <= 5)
                            {
                                possibleMoves.Add((targetRow, targetCol));
                                //rabbit_on.field[Row, Col] -= 1; // nyulat eltávolítjuk a jelenlegi mezőről
                                //rabbit_on.field[targetRow, targetCol] += 1; // nyulat elhelyezzük a grass mezejére
                                //Row = targetRow;
                                //Col = targetCol;
                                //return;
                            }


                        }
                    }
                }
            }
            if (possibleMoves.Count > 0)
            {
                int randomIndex = random.Next(possibleMoves.Count);
                var randomMove = possibleMoves[randomIndex];
                //Console.WriteLine(rabbit_on.field[randomMove.Item1, randomMove.Item2]);

                rabbit_on.field[Row, Col] -= 1; // Nyúlat eltávolítjuk a jelenlegi mezőről
                //Console.WriteLine(rabbit_on.field[Row, Col]);
                rabbit_on.field[randomMove.Item1, randomMove.Item2] += 1; // Nyúlat elhelyezzük a kiválasztott mezőre
                Row = randomMove.Item1;
                Col = randomMove.Item2;

            }
            Hunger--;
            if (Hunger == 0)
            {
                // Csökkentjük a nyulat szimbolizáló értéket
                if (rabbit_on.field[Row, Col] == 11 || rabbit_on.field[Row, Col] == 21 || rabbit_on.field[Row, Col] == 31)
                {
                    rabbit_on.field[Row, Col] -= 1;
                }
            }
        }



        public Rabbit Reproduction()
        {
            int newRabbitRow;
            int newRabbitCol;

            List<(int, int)> emptyFields = new List<(int, int)>();
            List<(int, int)> neighborRabbits = new List<(int, int)>();


            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int targetRow = Row + i;
                    int targetCol = Col + j;

                    if (targetRow >= 0 && targetRow < rabbit_on.field.GetLength(0) &&
                        targetCol >= 0 && targetCol < rabbit_on.field.GetLength(1))
                    {
                        if (!(i == 0 && j == 0) && rabbit_on.field[targetRow, targetCol] == 11 ||
                            rabbit_on.field[targetRow, targetCol] == 21 ||
                            rabbit_on.field[targetRow, targetCol] == 31)  
                        {
                            neighborRabbits.Add((targetRow, targetCol));
                        } else if (rabbit_on.field[targetRow, targetCol] == 10 ||
                                rabbit_on.field[targetRow, targetCol] == 20 ||
                                rabbit_on.field[targetRow, targetCol] == 30)
                        {
                            emptyFields.Add((targetRow, targetCol));
                        }
                    }
                }      
            }

            if (emptyFields.Count >= 1 && neighborRabbits.Count == 1 && rabbit_on.rabbits.IndexOf(this) == 0)
            {
                (newRabbitRow, newRabbitCol) = emptyFields[random.Next(emptyFields.Count)];
                rabbit_on.field[newRabbitRow, newRabbitCol] += 1;
                Rabbit newRabbit = new Rabbit(newRabbitRow, newRabbitCol, rabbit_on);
                newRabbit.Hunger = 5;
                rabbit_on.rabbits.Add(newRabbit);
                return newRabbit;
            }

            return null;
        }


    }
}
