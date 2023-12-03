using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RokakNyulak
{
    public class Grass : Field,IGrass
    {
        private string _Entity;
		public new string Entity {
            get
            {
                return _Entity;
            }
            set
            {
                if (value != "grass") throw new InvalidDataException("Fű mező nem lehet állat vagy egyéb más!");
                else _Entity = value;
            }
        }

        private int _Food_Value;
        public int Food_value
        {
            get { return _Food_Value; }
            set
            {
                if (value > 2) throw new ArgumentOutOfRangeException("A fű tápértéke max 2 lehet!");
                else _Food_Value = value;
            }
        }

        private int _State;
        public int State { 
            get { return _State; } 
            set {
                if (value > 3) throw new ArgumentOutOfRangeException("A fű kifejlettsége max 3 lehet!");
                else _State = value;
            } 
        }
        

        /*
         
         
        */
        public Grass(string entity, int[] pos, int food_value, int state, ConsoleColor color) : base(pos,color)
        {
            this.Entity = entity;
            this.Food_value = food_value;
            this.State = state;
        }

	}
}
