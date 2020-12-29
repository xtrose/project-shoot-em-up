using System;
using System.ComponentModel;





// Namespace
namespace MyFirstGame
{





    // Klasse der Hintergrundanimationen
    class ClassBackgroundAnimation
    {
        // Variabeln erstellen
        public int x { get; set; }
        public int y { get; set; }
        public int speed {get; set;}
        public float opacity { get; set; }

        // Zur Liste hinzufügen
        public ClassBackgroundAnimation (int x, int y, int speed, float opacity)
        {
            this.x = x;
            this.y = y;
            this.speed = speed;
            this.opacity = opacity;
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
