using System;
using System.ComponentModel;





// Namespace
namespace MyFirstGame
{





    // Klasse, der feindlichen schüsse, die direct fliegen
    class ClassEnemyShotDirect
    {
        // Variabeln erstellen
        public double x { get; set; }                   // Aktueller x Punkt
        public double y { get; set; }                   // Aktueller y Punkt
        public double x_way { get; set; }               // Flugbahn x, pro Frame
        public double y_way { get; set; }               // Flugbahn y, pro Frame
        public int hitbox_x;
        public int hitbox_y;
        public int hitbox_width { get; set; }   
        public int hitbox_height { get; set; }   
        public int angel = 1;

        // Zur Liste hinzufügen
        public ClassEnemyShotDirect(double x, double y, double x_way, double y_way, int hitbox_width, int hitbox_height)
        {
            this.x = x;
            this.y = y;
            this.x_way = x_way;
            this.y_way = y_way;
            this.hitbox_width = hitbox_width;
            this.hitbox_height = hitbox_height;
            hitbox_x = Convert.ToInt32(x) - (hitbox_width / 2);
            hitbox_y = Convert.ToInt32(y) - (hitbox_height / 2);
        }

    }
}
