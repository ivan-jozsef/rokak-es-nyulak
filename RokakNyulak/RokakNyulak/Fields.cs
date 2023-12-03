using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RokakNyulak
{
    public class Fields
    {
        static Random rnd = new Random();
        List<Field> fields = new List<Field>();

        private int[] MaxSize { get; set; }
        public List<Field> GetFields => fields;

        string[] entity =
        {
            "grass",
            "etc"
        };

        /*List<Field> GenerateFields()
        {
            List<Field> ret = new List<Field>();
            for (int row = 0; row < MaxSize[1]; row++)
            {
                for (int col = 0; col < MaxSize[0]; col++)
                {
                    int[] ActPos = { row, col };
                    yield return entity[rnd.Next(entity.Length)] switch
                    {
                        "grass" => new Grass("grass", ActPos, rnd.Next(0, 2 + 1), rnd.Next(0, 3 + 1), ConsoleColor.Green),
                        _ => new Field(ActPos, ConsoleColor.Gray)
                    };
                    ret.Add(new Grass("grass", ActPos, rnd.Next(0, 2 + 1), rnd.Next(0, 3 + 1), ConsoleColor.Green));
                }
            }

            return ret;
        }*/

        IEnumerable<Field> GenerateFields()
        {
            for (int row = 0; row < MaxSize[1]; row++)
            {
                for (int col = 0; col < MaxSize[0]; col++)
                {
                    int[] ActPos = { row, col };
                    yield return entity[rnd.Next(entity.Length)] switch
                    {
                        "grass" => new Grass("grass", ActPos, rnd.Next(0, 2 + 1), rnd.Next(0, 3 + 1), ConsoleColor.Green),
                        _ => new Field(ActPos, ConsoleColor.Gray)
                    };
                }
            }
        }

        public Fields(int[] maxsize) 
        { 
            this.MaxSize = maxsize;
            this.fields = GenerateFields().ToList();
        }
    }
}
