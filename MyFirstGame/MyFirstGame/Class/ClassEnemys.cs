using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Linq;





// Namespace
namespace MyFirstGame
{




    // Klasse der Gegner
    class ClassEnemys
    {
        // Variabeln erstellen
        public string enemy { get; set; }
        public bool just { get; set; }
        public bool left { get; set; }
        public bool right { get; set; }
        public int hitbox_cor_x { get; set; }
        public int hitbox_cor_y { get; set; }
        public int hitbox_width { get; set; }
        public int hitbox_height { get; set; }
        public string explosion_type { get; set; }
        public float rotate { get; set; }

        //Zur Liste hinzufügen
        public ClassEnemys(string enemy, string sprites, int hitbox_cor_x, int hitbox_cor_y, int hitbox_width, int hitbox_height, string explosion_type, float rotate)
        {
            // Gegner Name hinzufügen
            this.enemy = enemy;
            this.hitbox_cor_x = hitbox_cor_x;
            this.hitbox_cor_y = hitbox_cor_y;
            this.hitbox_width = hitbox_width;
            this.hitbox_height = hitbox_height;
            this.explosion_type = explosion_type;
            this.rotate = rotate;

            // Sprites durchlaufen und prüfen welche vorhanden
            string[] split_sprites = Regex.Split(sprites , ",");
            for (int i = 0; i < split_sprites.Count(); i++)
            {
                if (split_sprites[i] == "just")
                {
                    just = true;
                }
                if (split_sprites[i] == "left")
                {
                    left = true;
                }
                if (split_sprites[i] == "right")
                {
                    right = true;
                }
            }

        }

        //PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
