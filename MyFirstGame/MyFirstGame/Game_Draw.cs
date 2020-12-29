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
using Microsoft.Xna.Framework;
using System;






//Namespace
namespace MyFirstGame
{





    // Partial Game Klasse // Methoden zum zeichen zur Laufzeit
    public partial class Game1 : Microsoft.Xna.Framework.Game
    {





        // Zeichnet zur Laufzeit den Bildschirm neu
        // ------------------------------------------------------------------------------------------------------------------------------------
        protected override void Draw(GameTime gameTime)
        {
            // Erstellt eine Hintergrundfarbe
            GraphicsDevice.Clear(Color.CornflowerBlue);





            //Beginnen Sprites zu erstellen
            spriteBatch.Begin();





            // Hauptmenü
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            if (Game_Control == "Main_Menu")
            {
                // Hauptmenü zeichnen
                Draw_Main_Menu();
            }
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++





            // Ladebildschirm zeichnen
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            else if (Game_Control == "Loading")
            {
                // Hauptmenü zeichnen
                Draw_Loading();
            }
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++





            // Level zeichnen
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            else if (Game_Control == "Level")
            {
                // Hauptmenü zeichnen
                Draw_Level();
            }
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++





            // Ende Sprites erstellen
            spriteBatch.End();

            // Zeichnen
            base.Draw(gameTime);
        }
        // ------------------------------------------------------------------------------------------------------------------------------------





    }





}
