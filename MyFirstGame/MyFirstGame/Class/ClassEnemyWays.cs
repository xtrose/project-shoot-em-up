using System;
using System.ComponentModel;





// Namespace
namespace MyFirstGame
{




    // Klasse für die Wege der Gegner
    class ClassEnemyWays
    {
        // Variabeln erstellen
        public string way { get; set; }

        //Zur Liste hinzufügen
        public ClassEnemyWays(string way)
        {
            this.way = way;
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
