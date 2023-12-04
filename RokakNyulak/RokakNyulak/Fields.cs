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
        List<Field> fields = new List<Field>();

        /// <summary>
        /// Gets or sets the maximum size.
        /// </summary>
        /// <value>
        /// The maximum size.
        /// </value>
        //Maximum méret (táblaméret) mely 2 elemű [y - sor, x - oszlop].
        private int[] MaxSize { get; set; }

        /// <summary>
        /// Gets the fields.
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        //Vissza adja a Field -ek listáját.
        public List<Field> GetFields => fields;

        /// <summary>
        /// The entities.
        /// </summary>
        // Entity-k listája.
        string[] entities =
        {
            "grass",
            "etc"
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
            for (int row = 0; row < MaxSize[1]; row++)
            {
                for (int col = 0; col < MaxSize[0]; col++)
                {
                    int[] ActPos = { row, col };
                    yield return entities[rnd.Next(entities.Length)] switch
                    {
                        "grass" => new Grass(ActPos, rnd.Next(0, 2 + 1), rnd.Next(0, 3 + 1), ConsoleColor.Green),
                        _ => new Field(ActPos, ConsoleColor.Gray)
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
            this.MaxSize = maxsize;
            this.fields = GenerateFields().ToList();
        }
    }
}
