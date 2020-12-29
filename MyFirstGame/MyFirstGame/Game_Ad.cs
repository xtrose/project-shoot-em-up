using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using Microsoft.Advertising.Mobile.Xna;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.IO;
using System.Text.RegularExpressions;
using System.ComponentModel;
using Microsoft.Phone.Tasks;
using System.Windows.Navigation;
using Microsoft.Phone.Marketplace;
using System.Windows.Controls;






//Namespace
namespace MyFirstGame
{





    // Partial Game Klasse // Methoden zum einblenden der Werbung
    public partial class Game1 : Microsoft.Xna.Framework.Game
    {



        // Werbung
        // ------------------------------------------------------------------------------------------------------------------------------------
        private void CreateAd()
        {
            // Create a banner ad for the game.
            int width = 480;
            int height = 80;
            int x = 0;
            int y = 0;

            bannerAd = AdGameComponent.Current.CreateAd("Image480_80", new Rectangle(x, y, width, height), true);
        }
        // ------------------------------------------------------------------------------------------------------------------------------------





    }





}
