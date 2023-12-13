﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RokakNyulak
{
    public class Fox
    {
        public int Row;
        public int Col;
        public int Hunger;
        public Field fox_on_field;
        private static Random random = new Random();


        public Fox(int row, int col, Field field)
        {
            Row = row;
            Col = col;
            Hunger = 10;
            fox_on_field = field;
        }

        public void Move()
        {
            int newRow = Row;
            int newCol = Col;

            for (int i = -2; i <= 2; i++)
            {
                for (int j = -2; j <= 2; j++)
                {
                    int targetRow = Row + i;
                    int targetCol = Col + j;

                    // Ellenőrizzük, hogy a célmegállapítás a pályán belül van-e
                    if (targetRow >= 0 && targetRow < fox_on_field.field.GetLength(0) &&
                        targetCol >= 0 && targetCol < fox_on_field.field.GetLength(1))
                    {
                        // Ellenőrizzük, hogy a célmezőn van-e nyúl
                        if ((fox_on_field.field[targetRow, targetCol] == 11 ||
                            fox_on_field.field[targetRow, targetCol] == 21 ||
                            fox_on_field.field[targetRow, targetCol] == 31) &&
                            (Hunger < 8))
                        {
                            // Mozgatjuk a rókát a nyúlhoz
                            fox_on_field.field[Row, Col] -= 2; // Rókát eltávolítjuk a jelenlegi mezőről
                            fox_on_field.field[targetRow, targetCol] += 1; // Rókát elhelyezzük a nyúl mezőjére
                            Hunger += 3;
                            Row = targetRow;
                            Col = targetCol;
                            return; 
                        }
                    }
                }
            }

            int direction = random.Next(8);

            switch (direction)
            {
                case 0:
                    newRow = Math.Max(0, newRow - 1); break;
                case 1:
                    newRow = Math.Max(0, newRow - 1);
                    newCol = Math.Min(fox_on_field.field.GetLength(1) - 1, newCol + 1); break;
                case 2:
                    newCol = Math.Min(fox_on_field.field.GetLength(1) - 1, newCol + 1);
                    break;
                case 3:
                    newRow = Math.Min(fox_on_field.field.GetLength(0) - 1, newRow + 1);
                    newCol = Math.Min(fox_on_field.field.GetLength(1) - 1, newCol + 1);
                    break;
                case 4:
                    newRow = Math.Min(fox_on_field.field.GetLength(0) - 1, newRow + 1);
                    break;
                case 5:
                    newRow = Math.Min(fox_on_field.field.GetLength(0) - 1, newRow + 1);
                    newCol = Math.Max(0, newCol - 1);
                    break;
                case 6:
                    newCol = Math.Max(0, newCol - 1);
                    break;
                case 7:
                    newRow = Math.Max(0, newRow - 1);
                    newCol = Math.Max(0, newCol - 1);
                    break;
            }
            if (fox_on_field.field[newRow, newCol] == 10 || fox_on_field.field[newRow, newCol] == 20 || fox_on_field.field[newRow, newCol] == 30)
            {
                fox_on_field.field[Row, Col] -= 2;
                fox_on_field.field[newRow, newCol] += 2;
                Row = newRow;
                Col = newCol;

                Hunger--;
                if (Hunger == 0)
                {
                    // Csökkentjük a rókát szimbolizáló értéket
                    if (fox_on_field.field[Row, Col] == 12 || fox_on_field.field[Row, Col] == 22 || fox_on_field.field[Row, Col] == 32)
                    {
                        fox_on_field.field[Row, Col] -= 2;
                    }
                }
            }
        }

        public Fox? Reproduction()
        {
            //környező mezők vizsgálata, üres, illetve két róka egymás mellett van, akkor a következő körbe egy szabad mezőre egy új róka kerül

            // Keresés a környező mezőkön
            int newFoxRow;
            int newFoxCol;

            List<(int, int)> emptyFields = new List<(int, int)>();
            List<(int, int)> neighborFoxes = new List<(int, int)>();


            for (int i = -1; i <= 1; i++) //egy róka körül kiválasztunk egy üres mezőt, ahol csak egy másik róka tartózkodik
            {
                for (int j = -1; j <= 1; j++)
                {
                    //Console.WriteLine($"Az egyik róka koordinátái: {Row}:{Col}");
                    int targetRow = Row + i;
                    int targetCol = Col + j;

                    // Ellenőrizzük, hogy a célmegállapítás a pályán belül van-e
                    if (targetRow >= 0 && targetRow < fox_on_field.field.GetLength(0) &&
                        targetCol >= 0 && targetCol < fox_on_field.field.GetLength(1))
                    {
                        if (!(i == 0 && j == 0))
                        {
                            // Ellenőrizzük, hogy a célmezőn van-e róka
                            if (fox_on_field.field[targetRow, targetCol] == 12 ||
                                fox_on_field.field[targetRow, targetCol] == 22 ||
                                fox_on_field.field[targetRow, targetCol] == 32)
                            {
                                neighborFoxes.Add((targetRow, targetCol));
                            }
                            else if (fox_on_field.field[targetRow, targetCol] == 10 ||
                                fox_on_field.field[targetRow, targetCol] == 20 ||
                                fox_on_field.field[targetRow, targetCol] == 30)
                            {
                                emptyFields.Add((targetRow, targetCol));
                            }

                        }
                    }
                }
            }


            if (neighborFoxes.Count == 1 && emptyFields.Count >= 1 && fox_on_field.foxes.IndexOf(this) == 0)
            {
                (newFoxRow, newFoxCol) = emptyFields[random.Next(emptyFields.Count)];
                fox_on_field.field[newFoxRow, newFoxCol] += 2;
                //return true;

                Fox newFox = new Fox(newFoxRow, newFoxCol, fox_on_field);
                newFox.Hunger = 10;
                fox_on_field.foxes.Add(newFox);
                return newFox;

                //return true;
            }
            return null;
        }

    }
}

