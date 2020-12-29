





// Namespace
namespace MyFirstGame
{





    // Klasse die alle Raketen verwaltet
    class ClassMyShotRocket
    {
        // Variabeln erstellen
        public int position { get; set; }      // Position der Rakete // Links aussen -3 // Links Mitte -2 // Links Innen - 1 // Rechts Innen 1 // Rechts Mitte 2 // Rechts aussen 3
        public int x { get; set; }
        public int y { get; set; }
        public int smoke1_y = -1000;
        public int smoke2_y = -1000;
        public int smoke3_y = -1000;
        public int smoke4_y = -1000;
        public int smoke5_y = -1000;
        public int frame = 1;                   // Aktuelles Frame der Rakete
        public int speed = 1;                   //Aktuelle Geschwindigkeit der Rakete

        // Der Liste hinzufügen
        public ClassMyShotRocket(int position, int x, int y)
        {
            this.position = position;
            //Position bestimmen
            if (position == -1)
            {
                this.x = x - 20;
                this.y = y + 20;
            }
            if (position == 1)
            {
                this.x = x + 20;
                this.y = y + 20;
            }
            if (position == -2)
            {
                this.x = x - 30;
                this.y = y + 22;
            }
            if (position == 2)
            {
                this.x = x + 30;
                this.y = y + 22;
            }
            if (position == -3)
            {
                this.x = x - 40;
                this.y = y + 24;
            }
            if (position == 3)
            {
                this.x = x + 40;
                this.y = y + 24;
            }
        }
    }
}
