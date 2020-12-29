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





    // Partial Game Klasse // Methoden zum erneuern des Spielverlaufs
    public partial class Game1 : Microsoft.Xna.Framework.Game
    {





        // Spielschleife // Zum errechenen des Spielablaufs
        // ------------------------------------------------------------------------------------------------------------------------------------
        protected override void Update(GameTime gameTime)
        {
            // Alle Eingaben aus dem Taouchpanal holen
            TouchCollection touchCollection = TouchPanel.GetState();





            // Positionen der Finger durchlaufen // Position des Fingers ermitteln
            // **************************************************************************************************************
            // Frames in dem nicht gedrückt ist erhöhen
            LastClickFrames++;
            foreach (TouchLocation tl in touchCollection)
            {
                // Nur wenn der Status gedrückt oder bewegend ist, ablegen
                if ((tl.State == TouchLocationState.Pressed) || (tl.State == TouchLocationState.Moved))
                {
                    // Doppelklick zurücksetzen
                    DoubleClick = false;
                    // Aktuelle Posistion des Finges ermitteln
                    PositionFinger = tl.Position;
                    // Wenn erste Position des Fingers nicht vorhanden, erstellen
                    if (FirstPositionFinger.X == -100 & FirstPositionFinger.Y == -100)
                    {
                        // Erste Position des Fingers erstellen
                        FirstPositionFinger = PositionFinger;
                        // Prüfen ob Doppelklick
                        if (LastClickFrames < 4)
                        {
                            DoubleClick = true;
                            LastClickFrames = 0;
                        }
                        // Abstand zwischen Finger und Schiff bestimmen
                        PositionY = MyShip_Y - Convert.ToInt32(FirstPositionFinger.Y);
                    }
                }
                // Wenn Status nicht gedrückt oder bewegt ist 
                else
                {
                    // Erste Position des Fingers zurücksetzen
                    FirstPositionFinger = new Vector2(-100, -100);
                    LastClickFrames = 0;
                }
            }
            // **************************************************************************************************************





            // Hauptmenü
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            if (Game_Control == "Main_Menu")
            {
                Update_Main_Menu();
            }
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++





            // Ladebildschirm
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            else if (Game_Control == "Loading")
            {
                Update_Loading();
            }
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++





            // Level
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            else if (Game_Control == "Level")
            {
                Update_Level();
            }
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++





            // Updaten
            base.Update(gameTime);
        }
        // ------------------------------------------------------------------------------------------------------------------------------------





    }





}
