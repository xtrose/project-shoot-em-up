using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;




// Namespace
namespace MyFirstGame
{





    /// Klasse aller Texturen von allen Gegnern
    public class ClassEnemyTextures
    {
        // Variabeln
        public string enemy_type { get; set; }
        public Texture2D just { get; set; }
        public Texture2D left { get; set; }
        public Texture2D right { get; set; }
        SpriteBatch spriteBatch;

        //Zur Liste hinzufügen
        public ClassEnemyTextures(string enemy_type, Texture2D just, Texture2D left, Texture2D right)
        {
            // Variabeln erstellen
            this.enemy_type = enemy_type;
            this.just = just;
            this.left = left;
            this.right = right;
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
