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





    // Partial Game Klasse // Methoden zum berrechnen des Spielverlaufs des Menüs
    public partial class Game1 : Microsoft.Xna.Framework.Game
    {




        // Ladebildschirm // Variabeln
        // ------------------------------------------------------------------------------------------------------------------------------------
        bool Load_Next = false;
        int Loading_FrameCount = 0;
        // ------------------------------------------------------------------------------------------------------------------------------------










        // Ladebildschirm // Alten Content entladen // Nächsten Content laden
        // ------------------------------------------------------------------------------------------------------------------------------------
        void Update_Loading()
        {
            // Allgemeine Aktionen
            // **************************************************************************************************************
            // FrameCount erhöhen
            Loading_FrameCount++;

            // Angeben was als nächstes geladen wird
            if (Game_Control_Next == "None" | Game_Control_Next == "")
            {
                Game_Control_Next = Game_LoadContent;
            }
            // **************************************************************************************************************



            // Bestimmte Ladeaktion ausführen
            // **************************************************************************************************************
            if (Loading_FrameCount > 2)
            {
                // Wenn Unload Content noch besteht
                if (Game_UnloadContent != "None" & Game_UnloadContent != "")
                {
                    // Content entladen
                    UnloadContent();
                }

                // Wenn Unload Content noch besteht
                if (Game_LoadContent != "None" & Game_LoadContent != "")
                {
                    // Content laden
                    LoadContent();
                }

                // Wenn alles geladen
                else
                {
                    // Angeben das alles geladen, das nach dem zeichen die nächste Aktion berechnet wird
                    Load_Next = true;
                }
            }
            // **************************************************************************************************************
        }
        // ------------------------------------------------------------------------------------------------------------------------------------









        // Ladebildschirm zeichnen
        // ------------------------------------------------------------------------------------------------------------------------------------
        void Draw_Loading()
        {
            // Ladebidschirm zeichnen
            spriteBatch.Draw(texLoading, new Vector2(0, 0), Color.White);

            // Wenn nächste Aktion ausgeführt wird, Nächste Aktion berechnen
            if (Load_Next == true)
            {
                // Game_Control neu erstellen
                Game_Control = Game_Control_Next;
                // Game_Control_Next zurücksetzen
                Game_Control_Next = "None";
                Load_Next = false;
            }
        }
        // ------------------------------------------------------------------------------------------------------------------------------------





    }





}
