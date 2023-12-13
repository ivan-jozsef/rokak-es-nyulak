using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RokakNyulak
{
    public class Grass
    {
        public int State { get; set; }

        public Grass(int initialState)
        {
            State = initialState;
        }

        public void Grow()
        {
            if (State < 30)
            {
                State += 10;
            }
        }
    }
}
