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




        // Hauptmenü // Spielverlauf berrechnen
        // ------------------------------------------------------------------------------------------------------------------------------------
        void Update_Main_Menu()
        {
            // Variablen // Spielverlauf berrechnen
            // **************************************************************************************************************
            bool playSndButton = false;
            bool playSndCheat = false;
            // **************************************************************************************************************



            // Back Button
            // **************************************************************************************************************
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                // Im Hauptmenü
                if (Game_Menu_Part == "Main")
                {
                    this.Exit();
                }
                else
                {
                    // Nach jedem Release, Fingerposition zurücksetzen
                    PositionFinger.X = -1;
                    PositionFinger.Y = -1;

                    // Zum Hauptmenü wechseln
                    Game_Menu_Part = "Main";
                    Menu_FrameCount = 0;

                    // Angeben das Button Sound gespielt wird
                    playSndButton = true;
                }
            }
            // **************************************************************************************************************



            // Musik abspielen
            // **************************************************************************************************************
            if (MediaPlayer.State.ToString() != "Playing")
            {
                MediaPlayer.Play(songBackgroundMusic);
            }
            // **************************************************************************************************************



            // Frame Count erhöhen
            // **************************************************************************************************************
            Menu_FrameCount++;
            Menu_ShipFrameCount++;
            FrameCount++;
            // **************************************************************************************************************



            // SplashScreen entladen, wenn nicht mehr verwendet wird
            // **************************************************************************************************************
            if (Menu_FrameCount == 1)
            {
                // Angeben das SplashScreen entladen wird
                Game_UnloadContent = "SplashScreen";
                // Entladen
                UnloadContent();
            }
            // **************************************************************************************************************



            // Button Druck Anhand der Position des Fingers ermitteln
            // **************************************************************************************************************
            // Koordinaten löschen
            Menu_Button_Background_X = 0;
            Menu_Button_Background_Y = 0;
            Menu_Button_Background_Small_X = 0;
            Menu_Button_Background_Small_Y = 0;



            // Eingabe nach Press erkennen
            if (FirstPositionFinger.X != -100 & FirstPositionFinger.Y != -100)
            {

                // Eingabe nach Press erkennen // Im Hauptmenü
                if (Game_Menu_Part == "Main")
                {
                    // Bei Press von Button Play
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 152 & PositionFinger.Y <= 192)
                    {
                        Menu_Button_Background_X = 25;
                        Menu_Button_Background_Y = 152;
                    }

                    // Bei Press von Button Difficulty // Linke Seite
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 210 & PositionFinger.Y <= 250)
                    {
                        Menu_Button_Background_X = 25;
                        Menu_Button_Background_Y = 210;
                    }

                    // Bei Press von Button Difficulty // Rechte Seite
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 210 & PositionFinger.Y <= 250)
                    {
                        Menu_Button_Background_Small_X = 325;
                        Menu_Button_Background_Small_Y = 210;
                    }

                    // Bei Press von Button Level Select // Linke Seite
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 268 & PositionFinger.Y <= 308)
                    {
                        Menu_Button_Background_X = 25;
                        Menu_Button_Background_Y = 268;
                    }

                    // Bei Press von Button Level Select // Rechte Seite
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 268 & PositionFinger.Y <= 308)
                    {
                        Menu_Button_Background_Small_X = 325;
                        Menu_Button_Background_Small_Y = 268;
                    }

                    // Bei Press von Button Highscores
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 326 & PositionFinger.Y <= 366)
                    {
                        Menu_Button_Background_X = 25;
                        Menu_Button_Background_Y = 326;
                    }

                    // Bei Press von Button About
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 384 & PositionFinger.Y <= 424)
                    {
                        Menu_Button_Background_X = 25;
                        Menu_Button_Background_Y = 384;
                    }

                    // Bei Press von Button Buy Game
                    if ((PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 442 & PositionFinger.Y <= 482) & !Fullversion)
                    {
                        Menu_Button_Background_X = 25;
                        Menu_Button_Background_Y = 442;
                    }

                    // Bei Press von Button Exit
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 500 & PositionFinger.Y <= 540)
                    {
                        Menu_Button_Background_X = 25;
                        Menu_Button_Background_Y = 500;
                    }
                }

                // Eingabe nach Press erkennen // Im Difficulty Menü
                if (Game_Menu_Part == "Difficulty")
                {
                    // Bei Press von Button Difficulty // Linke Seite
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 210 & PositionFinger.Y <= 250)
                    {
                        Menu_Button_Background_X = 25;
                        Menu_Button_Background_Y = 210;
                    }

                    // Bei Press von Button Difficulty // Rechte Seite // Easy
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 152 & PositionFinger.Y <= 192)
                    {
                        Menu_Button_Background_Small_X = 325;
                        Menu_Button_Background_Small_Y = 152;
                    }

                    // Bei Press von Button Difficulty // Rechte Seite // Medium
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 210 & PositionFinger.Y <= 250)
                    {
                        Menu_Button_Background_Small_X = 325;
                        Menu_Button_Background_Small_Y = 210;
                    }

                    // Bei Press von Button Difficulty // Rechte Seite // Hard
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 268 & PositionFinger.Y <= 308)
                    {
                        Menu_Button_Background_Small_X = 325;
                        Menu_Button_Background_Small_Y = 268;
                    }

                    // Bei Press von Button Back
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 500 & PositionFinger.Y <= 540)
                    {
                        Menu_Button_Background_X = 25;
                        Menu_Button_Background_Y = 500;
                    }
                }

                // Eingabe nach Press erkennen // Im Level Select Menü
                if (Game_Menu_Part == "LevelSelect")
                {
                    // Bei Press von Button Level Select // Linke Seite
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 268 & PositionFinger.Y <= 308)
                    {
                        Menu_Button_Background_X = 25;
                        Menu_Button_Background_Y = 268;
                    }

                    // Bei Press von Button Difficulty // Level Select // Level 1
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 152 & PositionFinger.Y <= 192)
                    {
                        Menu_Button_Background_Small_X = 325;
                        Menu_Button_Background_Small_Y = 152;
                    }

                    // Bei Press von Button Difficulty // Level Select // Level 2
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 210 & PositionFinger.Y <= 250)
                    {
                        Menu_Button_Background_Small_X = 325;
                        Menu_Button_Background_Small_Y = 210;
                    }

                    // Bei Press von Button Difficulty // Level Select // Level 3
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 268 & PositionFinger.Y <= 308)
                    {
                        Menu_Button_Background_Small_X = 325;
                        Menu_Button_Background_Small_Y = 268;
                    }

                    // Bei Press von Button Difficulty // Level Select // Level 4
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 326 & PositionFinger.Y <= 366)
                    {
                        Menu_Button_Background_Small_X = 325;
                        Menu_Button_Background_Small_Y = 326;
                    }

                    // Bei Press von Button Difficulty // Level Select // Level 5
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 384 & PositionFinger.Y <= 424)
                    {
                        Menu_Button_Background_Small_X = 325;
                        Menu_Button_Background_Small_Y = 384;
                    }

                    // Bei Press von Button Difficulty // Level Select // Level 6
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 442 & PositionFinger.Y <= 482)
                    {
                        Menu_Button_Background_Small_X = 325;
                        Menu_Button_Background_Small_Y = 442;
                    }

                    // Bei Press von Button Difficulty // Level Select // Level 7
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 500 & PositionFinger.Y <= 540)
                    {
                        Menu_Button_Background_Small_X = 325;
                        Menu_Button_Background_Small_Y = 500;
                    }

                    // Bei Press von Button Back
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 500 & PositionFinger.Y <= 540)
                    {
                        Menu_Button_Background_X = 25;
                        Menu_Button_Background_Y = 500;
                    }
                }

                // Eingabe nach Press erkennen // Im About Menü
                if (Game_Menu_Part == "About")
                {
                    // Bei Press von Button Back
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 500 & PositionFinger.Y <= 540)
                    {
                        Menu_Button_Background_X = 25;
                        Menu_Button_Background_Y = 500;
                    }
                }

                // Eingabe nach Press erkennen // Im Highscores Menü
                if (Game_Menu_Part == "Highscores")
                {
                    // Bei Press von Button Back
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 500 & PositionFinger.Y <= 540)
                    {
                        Menu_Button_Background_X = 25;
                        Menu_Button_Background_Y = 500;
                    }
                }
            }



            // Eingabe nach Release erkennen
            if (FirstPositionFinger.X == -100 & FirstPositionFinger.Y == -100)
            {

                // Im Hauptmenü
                if (Game_Menu_Part == "Main")
                {
                    // Bei Release von Button Play
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 152 & PositionFinger.Y <= 192)
                    {
                        // Spiel starten
                        Menu_Main_Button_Play_Click();
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombinationen
                        Menu_Cheat = 0;
                    }

                    // Bei Release von Button Difficulty // Linke Seite
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 210 & PositionFinger.Y <= 250)
                    {
                        // Difficulty Menü öffnen
                        Menu_Main_Button_SwitchMenu_Click("Difficulty", 20);
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombinationen
                        if (Menu_Cheat == 2)
                        {
                            Menu_Cheat = 3;
                        }
                        else
                        {
                            Menu_Cheat = 0;
                        }
                    }

                    // Bei Release von Button Difficulty // Rechte Seite
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 210 & PositionFinger.Y <= 250)
                    {
                        // Difficulty Menü öffnen
                        Menu_Main_Button_SwitchMenu_Click("Difficulty", 20);
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombination
                        Menu_Cheat = 0;
                    }

                    // Bei Release von Level Selecct // Linke Seite
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 268 & PositionFinger.Y <= 308)
                    {
                        // Level Select Menü öffnen
                        Menu_Main_Button_SwitchMenu_Click("LevelSelect", 20);
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombinationen
                        if (Menu_Cheat == 4)
                        {
                            Menu_Cheat = 5;
                        }
                        else
                        {
                            Menu_Cheat = 0;
                        }
                    }

                    // Bei Press von Button Level Select // Rechte Seite
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 268 & PositionFinger.Y <= 308)
                    {
                        // Level Select Menü öffnen
                        Menu_Main_Button_SwitchMenu_Click("LevelSelect", 20);
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombination
                        Menu_Cheat = 0;
                    }

                    // Bei Release von Button Highscores
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 326 & PositionFinger.Y <= 366)
                    {
                        // Highscores Menü öffnen
                        Menu_Main_Button_SwitchMenu_Click("Highscores", 20);
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombination
                        Menu_Cheat = 0;
                    }

                    // Bei Release von About
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 384 & PositionFinger.Y <= 424)
                    {
                        // About Menü öffnen
                        Menu_Main_Button_SwitchMenu_Click("About", 20);
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombination
                        if (Menu_Cheat == 0)
                        {
                            Menu_Cheat = 1;
                        }
                        else if (Menu_Cheat == 6)
                        {
                            Menu_Cheat = 7;
                        }
                        else
                        {
                            Menu_Cheat = 0;
                        }
                    }

                    // Bei Release von Buy Game
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 442 & PositionFinger.Y <= 482)
                    {
                        // Marktplatz kauf öffnen
                        MarketplaceDetailTask marketPlaceDetailTask = new MarketplaceDetailTask();
                        marketPlaceDetailTask.Show();
                        // Cheat Kombination
                        Menu_Cheat = 0;
                    }

                    // Bei Release von Button Exit
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 500 & PositionFinger.Y <= 540)
                    {
                        // Spiel beenden
                        Menu_Main_Button_Exit_Click();
                    }

                    // Nach jedem Release, Fingerposition zurücksetzen
                    PositionFinger.X = -1;
                    PositionFinger.Y = -1;
                }

                // Eingabe nach Release erkennen // Im Difficulty Menü
                if (Game_Menu_Part == "Difficulty")
                {
                    // Bei Release von Button Difficulty // Linke Seite
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 210 & PositionFinger.Y <= 250)
                    {
                        // Zurück zum Hauptmenü
                        Menu_BackToMain();
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombinationen
                        if (Menu_Cheat == 3)
                        {
                            Menu_Cheat = 4;
                        }
                        else
                        {
                            Menu_Cheat = 0;
                        }
                    }

                    // Bei Release von Button Difficulty // Rechte Seite // Easy
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 152 & PositionFinger.Y <= 192)
                    {
                        // Schwierigkeit auswählen // Easy
                        Menu_Difficulty_Select("Easy");
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombination
                        Menu_Cheat = 0;
                    }

                    // Bei Release von Button Difficulty // Rechte Seite // Medium
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 210 & PositionFinger.Y <= 250)
                    {
                        // Schwierigkeit auswählen // Medium
                        Menu_Difficulty_Select("Medium");
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombination
                        Menu_Cheat = 0;
                    }

                    // Bei Release von Button Difficulty // Rechte Seite // Hard
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 268 & PositionFinger.Y <= 308)
                    {
                        // Schwierigkeit auswählen // Hard
                        Menu_Difficulty_Select("Hard");
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombination
                        Menu_Cheat = 0;
                    }

                    // Bei Release von Button Back
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 500 & PositionFinger.Y <= 540)
                    {
                        // Hauptmenü öffnen
                        Menu_BackToMain();
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombination
                        Menu_Cheat = 0;
                    }

                    // Nach jedem Release, Fingerposition zurücksetzen
                    PositionFinger.X = -1;
                    PositionFinger.Y = -1;
                }

                // Eingabe nach Release erkennen // Im Level Select Menü
                if (Game_Menu_Part == "LevelSelect")
                {
                    // Bei Release von Button Level Select // Linke Seite
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 268 & PositionFinger.Y <= 308)
                    {
                        // Zurück zum Hauptmenü
                        Menu_BackToMain();
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombinationen
                        if (Menu_Cheat == 5)
                        {
                            Menu_Cheat = 6;
                        }
                        else
                        {
                            Menu_Cheat = 0;
                        }
                    }

                    // Bei Release von Button Level Select // Level 1
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 152 & PositionFinger.Y <= 192)
                    {
                        // Level auswählen // 1
                        Menu_Level_Select(1);
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombination
                        Menu_Cheat = 0;
                    }

                    // Bei Release von Button Level Select // Level 2
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 210 & PositionFinger.Y <= 250)
                    {
                        // Level auswählen // 2
                        Menu_Level_Select(2);
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombination
                        Menu_Cheat = 0;
                    }

                    // Bei Release von Button Level Select // Level 3
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 268 & PositionFinger.Y <= 308)
                    {
                        // Level auswählen // 3
                        Menu_Level_Select(3);
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombination
                        Menu_Cheat = 0;
                    }

                    // Bei Release von Button Level Select // Level 4
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 326 & PositionFinger.Y <= 366)
                    {
                        // Level auswählen // 4
                        Menu_Level_Select(4);
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombination
                        Menu_Cheat = 0;
                    }

                    // Bei Release von Button Level Select // Level 5
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 384 & PositionFinger.Y <= 424)
                    {
                        // Level auswählen // 5
                        Menu_Level_Select(5);
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombination
                        Menu_Cheat = 0;
                    }

                    // Bei Release von Button Level Select // Level 6
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 442 & PositionFinger.Y <= 482)
                    {
                        // Level auswählen // 6
                        Menu_Level_Select(6);
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombination
                        Menu_Cheat = 0;
                    }

                    // Bei Release von Button Level Select // Level 7
                    if (PositionFinger.X >= 325 & PositionFinger.X <= 455 & PositionFinger.Y >= 500 & PositionFinger.Y <= 540)
                    {
                        // Level auswählen // 7
                        Menu_Level_Select(7);
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombination
                        Menu_Cheat = 0;
                    }

                    // Bei Release von Button Back
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 500 & PositionFinger.Y <= 540)
                    {
                        // Hauptmenü öffnen
                        Menu_BackToMain();
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombination
                        Menu_Cheat = 0;
                    }

                    // Nach jedem Release, Fingerposition zurücksetzen
                    PositionFinger.X = -1;
                    PositionFinger.Y = -1;
                }


                // Eingabe nach Release erkennen // Im About Menü
                if (Game_Menu_Part == "About")
                {
                    // Bei Release von Button xtrose
                    if (PositionFinger.X >= 390 & PositionFinger.X <= 454 & PositionFinger.Y >= 140 & PositionFinger.Y <= 204)
                    {
                        // Cheat Kombination
                        Menu_Cheat = 0;
                        // xtrose Website öffnen
                        Menu_Main_Button_Website_Click("http://www.xtrose.com");
                    }

                    // Bei Release von Button Facebook
                    if (PositionFinger.X >= 390 & PositionFinger.X <= 454 & PositionFinger.Y >= 224 & PositionFinger.Y <= 288)
                    {
                        // Cheat Kombination
                        Menu_Cheat = 0;
                        // Facebook Webseite öffnen
                        Menu_Main_Button_Website_Click("https://www.facebook.com/xtrose.xtrose");
                    }

                    // Bei Release von Button VK
                    if (PositionFinger.X >= 390 & PositionFinger.X <= 454 & PositionFinger.Y >= 308 & PositionFinger.Y <= 372)
                    {
                        // Cheat Kombination
                        Menu_Cheat = 0;
                        // VK Webseite öffnen
                        Menu_Main_Button_Website_Click("http://vk.com/public54083459");
                    }

                    // Bei Release von Button Twitter
                    if (PositionFinger.X >= 390 & PositionFinger.X <= 454 & PositionFinger.Y >= 392 & PositionFinger.Y <= 456)
                    {
                        // Cheat Kombination
                        Menu_Cheat = 0;
                        // Twitter Webseite öffnen
                        Menu_Main_Button_Website_Click("https://twitter.com/xtrose");
                    }

                    // Bei Release von Button YouTube
                    if (PositionFinger.X >= 390 & PositionFinger.X <= 454 & PositionFinger.Y >= 476 & PositionFinger.Y <= 540)
                    {
                        // Cheat Kombination
                        Menu_Cheat = 0;
                        // You Tube Webseite öffnen
                        Menu_Main_Button_Website_Click("https://www.youtube.com/user/xtrose2overdose");
                    }

                    // Bei Release von Button Back
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 500 & PositionFinger.Y <= 540)
                    {
                        // Hauptmenü öffnen
                        Menu_BackToMain();
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombination
                        if (Menu_Cheat == 1)
                        {
                            Menu_Cheat = 2;
                        }
                        else if (Menu_Cheat == 7)
                        {
                            if (DEBUG)
                            {
                                // Angeben das Button Sound gespielt wird
                                playSndCheat = true;
                                // DEBUG deaktivieren
                                DEBUG = false;
                                // Cheat Menü zurücksetzen
                                Menu_Cheat = 0;
                            }
                            else
                            {
                                // Angeben das Button Sound gespielt wird
                                playSndCheat = true;
                                // DEBUG aktivieren
                                DEBUG = true;
                                // Cheat Menü zurücksetzen
                                Menu_Cheat = 0;
                            }
                        }
                        else
                        {
                            Menu_Cheat = 0;
                        }
                    }

                    // Bei Release von Button Rate
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 268 & PositionFinger.Y <= 308)
                    {
                        // Cheat Kombination
                        Menu_Cheat = 0;
                        // Bewertung öffnen
                        MarketplaceReviewTask review = new MarketplaceReviewTask();
                        review.Show();
                    }

                    // Bei Release von Button Support
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 326 & PositionFinger.Y <= 366)
                    {
                        // Cheat Kombination
                        Menu_Cheat = 0;
                        // Kontakt E-Mail erstellen
                        EmailComposeTask emailcomposer = new EmailComposeTask();
                        emailcomposer.To = "xtrose@hotmail.com";
                        emailcomposer.Subject = "Shoot Em Up";
                        emailcomposer.Body = "";
                        emailcomposer.Show();
                    }

                    // Bei Release von Button Music By
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 384 & PositionFinger.Y <= 424)
                    {
                        // Cheat Kombination
                        Menu_Cheat = 0;
                        // Webseite des Musikers öffnen
                        Menu_Main_Button_Website_Click("http://dreade.com/nosoap/");
                    }

                    // Nach jedem Release, Fingerposition zurücksetzen
                    PositionFinger.X = -1;
                    PositionFinger.Y = -1;
                }

                // Eingabe nach Release erkennen // Im Highscores Menü
                if (Game_Menu_Part == "Highscores")
                {
                    // Bei Press von Button Back
                    if (PositionFinger.X >= 25 & PositionFinger.X <= 300 & PositionFinger.Y >= 500 & PositionFinger.Y <= 540)
                    {
                        // Hauptmenü öffnen
                        Menu_BackToMain();
                        // Angeben das Button Sound gespielt wird
                        playSndButton = true;
                        // Cheat Kombination
                        Menu_Cheat = 0;
                    }

                    // Nach jedem Release, Fingerposition zurücksetzen
                    PositionFinger.X = -1;
                    PositionFinger.Y = -1;
                }

            }
            // **************************************************************************************************************



            // Positon des Hintergrundbildes ermitteln
            // **************************************************************************************************************
            int bg_start_pos = 0 - texBackground.Height + 800;
            int bg_end_pos = 0;
            double bg_way = bg_start_pos - bg_end_pos;
            double percent = Convert.ToDouble(100) / Convert.ToDouble(Background_Frames) * Convert.ToDouble(FrameCount);
            if (percent > 100)
            {
                percent = 100;
                Background_Position = 0;
            }
            else
            {
                double bg_pos = bg_way / Convert.ToDouble(100) * percent;
                Background_Position = Convert.ToInt32(bg_way) - Convert.ToInt32(bg_pos);
            }
            // **************************************************************************************************************



            // Hintergrundanimation
            // **************************************************************************************************************
            // Frame Count der Hintergrundanimation erhöhen
            BackgroundAnimationFrameCount++;

            // delete_string zurücksetzen
            string delete_string = "";



            // Wenn neue Hintergrundanimation erzeugt wird
            if (BackgroundAnimationFrameCount == BackgroundAnimationOccurrence)
            {
                // Frame Count zurücksetzen
                BackgroundAnimationFrameCount = 0;
                // Zufällige Ausrichtung und Geschwindigkeit erstellen
                Random rand = new Random();
                int x = rand.Next(1 - (texBackgroundAnimation.Width + 1), 479);
                int speed = rand.Next(BackgroundAnimationSpeedMin, BackgroundAnimationSpeedMax);
                float Opacity = 1.0f;
                int tempOpacity = rand.Next(BackgroundAnimationOpacityMin, BackgroundAnimationOpacityMax);
                if (tempOpacity < 10)
                {
                    double tempOpacity2 = Convert.ToDouble("0." + tempOpacity);
                    Opacity = Convert.ToSingle(tempOpacity2);
                }
                // Neue Hintergrundanimation erzeugen
                ListBackgroundAnimation.Add(new ClassBackgroundAnimation(x, 0 - texBackgroundAnimation.Height, speed, Opacity));
            }


            // Hintergrundanimationen durchlaufen und bewegen
            for (int i = 0; i < ListBackgroundAnimation.Count(); i++)
            {
                // Animation nach unten bewegen
                ListBackgroundAnimation[i].y += ListBackgroundAnimation[i].speed;
                // Nicht mehr verwendete Elemente löschen
                if (ListBackgroundAnimation[i].y > 800 + texBackgroundAnimation.Height)
                {
                    string[] tempSplit = Regex.Split(";" + delete_string, ";" + i.ToString() + ";");
                    if (tempSplit.Count() == 1)
                    {
                        delete_string += i.ToString() + ";";
                    }
                }
            }



            // Nicht mehr verwendete Hintergrundanimationen löschen
            if (delete_string.Length > 0)
            {
                string[] delete_split = Regex.Split(delete_string, ";");
                for (int i = delete_split.Count() - 2; i >= 0; i--)
                {
                    ListBackgroundAnimation.RemoveAt(Convert.ToInt32(delete_split[i]));
                }
            }
            // **************************************************************************************************************



            // Position des Schiffes ermitteln
            // **************************************************************************************************************
            if (Menu_ShipFrameCount < 50)
            {
                MyShip_X = 240;
                MyShip_Y = 850 - (Menu_ShipFrameCount * 3);
                MyShipPosition = 0;
            }
            else if (Menu_ShipFrameCount < 100)
            {
            }
            else if (Menu_ShipFrameCount < 200)
            {
                MyShip_X = 240 + Menu_ShipFrameCount - 100;
                MyShipPosition = 1;
            }
            else if (Menu_ShipFrameCount < 400)
            {
                MyShip_X = 340 - (Menu_ShipFrameCount - 200);
                MyShipPosition = -1;
            }
            else if (Menu_ShipFrameCount < 500)
            {
                MyShip_X = 140 + Menu_ShipFrameCount - 400;
                MyShipPosition = 1;
            }
            else
            {
                Menu_ShipFrameCount = 100;
            }
            // **************************************************************************************************************



            // Soundeffekte ausgeben
            // **************************************************************************************************************
            // Menü Button Sound
            if (playSndButton == true)
            {
                sndMenu_Main_Button_Sound.Play();
            }
            // Menü Cheat Sound
            if (playSndCheat == true)
            {
                sndMenu_Main_Cheat_Sound.Play();
            }
            // **************************************************************************************************************
        }
        // ------------------------------------------------------------------------------------------------------------------------------------










        // Hauptmenü // Spielverlauf zeichnen
        // ------------------------------------------------------------------------------------------------------------------------------------
        void Draw_Main_Menu()
        {
            // Background // Hintergrundbild bewegen
            // **************************************************************************************************************
            spriteBatch.Draw(texBackground, new Vector2(0, Background_Position), Color.White);
            // **************************************************************************************************************



            // Hintergundanimationen durchlaufen und zeichnen
            // **************************************************************************************************************
            for (int i = 0; i < ListBackgroundAnimation.Count(); i++)
            {
                spriteBatch.Draw(texBackgroundAnimation, new Vector2(ListBackgroundAnimation[i].x, ListBackgroundAnimation[i].y), null, Color.White, 0.0f, new Vector2(texBackgroundAnimation.Width, texBackgroundAnimation.Height), 1.0f, SpriteEffects.None, 1);
            }
            // **************************************************************************************************************



            // MyShip // Eigenes Raumschiff
            // **************************************************************************************************************
            // Wenn eigenes Schiff aktiv
            if (MyShipIsActive == true)
            {
                if (Indestructible == 0 | (Indestructible % 2 == 0))
                {
                    // Raumschiff zeichnen
                    if (MyShipPosition == 0)
                    {
                        spriteBatch.Draw(texMyShip, new Vector2(MyShip_X - (texMyShip.Width / 2), MyShip_Y - (texMyShip.Height / 2)), Color.White);
                    }
                    if (MyShipPosition == 1)
                    {
                        spriteBatch.Draw(texMyShipRight, new Vector2(MyShip_X - (texMyShipRight.Width / 2), MyShip_Y - (texMyShipRight.Height / 2)), Color.White);
                    }
                    if (MyShipPosition == -1)
                    {
                        spriteBatch.Draw(texMyShipLeft, new Vector2(MyShip_X - (texMyShipLeft.Width / 2), MyShip_Y - (texMyShipLeft.Height / 2)), Color.White);
                    }
                }
            }
            // **************************************************************************************************************



            // Menü zeichnen
            // **************************************************************************************************************
            // Splash Screen // Wenn Menü_FrameCount < 0
            if (Menu_FrameCount < 0)
            {
                spriteBatch.Draw(texSplashScreen, new Vector2(0, 0), Color.White);
            }



            // Menü zeichnen // Wenn Menü_FrameCount >= 0
            else
            {

                //Menü Hintergrund // Hauptmenü
                if (Game_Menu_Part == "Main")
                {
                    if ((Menu_FrameCount >= 30 & Menu_FrameCount < 40) | Menu_FrameCount > 43)
                    {
                        spriteBatch.Draw(texMenu_Main_Background, new Vector2(0, 100), Color.White);
                    }
                    if ((Menu_FrameCount >= 10 & Menu_FrameCount < 20) | (Menu_FrameCount > 23 & (Menu_FrameCount < 300 | Menu_FrameCount > 304)))
                    {
                        spriteBatch.Draw(texMenu_Main_Background_Part1, new Vector2(298, 151), Color.White);
                    }
                    if ((Menu_FrameCount >= 0 & Menu_FrameCount < 10) | (Menu_FrameCount > 13 & (Menu_FrameCount < 290 | Menu_FrameCount > 294)))
                    {
                        spriteBatch.Draw(texMenu_Main_Background_Part2, new Vector2(96, 266), Color.White);
                    }
                    if ((Menu_FrameCount >= 20 & Menu_FrameCount < 30) | (Menu_FrameCount > 33 & (Menu_FrameCount < 310 | Menu_FrameCount > 314)))
                    {
                        spriteBatch.Draw(texMenu_Main_Background_Part3, new Vector2(297, 382), Color.White);
                    }
                }

                // Menü Hintergrund // In allen weiteren Menüs 
                else
                {
                    if (Menu_FrameCount > 0)
                    {
                        spriteBatch.Draw(texMenu_Main_Background, new Vector2(0, 100), Color.White);
                    }
                    if (Menu_FrameCount < 300 | Menu_FrameCount > 304)
                    {
                        spriteBatch.Draw(texMenu_Main_Background_Part1, new Vector2(298, 151), Color.White);
                    }
                    if (Menu_FrameCount < 290 | Menu_FrameCount > 294)
                    {
                        spriteBatch.Draw(texMenu_Main_Background_Part2, new Vector2(96, 266), Color.White);
                    }
                    if (Menu_FrameCount < 310 | Menu_FrameCount > 314)
                    {
                        spriteBatch.Draw(texMenu_Main_Background_Part3, new Vector2(297, 382), Color.White);
                    }
                }



                // Menü Überschift
                if ((Menu_FrameCount >= 30 & Menu_FrameCount < 40) | Menu_FrameCount > 43)
                {
                    spriteBatch.Draw(texMenu_Main_Header, new Vector2(1, 60), Color.White);
                }



                // Buttons // Hauptmenü
                if (Game_Menu_Part == "Main")
                {
                    // Button Play
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35) | Menu_FrameCount > 38)
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Play, new Vector2(25, 152), Color.White);
                    }

                    // Button Dificulty mit eingestelltem Schwierigkeitsgrad rechts
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35) | Menu_FrameCount > 38)
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Options, new Vector2(25, 210), Color.White);
                        if (Menu_Selected_Difficulty == "Easy")
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Easy, new Vector2(325, 210), Color.White);
                        }
                        else if (Menu_Selected_Difficulty == "Medium")
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Medium, new Vector2(325, 210), Color.White);
                        }
                        else if (Menu_Selected_Difficulty == "Hard")
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Hard, new Vector2(325, 210), Color.White);
                        }
                    }

                    // Button Level Select mit eingestelltem Level rechts
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35) | Menu_FrameCount > 38)
                    {
                        spriteBatch.Draw(texMenu_Main_Button_LevelSelect, new Vector2(25, 268), Color.White);
                        if (Menu_Selected_Level == 1)
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level1, new Vector2(325, 268), Color.White);
                        }
                        else if (Menu_Selected_Level == 2)
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level2, new Vector2(325, 268), Color.White);
                        }
                        else if (Menu_Selected_Level == 3)
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level3, new Vector2(325, 268), Color.White);
                        }
                        else if (Menu_Selected_Level == 4)
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level4, new Vector2(325, 268), Color.White);
                        }
                        else if (Menu_Selected_Level == 5)
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level5, new Vector2(325, 268), Color.White);
                        }
                        else if (Menu_Selected_Level == 6)
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level6, new Vector2(325, 268), Color.White);
                        }
                        else if (Menu_Selected_Level == 7)
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level7, new Vector2(325, 268), Color.White);
                        }
                    }

                    // Button Highscores
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35) | Menu_FrameCount > 38)
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Highscores, new Vector2(25, 326), Color.White);
                    }

                    // Button About
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35) | Menu_FrameCount > 38)
                    {
                        spriteBatch.Draw(texMenu_Main_Button_About, new Vector2(25, 384), Color.White);
                    }

                    // Button Buy Game
                    if (((Menu_FrameCount >= 25 & Menu_FrameCount < 35) | Menu_FrameCount > 38) & !Fullversion)
                    {
                        spriteBatch.Draw(texMenu_Main_Button_RemoveAd, new Vector2(25, 442), Color.White);
                    }

                    // Button Exit
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35) | Menu_FrameCount > 38)
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Exit, new Vector2(25, 500), Color.White);
                    }

                    // Buttons Hintergrund, wenn gedrückt
                    if (Menu_Button_Background_X != 0 & Menu_Button_Background_Y != 0)
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Background, new Vector2(Menu_Button_Background_X, Menu_Button_Background_Y), Color.White);
                    }
                    if (Menu_Button_Background_Small_X != 0 & Menu_Button_Background_Small_Y != 0)
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Background_Small, new Vector2(Menu_Button_Background_Small_X, Menu_Button_Background_Small_Y), Color.White);
                    }
                }

                // Buttons // Difficulty Menü
                if (Game_Menu_Part == "Difficulty")
                {
                    // Button Difficulty und Buttons zum einstellen rechts
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35) | Menu_FrameCount > 38)
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Options, new Vector2(25, 210), Color.White);
                        spriteBatch.Draw(texMenu_Main_Button_Easy, new Vector2(325, 152), Color.White);
                        spriteBatch.Draw(texMenu_Main_Button_Medium, new Vector2(325, 210), Color.White);
                        spriteBatch.Draw(texMenu_Main_Button_Hard, new Vector2(325, 268), Color.White);
                    }

                    // Button Back
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35 | Menu_FrameCount > 38))
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Back, new Vector2(25, 500), Color.White);
                    }

                    // Button Hintergrund, wenn gedrückt
                    if (Menu_Button_Background_X != 0 & Menu_Button_Background_Y != 0)
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Background, new Vector2(Menu_Button_Background_X, Menu_Button_Background_Y), Color.White);
                    }
                    if (Menu_Button_Background_Small_X != 0 & Menu_Button_Background_Small_Y != 0)
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Background_Small, new Vector2(Menu_Button_Background_Small_X, Menu_Button_Background_Small_Y), Color.White);
                    }
                }

                // Buttons // Level Select Menü
                if (Game_Menu_Part == "LevelSelect")
                {
                    // Button Level Select und Buttons zum einstellen rechts
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35) | Menu_FrameCount > 38)
                    {
                        // Button Level Select // Links
                        spriteBatch.Draw(texMenu_Main_Button_LevelSelect, new Vector2(25, 268), Color.White);
                        // Button Level 1 // Rechts
                        spriteBatch.Draw(texMenu_Main_Button_Level1, new Vector2(325, 152), Color.White);
                        // Button Level 2 // Rechts
                        if (Menu_Selected_Difficulty == "Easy" & (ReachedDifficulty == "Medium" | ReachedDifficulty == "Hard" | (ReachedDifficulty == "Easy" & Convert.ToInt32(ReachedLevel) >= 2)))
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level2, new Vector2(325, 210), Color.White);
                        }
                        else if (Menu_Selected_Difficulty == "Medium" & (ReachedDifficulty == "Hard" | (ReachedDifficulty == "Medium" & Convert.ToInt32(ReachedLevel) >= 2)))
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level2, new Vector2(325, 210), Color.White);
                        }
                        else if (Menu_Selected_Difficulty == "Hard" & Convert.ToInt32(ReachedLevel) >= 2)
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level2, new Vector2(325, 210), Color.White);
                        }
                        else
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level2_No, new Vector2(325, 210), Color.White);
                        }
                        // Button Level 3 // Rechts
                        if (Menu_Selected_Difficulty == "Easy" & (ReachedDifficulty == "Medium" | ReachedDifficulty == "Hard" | (ReachedDifficulty == "Easy" & Convert.ToInt32(ReachedLevel) >= 3)))
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level3, new Vector2(325, 268), Color.White);
                        }
                        else if (Menu_Selected_Difficulty == "Medium" & (ReachedDifficulty == "Hard" | (ReachedDifficulty == "Medium" & Convert.ToInt32(ReachedLevel) >= 3)))
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level3, new Vector2(325, 268), Color.White);
                        }
                        else if (Menu_Selected_Difficulty == "Hard" & Convert.ToInt32(ReachedLevel) >= 3)
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level3, new Vector2(325, 268), Color.White);
                        }
                        else
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level3_No, new Vector2(325, 268), Color.White);
                        }
                        // Button Level 4 // Rechts
                        if (Menu_Selected_Difficulty == "Easy" & (ReachedDifficulty == "Medium" | ReachedDifficulty == "Hard" | (ReachedDifficulty == "Easy" & Convert.ToInt32(ReachedLevel) >= 4)))
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level4, new Vector2(325, 326), Color.White);
                        }
                        else if (Menu_Selected_Difficulty == "Medium" & (ReachedDifficulty == "Hard" | (ReachedDifficulty == "Medium" & Convert.ToInt32(ReachedLevel) >= 4)))
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level4, new Vector2(325, 326), Color.White);
                        }
                        else if (Menu_Selected_Difficulty == "Hard" & Convert.ToInt32(ReachedLevel) >= 4)
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level4, new Vector2(325, 326), Color.White);
                        }
                        else
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level4_No, new Vector2(325, 326), Color.White);
                        }
                        // Button Level 5 // Rechts
                        if (Menu_Selected_Difficulty == "Easy" & (ReachedDifficulty == "Medium" | ReachedDifficulty == "Hard" | (ReachedDifficulty == "Easy" & Convert.ToInt32(ReachedLevel) >= 5)))
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level5, new Vector2(325, 384), Color.White);
                        }
                        else if (Menu_Selected_Difficulty == "Medium" & (ReachedDifficulty == "Hard" | (ReachedDifficulty == "Medium" & Convert.ToInt32(ReachedLevel) >= 5)))
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level5, new Vector2(325, 384), Color.White);
                        }
                        else if (Menu_Selected_Difficulty == "Hard" & Convert.ToInt32(ReachedLevel) >= 5)
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level5, new Vector2(325, 384), Color.White);
                        }
                        else
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level5_No, new Vector2(325, 384), Color.White);
                        }
                        // Button Level 6 // Rechts
                        if (Menu_Selected_Difficulty == "Easy" & (ReachedDifficulty == "Medium" | ReachedDifficulty == "Hard" | (ReachedDifficulty == "Easy" & Convert.ToInt32(ReachedLevel) >= 6)))
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level6, new Vector2(325, 442), Color.White);
                        }
                        else if (Menu_Selected_Difficulty == "Medium" & (ReachedDifficulty == "Hard" | (ReachedDifficulty == "Medium" & Convert.ToInt32(ReachedLevel) >= 6)))
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level6, new Vector2(325, 442), Color.White);
                        }
                        else if (Menu_Selected_Difficulty == "Hard" & Convert.ToInt32(ReachedLevel) >= 6)
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level6, new Vector2(325, 442), Color.White);
                        }
                        else
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level6_No, new Vector2(325, 442), Color.White);
                        }
                        // Button Level 7 // Rechts
                        if (Menu_Selected_Difficulty == "Easy" & (ReachedDifficulty == "Medium" | ReachedDifficulty == "Hard" | (ReachedDifficulty == "Easy" & Convert.ToInt32(ReachedLevel) >= 7)))
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level7, new Vector2(325, 500), Color.White);
                        }
                        else if (Menu_Selected_Difficulty == "Medium" & (ReachedDifficulty == "Hard" | (ReachedDifficulty == "Medium" & Convert.ToInt32(ReachedLevel) >= 7)))
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level7, new Vector2(325, 500), Color.White);
                        }
                        else if (Menu_Selected_Difficulty == "Hard" & Convert.ToInt32(ReachedLevel) >= 7)
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level7, new Vector2(325, 500), Color.White);
                        }
                        else
                        {
                            spriteBatch.Draw(texMenu_Main_Button_Level7_No, new Vector2(325, 500), Color.White);
                        }
                    }

                    // Button Back
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35 | Menu_FrameCount > 38))
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Back, new Vector2(25, 500), Color.White);
                    }

                    // Button Hintergrund, wenn gedrückt
                    if (Menu_Button_Background_X != 0 & Menu_Button_Background_Y != 0)
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Background, new Vector2(Menu_Button_Background_X, Menu_Button_Background_Y), Color.White);
                    }
                    if (Menu_Button_Background_Small_X != 0 & Menu_Button_Background_Small_Y != 0)
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Background_Small, new Vector2(Menu_Button_Background_Small_X, Menu_Button_Background_Small_Y), Color.White);
                    }
                }

                // Buttons und Bauteile // About Menü
                if (Game_Menu_Part == "About")
                {
                    // xtrose Logo
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35) | Menu_FrameCount > 38)
                    {
                        spriteBatch.Draw(texMenu_Main_xtrose_Logo, new Vector2(24, 140), Color.White);
                    }

                    // Icon xtrose
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35) | Menu_FrameCount > 38)
                    {
                        spriteBatch.Draw(texMenu_Main_xtrose, new Vector2(390, 140), Color.White);
                    }

                    // Icon Facebook
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35) | Menu_FrameCount > 38)
                    {
                        spriteBatch.Draw(texMenu_Main_Facebook, new Vector2(390, 224), Color.White);
                    }

                    // Icon VK
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35) | Menu_FrameCount > 38)
                    {
                        spriteBatch.Draw(texMenu_Main_VK, new Vector2(390, 308), Color.White);
                    }

                    // Icon Twitter
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35) | Menu_FrameCount > 38)
                    {
                        spriteBatch.Draw(texMenu_Main_Twitter, new Vector2(390, 392), Color.White);
                    }

                    // Icon YouTube
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35) | Menu_FrameCount > 38)
                    {
                        spriteBatch.Draw(texMenu_Main_YouTube, new Vector2(390, 476), Color.White);
                    }

                    // Button Rate
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35 | Menu_FrameCount > 38))
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Rate, new Vector2(25, 268), Color.White);
                    }

                    // Button Support
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35 | Menu_FrameCount > 38))
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Support, new Vector2(25, 326), Color.White);
                    }

                    // Button Music By
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35 | Menu_FrameCount > 38))
                    {
                        spriteBatch.Draw(texMenu_Main_Button_MusicBy, new Vector2(25, 384), Color.White);
                    }

                    // Button Back
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35 | Menu_FrameCount > 38))
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Back, new Vector2(25, 500), Color.White);
                    }

                    // Button Hintergrund, wenn gedrückt
                    if (Menu_Button_Background_X != 0 & Menu_Button_Background_Y != 0)
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Background, new Vector2(Menu_Button_Background_X, Menu_Button_Background_Y), Color.White);
                    }
                    if (Menu_Button_Background_Small_X != 0 & Menu_Button_Background_Small_Y != 0)
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Background_Small, new Vector2(Menu_Button_Background_Small_X, Menu_Button_Background_Small_Y), Color.White);
                    }
                }

                // Buttons und Bauteile // Highscores
                if (Game_Menu_Part == "Highscores")
                {
                    // Hintergrund der Highscores
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35) | Menu_FrameCount > 38)
                    {
                        spriteBatch.Draw(texMenu_Main_Highscores_Background, new Vector2(25, 152), Color.White);
                    }

                    // Highscores ausgeben
                    int tempHight = 200;
                    Color tempColor = Color.SaddleBrown;
                    for (int i = 0; i < listHighscores.Count(); i++)
                    {

                        Vector2 FontOrigin = fntHighscores.MeasureString(listHighscores[i].ToString());
                        spriteBatch.DrawString(fntHighscores, listHighscores[i].ToString(), new Vector2(420, tempHight), tempColor, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(fntHighscores, (i + 1).ToString(), new Vector2(60, tempHight), tempColor, 0, new Vector2(0, FontOrigin.Y), 1.0f, SpriteEffects.None, 0.5f);
                        tempHight += 30;
                        if (tempColor == Color.SaddleBrown)
                        {
                            tempColor = Color.Sienna;
                        }
                        else
                        {
                            tempColor = Color.SaddleBrown;
                        }
                    }

                    // Button Back
                    if ((Menu_FrameCount >= 25 & Menu_FrameCount < 35 | Menu_FrameCount > 38))
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Back, new Vector2(25, 500), Color.White);
                    }

                    // Button Hintergrund, wenn gedrückt
                    if (Menu_Button_Background_X != 0 & Menu_Button_Background_Y != 0)
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Background, new Vector2(Menu_Button_Background_X, Menu_Button_Background_Y), Color.White);
                    }
                    if (Menu_Button_Background_Small_X != 0 & Menu_Button_Background_Small_Y != 0)
                    {
                        spriteBatch.Draw(texMenu_Main_Button_Background_Small, new Vector2(Menu_Button_Background_Small_X, Menu_Button_Background_Small_Y), Color.White);
                    }
                }
            }
            // **************************************************************************************************************
        }
        // ------------------------------------------------------------------------------------------------------------------------------------










        // Hauptmenü Buttons
        // ------------------------------------------------------------------------------------------------------------------------------------
        // Button Play
        void Menu_Main_Button_Play_Click()
        {
            // Schwierigkeitsgrad und Level übenehmen
            Level = Menu_Selected_Level;
            Difficulty = Menu_Selected_Difficulty;

            // Game Type angeben
            GameType = "Play";

            // Mediaplayer stoppen
            MediaPlayer.Stop();

            // Ladebildschirm ausgeben
            Game_UnloadContent = "Main_Menu";
            Game_LoadContent = "Level";
            Game_Control = "Loading";
        }



        // Menü Anzeige umstellen
        void Menu_Main_Button_SwitchMenu_Click(string part, int frame)
        {
            // Menü umstellen
            Game_Menu_Part = part;
            Menu_FrameCount = frame;
        }



        // Button Web Link
        void Menu_Main_Button_Website_Click(string wbUrl)
        {
            var wb = new WebBrowserTask();
            wb.URL = wbUrl;
            wb.Show();
        }



        // Menü Difficulty Auswahl
        void Menu_Difficulty_Select(string selDifficulty)
        {
            // Bei Easy
            if (selDifficulty == "Easy")
            {
                Menu_Selected_Difficulty = "Easy";
                Menu_Selected_Level = 1;
                Menu_BackToMain();
            }
            // Bei Medium
            if (selDifficulty == "Medium")
            {
                // Prüfen ob möglich
                if (ReachedDifficulty == "Medium" | ReachedDifficulty == "Hard")
                {
                    Menu_Selected_Difficulty = "Medium";
                    Menu_Selected_Level = 1;
                    Menu_BackToMain();
                }
            }
            // Bei Hard
            if (selDifficulty == "Hard")
            {
                // Prüfen ob möglich
                if (ReachedDifficulty == "Hard")
                {
                    Menu_Selected_Difficulty = "Hard";
                    Menu_Selected_Level = 1;
                    Menu_BackToMain();
                }
            }
        }



        // Menü Level Select Auswahl
        void Menu_Level_Select(int selLevel)
        {
            // Bei Easy
            if (Menu_Selected_Difficulty == "Easy")
            {
                // Wenn auswahl < als erreichtes Level
                if ((selLevel <= Convert.ToInt32(ReachedLevel)) | ReachedDifficulty == "Medium" | ReachedDifficulty == "Hard")
                {
                    Menu_Selected_Level = selLevel;
                    Menu_BackToMain();
                }
                else
                {
                    // Geht Nicht Aktion
                }
            }
            // Bei Medium
            if (Menu_Selected_Difficulty == "Medium")
            {
                // Wenn auswahl < als erreichtes Level
                if ((selLevel <= Convert.ToInt32(ReachedLevel) & ReachedDifficulty == "Medium") | ReachedDifficulty == "Hard")
                {
                    Menu_Selected_Level = selLevel;
                    Menu_BackToMain();
                }
                else
                {
                    // Geht Nicht Aktion
                }
            }
            // Bei Hard
            if (Menu_Selected_Difficulty == "Hard")
            {
                // Wenn auswahl < als erreichtes Level
                if (selLevel <= Convert.ToInt32(ReachedLevel) & ReachedDifficulty == "Hard")
                {
                    Menu_Selected_Level = selLevel;
                    Menu_BackToMain();
                }
                else
                {
                    // Geht Nicht Aktion
                }
            }
        }



        // Action // Zurück zum Hauptmenü
        void Menu_BackToMain()
        {
            // Zurück zum Hauptmenü
            if (Game_Menu_Part != "Main")
            {
                Game_Menu_Part = "Main";
                Menu_FrameCount = 0;
            }
        }



        // Button Exit
        void Menu_Main_Button_Exit_Click()
        {
            Exit();
        }
        // ------------------------------------------------------------------------------------------------------------------------------------





    }





}
