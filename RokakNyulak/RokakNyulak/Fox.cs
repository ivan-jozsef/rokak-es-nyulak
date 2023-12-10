using System;
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

        public void Eat()
        {
            Hunger--;
            if (Hunger == 0)
            {
                fox_on_field.field[Row, Col] -= 2;
            }
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
            }
        }
    }
}
