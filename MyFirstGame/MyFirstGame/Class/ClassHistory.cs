using System;
using System.ComponentModel;





// Namespace
namespace MyFirstGame
{





    // Klasse des Spielverlaufs
    class ClassHistory
    {
        // Variabeln erstellen
        public int frame { get; set; }
        public int enemy_type { get; set; }
        public int energy { get; set; }
        public int way_type { get; set; }
        public int way_cor_x { get; set; }
        public int way_cor_y { get; set; }
        public bool way_mirrow { get; set; }
        public string shot_data { get; set; }
        public string group_data { get; set; }

        //Zur Liste hinzufügen
        public ClassHistory(int frame, int enemy_type, int energy, int way_type, int way_cor_x, int way_cor_y, bool way_mirrow, string shot_data, string group_data)
        {
            this.frame = frame;
            this.enemy_type = enemy_type;
            this.energy = energy;
            this.way_type = way_type;
            this.way_mirrow = way_mirrow;
            this.shot_data = shot_data;
            this.way_cor_x = way_cor_x;
            this.way_cor_y = way_cor_y;
            this.group_data = group_data;
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
