using Microsoft.Xna.Framework.Graphics;





// Namespace
namespace MyFirstGame
{





    // Klasse der Boss Texturen
    class ClassBossTextures
    {
        // Variableln
        public Texture2D texture { get; set; }

        // Zur Liste hinzuf�gen
        public ClassBossTextures(Texture2D texture)
        {
            this.texture = texture;
        }
    }
}
