using Microsoft.Xna.Framework.Graphics;





// Namespace
namespace MyFirstGame
{





    // Klasse aller Explosionen
    class ClassExplosions
    {
        // Variabeln erstellen
        public string type { get; set; }
        public int frame { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public Texture2D Texture;

        //Zur Liste hinzufügen
        public ClassExplosions(string type, int frame, int x, int y)
        {
            // Variabeln übernehmen
            this.type = type;
            this.frame = frame;
            this.x = x;
            this.y = y;            
        }
    }
}
