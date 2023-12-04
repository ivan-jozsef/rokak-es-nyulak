using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RokakNyulak
{
    public class Grass : Field,IGrass
    {
        /// <summary>
        /// The entity
        /// </summary>
        //Grass Field entitása, csak "grass" lehet!!
        private string _Entity = String.Empty;
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

        /// <summary>
        /// The food value
        /// </summary>
        //Grass Field tápértéke (Max 2!)
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

        /// <summary>
        /// The state
        /// </summary>
        //Grass Field állapota (Max 3!)
        private int _State;
        public int State { 
            get { return _State; } 
            set {
                if (value > 3) throw new ArgumentOutOfRangeException("A fű kifejlettsége max 3 lehet!");
                else _State = value;
            } 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Grass"/> class.
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <param name="food_value">The food value.</param>
        /// <param name="state">The state.</param>
        /// <param name="color">The color.</param>
        /*
         * Grass konstruktora.
         * Paraméterek:
         * pos -> Grass Field pozíciója mely 2 elemű int tömb [y - sor, x - oszlop].
         * food_value -> Grass Field tápértéke (Max 2!)
         * state -> Grass Field állapota (Max 3!)
         * color -> Grass Field színe. ConsoleColor típusú
         */
        public Grass(int[] pos, int food_value, int state, ConsoleColor color) : base(pos,color)
        {
            this.Entity = "grass";
            this.Food_value = food_value;
            this.State = state;
        }

	}
}
