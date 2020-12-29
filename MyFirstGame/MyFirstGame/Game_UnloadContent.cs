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





    // Partial Game Klasse // Methoden zum entladen des Contents
    public partial class Game1 : Microsoft.Xna.Framework.Game
    {





        // Gegenstände aus Speicher entfernen
        // ------------------------------------------------------------------------------------------------------------------------------------
        protected override void UnloadContent()
        {
            // SplashScreen entladen
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            if (Game_UnloadContent == "SplashScreen")
            {
                // SplashScreen entladen
                texSplashScreen.Dispose();
                // Control zurücksetzen
                Game_UnloadContent = "None";
            }
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++





            // Hauptmenü entladen
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            if (Game_UnloadContent == "Main_Menu")
            {
                // Hauptmenü Content entladen
                UnloadContent_Main_Menu();
                // Control zurücksetzen
                Game_UnloadContent = "None";
            }
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        }
        // ------------------------------------------------------------------------------------------------------------------------------------





    }





}
