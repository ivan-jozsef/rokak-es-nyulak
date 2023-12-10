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
            if (Hunger < 1)
            {
                fox_on_field.field[Row, Col] -= 2;
            }
        }


    }

}
