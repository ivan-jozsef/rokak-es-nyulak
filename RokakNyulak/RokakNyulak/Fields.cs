using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RokakNyulak
{
    public class Fields
    {
        /// <summary>
        /// The random
        /// </summary>
        // Statikus Random, random generáláshoz.
        static Random rnd = new Random();

        /// <summary>
        /// The fields
        /// </summary>
        //A mezők listája
        private List<Field> fields { get; set; }

        /// <summary>
        /// Gets or sets the maximum size.
        /// </summary>
        /// <value>
        /// The maximum size.
        /// </value>
        //Méret (táblaméret) mely 2 elemű [y - sor, x - oszlop].
        public int[] Size { get; set; }

        /// <summary>
        /// Gets the fields.
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        //Vissza adja a Field -ek listáját.
        public List<Field> GetFields => fields;
        public List<Field> GetEntityFields(string entityName)
        {
            //fields.Where(x => x.Entity == entityName).ToList() ?? new List<Field>();
            if (fields != null) return fields.Where(x => x.Entity == entityName).ToList();
            else return new List<Field> { };
        }

        public int GetEntityCount(string entityName) => fields.Count(x => x.Entity == entityName);

        public string GetNextEntityType(string actEntity)
        {
            List<Field> actEntityFields = GetEntityFields(actEntity);
            return actEntityFields.Count > GetEntityFields("grass").Count ? "grass" : actEntity; 
        }

        /// <summary>
        /// The entities.
        /// </summary>
        // Entity-k listája.
        string[] entities =
        {
            "grass",
            "fox",
            "rabbit",
            
        };

        /// <summary>Generates the fields.</summary>
        /// <returns>
        ///   IEnumerable<Field>
        /// </returns>
        /*
         * Legenerálja a Field-eket, majd visszaad egy IEnumerable<Field> -et.
         */
        IEnumerable<Field> GenerateFields()
        {
            for (int row = 0; row < Size[1]; row++)
            {
                for (int col = 0; col < Size[0]; col++)
                {
                    int[] ActPos = { row, col };
                    //string entityType = entities[rnd.Next(entities.Length)];
                    //if (entityType == "fox" && rnd.Next(50) == 0)
                    //{
                    //    yield return new Fox(entityType, ActPos, ConsoleColor.Red);
                    //} else
                    //{
                    //    yield return entityType switch
                    //    {
                    //        "grass" => new Grass(ActPos, rnd.Next(0, 2 + 1), rnd.Next(0, 3 + 1), ConsoleColor.Green),
                    //        "rabbit" => new Field("rabbit", ActPos, ConsoleColor.White),
                    //        _ => new Grass(ActPos, rnd.Next(0, 2 + 1), rnd.Next(0, 3 + 1), ConsoleColor.Green)
                    //    };
                    //}


                    yield return entities[rnd.Next(entities.Length)] switch
                    {
                        "grass" => new Grass(ActPos, rnd.Next(0, 2 + 1), rnd.Next(0, 3 + 1), ConsoleColor.Green),
                        "fox" => new Fox("fox", ActPos, ConsoleColor.Red),
                        "rabbit" => new Field("rabbit", ActPos, ConsoleColor.White),
                        _ => new Grass(ActPos, rnd.Next(0, 2 + 1), rnd.Next(0, 3 + 1), ConsoleColor.Green)
                    };
                }
            }
        }

        /// <summary>Creates a new <see cref="Fields" /> class.</summary>
        /// <param name="maxsize">The maxsize. It's an int[].</param>
        /*
         * Fields osztály konstruktor, létrehoz egy Fields osztályt illetve Field-eket is generál.
         * Paramétere egy darab int tömb, mely 2 elemű [y - sor, x - oszlop].
         */
        public Fields(int[] maxsize) 
        { 
            this.Size = maxsize;
            this.fields = GenerateFields().ToList();
        }
    }
}
