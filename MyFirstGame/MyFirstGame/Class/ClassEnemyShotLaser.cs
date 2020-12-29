using Microsoft.Xna.Framework.Graphics;
using System;
using System.ComponentModel;




// Namespace
namespace MyFirstGame
{





    // Klasse der Feindlichen Sch�sse // Laser 
    class ClassEnemyShotLaser
    {
        // Variabeln erstellen
        public Texture2D texture { get; set; }          // Textur des Schusses
        public int type { get; set; }                   // Typ des Schusses
        public double x { get; set; }                   // Aktueller x Punkt
        public double y { get; set; }                   // Aktueller y Punkt
        public int speed { get; set; }                  // Geschwindigkeit des Schusses

        // Zur Liste hinzuf�gen
        public ClassEnemyShotLaser(Texture2D texture, int type, double x, double y, int speed)
        {
            this.texture = texture;
            this.type = type;
            this.x = x;
            this.y = y;
            this.speed = speed;
        }
    }
}
