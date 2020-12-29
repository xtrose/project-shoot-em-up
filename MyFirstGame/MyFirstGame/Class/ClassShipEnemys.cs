using System;
using System.ComponentModel;





// Namespace
namespace MyFirstGame
{





    // Klasse aller Gegner auf dem Spielfeld
    class ClassShipEnemys
    {
        // Variablen erstellen
        public int enemy_type { get; set; }
        public int way_type { get; set; }
        public int way_cor_x { get; set; }
        public int way_cor_y { get; set; }
        public bool way_mirrow { get; set; }
        public int frame_start { get; set; }
        public int position_x { get; set; }
        public int position_y { get; set; }
        public int hitbox_cor_x { get; set; }
        public int hitbox_cor_y { get; set; }
        public int hitbox_x { get; set; }
        public int hitbox_y { get; set; }
        public int hitbox_width { get; set; }
        public int hitbox_height { get; set; }
        public int energy { get; set; }
        public string status { get; set; }
        public string sprite { get; set; }
        public int shot_number { get; set; }
        public string shot_data { get; set; }
        public string group_data { get; set; }
        public float rotate { get; set; }
        public float rotation { get; set; }


        //Zur Liste hinzufügen
        public ClassShipEnemys(int enemy_type, int way_type, int way_cor_x, int way_cor_y, bool way_mirrow, int frame_start, int energy, int hitbox_width, int hitbox_height, int hitbox_cor_x, int hitbox_cor_y, string shot_data, string group_data, float rotate)
        {
            this.enemy_type = enemy_type;
            this.way_type = way_type;
            this.way_mirrow = way_mirrow;
            this.frame_start = frame_start;
            this.energy = energy;
            this.hitbox_height = hitbox_height;
            this.hitbox_width = hitbox_width;
            this.hitbox_cor_x = hitbox_cor_x;
            this.hitbox_cor_y = hitbox_cor_y;
            this.shot_data = shot_data;
            this.way_cor_x = way_cor_x;
            this.way_cor_y = way_cor_y;
            this.shot_number = 0;
            this.group_data = group_data;
            this.rotate = rotate;
            this.rotation = 0.0f;
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
