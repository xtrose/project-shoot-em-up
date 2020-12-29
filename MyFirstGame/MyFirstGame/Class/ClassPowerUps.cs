using Microsoft.Xna.Framework.Graphics;





// Namespace
namespace MyFirstGame
{





    // Klasse aller Power Ups
    class ClassPowerUps
    {
        // Variabeln erstellen
        public string type { get; set; }
        public int frame = 0;
        public int frame_complete = 0;
        public bool show = true;
        public int x { get; set; }
        public int y { get; set; }
        public Texture2D Texture;

        // Zur List hinzufügen
        public ClassPowerUps(string type, int x, int y)
        {
            this.type = type;
            this.x = x;
            this.y = y;
        }
    }
}
