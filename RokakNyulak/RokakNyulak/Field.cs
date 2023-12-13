namespace RokakNyulak
{
    public class Field : IField
    {
        /// <summary>
        /// The entity
        /// </summary>
        //Entitás neve (fajtája?!)
        private string? _Entity;
        public string Entity
        {
            get
            {
                return _Entity ?? "undefinied";
            }
            set
            {
                if (value == String.Empty) throw new ArgumentException("A mező fajtája nem lehet üres!");
                else _Entity = value;
            }
        }

        /// <summary>
        /// The position of entity
        /// </summary>
        //A Field (entitás) pozíciója mely 2 elemű int tömb [y - sor, x - oszlop].
        private int[] _Pos = new int[2];
        public int[] Pos
        {
            get
            {
                return _Pos;
            }
            set
            {
                if (value.Length > 2) throw new ArgumentOutOfRangeException("Csak sor és oszlop létezik!");
                else _Pos = value;
            }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        //A Field (entitás?!) színe. ConsoleColor a típusa.
        public ConsoleColor Color { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Field"/> class.
        /// </summary>
        /// <param name="pos">The position. Type is int[]</param>
        /// <param name="color">The color. Type is ConsoleColor </param>
        //Konstruktor a Field osztályhoz, 2 paramétere van, az első az egy int tömb [y - sor, x - oszlop].
        //A második egy ConsoleColor, amely a Field színét határozza meg.
        public Field(string entity, int[] pos, ConsoleColor color)
        {
            this.Entity = entity;
            this.Pos = pos;
            this.Color = color;
        }


    }
}
