




// Namespace
namespace MyFirstGame
{




    // Klasse für die eigenen Schüsse
    class ClassMyShots
    {
        // Variabeln erstellen
        public string type { get; set;  }
        public int level { get; set; }
        public float angle { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int start_x = 0;
        public int start_frame= 0;
        public int hitbox_x = 0;
        public int hitbox_y = 0;
        public int hitbox_width = 0;
        public int hitbox_height = 0;

        //Zur Liste hinzufügen
        public ClassMyShots(string type, int level, int x, int y, float angle)
        {
            // Variabeln deklarieren
            this.type = type;
            this.level = level;
            this.angle = angle;
            this.x = x;
            this.y = y;
            this.start_x = x;
            this.start_frame = 0;
            // Hitbox Daten, bei MyShotFire // Feuer
            if (type == "Fire")
            {
                hitbox_width = 20;
                hitbox_height = 28;
                hitbox_x = x - (hitbox_width / 2);
                hitbox_y = y - (hitbox_height / 2);
            }
            // Hitbox Daten, bei MyShotPhaser // Phaser
            if (type == "Phaser")
            {
                hitbox_width = 48;
                hitbox_height = 28;
                hitbox_x = x - (hitbox_width / 2);
                hitbox_y = y - (hitbox_height / 2);
            }
            // Hitbox Daten, bei MyShotLaser // Laser
            if (type == "Laser")
            {
                // Wenn Laser Level 1
                if (level == 1)
                {
                    hitbox_width = 9;
                    hitbox_height = 20;
                    hitbox_x = x - 4;
                    hitbox_y = y - 19;
                }
                // Wenn Laser Level 2
                if (level == 2)
                {
                    hitbox_width = 18;
                    hitbox_height = 20;
                    hitbox_x = x - 9;
                    hitbox_y = y - 27;
                }
                // Wenn Laser Level 3
                if (level == 3)
                {
                    hitbox_width = 27;
                    hitbox_height = 20;
                    hitbox_x = x -15;
                    hitbox_y = y -36;
                }
            }
        }
    }
}
