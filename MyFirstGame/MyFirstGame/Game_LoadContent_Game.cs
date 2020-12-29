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





    // Partial Game Klasse // Methoden zum Laden des Contents des Spieles
    public partial class Game1 : Microsoft.Xna.Framework.Game
    {




        // Level // Variabeln // Variabeln die nur für den Ablauf des Levels benötigt werden
        // ------------------------------------------------------------------------------------------------------------------------------------
        // Sprites // Allgemein
        public Texture2D texBackground;            // Hintergrund
        public Texture2D texBackgroundAnimation;   // Hintergrund Animation
        public Texture2D HitboxTexture;            // Textur der Hitbox
        public Rectangle HitboxRectangle;          // Quadrat der Hitbox
        public Texture2D texDisplay;               // Anzeige
        public Texture2D texDisplay_Weapon;        // Textur der Aktuellen Waffe
        public Texture2D texDisplay_Fire;          // Anzeige, Waffe Fire
        public Texture2D texDisplay_Laser;         // Anzeige, Waffe Laser
        public Texture2D texDisplay_Phaser;        // Anzeige, Waffe Phaser
        public Texture2D texDisplay_Level1;        // Anzeige, der Stärke des Schusses
        public Texture2D texDisplay_Level2;
        public Texture2D texDisplay_Level3;
        public Texture2D texDisplay_LevelShot;
        public Texture2D texDisplay_LevelExtension;
        public Texture2D texDisplay_Extension;     // Anzeige der aktuellen Erweiterung
        public Texture2D texDisplay_Rocket;        // Anzeige der Erweiterung Rocket
        public Texture2D texDisplay_PowerShotBar;  // Anzeige der Powerschuss Aufladeung


        // Sprites // Eigenes Schiff
        public Texture2D texMyShip;        // Sprite des eigenen Raumschifes
        public Texture2D texMyShipLeft;    // Sprite des eigenen Raumschifes
        public Texture2D texMyShipRight;   // Sprite des eigenen Raumschifes

        // Srites // Eigene Schüsse
        public Texture2D texMyShotFire;    // Spite des eigenen Schusses // Feuer
        public Texture2D texMyShotPhaser;  // Spite des eigenen Schusses // Feuer
        public Texture2D texMyShotRocket;  // Sprite der erweiterten Schusses // Rocket
        public Texture2D texMyShotLaser1;  // Sprite des eigenen Schusses // Laser Level 1
        public Texture2D texMyShotLaser2;  // Sprite des eigenen Schusses // Laser Level 2
        public Texture2D texMyShotLaser3;  // Sprite des eigenen Schusses // Laser Level 3

        // Srites // Powerschuss
        public Texture2D texMyShotPowerShot;     // Aktuelle Powerschuss Animation
        public Texture2D texMyShotPowerShot1;    // Spite des Powerschusses
        public Texture2D texMyShotPowerShot2;    // Sprite des Powerschusses
        public Texture2D texMyShotPowerShot3;    // Sprite des Powerschusses
        public Texture2D texMyShotPowerShot4;    // Sprite des Powerschusses
        public Texture2D texMyShotPowerShot5;    // Sprite des Powerschusses
        public Texture2D texMyShotPowerShotFinal;// Sprite des Powerschusses

        // Sprites // Rauch // Wird als Spur bei manchen Schüssen verwendet
        public Texture2D texSmoke1;
        public Texture2D texSmoke2;
        public Texture2D texSmoke3;
        public Texture2D texSmoke4;
        public Texture2D texSmoke5;

        // Sprites // Gegner
        public Texture2D texEnemyJust;   // Sprite Just // Normale Position von oben
        public Texture2D texEnemyLeft;   // Sprite Left // Gegner steuert nach links
        public Texture2D texEnemyRight;  // Sprite Right // Gegner steuert nach rechts

        // Sprites // Endboss 
        public Texture2D texWarning1; // Anzeige Warning
        public Texture2D texWarning2; // Anzeige Warning
        public Texture2D texWarning3; // Anzeige Warning
        public Texture2D texWarning;
        public Texture2D texBoss;  // Aktuelle Boss Textur // Wird verwendet um alle Texturen in eine Liste zu laden

        // Sprites // Explosion Mini
        public Texture2D texExplosionMini0;
        public Texture2D texExplosionMini1;
        public Texture2D texExplosionMini2;
        public Texture2D texExplosionMini3;
        public Texture2D texExplosionMini4;

        // Sprites // Explosion klein
        public Texture2D texExplosionSmall0;
        public Texture2D texExplosionSmall1;
        public Texture2D texExplosionSmall2;
        public Texture2D texExplosionSmall3;
        public Texture2D texExplosionSmall4;

        // Sprites // Explosion Medium
        public Texture2D texExplosionMedium0;
        public Texture2D texExplosionMedium1;
        public Texture2D texExplosionMedium2;
        public Texture2D texExplosionMedium3;
        public Texture2D texExplosionMedium4;

        // Sprites // Explosion groß
        public Texture2D texExplosionBig0;
        public Texture2D texExplosionBig1;
        public Texture2D texExplosionBig2;
        public Texture2D texExplosionBig3;
        public Texture2D texExplosionBig4;
        public Texture2D texExplosionBig5;
        public Texture2D texExplosionBig6;
        public Texture2D texExplosionBig7;

        // Sprites // Gegnerische Schüsse
        public Texture2D texEnemyShot1;
        public Texture2D texEnemyShot1_2;
        public Texture2D texEnemyShot2_1;
        public Texture2D texEnemyShot2_2;
        public Texture2D texEnemyShot2_3;

        // Sprites // PowerUps
        public Texture2D texPowerUpFire_1;
        public Texture2D texPowerUpFire_2;
        public Texture2D texPowerUpFire_3;
        public Texture2D texPowerUpFire_4;
        public Texture2D texPowerUpFire_5;
        public Texture2D texPowerUpFire_6;
        public Texture2D texPowerUpFire_7;
        public Texture2D texPowerUpPhaser_1;
        public Texture2D texPowerUpPhaser_2;
        public Texture2D texPowerUpPhaser_3;
        public Texture2D texPowerUpPhaser_4;
        public Texture2D texPowerUpPhaser_5;
        public Texture2D texPowerUpPhaser_6;
        public Texture2D texPowerUpPhaser_7;
        public Texture2D texPowerUpLaser_1;
        public Texture2D texPowerUpLaser_2;
        public Texture2D texPowerUpLaser_3;
        public Texture2D texPowerUpLaser_4;
        public Texture2D texPowerUpLaser_5;
        public Texture2D texPowerUpLaser_6;
        public Texture2D texPowerUpLaser_7;
        public Texture2D texPowerUpOneUp_1;
        public Texture2D texPowerUpOneUp_2;
        public Texture2D texPowerUpOneUp_3;
        public Texture2D texPowerUpOneUp_4;
        public Texture2D texPowerUpOneUp_5;
        public Texture2D texPowerUpOneUp_6;
        public Texture2D texPowerUpOneUp_7;
        public Texture2D texPowerUpRocket_1;
        public Texture2D texPowerUpRocket_2;
        public Texture2D texPowerUpRocket_3;
        public Texture2D texPowerUpRocket_4;
        public Texture2D texPowerUpRocket_5;
        public Texture2D texPowerUpRocket_6;
        public Texture2D texPowerUpRocket_7;

        // Soundeffekte Waffen // Wird nur zu den Levels geladen
        public SoundEffect sndMyShotFire;       // Sound MyShotFire
        public SoundEffect sndMyShotPhaser;     // Sound MyShotPhaser
        public SoundEffect sndMyShotLaser;      // Sound MyShotLaser
        public SoundEffect sndMyShotRocket;     // Sound MyShotRocket
        public SoundEffect sndMyShotPowerShot;  // Sound Powerschuss
        public SoundEffect sndImpact;           // Sound ImpactLight // Einschlag
        public SoundEffect sndExplosionSmall;   // Sound ExplosionSmall // Explosion klein
        public SoundEffect sndExplosionBig;     // Sound ExplosionBig // Explosion gross
        public SoundEffect sndPowerUp;          // Wenn Schüsse erweitert werden
        public SoundEffect sndFire;             // Wenn auf Schuss Fire gewechselt wird
        public SoundEffect sndPhaser;           // Wenn auf Schuss Phaser gewechselt wird
        public SoundEffect sndOneUp;            // Wenn ein Leben erreicht wird oder aufgesammelt wird
        public SoundEffect sndRocket;           // Erweiterung Raketen
        public SoundEffect sndLaser;            // Wenn auf Schuss Laser gewechselt wird
        public SoundEffect sndPowerShotReady;   // Wenn auf Schuss Laser gewechselt wird

        public SoundEffect sndEnemyShot1Sound;  // Gegner, Schuss 1 Sound
        public SoundEffect sndEnemyShot2Sound;  // Gegner, Schuss 2 Sound
        public SoundEffect sndEnemyShot3Sound;  // Gegner, Schuss 3 Sound
        public SoundEffect sndAlert;            // Endboss Alarm

        public SoundEffect sndBoss;             // Endboss Soundeffekt der ausgegeben wird

        // Listen für den Spielablauf
        List<ClassMyShots> ListMyShots = new List<ClassMyShots>();                                          // Liste eigener Schüsse
        List<ClassMyShotRocket> ListMyShotRocket = new List<ClassMyShotRocket>();                           // Liste eigener Schüsse Raketen
        List<ClassEnemys> ListEnemys = new List<ClassEnemys>();                                             // Liste der Feinde
        List<ClassEnemyWays> ListEnemysWays = new List<ClassEnemyWays>();                                   // Liste der Wege, der Feinde
        List<ClassHistory> ListHistory = new List<ClassHistory>();                                          // Liste des Spielverlaufs
        List<ClassShipEnemys> ListShipEnemys = new List<ClassShipEnemys>();                                 // Liste der Gegner auf dem Spielfeld
        List<ClassEnemyTextures> ListEnemyTextures = new List<ClassEnemyTextures>();                        // Liste der Gegner Texturen
        List<ClassExplosions> ListExplosions = new List<ClassExplosions>();                                 // Liste aller explosionen
        List<ClassEnemyShotDirect> ListEnemyShotDirect = new List<ClassEnemyShotDirect>();                  // Liste aller Gegnerischen Schüsse, Directe Schüsse
        List<ClassEnemyGroups> ListEnemyGroups = new List<ClassEnemyGroups>();                              // Liste Gegnerischen Gruppen
        List<ClassPowerUps> ListPowerUps = new List<ClassPowerUps>();                                       // Liste aller PowerUps
        List<ClassBackgroundAnimation> ListBackgroundAnimation = new List<ClassBackgroundAnimation>();      // Liste der Hintergrundanimationen
        List<ClassBossTextures> ListBossTextures = new List<ClassBossTextures>();                           // Liste der Boss Texturen
        List<ClassBossSounds> ListBossSounds = new List<ClassBossSounds>();                                 // Liste der Boss Soundeffecte
        List<ClassEnemyShotLaser> ListEnemyShotLaser = new List<ClassEnemyShotLaser>();                     // Liste der gegnerischen Schüsse, Laser

        // Variabeln // Steuerung dees Spiels
        string MyShotType = "Fire";         // Fire, Phaser
        int MyShotFrame = 0;                // Frames bis zum nächsten Schuss
        string MyExtensionType = "None";    // Erweiterter Schuss
        int MyExtensionFrame = 0;           // Frames bis zum nächsten erweiterten Schuss
        public int Background_Frames = 30000;          // Gesamte Frames in dem sich das Hintergrundbild bewegt
        public int Background_Position = 0;            // Aktuelle Positon des hintergrundbildes
        public int BackgroundAnimationSpeedMin = 10;   // Minimal Geschwindigkeit der Hintergrundanimationen
        public int BackgroundAnimationSpeedMax = 20;   // Maximale Geschwindigkeit der Hintergrundanimation
        public int BackgroundAnimationOpacityMin = 5;  // Minimale Transparenz der Hintergrundanimation
        public int BackgroundAnimationOpacityMax = 10; // Maximale Transparenz der Hintergrundanimation
        public int BackgroundAnimationOccurrence = 15; // Zeit bis neue Hintergrundanimation erzeugt wird
        public int BackgroundAnimationFrameCount = 0;  // Frames bis die nächste Hintergrundanimation erzeugt wird
        public int FramesToAppear = 0;                 // Wenn eigenes Schiff zerstört wurde, Zeit bis es weiter geht
        public int Indestructible = 0;                 // Zeit in der das Schiff unzerstörbar ist

        // Variabeln // Schuss Feuer
        int MyShotFireSpeed = 6;
        int MyShotFireLevel = 0;
        int MyShotFireDamage = 40;

        // Variabeln // Schuss Phaser
        int MyShotPhaserSpeed = 10;
        int MyShotPhaserLevel = 0;
        int MyShotPhaserDamage = 90;

        // Variabeln // Schuss Laser
        int MyShotLaserSpeed = 11;
        int MyShotLaserLevel = 0;
        int MyShotLaserDamage = 25;
        string MyShotLaserSide = "Left";

        // Variabeln // Erweiterung Raketen
        int MyShotRocketSpeed = 70;
        int MyShotRocketLevel = 0;
        int MyShotRocketDamage = 120;

        // Variabeln // Schiff Hitboxen
        int MyShip_PowerShot_Hitbox_X = 240;        // Aussere Powershot Hitbox + 1;
        int MyShip_PowerShot_Hitbox_Y = 600;        // Aussere Powershot Hitbox + 1;
        int MyShip_PowerShot_Hitbox_Width = 100;    // Aussere Powershot Hitbox + 1;
        int MyShip_PowerShot_Hitbox_Height = 100;   // Aussere Powershot Hitbox + 1;
        int MyShip_PowerShot_Hitbox_X_2 = 240;      // Innere Powershot Hitbox + 2;
        int MyShip_PowerShot_Hitbox_Y_2 = 600;      // Innere Powershot Hitbox + 2;
        int MyShip_PowerShot_Hitbox_Width_2 = 65;   // Innere Powershot Hitbox + 2;
        int MyShip_PowerShot_Hitbox_Height_2 = 65;  // Innere Powershot Hitbox + 2;

        // Variabeln // Powerschuss
        int MyShip_PowerShots = 0;              // Anzahl der vorhandenen PowerShots
        int MyShip_PowerShot_Loading = 0;       // Aufladung des Powerschusses
        int MyShip_PowerShot_Load = 0;          // Aktuelle zuladung des Powerschusses // Wid zum errechnen der Punkte verwendet
        int MyShip_PowerShot_Max_Loading = 400; // Maximale Aufladung des Powerschusses
        int MyShip_PowerShot_Width = 0;         // Größe des Powersschuss Balkens
        bool PowerShotAnimation = false;        // Gibt an ob die Animation läuft
        int PowerShotAnimationFrame = 0;        // Aktuelles Frame der Powerschuss-Animation
        int PowerShotHitboxHeight = 800;        // Hitbox des Powerschusses // Höhe
        int PowerShotHitboxWidth = 120;         // Hitbox des Powerschusses // Breite
        int PowerShotHitboxX = 0;               // Hitbox des Powerschusses // X
        int PowerShotHitboxY = 0;               // Hitbox des Powerschusses // Y
        int PowerShotDamage = 50;               // Powerschuss Schaden per Frame
        int PowerShotTime = 120;                // Powerschuss Zeit in Frames

        // Allgemeine Variabeln und Bauteile
        bool PlayBackgroundMusic = true;        // Gibt an ob die Hintergrundmusik im Loop weiterläuft
        bool ShotIsActive = true;               // Gibt an ob Aktuell ein neuer Schuss erstellt wird

        // Endboss Variabeln
        bool BossSzenario = false;              // Gibt an ob BossScenazio aktiv ist
        bool DrawBoss = true;                   // Gibt an ob der Boss gezeichnet wird
        public Song songBossMusic;              // EndbossMusik
        public int BossFrameCount = 0;          // Aktuelles Frame der Endboss-Animation
        public int BossFrame = 0;               // Frame ab dem das Boss Szenario geladen wird
        public int BossEnergie = 0;
        public int BossTextures = 0;            // Anzahl der Texturen des Bosses
        public int BossSounds = 0;              // Anzahl der Sounds des Bosses
        public bool ShowWarning = false;        // Gibt an ob Warning Animation ausgegeben wird
        int BossIncoming;                       // x Achse in der der Boss herein kommt
        int BossTime = 0;                       // Ablaufende Zeit beim Endboss
        int BossTimeRest = 0;                   // Restliche Endbosszeit
        string BossTimeString = "";             // Ausgabe String der Bosszeit
        string[] BossShotPoints;                // Schusspunkte des Endbosses
        string[] BossWeaponPoints;              // Punkte an der sich die Waffen des Bosses befinden
        string[] BossWayPoints;                 // Wegpunkte des Endboss Loops
        string[] BossSoundPoints;               // Soundausgabepunkte des Endbosses
        int Boss_X;                             // Aktueller X Punkt des Bosses
        int Boss_Y;                             // Aktueller Y Punkt des Bosses
        int Boss_Hitbox_Width;                  // Boss Hitbox Breite
        int Boss_Hitbox_Height;                 // Boss Hitbox Höhe
        // ------------------------------------------------------------------------------------------------------------------------------------











        // Level // Content laden
        // ------------------------------------------------------------------------------------------------------------------------------------
        void LoadContent_Level()
        {
            // Daten zurücksetzen
            // **************************************************************************************************************
            // Alle Listen zurücksetzen
            ListBackgroundAnimation.Clear();
            ListBossSounds.Clear();
            ListBossTextures.Clear();
            ListEnemyGroups.Clear();
            ListEnemys.Clear();
            ListEnemyShotDirect.Clear();
            ListEnemysWays.Clear();
            ListEnemyTextures.Clear();
            ListExplosions.Clear();
            ListHistory.Clear();
            ListMyShotRocket.Clear();
            ListMyShots.Clear();
            ListPowerUps.Clear();
            ListShipEnemys.Clear();
            ListEnemyShotLaser.Clear();

            // Variabeln zurücksetzen
            FrameCount = 0;
            MyShotFrame = 0;
            MyExtensionFrame = 0;
            Background_Frames = 30000;
            Background_Position = 0;
            BackgroundAnimationSpeedMin = 10;
            BackgroundAnimationSpeedMax = 20;
            BackgroundAnimationOpacityMin = 5;
            BackgroundAnimationOpacityMax = 10;
            BackgroundAnimationOccurrence = 15;
            BackgroundAnimationFrameCount = 0;
            FramesToAppear = 0;
            Indestructible = 0;

            BossFrameCount = 0;
            BossFrame = 0;
            BossEnergie = 0;
            BossTextures = 0;
            BossSounds = 0;
            BossTime = 0;
            BossTimeRest = 0;
            BossTimeString = "";

            PlayBackgroundMusic = true;
            MyShipControl = false;
            BossSzenario = false;
            DrawBoss = true;
            Boss_Y = -100;
            Boss_X = 0;
            // **************************************************************************************************************



            // Level Daten laden
            // **************************************************************************************************************
            string temp;
            using (var stream = TitleContainer.OpenStream("Game_Data/Level" + Level + "_" + Difficulty + "_Data.txt"))
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
                if (split_data[0] == "BossFrame")
                {
                    BossFrame = Convert.ToInt32(split_data[1].Trim());
                }
            }



            // Wege der Feinde laden und in Liste speichern
            using (var stream = TitleContainer.OpenStream("Game_Data/Level" + Level + "_" + Difficulty + "_Ways.txt"))
            {
                using (var reader = new StreamReader(stream))
                {
                    temp = reader.ReadToEnd();
                }
            }
            temp_split = Regex.Split(temp, "//");
            temp_split = Regex.Split(temp_split[0].Trim(), ";;;");
            for (int x = 0; x < temp_split.Count() - 1; x++)
            {
                ListEnemysWays.Add(new ClassEnemyWays(temp_split[x].Trim()));
            }



            // Feinde laden und in Liste speichern
            using (var stream = TitleContainer.OpenStream("Game_Data/Level" + Level + "_" + Difficulty + "_Enemys.txt"))
            {
                using (var reader = new StreamReader(stream))
                {
                    temp = reader.ReadToEnd();
                }
            }
            // Beschreibung wegschneiden
            temp_split = Regex.Split(temp, "//");
            // Gegnertypen trennen
            temp_split = Regex.Split(temp_split[0].Trim(), ";;;");
            // Gegnertypen durchlaufen
            for (int x = 0; x < temp_split.Count() - 1; x++)
            {
                // Gegner Eigenschaften trennen
                string[] temp_split_2 = Regex.Split(temp_split[x].Trim(), ";");
                // Rotation erstellen
                temp_split_2[7] = temp_split_2[7].Trim();
                if (temp_split_2[7].Length > 1)
                {
                    float flTemp = (float)Convert.ToDouble(temp_split_2[7].Trim());
                    if (flTemp > 1.0f | flTemp < -1.0f)
                    {
                        temp_split_2[7] = Regex.Replace(temp_split_2[7], ",", ".");
                    }
                }
                float flRotate = (float)Convert.ToDouble(temp_split_2[7].Trim());
                // Eigenschaften in klasse schreiben
                ListEnemys.Add(new ClassEnemys(temp_split_2[0].Trim(), temp_split_2[1].Trim(), Convert.ToInt32(temp_split_2[2].Trim()), Convert.ToInt32(temp_split_2[3].Trim()), Convert.ToInt32(temp_split_2[4].Trim()), Convert.ToInt32(temp_split_2[5].Trim()), temp_split_2[6].Trim(), flRotate));
            }



            // History, Spielverlauf laden und in Liste speichern
            using (var stream = TitleContainer.OpenStream("Game_Data/Level" + Level + "_" + Difficulty + "_History.txt"))
            {
                using (var reader = new StreamReader(stream))
                {
                    temp = reader.ReadToEnd();
                }
            }
            // Infotexte herausschneiden anhand des Trennzeichens "//"
            temp_split = Regex.Split(temp, "//");
            temp = temp_split[0].Trim();
            // History Daten aufteilen
            temp_split = Regex.Split(temp, ";;;");
            // History Daten durchlaufen und in Klasse schreiben
            for (int x = 0; x < temp_split.Count() - 1; x++)
            {
                // In ListHistory schreiben
                string[] temp_split_2 = Regex.Split(temp_split[x].Trim(), ",");
                ListHistory.Add(new ClassHistory(Convert.ToInt32(temp_split_2[0].Trim()), Convert.ToInt32(temp_split_2[1].Trim()), Convert.ToInt32(temp_split_2[2].Trim()), Convert.ToInt32(temp_split_2[3].Trim()), Convert.ToInt32(temp_split_2[4].Trim()), Convert.ToInt32(temp_split_2[5].Trim()), Convert.ToBoolean(temp_split_2[6].Trim()), temp_split_2[7].Trim(), temp_split_2[8].Trim()));

                // Gruppendaten zerlegen
                string[] split_groups = Regex.Split(temp_split_2[8].Trim(), ";");
                // Einzelne Gruppen des Gegners durchlaufen
                for (int i2 = 0; i2 < split_groups.Count(); i2++)
                {
                    // Wenn Gruppendaten vorhanden
                    if (split_groups[i2].Trim().Length > 0)
                    {
                        // Gruppendaten ermitteln
                        string[] group_datas = Regex.Split(split_groups[i2], ":");
                        // Wenn mehr als nur Gruppe und Anzahl Gegner vorhanden
                        if (group_datas.Count() > 1)
                        {
                            // Prüfen ob Gruppe vorhanden und erstellen
                            bool group_exists = false;
                            for (int i3 = 0; i3 < ListEnemyGroups.Count(); i3++)
                            {
                                if (ListEnemyGroups[i3].ID == Convert.ToInt32(group_datas[0]))
                                {
                                    group_exists = true;
                                    break;
                                }
                            }
                            // Wenn Gruppe nicht existiert
                            if (group_exists == false)
                            {
                                string powerUp = "Random";
                                // PowerUp Prüfen
                                if (group_datas.Count() > 2)
                                {
                                    if (group_datas[2].Trim().Length != 0)
                                    {
                                        powerUp = group_datas[2];
                                    }
                                }
                                // Gruppe erstellen
                                ListEnemyGroups.Add(new ClassEnemyGroups(Convert.ToInt32(group_datas[0]), Convert.ToInt32(group_datas[1]), powerUp));
                            }
                        }
                    }
                }
            }



            // Endboss Daten laden
            using (var stream = TitleContainer.OpenStream("Game_Data/Level" + Level + "_" + Difficulty + "_Boss.txt"))
            {
                using (var reader = new StreamReader(stream))
                {
                    temp = reader.ReadToEnd();
                }
            }
            temp_split = Regex.Split(temp, "//");
            temp_split = Regex.Split(temp_split[0].Trim(), ";;;");
            for (int i = 0; i < temp_split.Count(); i++)
            {
                string[] split_data = Regex.Split(temp_split[i], "=");
                split_data[0] = split_data[0].Trim();
                if (split_data[0] == "BossTextures")
                {
                    BossTextures = Convert.ToInt32(split_data[1].Trim());
                }
                if (split_data[0] == "BossSounds")
                {
                    BossSounds = Convert.ToInt32(split_data[1].Trim());
                }
                if (split_data[0] == "BossEnergie")
                {
                    BossEnergie = Convert.ToInt32(split_data[1].Trim());
                }
                if (split_data[0] == "BossIncoming")
                {
                    BossIncoming = Convert.ToInt32(split_data[1].Trim());
                    Boss_X = BossIncoming;
                }
                if (split_data[0] == "BossWeaponPoints")
                {
                    BossWeaponPoints = Regex.Split(split_data[1].Trim(), ";");
                }
                if (split_data[0] == "BossWayPoints")
                {
                    BossWayPoints = Regex.Split(split_data[1].Trim(), ";");
                }
                if (split_data[0] == "BossShotPoints")
                {
                    BossShotPoints = Regex.Split(split_data[1].Trim(), ";");
                }
                if (split_data[0] == "BossSoundPoints")
                {
                    BossSoundPoints = Regex.Split(split_data[1].Trim(), ";");
                }
                if (split_data[0] == "BossTime")
                {
                    BossTime = Convert.ToInt32(split_data[1].Trim());
                }
                if (split_data[0] == "BossHitbox")
                {
                    string[] split_BossHitbox = Regex.Split(split_data[1].Trim(), ",");
                    Boss_Hitbox_Width = Convert.ToInt32(split_BossHitbox[0]);
                    Boss_Hitbox_Height = Convert.ToInt32(split_BossHitbox[1]);
                }
            }
            // **************************************************************************************************************



            // Level // Content Laden
            // **************************************************************************************************************
            // Allgemeine Sprites
            fntDisplay = Content.Load<SpriteFont>("FontDisplay");                                                   // Schrift der Anzeige
            fntBossTime = Content.Load<SpriteFont>("FontBossTime");                                                 // Schrift der Boss Zeit
            texBackground = Content.Load<Texture2D>("Level" + Level.ToString() + "_Background");                    // Sprites Hintergrund
            texBackgroundAnimation = Content.Load<Texture2D>("Level" + Level.ToString() + "_BackgroundAnimation");  // Sprites Hintergrundanimation

            texDisplay = Content.Load<Texture2D>("Display");                                                        // Sprites Anzeige
            texDisplay_Fire = Content.Load<Texture2D>("Display_Fire");                                              // Sprites Anzeige
            texDisplay_Phaser = Content.Load<Texture2D>("Display_Phaser");                                          // Sprites Anzeige
            texDisplay_Laser = Content.Load<Texture2D>("Display_Laser");                                            // Sprites Anzeige
            texDisplay_Level1 = Content.Load<Texture2D>("Display_Level1");                                          // Sprites Anzeige
            texDisplay_Level2 = Content.Load<Texture2D>("Display_Level2");                                          // Sprites Anzeige
            texDisplay_Level3 = Content.Load<Texture2D>("Display_Level3");                                          // Sprites Anzeige
            texDisplay_Rocket = Content.Load<Texture2D>("Display_Rocket");                                          // Sprites Anzeige
            texDisplay_PowerShotBar = Content.Load<Texture2D>("Display_PowerShotBar");                              // Sprites Anzeige

            HitboxTexture = new Texture2D(GraphicsDevice, 1, 1);                                                    // Sprites zum erstellen der Hitboxen
            HitboxTexture.SetData(new Color[] { Color.White });                                                     // Sprites zum erstellen der Hitboxen

            // Sprites eigene Schüsse
            texMyShip = Content.Load<Texture2D>("MyShip");                              // Sprites eigenes Raumschiff
            texMyShipLeft = Content.Load<Texture2D>("MyShipLeft");                      // Sprites eigenes Raumschiff
            texMyShipRight = Content.Load<Texture2D>("MyShipRight");                    // Sprites eigenes Raumschiff
            texMyShotFire = Content.Load<Texture2D>("MyShotFire");                      // Sprites Schuss Feuer
            texMyShotLaser1 = Content.Load<Texture2D>("MyShotLaser1");                  // Sprites Schuss Laser
            texMyShotLaser2 = Content.Load<Texture2D>("MyShotLaser2");                  // Sprites Schuss Laser
            texMyShotLaser3 = Content.Load<Texture2D>("MyShotLaser3");                  // Sprites Schuss Laser
            texMyShotPhaser = Content.Load<Texture2D>("MyShotPhaser");                  // Sprites Schuss Phaser
            texMyShotRocket = Content.Load<Texture2D>("MyShotRocket");                  // Sprites Extension Raketen
            texMyShotPowerShot1 = Content.Load<Texture2D>("MyShotPowerShot1");          // Sprites Powerschuss
            texMyShotPowerShot2 = Content.Load<Texture2D>("MyShotPowerShot2");          // Sprites Powerschuss
            texMyShotPowerShot3 = Content.Load<Texture2D>("MyShotPowerShot3");          // Sprites Powerschuss
            texMyShotPowerShot4 = Content.Load<Texture2D>("MyShotPowerShot4");          // Sprites Powerschuss
            texMyShotPowerShot5 = Content.Load<Texture2D>("MyShotPowerShot5");          // Sprites Powerschuss
            texMyShotPowerShotFinal = Content.Load<Texture2D>("MyShotPowerShotFinal");  // Sprites Powerschuss

            // Sprites Effekte
            texSmoke1 = Content.Load<Texture2D>("Smoke_1");         // Sprites Rauch
            texSmoke2 = Content.Load<Texture2D>("Smoke_2");         // Sprites Rauch
            texSmoke3 = Content.Load<Texture2D>("Smoke_3");         // Sprites Rauch
            texSmoke4 = Content.Load<Texture2D>("Smoke_4");         // Sprites Rauch
            texSmoke5 = Content.Load<Texture2D>("Smoke_5");         // Sprites Rauch

            // Sprites Gegner // Durchlaufen und in eine Liste schreiben
            for (int i = 0; i < ListEnemys.Count(); i++)
            {
                // Wenn Just vorhanden
                if (ListEnemys[i].just == true)
                {
                    texEnemyJust = Content.Load<Texture2D>(ListEnemys[i].enemy + "just");
                }
                // Wenn left vorhanden
                if (ListEnemys[i].left == true)
                {
                    texEnemyLeft = Content.Load<Texture2D>(ListEnemys[i].enemy + "Left");
                }
                // Wenn right vorhanden
                if (ListEnemys[i].right == true)
                {
                    texEnemyRight = Content.Load<Texture2D>(ListEnemys[i].enemy + "right");
                }
                // Texturen in Liste schreiben
                ListEnemyTextures.Add(new ClassEnemyTextures(ListEnemys[i].enemy, texEnemyJust, texEnemyLeft, texEnemyRight));

                // Texturen zurücksetzen um zu vermeiden das vorherige in Liste geschrieben werden
                texEnemyJust = null;
                texEnemyLeft = null;
                texEnemyRight = null;

            }

            // Sprites Gegnerische Schüsse
            texEnemyShot1 = Content.Load<Texture2D>("EnemyShot1");                  // Sprites Gegnerischen Schuss Typ 1
            texEnemyShot1_2 = Content.Load<Texture2D>("EnemyShot1_2");                  // Sprites Gegnerischen Schuss Typ 1 groß
            sndEnemyShot1Sound = Content.Load<SoundEffect>("EnemyShot1Sound");      // Soundeffekt Gegnerische Schuss Typ 1
            texEnemyShot2_1 = Content.Load<Texture2D>("EnemyShot2_1");              // Sprites Gegnerischen Schuss Typ 2
            texEnemyShot2_2 = Content.Load<Texture2D>("EnemyShot2_2");              // Sprites Gegnerischen Schuss Typ 2
            texEnemyShot2_3 = Content.Load<Texture2D>("EnemyShot2_3");              // Sprites Gegnerischen Schuss Typ 2
            sndEnemyShot2Sound = Content.Load<SoundEffect>("EnemyShot2Sound");      // Soundeffekt Gegnerische Schuss Typ 1
            sndEnemyShot3Sound = Content.Load<SoundEffect>("EnemyShot3Sound");      // Soundeffekt Gegnerische Schuss Typ 1 groß


            // Sprites Explosionen
            texExplosionMini0 = Content.Load<Texture2D>("ExplosionMini0");        // Sprites Explosion Mini
            texExplosionMini1 = Content.Load<Texture2D>("ExplosionMini1");        // Sprites Explosion Mini  
            texExplosionMini2 = Content.Load<Texture2D>("ExplosionMini2");        // Sprites Explosion Mini
            texExplosionMini3 = Content.Load<Texture2D>("ExplosionMini3");        // Sprites Explosion Mini
            texExplosionMini4 = Content.Load<Texture2D>("ExplosionMini4");        // Sprites Explosion Mini

            texExplosionSmall0 = Content.Load<Texture2D>("ExplosionSmall0");        // Sprites Explosion klein
            texExplosionSmall1 = Content.Load<Texture2D>("ExplosionSmall1");        // Sprites Explosion klein  
            texExplosionSmall2 = Content.Load<Texture2D>("ExplosionSmall2");        // Sprites Explosion klein
            texExplosionSmall3 = Content.Load<Texture2D>("ExplosionSmall3");        // Sprites Explosion klein
            texExplosionSmall4 = Content.Load<Texture2D>("ExplosionSmall4");        // Sprites Explosion klein

            texExplosionMedium0 = Content.Load<Texture2D>("ExplosionMedium0");        // Sprites Explosion Medium
            texExplosionMedium1 = Content.Load<Texture2D>("ExplosionMedium1");        // Sprites Explosion Medium  
            texExplosionMedium2 = Content.Load<Texture2D>("ExplosionMedium2");        // Sprites Explosion Medium
            texExplosionMedium3 = Content.Load<Texture2D>("ExplosionMedium3");        // Sprites Explosion Medium
            texExplosionMedium4 = Content.Load<Texture2D>("ExplosionMedium4");        // Sprites Explosion Medium

            texExplosionBig0 = Content.Load<Texture2D>("ExplosionBig0");            // Sprites Explosion groß   
            texExplosionBig1 = Content.Load<Texture2D>("ExplosionBig1");            // Sprites Explosion groß
            texExplosionBig2 = Content.Load<Texture2D>("ExplosionBig2");            // Sprites Explosion groß
            texExplosionBig3 = Content.Load<Texture2D>("ExplosionBig3");            // Sprites Explosion groß
            texExplosionBig4 = Content.Load<Texture2D>("ExplosionBig4");            // Sprites Explosion groß
            texExplosionBig5 = Content.Load<Texture2D>("ExplosionBig5");            // Sprites Explosion groß
            texExplosionBig6 = Content.Load<Texture2D>("ExplosionBig6");            // Sprites Explosion groß
            texExplosionBig7 = Content.Load<Texture2D>("ExplosionBig7");            // Sprites Explosion groß

            // Sprites PowerUps
            texPowerUpFire_1 = Content.Load<Texture2D>("PowerUp_Fire_1");           // Sprites PowerUp Schuss Feuer
            texPowerUpFire_2 = Content.Load<Texture2D>("PowerUp_Fire_2");           // Sprites PowerUp Schuss Feuer
            texPowerUpFire_3 = Content.Load<Texture2D>("PowerUp_Fire_3");           // Sprites PowerUp Schuss Feuer
            texPowerUpFire_4 = Content.Load<Texture2D>("PowerUp_Fire_4");           // Sprites PowerUp Schuss Feuer
            texPowerUpFire_5 = Content.Load<Texture2D>("PowerUp_Fire_5");           // Sprites PowerUp Schuss Feuer
            texPowerUpFire_6 = Content.Load<Texture2D>("PowerUp_Fire_6");           // Sprites PowerUp Schuss Feuer
            texPowerUpFire_7 = Content.Load<Texture2D>("PowerUp_Fire_7");           // Sprites PowerUp Schuss Feuer
            texPowerUpPhaser_1 = Content.Load<Texture2D>("PowerUp_Phaser_1");       // Sprites PowerUp Schuss Phaser
            texPowerUpPhaser_2 = Content.Load<Texture2D>("PowerUp_Phaser_2");       // Sprites PowerUp Schuss Phaser
            texPowerUpPhaser_3 = Content.Load<Texture2D>("PowerUp_Phaser_3");       // Sprites PowerUp Schuss Phaser
            texPowerUpPhaser_4 = Content.Load<Texture2D>("PowerUp_Phaser_4");       // Sprites PowerUp Schuss Phaser
            texPowerUpPhaser_5 = Content.Load<Texture2D>("PowerUp_Phaser_5");       // Sprites PowerUp Schuss Phaser
            texPowerUpPhaser_6 = Content.Load<Texture2D>("PowerUp_Phaser_6");       // Sprites PowerUp Schuss Phaser
            texPowerUpPhaser_7 = Content.Load<Texture2D>("PowerUp_Phaser_7");       // Sprites PowerUp Schuss Phaser
            texPowerUpLaser_1 = Content.Load<Texture2D>("PowerUp_Laser_1");         // Sprites PowerUp Schuss Laser
            texPowerUpLaser_2 = Content.Load<Texture2D>("PowerUp_Laser_2");         // Sprites PowerUp Schuss Laser
            texPowerUpLaser_3 = Content.Load<Texture2D>("PowerUp_Laser_3");         // Sprites PowerUp Schuss Laser
            texPowerUpLaser_4 = Content.Load<Texture2D>("PowerUp_Laser_4");         // Sprites PowerUp Schuss Laser
            texPowerUpLaser_5 = Content.Load<Texture2D>("PowerUp_Laser_5");         // Sprites PowerUp Schuss Laser
            texPowerUpLaser_6 = Content.Load<Texture2D>("PowerUp_Laser_6");         // Sprites PowerUp Schuss Laser
            texPowerUpLaser_7 = Content.Load<Texture2D>("PowerUp_Laser_7");         // Sprites PowerUp Schuss Laser
            texPowerUpOneUp_1 = Content.Load<Texture2D>("PowerUp_OneUp_1");         // Sprites PowerUp OneUp
            texPowerUpOneUp_2 = Content.Load<Texture2D>("PowerUp_OneUp_2");         // Sprites PowerUp OneUp
            texPowerUpOneUp_3 = Content.Load<Texture2D>("PowerUp_OneUp_3");         // Sprites PowerUp OneUp
            texPowerUpOneUp_4 = Content.Load<Texture2D>("PowerUp_OneUp_4");         // Sprites PowerUp OneUp
            texPowerUpOneUp_5 = Content.Load<Texture2D>("PowerUp_OneUp_5");         // Sprites PowerUp OneUp   
            texPowerUpOneUp_6 = Content.Load<Texture2D>("PowerUp_OneUp_6");         // Sprites PowerUp OneUp
            texPowerUpOneUp_7 = Content.Load<Texture2D>("PowerUp_OneUp_7");         // Sprites PowerUp OneUp
            texPowerUpRocket_1 = Content.Load<Texture2D>("PowerUp_Rocket_1");       // Sprites PowerUp Schuss Rakete
            texPowerUpRocket_2 = Content.Load<Texture2D>("PowerUp_Rocket_2");       // Sprites PowerUp Schuss Rakete
            texPowerUpRocket_3 = Content.Load<Texture2D>("PowerUp_Rocket_3");       // Sprites PowerUp Schuss Rakete
            texPowerUpRocket_4 = Content.Load<Texture2D>("PowerUp_Rocket_4");       // Sprites PowerUp Schuss Rakete
            texPowerUpRocket_5 = Content.Load<Texture2D>("PowerUp_Rocket_5");       // Sprites PowerUp Schuss Rakete
            texPowerUpRocket_6 = Content.Load<Texture2D>("PowerUp_Rocket_6");       // Sprites PowerUp Schuss Rakete
            texPowerUpRocket_7 = Content.Load<Texture2D>("PowerUp_Rocket_7");       // Sprites PowerUp Schuss Rakete

            // Sprites, Schriftzug Warning
            texWarning1 = Content.Load<Texture2D>("Warning1");                      // Sprites Warning
            texWarning2 = Content.Load<Texture2D>("Warning2");                      // Sprites Warning
            texWarning3 = Content.Load<Texture2D>("Warning3");                      // Sprites Warning

            // Sprites Endboss // Durchlaufen und in Liste speichern
            ListBossTextures.Clear();
            // Anzahl durchlaufen und laden
            for (int i = 1; i <= BossTextures; i++)
            {
                texBoss = Content.Load<Texture2D>("Boss" + Level + "_" + i);
                ListBossTextures.Add(new ClassBossTextures(texBoss));
            }

            // Soundeffekte Endboss // Durchlaufen und in Liste speichern
            ListBossSounds.Clear();
            // Anzahl durchlaufen und laden
            for (int i = 1; i <= BossSounds; i++)
            {

                sndBoss = Content.Load<SoundEffect>("Boss" + Level + "_Sound" + i);
                ListBossSounds.Add(new ClassBossSounds(sndBoss));
            }

            // Soundeffekte
            sndMyShotFire = Content.Load<SoundEffect>("MyShotFireSound");           // Soundeffekt Schuss Feuer
            sndMyShotPhaser = Content.Load<SoundEffect>("MyShotPhaserSound");       // Soundeffekt Schuss Phaser
            sndMyShotLaser = Content.Load<SoundEffect>("MyShotLaserSound");         // Soundeffekt Schuss Laser
            sndMyShotRocket = Content.Load<SoundEffect>("MyShotRocketSound");       // Soundeffekt Schuss Raketen
            sndMyShotPowerShot = Content.Load<SoundEffect>("MyShotPowerShotSound"); // Soundeffekt Powerschuss

            sndImpact = Content.Load<SoundEffect>("ImpactSound");                   // Soundeffekt Einschlag
            sndExplosionSmall = Content.Load<SoundEffect>("ExplosionSmallSound");   // Soundeffekt Explosion klein
            sndExplosionBig = Content.Load<SoundEffect>("ExplosionBigSound");       // Soundeffekt Explosion groß

            sndPowerUp = Content.Load<SoundEffect>("Sound_PowerUp");                // Soundeffekt PowerUp
            sndFire = Content.Load<SoundEffect>("Sound_Fire");                      // Soundeffekt Fire
            sndPhaser = Content.Load<SoundEffect>("Sound_Phaser");                  // Sounderrekt Phaser
            sndOneUp = Content.Load<SoundEffect>("Sound_OneUp");                    // Soundeffekt OneUp
            sndRocket = Content.Load<SoundEffect>("Sound_Rocket");                  // Soundeffekt Rocket Extension
            sndLaser = Content.Load<SoundEffect>("Sound_Laser");                    // Soundeffekt Laser
            sndPowerShotReady = Content.Load<SoundEffect>("Sound_PowerShotReady");  // Soundeffekt Powershot Ready

            sndAlert = Content.Load<SoundEffect>("Sound_Alert");                    // Soundeffekt Alarm

            songBackgroundMusic = Content.Load<Song>("Level" + Level.ToString() + "_Music");       // Musik Hintergrundmusik
            songBossMusic = Content.Load<Song>("Boss_Music");                                           // Musik Endboss Musik
            // **************************************************************************************************************
        }
        // ------------------------------------------------------------------------------------------------------------------------------------





    }





}
