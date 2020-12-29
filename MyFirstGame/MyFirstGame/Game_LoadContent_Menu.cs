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





    // Partial Game Klasse // Methoden Laden des Contents des Menüs
    public partial class Game1 : Microsoft.Xna.Framework.Game
    {




        // Hauptmenü
        // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Hauptmenü // Variabeln erstellen
        // ------------------------------------------------------------------------------------------------------------------------------------
        // Sprites erstellen
        public Texture2D texMenu_Main_Header;                       // Schriftzug Überschrift
        public Texture2D texMenu_Main_Background;                   // Sprites Hintergrund
        public Texture2D texMenu_Main_Background_Part1;             // Sprites Teile des Hintergrunds
        public Texture2D texMenu_Main_Background_Part2;
        public Texture2D texMenu_Main_Background_Part3;
        public Texture2D texMenu_Main_Button_Background;            // Sprites Hintergund der Buttons
        public Texture2D texMenu_Main_Button_Background_Small;      // Sprites Hintergund der kleinen Buttons
        public Texture2D texMenu_Main_Button_Play;                  // Sprites Button Play
        public Texture2D texMenu_Main_Button_LevelSelect;           // Sprites Button Level Select
        public Texture2D texMenu_Main_Button_Options;               // Sprites Button Options
        public Texture2D texMenu_Main_Button_Highscores;            // Sprites Button Highscores
        public Texture2D texMenu_Main_Button_RemoveAd;              // Sprites Button Remove Ad  
        public Texture2D texMenu_Main_Button_Exit;                  // Sprites Button Exit
        public Texture2D texMenu_Main_Button_About;                 // Sprites Button About
        public Texture2D texMenu_Main_Button_Easy;                  // Sprites Button Easy
        public Texture2D texMenu_Main_Button_Medium;                // Sprites Button Medium
        public Texture2D texMenu_Main_Button_Hard;                  // Sprites Button Hard
        public Texture2D texMenu_Main_Button_Level1;                // Sprites Button Level
        public Texture2D texMenu_Main_Button_Level2;                // Sprites Button Level
        public Texture2D texMenu_Main_Button_Level3;                // Sprites Button Level
        public Texture2D texMenu_Main_Button_Level4;                // Sprites Button Level
        public Texture2D texMenu_Main_Button_Level5;                // Sprites Button Level
        public Texture2D texMenu_Main_Button_Level6;                // Sprites Button Level
        public Texture2D texMenu_Main_Button_Level7;                // Sprites Button Level
        public Texture2D texMenu_Main_Button_Level2_No;             // Sprites Button Level
        public Texture2D texMenu_Main_Button_Level3_No;             // Sprites Button Level
        public Texture2D texMenu_Main_Button_Level4_No;             // Sprites Button Level
        public Texture2D texMenu_Main_Button_Level5_No;             // Sprites Button Level
        public Texture2D texMenu_Main_Button_Level6_No;             // Sprites Button Level
        public Texture2D texMenu_Main_Button_Level7_No;             // Sprites Button Level
        public Texture2D texMenu_Main_xtrose_Logo;                  // xtrose Logo für den About Bereich
        public Texture2D texMenu_Main_Button_Back;                  // Button Back für Untermenüs
        public Texture2D texMenu_Main_Button_Rate;                  // Button Rate
        public Texture2D texMenu_Main_Button_Support;               // Button Support
        public Texture2D texMenu_Main_Button_MusicBy;               // Button Music By
        public Texture2D texMenu_Main_xtrose;                       // Button Facebook im About Menü
        public Texture2D texMenu_Main_Facebook;                     // Button Facebook im About Menü
        public Texture2D texMenu_Main_VK;                           // Button VK im About Menü
        public Texture2D texMenu_Main_Twitter;                      // Button Twitter im About Menü
        public Texture2D texMenu_Main_YouTube;                      // Button YouTube im About Menü
        public Texture2D texMenu_Main_Highscores_Background;        // Hintergrund Highscores

        // Soundeffekte erstellen
        public SoundEffect sndMenu_Main_Button_Sound;               // Sundeffect bei Button Klick
        public SoundEffect sndMenu_Main_Cheat_Sound;                // Soundeffect bei erfolgreicher Eingabe eines Cheats
        // ------------------------------------------------------------------------------------------------------------------------------------










        // Hauptmenü // Content laden
        // ------------------------------------------------------------------------------------------------------------------------------------
        void LoadContent_Main_Menu()
        {
            // Variabeln zurücksetzen
            // **************************************************************************************************************
            Background_Frames = 0;
            Menu_FrameCount = -45;
            Menu_ShipFrameCount = -45;
            FrameCount = 0;
            // **************************************************************************************************************


            // Level Daten laden für Hintergrundanimation
            // **************************************************************************************************************
            // Errechnen welche Hintergundanimation geladen wird
            int level_Temp = 0;
            if (ReachedDifficulty == "Medium" | ReachedDifficulty == "Hard")
            {
                level_Temp = 7;
            }
            else
            {
                level_Temp = Convert.ToInt32(ReachedLevel);
            }
            Random rand = new Random();
            level_Temp = rand.Next(0, level_Temp) + 1;

            // Daten der Hintergrundanimation laden
            string temp;
            using (var stream = TitleContainer.OpenStream("Game_Data/Level" + level_Temp + "_Easy_Data.txt"))
            {
                using (var reader = new StreamReader(stream))
                {
                    temp = reader.ReadToEnd();
                }
            }
            string[] temp_split = Regex.Split(temp, "//");
            temp_split = Regex.Split(temp_split[0].Trim(), ";");
            for (int i = 0; i < temp_split.Count(); i++)
            {
                string[] split_data = Regex.Split(temp_split[i], "=");
                split_data[0] = split_data[0].Trim();
                if (split_data[0] == "Background_Frames")
                {
                    Background_Frames = Convert.ToInt32(split_data[1]);
                }
                if (split_data[0] == "BackgroundAnimationOccurrence")
                {
                    BackgroundAnimationOccurrence = Convert.ToInt32(split_data[1]);
                }
                if (split_data[0] == "BackgroundAnimationSpeed")
                {
                    string[] split_data2 = Regex.Split(split_data[1].Trim(), "-");
                    BackgroundAnimationSpeedMin = Convert.ToInt32(split_data2[0]);
                    BackgroundAnimationSpeedMax = Convert.ToInt32(split_data2[1]);
                }
                if (split_data[0] == "BackgroundAnimationOpacity")
                {
                    string[] split_data2 = Regex.Split(split_data[1].Trim(), "-");
                    BackgroundAnimationOpacityMin = Convert.ToInt32(split_data2[0]);
                    BackgroundAnimationOpacityMax = Convert.ToInt32(split_data2[1]);
                }
            }
            // **************************************************************************************************************



            // Content laden
            // **************************************************************************************************************
            // Schrift der Highscores
            fntHighscores = Content.Load<SpriteFont>("FontHighscores");

            // Texturen // Splash Screen
            texSplashScreen = Content.Load<Texture2D>("SplashScreenImage");

            // Texturen // Ladebildschirm
            texLoading = Content.Load<Texture2D>("Loading");

            // Texturen // Background // Hintergrund der Menü Animation
            texBackground = Content.Load<Texture2D>("Level" + level_Temp.ToString() + "_Background");

            // Texturen // Background Animation
            texBackgroundAnimation = Content.Load<Texture2D>("Level" + level_Temp.ToString() + "_BackgroundAnimation");

            // Texturen // MyShip // Eigenes Raumschiff wird in der Menü Animation angezeigt
            texMyShip = Content.Load<Texture2D>("MyShip");
            texMyShipLeft = Content.Load<Texture2D>("MyShipLeft");
            texMyShipRight = Content.Load<Texture2D>("MyShipRight");

            // Texturen der Menüs
            texMenu_Main_Header = Content.Load<Texture2D>("Menu_Main_Header");
            texMenu_Main_Background = Content.Load<Texture2D>("Menu_Main_Background");
            texMenu_Main_Background_Part1 = Content.Load<Texture2D>("Menu_Main_Background_Part1");
            texMenu_Main_Background_Part2 = Content.Load<Texture2D>("Menu_Main_Background_Part2");
            texMenu_Main_Background_Part3 = Content.Load<Texture2D>("Menu_Main_Background_Part3");

            texMenu_Main_Button_Background = Content.Load<Texture2D>("Menu_Main_Button_Background");
            texMenu_Main_Button_Background_Small = Content.Load<Texture2D>("Menu_Main_Button_Background_Small");
            texMenu_Main_Button_Play = Content.Load<Texture2D>("Menu_Main_Button_Play");
            texMenu_Main_Button_LevelSelect = Content.Load<Texture2D>("Menu_Main_Button_LevelSelect");
            texMenu_Main_Button_Options = Content.Load<Texture2D>("Menu_Main_Button_Options");
            texMenu_Main_Button_Highscores = Content.Load<Texture2D>("Menu_Main_Button_Highscores");
            texMenu_Main_Button_RemoveAd = Content.Load<Texture2D>("Menu_Main_Button_RemoveAd");
            texMenu_Main_Button_Exit = Content.Load<Texture2D>("Menu_Main_Button_Exit");
            texMenu_Main_Button_About = Content.Load<Texture2D>("Menu_Main_Button_About");
            texMenu_Main_Button_Back = Content.Load<Texture2D>("Menu_Main_Button_Back");
            texMenu_Main_Button_Rate = Content.Load<Texture2D>("Menu_Main_Button_Rate");
            texMenu_Main_Button_Support = Content.Load<Texture2D>("Menu_Main_Button_Support");
            texMenu_Main_Button_MusicBy = Content.Load<Texture2D>("Menu_Main_Button_MusicBy");

            texMenu_Main_Button_Easy = Content.Load<Texture2D>("Menu_Main_Button_Easy");
            if (ReachedDifficulty == "Medium" | ReachedDifficulty == "Hard")
            {
                texMenu_Main_Button_Medium = Content.Load<Texture2D>("Menu_Main_Button_Medium");
            }
            else
            {
                texMenu_Main_Button_Medium = Content.Load<Texture2D>("Menu_Main_Button_Medium_No");
            }
            if (ReachedDifficulty == "Hard")
            {
                texMenu_Main_Button_Hard = Content.Load<Texture2D>("Menu_Main_Button_Hard");
            }
            else
            {
                texMenu_Main_Button_Hard = Content.Load<Texture2D>("Menu_Main_Button_Hard_No");
            }

            texMenu_Main_Button_Level1 = Content.Load<Texture2D>("Menu_Main_Button_Level_1");
            texMenu_Main_Button_Level2 = Content.Load<Texture2D>("Menu_Main_Button_Level_2");
            texMenu_Main_Button_Level3 = Content.Load<Texture2D>("Menu_Main_Button_Level_3");
            texMenu_Main_Button_Level4 = Content.Load<Texture2D>("Menu_Main_Button_Level_4");
            texMenu_Main_Button_Level5 = Content.Load<Texture2D>("Menu_Main_Button_Level_5");
            texMenu_Main_Button_Level6 = Content.Load<Texture2D>("Menu_Main_Button_Level_6");
            texMenu_Main_Button_Level7 = Content.Load<Texture2D>("Menu_Main_Button_Level_7");
            texMenu_Main_Button_Level2_No = Content.Load<Texture2D>("Menu_Main_Button_Level_2_No");
            texMenu_Main_Button_Level3_No = Content.Load<Texture2D>("Menu_Main_Button_Level_3_No");
            texMenu_Main_Button_Level4_No = Content.Load<Texture2D>("Menu_Main_Button_Level_4_No");
            texMenu_Main_Button_Level5_No = Content.Load<Texture2D>("Menu_Main_Button_Level_5_No");
            texMenu_Main_Button_Level6_No = Content.Load<Texture2D>("Menu_Main_Button_Level_6_No");
            texMenu_Main_Button_Level7_No = Content.Load<Texture2D>("Menu_Main_Button_Level_7_No");

            texMenu_Main_xtrose_Logo = Content.Load<Texture2D>("xtrose_Logo");
            texMenu_Main_xtrose = Content.Load<Texture2D>("Icon_xtrose");
            texMenu_Main_Facebook = Content.Load<Texture2D>("Icon_Facebook");
            texMenu_Main_VK = Content.Load<Texture2D>("Icon_VK");
            texMenu_Main_Twitter = Content.Load<Texture2D>("Icon_Twitter");
            texMenu_Main_YouTube = Content.Load<Texture2D>("Icon_YouTube");

            texMenu_Main_Highscores_Background = Content.Load<Texture2D>("Menu_Main_Highscores_Background");

            sndMenu_Main_Button_Sound = Content.Load<SoundEffect>("Menu_Main_Button_Sound");

            sndMenu_Main_Cheat_Sound = Content.Load<SoundEffect>("ExplosionBigSound");

            // Hintergrundmusik
            songBackgroundMusic = Content.Load<Song>("Menu_Main_Music");
            // **************************************************************************************************************
        }
        // ------------------------------------------------------------------------------------------------------------------------------------





    }





}
