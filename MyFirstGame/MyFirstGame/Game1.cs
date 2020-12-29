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





    // Game Klasse, enthält Methoden der Speilschleife
    public partial class Game1 : Microsoft.Xna.Framework.Game
    {





        // Allgemeine Variabeln
        // ------------------------------------------------------------------------------------------------------------------------------------
        // Für die Konfiguration der Darstellung // Portrait, Lanscape usw.
        public static GraphicsDeviceManager graphics;
        // Zum erstellen von 2D Grafiken, Zeichenketten
        public static  SpriteBatch spriteBatch;



        // Lese und Schreibdaten erstellen
        public static IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
        public static IsolatedStorageFileStream filestream;
        public static StreamReader sr;
        public static StreamWriter sw;



        // Lizenzinformationen
        private static LicenseInformation licenseInformation = new LicenseInformation();



        // Werbung
        public static DrawableAd bannerAd;

        // Debug Mode
        public static bool DEBUG = false;

        // Position des Fingers
        public static Vector2 PositionFinger;
        public static Vector2 FirstPositionFinger;
        public static int PositionY = 0;
        public static int LastClickFrames = 0;         // Zählt die Frames seit dem Letzten Klick
        public static bool DoubleClick = false;        // Gibt an ob ein Doppelklick erfolgt ist



        // Versions Variabeln
        public static string Version = "001000000000";
        public static bool Fullversion = false;
        public static int Display_Y = 0;
        public static int Display_Content_Y = 80;
        public static bool Display_Show_Extension = false;

        // Variablen zum Ablauf
        public static string Game_Control = "Main_Menu";       // Main Menu (Hauptmenü),
        public static string Game_LoadContent = "Main_Menu";   // Gibt an welcher Content geladen wird
        public static string Game_UnloadContent = "None";      // Gibt an welcher Content entladen wird
        public static string Game_Control_Next = "None";
        public static string Game_Menu_Part = "Main";           // Gibt an in welchem Menü man sich gerade befindet



        // Variabeln die das Hauptmenü benötigt
        List<int> listHighscores = new List<int>();                 // Liste der Highscores
        public static int Menu_Selected_Level = 1;                  // Gibt an welches Level Im Menü eingestellt ist
        public static string Menu_Selected_Difficulty = "Easy";     // Gibt an welche Schwierigkeit im Menü eingestellt ist
        public static int Menu_Level = 1;                           // Gibt an, von welchen Level der Hintergrund und die Hintergrundanimation geladen wird // Ändert sich, je nach erreichtem Level
        public static int Menu_FrameCount = 0;                      // Frame Count im Hauptmenü, der Menübauteile
        public static int Menu_ShipFrameCount = 0;                  // Frame Count im Hauptmenü, des Raumschiffes
        public static int Menu_Button_Background_X = 0;             // Koordinaten, des Hintergundes, der Buttons im Menü
        public static int Menu_Button_Background_Y = 0;
        public static int Menu_Button_Background_Small_X = 0;       // Koordinaten, des Hintergundes, der Buttons im Menü
        public static int Menu_Button_Background_Small_Y = 0;
        public static int Menu_Cheat = 0;                           // Cheat Kombinationen, die versteckt im Menü eingestellt werden können


        // Schriften // Werden immer geladen
        public static SpriteFont fntDisplay;              // Textausgabe Punkte
        public static SpriteFont fntBossTime;              // Textausgaben Bosszeit
        public static SpriteFont fntHighscores;              // Textausgabe Punkte

        // Hintergrundmusik //Wird immer geladen
        public static Song songBackgroundMusic;

        // Splash Screen
        public static Texture2D texSplashScreen;          // Hauptmenü, Hintergrund

        // Ladebildschirm
        public static Texture2D texLoading;                // Hauptmenü, Hintergrund



        // Variabeln des Spiels
        public static string GameType = "None";
        public static int Level = 1;
        public static string Difficulty = "Easy";             // Schwirigkeitsgrad // Easy, Normal, Hard
        public static int Lives = 3;
        public static int Continues = 3;
        public static int Points = 0;
        public static int FrameCount = 0;                     // Aktuelles Frame



        // Gespeicherte Einstellungen
        public static string ReachedLevel = "7";
        public static string ReachedDifficulty = "Medium";
        public static string PointsOverAll = "0";
        


        // Variabel des eigenen Schiffes
        public static bool MyShipIsActive = true;         // Gibt an ob das eigene Schiff momentan aktiv ist, erscheint und berrechnet wird
        public static bool MyShipControl = false;         // Gibt an ob das Schiff gesteuert werden kann oder von der CPU controlliert wird
        public static int CPUShipControl_X = 240;           // X Koordinaten des Schiffes, wenn CPU Kontrolliert
        public static int CPUShipControl_Y = 600;           // Y Koorsinaten des Schiffes, Wenn CPU kontrolliert
        public static int MyShipPosition = 0;             // Gibt die Position des Schiffes an // -1 Links, 0 Gerade, 1 Rechts
        public static int MyShip_X = 240;
        public static int MyShip_Y = 600;
        public static int MyShip_Hitbox_X = 240;
        public static int MyShip_Hitbox_Y = 600;
        public static int MyShip_Hitbox_Width = 20;
        public static int MyShip_Hitbox_Height = 20;
        public static int MyShipSpeed = 10;               // Geschwindigkeit der eigenen Schiffes, Pixel per Frame
        // ------------------------------------------------------------------------------------------------------------------------------------





        # region Game Klasse
        // Game Klasse erstellen
        // ------------------------------------------------------------------------------------------------------------------------------------
        public Game1()
        {
            // Grafik Content festlegen
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Extend battery life under lock.
            InactiveSleepTime = TimeSpan.FromSeconds(1);

            // Vollbild aktivieren
            graphics.IsFullScreen = true;

            // Portrait Orientation
            graphics.SupportedOrientations = DisplayOrientation.Portrait;
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 480;

            // Position des Displays anhand der Vollversion erstellen
            if (Fullversion == true)
            {
                Display_Y = -80;
                Display_Content_Y = 0;
            }
            else
            {
                Display_Y = 0;
                Display_Content_Y = 80;
            }

            // Erste Position der Finger erstellen
            PositionFinger.X = 240;
            PositionFinger.Y = 600;
        }
        // ------------------------------------------------------------------------------------------------------------------------------------
        # endregion





        # region Constructor
        // Constructor
        // ------------------------------------------------------------------------------------------------------------------------------------
        protected override void Initialize()
        {
            // Temponärer String der Highscores
            string tempHighscores = "";

            // Wenn Dateien in Isostore noch nicht angelegt
            if (!file.DirectoryExists("/Settings"))
            {
                // Verzeichnisse erstellen
                file.CreateDirectory("/Settings");
                // Dateien erstellen
                ReachedLevel = ClassFileManagment.loadCreateOverwrite("/Settings/Level.txt", ReachedLevel, true);
                ReachedDifficulty = ClassFileManagment.loadCreateOverwrite("/Settings/Difficulty.txt", ReachedDifficulty, true);
                PointsOverAll = ClassFileManagment.loadCreateOverwrite("/Settings/PointsOverAll.txt", ReachedDifficulty, true);
                tempHighscores = ClassFileManagment.loadCreateOverwrite("/Settings/Highscores.txt", tempHighscores, true);
                Version = ClassFileManagment.loadCreateOverwrite("/Settings/Version.txt", Version, true);
            }
            // Wenn Dateien bereits existieren, Einstellungen laden
            else
            {
                // Dateien laden
                ReachedLevel = ClassFileManagment.loadCreateOverwrite("/Settings/Level.txt", "", false);
                ReachedDifficulty = ClassFileManagment.loadCreateOverwrite("/Settings/Difficulty.txt", "", false);
                PointsOverAll = ClassFileManagment.loadCreateOverwrite("/Settings/PointsOverAll.txt", "", false);
                tempHighscores = ClassFileManagment.loadCreateOverwrite("/Settings/Highscores.txt", "", false);
                Version = ClassFileManagment.loadCreateOverwrite("/Settings/Version.txt", "", false);
            }

            // Highscores in Liste schreiben
            string[] arHighscores = Regex.Split(tempHighscores, "~");
            for (int i = 0; i < (arHighscores.Count() - 1); i++)
            {
                listHighscores.Add(Convert.ToInt32(arHighscores[i]));
            }

            // Auf Vollversion prüfen
            if (!Fullversion)
            {

                // Prüfen ob bereits gekauft wurde
                if (file.FileExists("/settings/FullVersion.txt"))
                {
                    Fullversion = true;
                }

                // Wenn noch nicht gekauft wurde
                else
                {
                    // Wenn App gerade gekauft wurde
                    if (!licenseInformation.IsTrial() & !Fullversion)
                    {
#if DEBUG

#else
                // Settings neu erstellen
                filestream = file.CreateFile("Settings/FullVersion.txt");
                sw = new StreamWriter(filestream);
                sw.WriteLine("1");
                sw.Flush();
                filestream.Close();

                // FullVersion umstellen
                Fullversion = true;
#endif
                    }


                    // Bei Vollversion // App anpassen
                    if (Fullversion)
                    {

                    }
                }
            }

            // Werbung erstellen
            if (!Fullversion)
            {
                AdGameComponent.Initialize(this, "test_client");
                Components.Add(AdGameComponent.Current);
                CreateAd();
            }

            // Komponenten initialisieren
            base.Initialize();
        }
        // ------------------------------------------------------------------------------------------------------------------------------------
        # endregion





    }





}
