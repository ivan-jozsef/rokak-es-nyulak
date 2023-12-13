using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RokakNyulak
{
    public class Rabbit : Field
    {
        private int _hunger_Value; // Éhség értéke
        public int Hunger_value
        {
            get { return _hunger_Value; }
            set
            {
                if(value < 5) throw new ArgumentOutOfRangeException("A nyúl éhségeérzete max 5 lehet!");
                _hunger_Value = value;
               
            }
        }

        public Rabbit(int[] pos, ConsoleColor color) : base("rabbit", pos, color)
        {
            this.Hunger_value = 5; // Kezdetben minden nyúl éhsége 5
        }


       
        public void Move(List<Field> fields)
        {
            Random rnd = new Random();
            int currentRow = Pos[0];
            int currentCol = Pos[1];

            int[] directions = { -1, 0, 1 };

            int newX = Pos[0] + directions[rnd.Next(3)];
            int newY = Pos[1] + directions[rnd.Next(3)];


            foreach (var field in fields)
            {
                if (field.Pos[0] == newX && field.Pos[1] == newY && field.Entity == null)
                {
                    Pos[0] = newX;
                    Pos[1] = newY;
                    break;
                }
            }


        }
              

        public void Feed(List<Field> fields)
        {
            int currentRow = Pos[0];
            int currentCol = Pos[1];

            // Ellenőrizzük, hogy a nyúl aktuális mezőjén van-e fű
            Field currentField = fields.FirstOrDefault(f => f.Pos[0] == currentRow && f.Pos[1] == currentCol && f.Entity == "grass");

            if (currentField != null && ((Grass)currentField).Food_value > 0)
            {
                // A fű táplálóértékét felveszi és a mező frissítése
                int foodValue = ((Grass)currentField).Food_value;
                ((Grass)currentField).Food_value = 0;

                // Nyúl tápláltságának növelése a fű táplálóértékével
                // Meggyőződünk arról, hogy a tápláltság ne lépje túl az 5-öt
                int maxHungry = 5;
                if (Hunger_value + foodValue <= maxHungry)
                {
                    Hunger_value += foodValue;
                }
                else
                {
                    Hunger_value = maxHungry;
                }
            }
            else
            {
                // Ha a nyúl nem talál ehető füvet, mozog egy másik mezőre
                Move(fields);
            }

            // A nyúl éhezésének csökkentése minden körben
            if (Hunger_value > 0)
            {
                Hunger_value--;
            }
        }


         



    }
}
