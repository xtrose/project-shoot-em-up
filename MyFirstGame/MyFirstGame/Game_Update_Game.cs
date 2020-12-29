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




        // Level // Spielverlauf berrechenen
        // ------------------------------------------------------------------------------------------------------------------------------------
        void Update_Level()
        {
            // Musik abspielen
            // **************************************************************************************************************
            if (MediaPlayer.State.ToString() != "Playing" & PlayBackgroundMusic == true)
            {
                // Hintergrundmusik
                if (BossSzenario == false)
                {
                    MediaPlayer.Play(songBackgroundMusic);
                }
                // Boss Musik
                else
                {
                    MediaPlayer.Play(songBossMusic);
                }
            }
            // **************************************************************************************************************





            // Variabeln zum Ablauf des Frames zurücksetzen
            // **************************************************************************************************************
            // String der zu löschenden Gegner
            string delete_string = "";

            // Sound Variabeln auf "false" stellen
            bool playSoundMyShotFire = false;
            bool playSoundMyShotPhaser = false;
            bool playSoundMyShotLaser = false;
            bool playSoundMyShotRocket = false;
            bool playSoundMyShotPowerShot = false;
            bool playSoundImpact = false;
            bool playSoundExplosionSmall = false;
            bool playSoundExplosionBig = false;
            bool playSoundPowerUp = false;
            bool playSoundPhaser = false;
            bool playSoundFire = false;
            bool playSoundOneUp = false;
            bool playSoundRocket = false;
            bool playSoundLaser = false;
            bool playSoundPowerShotReady = false;
            bool playSoundEnemyShot1 = false;
            bool playSoundEnemyShot2 = false;
            bool playSoundEnemyShot3 = false;
            // **************************************************************************************************************





            // Frames erhöhen
            // **************************************************************************************************************
            // Anzahl gesamt abgelaufener Frames
            FrameCount++;

            // Anzahl der Vergangenen Frames seit dem zuletzt erstellten Schuß
            if (MyShipIsActive == true)
            {
                MyShotFrame++;
                MyExtensionFrame++;
            }
            // **************************************************************************************************************





            // Berechnungen zum allgemeinen Spiel Ablauf
            // **************************************************************************************************************
            // Wenn eigenes Schiff nicht aktiv
            if (MyShipIsActive == false)
            {
                // Powerschuss Animation zurückstellen
                PowerShotAnimation = false;
                PowerShotAnimationFrame = 0;

                // Wenn noch Frames übrig bis es weiter geht
                if (FramesToAppear != 0)
                {
                    FramesToAppear--;
                }
                // Wenn keine Frames mehr übrig
                else
                {
                    // Wenn noch Leben übrig
                    if (Lives > 0)
                    {
                        // Schiff wieder auf aktiv stellen
                        MyShipIsActive = true;
                        // Schiff auf unzerstörbar stellen
                        Indestructible = 90;
                        // Powerschüsse und Ladung löschen
                        MyShip_PowerShot_Loading = 0;
                        MyShip_PowerShot_Load = 0;
                        MyShip_PowerShots = 0;
                        MyShip_PowerShot_Width = 0;
                    }
                    // Wenn keine Leben mehr übrig
                    else
                    {
                        // Wenn noch Continues vorhanden
                        if (Continues > 1)
                        {
                            // Hier ein Continue Menü erstellen
                        }
                        // Wenn keine Continues mehr übrig
                        else
                        {
                            // Hier zurück zum Hauptmenü gehen
                        }
                    }
                }
            }



            // Wenn eigenes Schiff unzerstörbar
            if (Indestructible > 0)
            {
                Indestructible--;
            }



            // Display Bauteile festlegen // Waffen
            // Fire
            if (MyShotType == "Fire")
            {
                texDisplay_Weapon = texDisplay_Fire;
                if (MyShotFireLevel == 0)
                {
                    texDisplay_LevelShot = texDisplay_Level1;
                }
                else if (MyShotFireLevel == 1)
                {
                    texDisplay_LevelShot = texDisplay_Level2;
                }
                else if (MyShotFireLevel == 2)
                {
                    texDisplay_LevelShot = texDisplay_Level3;
                }

            }
            // Phaser
            else if (MyShotType == "Phaser")
            {
                texDisplay_Weapon = texDisplay_Phaser;
                if (MyShotPhaserLevel == 0)
                {
                    texDisplay_LevelShot = texDisplay_Level1;
                }
                else if (MyShotPhaserLevel == 1)
                {
                    texDisplay_LevelShot = texDisplay_Level2;
                }
                else if (MyShotPhaserLevel == 2)
                {
                    texDisplay_LevelShot = texDisplay_Level3;
                }
            }
            // Laser
            else if (MyShotType == "Laser")
            {
                texDisplay_Weapon = texDisplay_Laser;
                if (MyShotLaserLevel == 0)
                {
                    texDisplay_LevelShot = texDisplay_Level1;
                }
                else if (MyShotLaserLevel == 1)
                {
                    texDisplay_LevelShot = texDisplay_Level2;
                }
                else if (MyShotLaserLevel == 2)
                {
                    texDisplay_LevelShot = texDisplay_Level3;
                }
            }

            // Extension Rocket
            if (MyExtensionType == "Rocket")
            {
                texDisplay_Extension = texDisplay_Rocket;
                if (MyShotRocketLevel == 0)
                {
                    texDisplay_LevelExtension = texDisplay_Level1;
                }
                else if (MyShotRocketLevel == 1)
                {
                    texDisplay_LevelExtension = texDisplay_Level2;
                }
                else if (MyShotRocketLevel == 2)
                {
                    texDisplay_LevelExtension = texDisplay_Level3;
                }
                // Angeben das angezeigt wird
                Display_Show_Extension = true;
            }
            else if (MyExtensionType == "None")
            {
                // Angeben das nich angezeigt wird
                Display_Show_Extension = false;
            }



            // Bei Doppelklick auf Powerschuss prüfen
            if (DoubleClick == true)
            {
                if (MyShipIsActive == true & MyShip_PowerShots > 0 & PowerShotAnimation == false)
                {
                    MyShip_PowerShots--;
                    PowerShotAnimation = true;
                    playSoundMyShotPowerShot = true;
                }
            }
            // Wenn Powerschussanimation
            if (PowerShotAnimation == true)
            {
                // Powerschuss Frame erhöhen
                PowerShotAnimationFrame++;
                // Powerschuss Aktionen nach Frames
                if (PowerShotAnimationFrame < 3)
                {
                    texMyShotPowerShot = texMyShotPowerShot1;
                }
                else if (PowerShotAnimationFrame < 6)
                {
                    texMyShotPowerShot = texMyShotPowerShot2;
                }
                else if (PowerShotAnimationFrame < 9)
                {
                    texMyShotPowerShot = texMyShotPowerShot3;
                }
                else if (PowerShotAnimationFrame < 12)
                {
                    texMyShotPowerShot = texMyShotPowerShot4;
                }
                else if (PowerShotAnimationFrame < 15)
                {
                    texMyShotPowerShot = texMyShotPowerShot5;
                }
                else if (PowerShotAnimationFrame < PowerShotTime)
                {
                    texMyShotPowerShot = texMyShotPowerShotFinal;
                }
                else
                {
                    PowerShotAnimation = false;
                    PowerShotAnimationFrame = 0;
                }
            }



            // Endboss Szenario
            if (FrameCount > BossFrame)
            {
                // Boss Scenario erstellen
                BossSzenario = true;
                // Warning Anzeige zurücksetzen
                ShowWarning = false;
                // Warnung ausgeben
                int BossSzenarioFrame = FrameCount - BossFrame;

                // Bei Boss Frame 1 // Warning Sound ausgeben, Schuss deaktivieren // Boss Textur auf die erste stellen
                if (BossSzenarioFrame == 1)
                {
                    // Schuss deaktivieren
                    ShotIsActive = false;
                    // Warnung Ton ausgeben
                    sndAlert.Play();
                    // Boss Textur auf die erste stellen
                    texBoss = ListBossTextures[0].texture;
                }
                // Beim Boss Frame 50 // Musik abstellen
                else if (BossSzenarioFrame == 50)
                {
                    // Hintergrundmusik stoppen
                    MediaPlayer.Stop();
                    PlayBackgroundMusic = false;
                }
                // Bei Boss Frame 350 // Endboss Musik abspielen
                else if (BossSzenarioFrame == 350)
                {
                    // Endbossmusik abspielen
                    MediaPlayer.Play(songBossMusic);
                    PlayBackgroundMusic = true;
                }
                // Bei Boss Frame 400 // Schuss wieder aktivieren
                else if (BossSzenarioFrame == 400)
                {
                    // Schuss aktivieren
                    ShotIsActive = true;
                }

                //Warnung erstellen
                if (BossSzenarioFrame < 5 | (BossSzenarioFrame >= 15 & BossSzenarioFrame < 20) | (BossSzenarioFrame >= 30 & BossSzenarioFrame < 35) | (BossSzenarioFrame >= 45 & BossSzenarioFrame < 50) | (BossSzenarioFrame >= 60 & BossSzenarioFrame < 65) | (BossSzenarioFrame >= 75 & BossSzenarioFrame < 80) | (BossSzenarioFrame >= 90 & BossSzenarioFrame < 95) | (BossSzenarioFrame >= 105 & BossSzenarioFrame < 110) | (BossSzenarioFrame >= 120 & BossSzenarioFrame < 125))
                {
                    texWarning = texWarning1;
                    ShowWarning = true;
                }
                else if (BossSzenarioFrame < 10 | (BossSzenarioFrame >= 20 & BossSzenarioFrame < 25) | (BossSzenarioFrame >= 35 & BossSzenarioFrame < 40) | (BossSzenarioFrame >= 50 & BossSzenarioFrame < 55) | (BossSzenarioFrame >= 65 & BossSzenarioFrame < 70) | (BossSzenarioFrame >= 80 & BossSzenarioFrame < 85) | (BossSzenarioFrame >= 95 & BossSzenarioFrame < 100) | (BossSzenarioFrame >= 110 & BossSzenarioFrame < 115) | (BossSzenarioFrame >= 125 & BossSzenarioFrame < 130))
                {
                    texWarning = texWarning2;
                    ShowWarning = true;
                }
                else if (BossSzenarioFrame < 15 | (BossSzenarioFrame >= 25 & BossSzenarioFrame < 30) | (BossSzenarioFrame >= 40 & BossSzenarioFrame < 45) | (BossSzenarioFrame >= 55 & BossSzenarioFrame < 60) | (BossSzenarioFrame >= 70 & BossSzenarioFrame < 75) | (BossSzenarioFrame >= 85 & BossSzenarioFrame < 100) | (BossSzenarioFrame >= 100 & BossSzenarioFrame < 105) | (BossSzenarioFrame >= 115 & BossSzenarioFrame < 120) | (BossSzenarioFrame >= 135 & BossSzenarioFrame < 140) | (BossSzenarioFrame >= 145 & BossSzenarioFrame < 150) | (BossSzenarioFrame >= 155 & BossSzenarioFrame < 160))
                {
                    texWarning = texWarning3;
                    ShowWarning = true;
                }

                // Animation, Boss fliegt herein // Endbosszeit Blinken lassen
                if (BossSzenarioFrame > 250 & BossSzenarioFrame <= 350)
                {
                    // Boss herein fliegen lassen
                    double temp = Convert.ToDouble(300) / Convert.ToDouble(100) * Convert.ToDouble(BossSzenarioFrame - 250);
                    Boss_Y = -100 + Convert.ToInt32(temp);
                    // Boss Zeit blinken lassen
                    if ((BossSzenarioFrame / 15) % 2 == 0)
                    {
                        BossTimeString = BossTime.ToString();
                    }
                    else
                    {
                        BossTimeString = "";
                    }

                }
                // Animation Boss
                else if (BossSzenarioFrame > 400)
                {
                    // Boss Zeit abziehen
                    if (BossEnergie > 0)
                    {
                        // Boss Zeit abziehen
                        BossTimeRest = BossTime - ((BossSzenarioFrame - 400) / 30);
                        // BossTime String erstellen
                        BossTimeString = BossTimeRest.ToString();
                    }
                    // BossFrameCount erhöhen
                    BossFrameCount++;
                    // WayPointFrame erstellen
                    int WayPointframe = 0;


                    // Wenn noch Energie vorhanden
                    if (BossEnergie > 0)
                    {
                        // Boss Bewegungs Loop erstellen
                        for (int i = 0; i < BossWayPoints.Count(); i++)
                        {
                            // Aktuelle Loop Datei zerlegen
                            string[] split_loop = Regex.Split(BossWayPoints[i], ",");
                            // Waypointframe um aktuelle Framezahl erhöhen
                            WayPointframe += Convert.ToInt32(split_loop[4].Trim());
                            // Wenn Wegdatei aktuell
                            if (WayPointframe >= BossFrameCount)
                            {
                                // Aktuellen Wegpunkt ermitteln
                                double PercentWayFrame = BossFrameCount - (WayPointframe - Convert.ToInt32(split_loop[4]));
                                double PercentWay = Convert.ToDouble(100) / Convert.ToDouble(split_loop[4].Trim()) * PercentWayFrame;
                                double PercentX = (Convert.ToDouble(split_loop[2].Trim()) - Convert.ToDouble(split_loop[0].Trim())) / Convert.ToDouble(100) * PercentWay;
                                Boss_X = Convert.ToInt32(Convert.ToInt32(split_loop[0]) + PercentX);
                                double PercentY = (Convert.ToDouble(split_loop[3].Trim()) - Convert.ToDouble(split_loop[1].Trim())) / Convert.ToDouble(100) * PercentWay;
                                Boss_Y = Convert.ToInt32(Convert.ToInt32(split_loop[1]) + PercentY);
                                texBoss = ListBossTextures[Convert.ToInt32(split_loop[5].Trim())].texture;
                                break;
                            }
                            // Wenn Wegdatei nicht aktuell
                            else
                            {
                                // Wenn letzte Datei
                                if ((BossWayPoints.Count() - 1) == i)
                                {
                                    // BossFrameCount zurücksetzen
                                    BossFrameCount = 1;
                                    // Boss Koordinaten auf erstes Frame setzen
                                    split_loop = Regex.Split(BossWayPoints[0], ",");
                                    Boss_X = Convert.ToInt32(split_loop[0].Trim());
                                    Boss_Y = Convert.ToInt32(split_loop[1].Trim());
                                    break;
                                }
                            }
                        }

                        // Boss Schusspunkte duchlaufen
                        for (int i = 0; i < BossShotPoints.Count(); i++)
                        {
                            // Schusss Datei zerlegen
                            string[] split_ShotPoints = Regex.Split(BossShotPoints[i], ",");
                            // Wenn Frame erreicht
                            if (Convert.ToInt32(split_ShotPoints[0].Trim()) == BossFrameCount)
                            {
                                // Wenn Schuss typ 1 --> Direkter Schuss --> Erzeugt Schuss in der Klasse <ClassEnemyShotDirect>
                                if (Convert.ToInt32(split_ShotPoints[1]) == 1)
                                {
                                    // Waffenpunkt zerlegen
                                    string[] split_WeaponPoint = Regex.Split(BossWeaponPoints[Convert.ToInt32(split_ShotPoints[3])], ",");
                                    // Gegnerischen Schuss ermitteln
                                    CreateEnemyShot1(Convert.ToDouble(Boss_X + Convert.ToInt32(split_WeaponPoint[0])), Convert.ToDouble(Boss_Y + Convert.ToInt32(split_WeaponPoint[1])), Convert.ToInt32(split_ShotPoints[2]));

                                    // Sound ausgeben
                                    playSoundEnemyShot1 = true;
                                }

                                // Wenn Schuss typ 3 --> Großer Direkter Schuss --> Erzeugt Schuss in der Klasse <ClassEnemyShotDirect>
                                if (Convert.ToInt32(split_ShotPoints[1]) == 3)
                                {
                                    // Waffenpunkt zerlegen
                                    string[] split_WeaponPoint = Regex.Split(BossWeaponPoints[Convert.ToInt32(split_ShotPoints[3])], ",");
                                    // Gegnerischen Schuss ermitteln
                                    CreateEnemyShot3(Convert.ToDouble(Boss_X + Convert.ToInt32(split_WeaponPoint[0])), Convert.ToDouble(Boss_Y + Convert.ToInt32(split_WeaponPoint[1])), Convert.ToInt32(split_ShotPoints[2]));

                                    // Sound ausgeben
                                    playSoundEnemyShot3 = true;
                                }

                                // Wenn Schuss typ 2 --> Dreifach Schuss --> Erzeugt drei Schüsse in der Klasse <ClassEnemyShotDirect>
                                if (Convert.ToInt32(split_ShotPoints[1]) == 2)
                                {
                                    // Waffenpunkt zerlegen
                                    string[] split_WeaponPoint = Regex.Split(BossWeaponPoints[Convert.ToInt32(split_ShotPoints[3])], ",");
                                    // Gegnerischen Schuss ermitteln
                                    CreateEnemyShot2(Convert.ToDouble(Boss_X + Convert.ToInt32(split_WeaponPoint[0])), Convert.ToDouble(Boss_Y + Convert.ToInt32(split_WeaponPoint[1])), Convert.ToInt32(split_ShotPoints[2]));

                                    // Sound ausgeben
                                    playSoundEnemyShot1 = true;
                                }

                                // Wenn Schuss typ 10, 11, 12 --> Laser Schuss --> Erzeugt einen Schuss in der Klasse <ClassEnemyShotLaser>
                                else if (Convert.ToInt32(split_ShotPoints[1]) == 10 | Convert.ToInt32(split_ShotPoints[1]) == 11 | Convert.ToInt32(split_ShotPoints[1]) == 12)
                                {
                                    int temp_type = 1;
                                    if (Convert.ToInt32(split_ShotPoints[1]) == 11)
                                    {
                                        temp_type = 2;
                                    }
                                    else if (Convert.ToInt32(split_ShotPoints[1]) == 12)
                                    {
                                        temp_type = 3;
                                    }
                                    // Waffenpunkt zerlegen
                                    string[] split_WeaponPoint = Regex.Split(BossWeaponPoints[Convert.ToInt32(split_ShotPoints[3])], ",");
                                    // Gegnerischen Schuss ermitteln
                                    CreateShotEnemyLaser(temp_type, Convert.ToDouble(Boss_X + Convert.ToInt32(split_WeaponPoint[0])), Convert.ToDouble(Boss_Y + Convert.ToInt32(split_WeaponPoint[1])), Convert.ToInt32(split_ShotPoints[2]));

                                    // Sound ausgeben
                                    playSoundEnemyShot2 = true;
                                }
                            }
                        }

                        // Soundpunkte durchlaufen
                        for (int i = 0; i < BossSoundPoints.Count(); i++)
                        {
                            // Sound Datei zerlegen
                            string[] split_SoundPoints = Regex.Split(BossSoundPoints[i], ",");
                            // Wenn Frame erreicht
                            if (Convert.ToInt32(split_SoundPoints[0].Trim()) == BossFrameCount)
                            {
                                // Soundeffect laden
                                sndBoss = ListBossSounds[Convert.ToInt32(split_SoundPoints[1].Trim())].soundeffect;
                                sndBoss.Play();
                            }
                        }
                    }

                    // Wenn keine Energie mehr vorhanden
                    else
                    {
                        // Boss Time String erstellen
                        BossTimeString = BossTimeRest.ToString();
                        // Wenn Schuss noch aktiv ist
                        if (ShotIsActive == true)
                        {
                            // Boss Frame Count zurückstellen
                            BossFrameCount = 0;
                            // Explosion erstellen
                            ListExplosions.Add(new ClassExplosions("Big", -1, Boss_X, Boss_Y));
                            // Sound Explosion ausgeben
                            playSoundExplosionBig = true;
                            // Schuss abstellen
                            ShotIsActive = false;
                        }
                        // Bei Boss Frame BossFrameCount 20 // Endboss verschwinden lassen
                        if (BossFrameCount == 20)
                        {
                            // Boss verschwinden lassen
                            DrawBoss = false;
                        }
                        // Bei BossFrameCount == 200 // Schiff an Ausgangsposition fliegen lassen
                        else if (BossFrameCount == 200)
                        {
                            // Kontrolle an CPU übergeben
                            MyShipControl = false;
                            CPUShipControl_X = 240;
                            CPUShipControl_Y = 600;
                        }
                        // Bei BossFrameCount zwischen 200 und 240 Frames // Bonus zusammen rechnen
                        else if (BossFrameCount < 240 & BossFrameCount >= 200)
                        {
                            BossTimeString += " X 5000";
                        }
                        // Bei BossFrameCount zwischen 241 und 280 // Bonus zusammen rechnen
                        else if (BossFrameCount < 280 & BossFrameCount >= 241)
                        {
                            BossTimeString = (BossTimeRest * 5000).ToString();
                        }
                        // Zum Schluss Punkte zusammen rechnen 
                        else if (BossFrameCount == 281)
                        {
                            BossTimeString = (BossTimeRest * 5000).ToString();
                            Points += (BossTimeRest * 5000);
                        }
                        // Level Beenden
                        else if (BossFrameCount == 350)
                        {
                            // Musik auschalten
                            MediaPlayer.Stop();

                            // Wenn GameType "Play" ist
                            if (GameType == "Play")
                            {
                                // Level Daten erhöhen
                                Level++;
                                // Nächstes laden
                                Game_LoadContent = "Level";
                                Game_UnloadContent = "Level";
                                Game_Control = "Loading";
                            }
                            // Wenn Game Type "LevelSelect" ist
                            else if (GameType == "LevelSelect")
                            {
                                // Hauptmenü laden
                                Game_LoadContent = "Menu";
                                Game_UnloadContent = "Level";
                                Game_Control = "Loading";
                            }
                        }
                        // Schiff raus fliegen
                        else
                        {
                            BossTimeString = "";
                            CPUShipControl_X = 240;
                            CPUShipControl_Y = -100;
                        }

                    }
                }

            }
            // **************************************************************************************************************





            // Position des Hintergundbildes ermitteln
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
            delete_string = "";



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
                if (ListBackgroundAnimation[i].y > (800 + texBackgroundAnimation.Height))
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





            // Laufzeit Ereignisse
            // **************************************************************************************************************
            // Liste der Laufzeit durchlaufen und neue Gegner erstellen
            for (int i = 0; i < ListHistory.Count; i++)
            {
                // Wenn Frame erreicht
                if (ListHistory[i].frame == FrameCount)
                {
                    // Neuen Gegner erstellen // Eventuell Eintrag löschen
                    ListShipEnemys.Add(new ClassShipEnemys(ListHistory[i].enemy_type, ListHistory[i].way_type, ListHistory[i].way_cor_x, ListHistory[i].way_cor_y, ListHistory[i].way_mirrow, FrameCount, ListHistory[i].energy, ListEnemys[ListHistory[i].enemy_type].hitbox_width, ListEnemys[ListHistory[i].enemy_type].hitbox_height, ListEnemys[ListHistory[i].enemy_type].hitbox_cor_x, ListEnemys[ListHistory[i].enemy_type].hitbox_cor_y, ListHistory[i].shot_data, ListHistory[i].group_data, ListEnemys[ListHistory[i].enemy_type].rotate));
                }
            }
            // **************************************************************************************************************





            // Position der gegnerischen Schiffe ermitteln
            // **************************************************************************************************************
            // delete_string zurücksetzen
            delete_string = "";

            // Gegner durchlaufen und Positionen neu ermitteln
            for (int i = 0; i < ListShipEnemys.Count(); i++)
            {
                // Variabeln erstellen
                int way_frame = FrameCount - ListShipEnemys[i].frame_start;
                int f_stop = 0;
                bool delete_enemy = true;

                // Rotation eintragen
                ListShipEnemys[i].rotation += ListShipEnemys[i].rotate;

                // Wegdatei laden
                string way = ListEnemysWays[ListShipEnemys[i].way_type].way;
                // Wegdatei aufteilen
                string[] way_split = Regex.Split(way, ";");
                // Einzelne Wege durchlaufen
                for (int i2 = 0; i2 < way_split.Count(); i2++)
                {
                    // Einzelne Wege aufteilen
                    string[] way_data = Regex.Split(way_split[i2], ",");
                    f_stop += Convert.ToInt32(way_data[4]);
                    // Prüfen ob vorhandenener Weg
                    if (way_frame <= f_stop)
                    {
                        // Neue Position errechnen
                        int f_start = f_stop - Convert.ToInt32(way_data[4]);
                        int f_now = way_frame - f_start;
                        double f_pec = Convert.ToDouble(100) / Convert.ToDouble(way_data[4]) * Convert.ToDouble(f_now);
                        int x_way = Convert.ToInt32(way_data[0]) - Convert.ToInt32(way_data[2]);
                        int y_way = Convert.ToInt32(way_data[1]) - Convert.ToInt32(way_data[3]);
                        double x_new = Convert.ToInt32(way_data[0]) - (Convert.ToDouble(x_way) / Convert.ToDouble(100) * f_pec);
                        double y_new = Convert.ToInt32(way_data[1]) - (Convert.ToDouble(y_way) / Convert.ToDouble(100) * f_pec);
                        x_new = x_new + Convert.ToInt32(ListShipEnemys[i].way_cor_x);
                        y_new = y_new + Convert.ToInt32(ListShipEnemys[i].way_cor_y);
                        // Seitenlage ermitteln
                        int side = Convert.ToInt32(way_data[5]);
                        // Wenn Weg gespiegelt
                        if (ListShipEnemys[i].way_mirrow == true)
                        {
                            x_new = Convert.ToDouble(480) - x_new;
                            if (side == -1)
                            {
                                side = 1;
                            }
                            else if (side == 1)
                            {
                                side = -1;
                            }
                        }
                        // Seitenlage in Sprite String umwandeln
                        string sprite = "just";
                        if (side == -1)
                        {
                            sprite = "left";
                        }
                        else if (side == 1)
                        {
                            sprite = "right";
                        }
                        // Position eintragen
                        ListShipEnemys[i].position_x = Convert.ToInt32(x_new);
                        ListShipEnemys[i].position_y = Convert.ToInt32(y_new);
                        ListShipEnemys[i].sprite = sprite;
                        // Hitbox erstellen
                        ListShipEnemys[i].hitbox_x = Convert.ToInt32(x_new) + ListShipEnemys[i].hitbox_cor_x;
                        ListShipEnemys[i].hitbox_y = Convert.ToInt32(y_new) + ListShipEnemys[i].hitbox_cor_y;
                        // Angeben das nicht gelöscht wird
                        delete_enemy = false;
                        // Schleife unterbrechen
                        break;
                    }
                }
                // Wenn Flugbahn zuende, Gegner löschen
                if (delete_enemy == true)
                {
                    delete_string += i.ToString() + ";";
                }
            }



            // Nicht mehr verwendete Gegner löschen
            if (delete_string.Length > 0)
            {
                string[] delete_split = Regex.Split(delete_string, ";");
                for (int i = delete_split.Count() - 2; i >= 0; i--)
                {
                    ListShipEnemys.RemoveAt(Convert.ToInt32(delete_split[i]));
                }
            }
            // **************************************************************************************************************





            // Position von eigenem Schiff berechnen // Bewegung nach Finger Eingabe
            // **************************************************************************************************************
            // Wenn Spiel Kontrolle über das Schiff hat
            if (MyShipControl == false)
            {
                PositionFinger.X = CPUShipControl_X;
                PositionFinger.Y = CPUShipControl_Y;
                FirstPositionFinger = new Vector2(CPUShipControl_X, CPUShipControl_Y);
            }

            // Schiff bewegen
            if (MyShip_X > PositionFinger.X)
            {
                MyShipPosition = -1;
                MyShip_X = MyShip_X - MyShipSpeed;
                if (MyShip_X < PositionFinger.X)
                {
                    MyShip_X = Convert.ToInt32(PositionFinger.X);
                    MyShipPosition = 0;
                }
                if (MyShip_X > 480)
                {
                    MyShip_X = 480;
                }
                if (MyShip_X < 0)
                {
                    MyShip_X = 0;
                }
            }
            else if (MyShip_X < PositionFinger.X)
            {
                MyShipPosition = 1;
                MyShip_X = MyShip_X + MyShipSpeed;
                if (MyShip_X > PositionFinger.X)
                {
                    MyShip_X = Convert.ToInt32(PositionFinger.X);
                    MyShipPosition = 0;
                }
                if (MyShip_X > 480)
                {
                    MyShip_X = 480;
                }
                if (MyShip_X < 0)
                {
                    MyShip_X = 0;
                }
            }
            if (MyShip_Y > (PositionFinger.Y + PositionY))
            {
                MyShip_Y = MyShip_Y - MyShipSpeed;
                if (MyShip_Y < (PositionFinger.Y + PositionY))
                {
                    MyShip_Y = Convert.ToInt32(PositionFinger.Y) + PositionY;
                }
                if (MyShip_Y > 800)
                {
                    MyShip_Y = 800;
                }
                if (MyShip_Y < 0)
                {
                    MyShip_Y = 0;
                }
            }
            else if (MyShip_Y < (PositionFinger.Y + PositionY))
            {
                MyShip_Y = MyShip_Y + MyShipSpeed;
                if (MyShip_Y > (PositionFinger.Y + PositionY))
                {
                    MyShip_Y = Convert.ToInt32(PositionFinger.Y) + PositionY;
                }
                if (MyShip_Y > 800)
                {
                    MyShip_Y = 800;
                }
                if (MyShip_Y < 0)
                {
                    MyShip_Y = 0;
                }
            }

            // Position in den ersten Frames auf gerade stellen und Stuerung deaktivieren
            if (FrameCount < 10)
            {
                // Steuerung deaktivieren
                MyShipControl = false;
                // Schuss deaktivieren
                ShotIsActive = false;
                // Position auf null stellen
                MyShipPosition = 0;
                // X und Y Koordinaten au Anfangsposition stellen
                MyShip_X = 240;
                MyShip_Y = 600;
                // Erste Posistion des Fingers zurücksetzen
                FirstPositionFinger = new Vector2(-100, -100);
                // Position des Fingers zurücksetzen
                PositionFinger.X = 240;
                PositionFinger.Y = 600;
            }
            // Bei Frame 10 Steuerung aktivieren
            else if (FrameCount == 10)
            {
                // Steuerung aktivieren
                MyShipControl = true;
                // Schuss Aktivieren
                ShotIsActive = true;
                // Erste Posistion des Fingers zurücksetzen
                FirstPositionFinger = new Vector2(-100, -100);
                PositionFinger.X = 240;
                PositionFinger.Y = 600;
            }

            // Hitbox berechnen
            MyShip_Hitbox_X = MyShip_X - (MyShip_Hitbox_Width / 2);
            MyShip_Hitbox_Y = MyShip_Y - (MyShip_Hitbox_Height / 2);

            // Hitbox des Powerschusses berechnen // Aufladung X 1
            MyShip_PowerShot_Hitbox_X = MyShip_X - (MyShip_PowerShot_Hitbox_Width / 2);
            MyShip_PowerShot_Hitbox_Y = MyShip_Y - (MyShip_PowerShot_Hitbox_Height / 2);

            // Hitbox des Powerschusses berechnen // Aufladung X 2
            MyShip_PowerShot_Hitbox_X_2 = MyShip_X - (MyShip_PowerShot_Hitbox_Width_2 / 2);
            MyShip_PowerShot_Hitbox_Y_2 = MyShip_Y - (MyShip_PowerShot_Hitbox_Height_2 / 2);

            // Hitbox des Powerschusses, Strahl wenn Aktiv
            if (PowerShotAnimation == true)
            {
                if (PowerShotAnimationFrame < 15)
                {
                    PowerShotHitboxX = MyShip_X - 40;
                    PowerShotHitboxY = MyShip_Y - 100;
                    PowerShotHitboxHeight = 80;
                    PowerShotHitboxWidth = 80;
                }
                else
                {
                    PowerShotHitboxX = MyShip_X - (PowerShotHitboxWidth / 2);
                    PowerShotHitboxY = MyShip_Y - 800;
                    PowerShotHitboxHeight = 800;
                    PowerShotHitboxWidth = 120;
                }
            }
            // **************************************************************************************************************





            // Eigene Schüsse berechnen
            // **************************************************************************************************************
            // String der zu löschende Schüsse
            delete_string = "";

            // MyShotFire // Schüsse Feuer // Durchlaufen und Weg neu berechnen
            for (int x = 0; x < ListMyShots.Count(); x++)
            {
                // MyShotFire // Aussen Links // Level 3
                if (ListMyShots[x].type == "Fire" & ListMyShots[x].angle == -0.6f)
                {
                    // x und y neu berechnen
                    ListMyShots[x].y = ListMyShots[x].y - 6;
                    ListMyShots[x].x = ListMyShots[x].x - 4;
                    // Hitbox Daten neu erstellen
                    ListMyShots[x].hitbox_x = ListMyShots[x].x - 8;
                    ListMyShots[x].hitbox_y = ListMyShots[x].y - 30;
                    // Nicht mehr verwendete Schüsse in dei Löschen Liste schreiben
                    if (ListMyShots[x].y < -50)
                    {
                        delete_string += x.ToString() + ";";
                    }
                }
                // MyShotFire // Mitte Links // Level 2 und Level 3
                if (ListMyShots[x].type == "Fire" & ListMyShots[x].angle == -0.2f)
                {
                    // x und y neu berechnen
                    ListMyShots[x].y = ListMyShots[x].y - 8;
                    ListMyShots[x].x = ListMyShots[x].x - 2;
                    // Hitbox Daten neu erstellen
                    ListMyShots[x].hitbox_x = ListMyShots[x].x - 8;
                    ListMyShots[x].hitbox_y = ListMyShots[x].y - 32;
                    // Nicht mehr verwendete Schüsse in dei Löschen Liste schreiben
                    if (ListMyShots[x].y < -50)
                    {
                        delete_string += x.ToString() + ";";
                    }
                }
                // MyShotFire // Mitte // Level 1
                if (ListMyShots[x].type == "Fire" & ListMyShots[x].angle == -0.0f)
                {
                    // x und y neu berechnen
                    ListMyShots[x].y = ListMyShots[x].y - 10;
                    // Hitbox Daten neu erstellen
                    ListMyShots[x].hitbox_x = ListMyShots[x].x - 7;
                    ListMyShots[x].hitbox_y = ListMyShots[x].y - 34;
                    // Nicht mehr verwendete Schüsse in dei Löschen Liste schreiben
                    if (ListMyShots[x].y < -50)
                    {
                        delete_string += x.ToString() + ";";
                    }
                }
                // MyShotFire // Mitte Rechte // Level 2 und Level 3
                if (ListMyShots[x].type == "Fire" & ListMyShots[x].angle == 0.2f)
                {
                    // x und y neu berechnen
                    ListMyShots[x].y = ListMyShots[x].y - 8;
                    ListMyShots[x].x = ListMyShots[x].x + 2;
                    // Hitbox Daten neu erstellen
                    ListMyShots[x].hitbox_x = ListMyShots[x].x - 8;
                    ListMyShots[x].hitbox_y = ListMyShots[x].y - 34;
                    // Nicht mehr verwendete Schüsse in dei Löschen Liste schreiben
                    if (ListMyShots[x].y < -50)
                    {
                        delete_string += x.ToString() + ";";
                    }
                }
                // MyShotFire // Aussen Rechts // Level 3
                if (ListMyShots[x].type == "Fire" & ListMyShots[x].angle == 0.6f)
                {
                    // x und y neu berechnen
                    ListMyShots[x].y = ListMyShots[x].y - 6;
                    ListMyShots[x].x = ListMyShots[x].x + 4;
                    // Hitbox Daten neu erstellen
                    ListMyShots[x].hitbox_x = ListMyShots[x].x - 4;
                    ListMyShots[x].hitbox_y = ListMyShots[x].y - 38;
                    // Nicht mehr verwendete Schüsse in dei Löschen Liste schreiben
                    if (ListMyShots[x].y < -50)
                    {
                        delete_string += x.ToString() + ";";
                    }
                }

                // MyShotPhaser
                if (ListMyShots[x].type == "Phaser")
                {
                    // x und y neu berechnen
                    ListMyShots[x].y = ListMyShots[x].y - 8;
                    // Hitbox Daten neu erstellen
                    ListMyShots[x].hitbox_x = ListMyShots[x].x - (texMyShotPhaser.Width / 2);
                    ListMyShots[x].hitbox_y = ListMyShots[x].y - 54;
                    // Nicht mehr verwendete Schüsse in dei Löschen Liste schreiben
                    if (ListMyShots[x].y < -50)
                    {
                        delete_string += x.ToString() + ";";
                    }
                }

                // MyShotLaser
                if (ListMyShots[x].type == "Laser")
                {
                    // x und y neu berechnen
                    ListMyShots[x].y = ListMyShots[x].y - 10;
                    ListMyShots[x].hitbox_y = ListMyShots[x].hitbox_y - 10;
                    // Nicht mehr verwendete Schüsse in dei Löschen Liste schreiben
                    if (ListMyShots[x].y < -50)
                    {
                        delete_string += x.ToString() + ";";
                    }
                }
            }



            // Nicht mehr verwendete Schüsse löschen
            if (delete_string.Length > 0)
            {
                string[] delete_split = Regex.Split(delete_string, ";");
                for (int i = delete_split.Count() - 2; i >= 0; i--)
                {
                    try
                    {
                        ListMyShots.RemoveAt(Convert.ToInt32(delete_split[i]));
                    }
                    catch
                    { }
                }
            }



            // Neue Schüsse erstellen // Wenn Schiff aktiv ist // Und Powerschuss nicht aktiv // Und Schuss aktiv ist
            if (MyShipIsActive == true & PowerShotAnimation == false & ShotIsActive == true)
            {
                // Neue Schüsse erstellen // MyShotFire // Schuss Feuer
                if (MyShotType == "Fire")
                {
                    // Level 0 // Fire erstellen
                    if (MyShotFireLevel == 0 & MyShotFrame >= MyShotFireSpeed)
                    {
                        ListMyShots.Add(new ClassMyShots("Fire", 2, MyShip_X, MyShip_Y - (texMyShip.Height / 2), 0.0f));

                        // Soundeffekt ausgeben
                        playSoundMyShotFire = true;

                        // MyShot Frame zurücksetzen
                        MyShotFrame = 0;
                    }
                    // Level 1 // Fire erstellen
                    if (MyShotFireLevel == 1 & MyShotFrame >= (MyShotFireSpeed * 1.2))
                    {
                        ListMyShots.Add(new ClassMyShots("Fire", 2, MyShip_X - 10, MyShip_Y - (texMyShip.Height / 2), -0.2f));
                        ListMyShots.Add(new ClassMyShots("Fire", 2, MyShip_X, MyShip_Y - (texMyShip.Height / 2), 0.0f));
                        ListMyShots.Add(new ClassMyShots("Fire", 2, MyShip_X + 10, MyShip_Y - (texMyShip.Height / 2), 0.2f));

                        // Soundeffekt ausgeben
                        playSoundMyShotFire = true;

                        // MyShot Frame zurücksetzen
                        MyShotFrame = 0;
                    }
                    // Level 2 // Fire erstellen
                    if (MyShotFireLevel == 2 & MyShotFrame >= (MyShotFireSpeed * 1.4))
                    {
                        ListMyShots.Add(new ClassMyShots("Fire", 2, MyShip_X - 20, MyShip_Y - (texMyShip.Height / 2), -0.6f));
                        ListMyShots.Add(new ClassMyShots("Fire", 2, MyShip_X - 10, MyShip_Y - (texMyShip.Height / 2), -0.2f));
                        ListMyShots.Add(new ClassMyShots("Fire", 2, MyShip_X, MyShip_Y - (texMyShip.Height / 2), 0.0f));
                        ListMyShots.Add(new ClassMyShots("Fire", 2, MyShip_X + 10, MyShip_Y - (texMyShip.Height / 2), 0.2f));
                        ListMyShots.Add(new ClassMyShots("Fire", 2, MyShip_X + 20, MyShip_Y - (texMyShip.Height / 2), 0.6f));

                        // Soundeffekt ausgeben
                        playSoundMyShotFire = true;

                        // MyShot Frame zurücksetzen
                        MyShotFrame = 0;
                    }
                }





                // Neue Schüsse erstellen // MyShotPhaser // Schuss Phaser
                if (MyShotType == "Phaser" & MyShotFrame >= MyShotPhaserSpeed)
                {
                    // Level 0 // Phaser erstellen
                    if (MyShotPhaserLevel == 0)
                    {
                        ListMyShots.Add(new ClassMyShots("Phaser", 0, MyShip_X, MyShip_Y, 0.0f));
                    }
                    // Level 1 // Phaser erstellen
                    if (MyShotPhaserLevel == 1)
                    {
                        ListMyShots.Add(new ClassMyShots("Phaser", 0, MyShip_X - 20, MyShip_Y, 0.0f));
                        ListMyShots.Add(new ClassMyShots("Phaser", 0, MyShip_X + 20, MyShip_Y, 0.0f));
                    }
                    // Level 2 // Phaser erstellen
                    if (MyShotPhaserLevel == 2)
                    {
                        ListMyShots.Add(new ClassMyShots("Phaser", 0, MyShip_X - 30, MyShip_Y, 0.0f));
                        ListMyShots.Add(new ClassMyShots("Phaser", 0, MyShip_X + 30, MyShip_Y, 0.0f));
                        ListMyShots.Add(new ClassMyShots("Phaser", 0, MyShip_X, MyShip_Y - 15, 0.0f));
                    }

                    // Soundeffekt ausgeben
                    playSoundMyShotPhaser = true; ;

                    // MyShot Frame zurücksetzen
                    MyShotFrame = 0;
                }

                LoadContent();


                // Neue Schüsse erstellen // MyShotLaser // Schuss Laser
                if (MyShotType == "Laser" & MyShotFrame >= MyShotLaserSpeed)
                {
                    // Level 1 // Laser erstellen // Links
                    if (MyShotLaserLevel == 0)
                    {
                        // Wenn linker Laser abgeschossen wird
                        if (MyShotLaserSide == "Left")
                        {
                            //Neuen Laser erstellen
                            ListMyShots.Add(new ClassMyShots("Laser", 1, (MyShip_X - 20), MyShip_Y, 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 1, (MyShip_X - 20), (MyShip_Y - 10), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 1, (MyShip_X - 20), (MyShip_Y - 20), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 1, (MyShip_X - 20), (MyShip_Y - 30), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 1, (MyShip_X - 20), (MyShip_Y - 40), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 1, (MyShip_X - 20), (MyShip_Y - 50), 0.0f));
                            // Seite umstellen
                            MyShotLaserSide = "Right";
                        }
                        // Wenn Rechter Laser abgeschossen wird
                        else if (MyShotLaserSide == "Right")
                        {
                            //Neuen Laser erstellen
                            ListMyShots.Add(new ClassMyShots("Laser", 1, (MyShip_X + 20), MyShip_Y, 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 1, (MyShip_X + 20), (MyShip_Y - 10), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 1, (MyShip_X + 20), (MyShip_Y - 20), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 1, (MyShip_X + 20), (MyShip_Y - 30), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 1, (MyShip_X + 20), (MyShip_Y - 40), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 1, (MyShip_X + 20), (MyShip_Y - 50), 0.0f));
                            // Seite umstellen
                            MyShotLaserSide = "Left";
                        }
                    }

                    // Level 2 // Laser erstellen // Links
                    if (MyShotLaserLevel == 1)
                    {
                        // Wenn linker Laser abgeschossen wird
                        if (MyShotLaserSide == "Left")
                        {
                            //Neuen Laser erstellen
                            ListMyShots.Add(new ClassMyShots("Laser", 2, (MyShip_X - 20), MyShip_Y, 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 2, (MyShip_X - 20), (MyShip_Y - 10), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 2, (MyShip_X - 20), (MyShip_Y - 20), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 2, (MyShip_X - 20), (MyShip_Y - 30), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 2, (MyShip_X - 20), (MyShip_Y - 40), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 2, (MyShip_X - 20), (MyShip_Y - 50), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 2, (MyShip_X - 20), (MyShip_Y - 60), 0.0f));
                            // Seite umstellen
                            MyShotLaserSide = "Right";
                        }
                        // Wenn Rechter Laser abgeschossen wird
                        else if (MyShotLaserSide == "Right")
                        {
                            //Neuen Laser erstellen
                            ListMyShots.Add(new ClassMyShots("Laser", 2, (MyShip_X + 20), MyShip_Y, 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 2, (MyShip_X + 20), (MyShip_Y - 10), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 2, (MyShip_X + 20), (MyShip_Y - 20), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 2, (MyShip_X + 20), (MyShip_Y - 30), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 2, (MyShip_X + 20), (MyShip_Y - 40), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 2, (MyShip_X + 20), (MyShip_Y - 50), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 2, (MyShip_X + 20), (MyShip_Y - 60), 0.0f));
                            // Seite umstellen
                            MyShotLaserSide = "Left";
                        }
                    }

                    // Level 3 // Laser erstellen // Links
                    if (MyShotLaserLevel == 2)
                    {
                        // Wenn linker Laser abgeschossen wird
                        if (MyShotLaserSide == "Left")
                        {
                            //Neuen Laser erstellen
                            ListMyShots.Add(new ClassMyShots("Laser", 3, (MyShip_X - 20), MyShip_Y, 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 3, (MyShip_X - 20), (MyShip_Y - 10), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 3, (MyShip_X - 20), (MyShip_Y - 20), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 3, (MyShip_X - 20), (MyShip_Y - 30), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 3, (MyShip_X - 20), (MyShip_Y - 40), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 3, (MyShip_X - 20), (MyShip_Y - 50), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 3, (MyShip_X - 20), (MyShip_Y - 60), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 3, (MyShip_X - 20), (MyShip_Y - 70), 0.0f));
                            // Seite umstellen
                            MyShotLaserSide = "Right";
                        }
                        // Wenn Rechter Laser abgeschossen wird
                        else if (MyShotLaserSide == "Right")
                        {
                            //Neuen Laser erstellen
                            ListMyShots.Add(new ClassMyShots("Laser", 3, (MyShip_X + 20), MyShip_Y, 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 3, (MyShip_X + 20), (MyShip_Y - 10), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 3, (MyShip_X + 20), (MyShip_Y - 20), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 3, (MyShip_X + 20), (MyShip_Y - 30), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 3, (MyShip_X + 20), (MyShip_Y - 40), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 3, (MyShip_X + 20), (MyShip_Y - 50), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 3, (MyShip_X + 20), (MyShip_Y - 60), 0.0f));
                            ListMyShots.Add(new ClassMyShots("Laser", 3, (MyShip_X + 20), (MyShip_Y - 70), 0.0f));
                            // Seite umstellen
                            MyShotLaserSide = "Left";
                        }
                    }

                    // Sound ausgeben
                    playSoundMyShotLaser = true;

                    // MyShot Frame zurücksetzen
                    MyShotFrame = 0;
                }
            }
            // **************************************************************************************************************





            // Erweiterte Schüsse Raketen berechen
            // **************************************************************************************************************
            // String der zu löschende Schüsse
            delete_string = "";

            // ListShotRocket durchlaufen und bewegen
            for (int i = 0; i < ListMyShotRocket.Count(); i++)
            {
                // Frame erhöhen
                ListMyShotRocket[i].frame++;
                // Wenn Frame < 10, Nach aussen bewegen
                if (ListMyShotRocket[i].frame < 10)
                {
                    // Rakete vorbereiten
                    if (ListMyShotRocket[i].position == 1)
                    {
                        ListMyShotRocket[i].x += 3;
                        ListMyShotRocket[i].y += 1;
                    }
                    else if (ListMyShotRocket[i].position == -1)
                    {
                        ListMyShotRocket[i].x -= 3;
                        ListMyShotRocket[i].y += 1;
                    }
                    else if (ListMyShotRocket[i].position == 2)
                    {
                        ListMyShotRocket[i].x += 6;
                        ListMyShotRocket[i].y += 2;
                    }
                    else if (ListMyShotRocket[i].position == -2)
                    {
                        ListMyShotRocket[i].x -= 6;
                        ListMyShotRocket[i].y += 2;
                    }
                    else if (ListMyShotRocket[i].position == 3)
                    {
                        ListMyShotRocket[i].x += 9;
                        ListMyShotRocket[i].y += 3;
                    }
                    else if (ListMyShotRocket[i].position == -3)
                    {
                        ListMyShotRocket[i].x -= 9;
                        ListMyShotRocket[i].y += 3;
                    }
                }
                // Wenn Frame > 20, Rakete nach vorne Bewegen und beschleunigen
                else
                {
                    // Variablen erstellen
                    int y_old = ListMyShotRocket[i].y;
                    int y_old2 = ListMyShotRocket[i].y;
                    bool stop_create = false;
                    // Rakete Bebegen
                    ListMyShotRocket[i].y = ListMyShotRocket[i].y - ListMyShotRocket[i].speed;
                    ListMyShotRocket[i].speed++;
                    // Rauch erstellen
                    if (ListMyShotRocket[i].smoke1_y != -1000)
                    {
                        y_old2 = ListMyShotRocket[i].smoke1_y;
                        ListMyShotRocket[i].smoke1_y = y_old;
                    }
                    else
                    {
                        ListMyShotRocket[i].smoke1_y = y_old;
                        stop_create = true;
                    }
                    y_old = y_old2;
                    if (stop_create == false)
                    {
                        if (ListMyShotRocket[i].smoke2_y != -1000)
                        {
                            y_old2 = ListMyShotRocket[i].smoke2_y;
                            ListMyShotRocket[i].smoke2_y = y_old;
                        }
                        else
                        {
                            ListMyShotRocket[i].smoke2_y = y_old;
                            stop_create = true;
                        }

                    }
                    y_old = y_old2;
                    if (stop_create == false)
                    {
                        if (ListMyShotRocket[i].smoke3_y != -1000)
                        {
                            y_old2 = ListMyShotRocket[i].smoke3_y;
                            ListMyShotRocket[i].smoke3_y = y_old;
                        }
                        else
                        {
                            ListMyShotRocket[i].smoke3_y = y_old;
                            stop_create = true;
                        }
                    }
                    y_old = y_old2;
                    if (stop_create == false)
                    {
                        if (ListMyShotRocket[i].smoke4_y != -1000)
                        {
                            y_old2 = ListMyShotRocket[i].smoke4_y;
                            ListMyShotRocket[i].smoke4_y = y_old;
                        }
                        else
                        {
                            ListMyShotRocket[i].smoke4_y = y_old;
                            stop_create = true;
                        }
                    }
                    y_old = y_old2;
                    if (stop_create == false)
                    {
                        if (ListMyShotRocket[i].smoke5_y != -1000)
                        {
                            y_old2 = ListMyShotRocket[i].smoke5_y;
                            ListMyShotRocket[i].smoke5_y = y_old;
                        }
                        else
                        {
                            ListMyShotRocket[i].smoke5_y = y_old;
                            stop_create = true;
                        }
                    }
                }

                // Wenn Frame == 10 Sound ausgeben
                if (ListMyShotRocket[i].frame == 10)
                {
                    playSoundMyShotRocket = true;
                }

                // Wenn Rakete gelöscht wird
                if (ListMyShotRocket[i].y < -100)
                {
                    string[] temp_split = Regex.Split(";" + delete_string, ";" + i.ToString() + ";");
                    if (temp_split.Count() == 1)
                    {
                        delete_string += i.ToString() + ";";
                    }
                }
            }




            // Nicht mehr verwendete Raketen löschen
            if (delete_string.Length > 0)
            {
                string[] delete_split = Regex.Split(delete_string, ";");
                for (int i = delete_split.Count() - 2; i >= 0; i--)
                {
                    try
                    {
                        ListMyShotRocket.RemoveAt(Convert.ToInt32(delete_split[i]));
                    }
                    catch
                    { }
                }
            }





            // Neue Schüsse erstellen // Extension Rocket
            if (MyShipIsActive == true & PowerShotAnimation == false & ShotIsActive == true)
            {
                if (MyExtensionType == "Rocket" & MyExtensionFrame >= MyShotRocketSpeed)
                {
                    // Level 0 // Rocket erstellen
                    if (MyShotRocketLevel == 0)
                    {
                        ListMyShotRocket.Add(new ClassMyShotRocket(-1, MyShip_X, MyShip_Y));
                        ListMyShotRocket.Add(new ClassMyShotRocket(1, MyShip_X, MyShip_Y));
                    }

                    // Level 1 // Rocket erstellen
                    if (MyShotRocketLevel == 1)
                    {
                        ListMyShotRocket.Add(new ClassMyShotRocket(-1, MyShip_X, MyShip_Y));
                        ListMyShotRocket.Add(new ClassMyShotRocket(1, MyShip_X, MyShip_Y));
                        ListMyShotRocket.Add(new ClassMyShotRocket(-2, MyShip_X, MyShip_Y));
                        ListMyShotRocket.Add(new ClassMyShotRocket(2, MyShip_X, MyShip_Y));
                    }

                    // Level 2 // Rocket erstellen
                    if (MyShotRocketLevel == 2)
                    {
                        ListMyShotRocket.Add(new ClassMyShotRocket(-1, MyShip_X, MyShip_Y));
                        ListMyShotRocket.Add(new ClassMyShotRocket(1, MyShip_X, MyShip_Y));
                        ListMyShotRocket.Add(new ClassMyShotRocket(-2, MyShip_X, MyShip_Y));
                        ListMyShotRocket.Add(new ClassMyShotRocket(2, MyShip_X, MyShip_Y));
                        ListMyShotRocket.Add(new ClassMyShotRocket(-3, MyShip_X, MyShip_Y));
                        ListMyShotRocket.Add(new ClassMyShotRocket(3, MyShip_X, MyShip_Y));
                    }

                    // Extension Frame zurüchsetzen
                    MyExtensionFrame = 0;
                }
            }
            // **************************************************************************************************************





            // Hitboxen eigener Schüsse mit Hitboxen von Gegnern abgleichen
            // **************************************************************************************************************
            string delete_string_enemys = "";
            string delete_string_shots = "";
            // Liste aller Gegner durchlaufen
            for (int i = 0; i < ListShipEnemys.Count(); i++)
            {
                // Gegner Hitbox Koordinaten laden
                int Enemy_x_start = ListShipEnemys[i].hitbox_x;
                int Enemy_x_end = Enemy_x_start + ListShipEnemys[i].hitbox_width;
                int Enemy_y_start = ListShipEnemys[i].hitbox_y;
                int Enemy_y_end = Enemy_y_start + ListShipEnemys[i].hitbox_height;
                // Liste aller eigener Schüsse durchlaufen
                for (int i2 = 0; i2 < ListMyShots.Count(); i2++)
                {
                    // Schuss Hitbox Koordinaten laden
                    int Shot_x_start = ListMyShots[i2].hitbox_x;
                    int Shot_x_end = Shot_x_start + ListMyShots[i2].hitbox_width;
                    int Shot_y_start = ListMyShots[i2].hitbox_y;
                    int Shot_y_end = Shot_y_start + ListMyShots[i2].hitbox_height;

                    //Hitboxen abgleichen
                    if (Match_Hitboxes(Enemy_x_start, Enemy_x_end, Enemy_y_start, Enemy_y_end, Shot_x_start, Shot_x_end, Shot_y_start, Shot_y_end) == true)
                    {
                        // Energie abziehen
                        int damage = 0;
                        if (ListMyShots[i2].type == "Fire")
                        {
                            damage = MyShotFireDamage;
                        }
                        if (ListMyShots[i2].type == "Phaser")
                        {
                            damage = MyShotPhaserDamage;
                        }
                        if (ListMyShots[i2].type == "Laser")
                        {
                            damage = MyShotLaserDamage;
                        }
                        ListShipEnemys[i].energy = ListShipEnemys[i].energy - damage;
                        // Punkte erhöhen
                        Points += damage;

                        // Wenn Energie verbraucht, Gegner löschen und Explosion erstellen
                        if (ListShipEnemys[i].energy <= 0)
                        {
                            // Wenn Gegner einer Gruppe Angehört, Abschüsse erhöhen
                            string[] split_groups = Regex.Split(ListShipEnemys[i].group_data, ";");
                            // Einzelne Gruppen des Gegners durchlaufen
                            for (int i3 = 0; i3 < split_groups.Count(); i3++)
                            {
                                // Wenn Gruppendaten vorhanden
                                if (split_groups[i3].Trim().Length > 0)
                                {
                                    // Gruppendaten ermitteln
                                    string[] group_datas = Regex.Split(split_groups[i3], ":");
                                    // Prüfen welche Gruppe
                                    for (int i4 = 0; i4 < ListEnemyGroups.Count(); i4++)
                                    {
                                        // Gruppen durchlaufen und prüfen welcher Gruppe angehört 
                                        if (ListEnemyGroups[i4].ID == Convert.ToInt32(group_datas[0]))
                                        {
                                            // Kills der Gruppe erhöhen
                                            ListEnemyGroups[i4].kills++;
                                            // Wenn anderes PowerUp vorhanden
                                            string powerUp = "Random";
                                            if (group_datas.Count() > 2)
                                            {
                                                if (group_datas[2].Trim() != "")
                                                {
                                                    ListEnemyGroups[i4].powerUp = group_datas[2];
                                                }
                                            }
                                            if (ListEnemyGroups[i4].powerUp.Trim() != "")
                                            {
                                                powerUp = ListEnemyGroups[i4].powerUp;
                                            }

                                            // Wenn PowerUp ausgegeben wird
                                            if (ListEnemyGroups[i4].kills == ListEnemyGroups[i4].killsForPowerUp)
                                            {
                                                // Wenn PowerUp Random
                                                if (powerUp == "Random")
                                                {
                                                    // Random Zahl erzeugen
                                                    Random rand = new Random();
                                                    int index_temp = rand.Next(1, 83);
                                                    // Powerup Fire erzeugen
                                                    if (index_temp < 21)
                                                    {
                                                        powerUp = "Fire";
                                                    }
                                                    // Powerup Phaser erzeugen
                                                    else if (index_temp < 41)
                                                    {
                                                        powerUp = "Phaser";
                                                    }
                                                    // Powerup Rocket erzeugen
                                                    else if (index_temp < 61)
                                                    {
                                                        powerUp = "Rocket";
                                                    }
                                                    // Powerup Laser erzeugen
                                                    else if (index_temp < 81)
                                                    {
                                                        powerUp = "Laser";
                                                    }
                                                    // PowerUp OneUp erzeugen
                                                    else
                                                    {
                                                        powerUp = "OneUp";
                                                    }
                                                }
                                                // Bei mehreren Powerups, Position des Powerups bestimmen
                                                int powerupX = 0;
                                                int powerupY = 0;
                                                if (i4 == 0)
                                                {
                                                    powerupY = 30;
                                                }
                                                else if (i4 == 1)
                                                {
                                                    powerupY = -30;
                                                }
                                                else if (i4 == 2)
                                                {
                                                    powerupX = 30;
                                                }
                                                else if (i4 == 3)
                                                {
                                                    powerupX = -30;
                                                }
                                                // PowerUp ausgeben
                                                ListPowerUps.Add(new ClassPowerUps(powerUp, (ListShipEnemys[i].position_x + powerupX), (ListShipEnemys[i].position_y + powerupY)));
                                            }
                                            break;
                                        }
                                    }
                                }
                            }

                            // Prüfen ob Gegner bereits als Gelöscht eingetragen
                            string[] tempTest = Regex.Split(";" + delete_string_enemys, ";" + i + ";");
                            if (tempTest.Count() == 1)
                            {
                                // Gegner löschen
                                delete_string_enemys += i + ";";
                            }
                            // Explosion erstellen
                            string explosion_type = ListEnemys[ListShipEnemys[i].enemy_type].explosion_type;
                            ListExplosions.Add(new ClassExplosions(explosion_type, -1, ListShipEnemys[i].position_x, ListShipEnemys[i].position_y));
                            // Sound explosion ausgeben
                            playSoundExplosionSmall = true;
                        }
                        // Wenn Energie nicht vollständig verbraucht, Sound Impact ausgeben
                        else
                        {
                            // Soundeffekt ausgeben
                            playSoundImpact = true;
                        }
                        // Schuss auf in die Löschliste schreiben
                        string[] temp_split = Regex.Split(";" + delete_string_shots, ";" + i2 + ";");
                        if (temp_split.Count() == 1)
                        {
                            delete_string_shots += i2 + ";";
                        }
                    }
                }
            }



            // Nicht mehr verwendete Schüsse löschen
            if (delete_string_shots.Length > 0)
            {
                string[] delete_split = Regex.Split(delete_string_shots, ";");
                for (int i = delete_split.Count() - 2; i >= 0; i--)
                {
                    try
                    {
                        ListMyShots.RemoveAt(Convert.ToInt32(delete_split[i]));
                    }
                    catch
                    { }
                }
            }



            // Nicht mehr verwendete Gegner löschen
            if (delete_string_enemys.Length > 0)
            {
                string[] delete_split = Regex.Split(delete_string_enemys, ";");
                for (int i = delete_split.Count() - 2; i >= 0; i--)
                {
                    try
                    {
                        ListShipEnemys.RemoveAt(Convert.ToInt32(delete_split[i]));
                    }
                    catch
                    { }
                }
            }
            // **************************************************************************************************************





            // Hitboxen eigener Schüsse mit Hitbox von Endboss abgleichen
            // **************************************************************************************************************
            // Variabeln zurücksetzen
            delete_string_shots = "";
            // Wenn Endboss Szenario
            if (BossSzenario == true & BossEnergie > 0)
            {
                int Boss_x_start = Boss_X - (Boss_Hitbox_Width / 2);
                int Boss_x_end = Boss_x_start + Boss_Hitbox_Width;
                int Boss_y_start = Boss_Y - (Boss_Hitbox_Height / 2);
                int Boss_y_end = Boss_y_start + Boss_Hitbox_Height;
                // Liste aller eigener Schüsse durchlaufen
                for (int i2 = 0; i2 < ListMyShots.Count(); i2++)
                {
                    // Schuss Hitbox Koordinaten laden
                    int Shot_x_start = ListMyShots[i2].hitbox_x;
                    int Shot_x_end = Shot_x_start + ListMyShots[i2].hitbox_width;
                    int Shot_y_start = ListMyShots[i2].hitbox_y;
                    int Shot_y_end = Shot_y_start + ListMyShots[i2].hitbox_height;

                    // Hitboxen abgleichen
                    if (Match_Hitboxes(Boss_x_start, Boss_x_end, Boss_y_start, Boss_y_end, Shot_x_start, Shot_x_end, Shot_y_start, Shot_y_end) == true)
                    {
                        // Energie abziehen
                        int damage = 0;
                        if (ListMyShots[i2].type == "Fire")
                        {
                            damage = MyShotFireDamage;
                        }
                        if (ListMyShots[i2].type == "Phaser")
                        {
                            damage = MyShotPhaserDamage;
                        }
                        if (ListMyShots[i2].type == "Laser")
                        {
                            damage = MyShotLaserDamage;
                        }
                        BossEnergie = BossEnergie - damage;
                        // Punkte erhöhen
                        Points += damage;

                        // Soundeffekt ausgeben
                        playSoundImpact = true;

                        // Schuss auf in die Löschliste schreiben
                        string[] temp_split = Regex.Split(";" + delete_string_shots, ";" + i2 + ";");
                        if (temp_split.Count() == 1)
                        {
                            delete_string_shots += i2 + ";";
                        }
                    }
                }
            }



            // Nicht mehr verwendete Schüsse löschen
            if (delete_string_shots.Length > 0)
            {
                string[] delete_split = Regex.Split(delete_string_shots, ";");
                for (int i = delete_split.Count() - 2; i >= 0; i--)
                {
                    try
                    {
                        ListMyShots.RemoveAt(Convert.ToInt32(delete_split[i]));
                    }
                    catch
                    { }
                }
            }
            // **************************************************************************************************************





            // Hitboxen erweiterter Schüsse, Raketen mit Hitboxen von Gegnern abgleichen
            // **************************************************************************************************************
            delete_string_enemys = "";
            delete_string_shots = "";
            // Liste aller Gegner durchlaufen
            for (int i = 0; i < ListShipEnemys.Count(); i++)
            {
                // Gegner Hitbox Koordinaten laden
                int Enemy_x_start = ListShipEnemys[i].hitbox_x;
                int Enemy_x_end = Enemy_x_start + ListShipEnemys[i].hitbox_width;
                int Enemy_y_start = ListShipEnemys[i].hitbox_y;
                int Enemy_y_end = Enemy_y_start + ListShipEnemys[i].hitbox_height;
                // Liste aller eigener Schüsse durchlaufen
                for (int i2 = 0; i2 < ListMyShotRocket.Count(); i2++)
                {
                    // Schuss Hitbox Koordinaten laden
                    int Shot_x_start = ListMyShotRocket[i2].x - (texMyShotRocket.Width / 2);
                    int Shot_x_end = Shot_x_start + texMyShotRocket.Width;
                    int Shot_y_start = ListMyShotRocket[i2].y - (texMyShotRocket.Height / 2);
                    int Shot_y_end = Shot_y_start + texMyShotRocket.Height;

                    // Hitboxen abgleichen
                    if (Match_Hitboxes(Enemy_x_start, Enemy_x_end, Enemy_y_start, Enemy_y_end, Shot_x_start, Shot_x_end, Shot_y_start, Shot_y_end) == true)
                    {
                        // Energie abziehen
                        ListShipEnemys[i].energy = ListShipEnemys[i].energy - MyShotRocketDamage;
                        // Punkte erhöhen
                        Points += MyShotRocketDamage;

                        // Wenn Energie verbraucht, Gegner löschen und Explosion erstellen
                        if (ListShipEnemys[i].energy <= 0)
                        {
                            // Wenn Gegner einer Gruppe Angehört, Abschüsse erhöhen
                            string[] split_groups = Regex.Split(ListShipEnemys[i].group_data, ";");
                            // Einzelne Gruppen des Gegners durchlaufen
                            for (int i3 = 0; i3 < split_groups.Count(); i3++)
                            {
                                // Wenn Gruppendaten vorhanden
                                if (split_groups[i3].Trim().Length > 0)
                                {
                                    // Gruppendaten ermitteln
                                    string[] group_datas = Regex.Split(split_groups[i3], ":");
                                    // Prüfen welche Gruppe
                                    for (int i4 = 0; i4 < ListEnemyGroups.Count(); i4++)
                                    {
                                        // Gruppen durchlaufen und prüfen welcher Gruppe angehört 
                                        if (ListEnemyGroups[i4].ID == Convert.ToInt32(group_datas[0]))
                                        {
                                            // Kills der Gruppe erhöhen
                                            ListEnemyGroups[i4].kills++;
                                            // Wenn anderes PowerUp vorhanden
                                            string powerUp = "Random";
                                            if (group_datas.Count() > 2)
                                            {
                                                if (group_datas[2].Trim() != "")
                                                {
                                                    ListEnemyGroups[i4].powerUp = group_datas[2];
                                                }
                                            }
                                            if (ListEnemyGroups[i4].powerUp.Trim() != "")
                                            {
                                                powerUp = ListEnemyGroups[i4].powerUp;
                                            }

                                            // Wenn PowerUp ausgegeben wird
                                            if (ListEnemyGroups[i4].kills == ListEnemyGroups[i4].killsForPowerUp)
                                            {
                                                // Wenn PowerUp Random
                                                if (powerUp == "Random")
                                                {
                                                    // Random Zahl erzeugen
                                                    Random rand = new Random();
                                                    int index_temp = rand.Next(1, 83);
                                                    // Powerup Fire erzeugen
                                                    if (index_temp < 21)
                                                    {
                                                        powerUp = "Fire";
                                                    }
                                                    // Powerup Phaser erzeugen
                                                    else if (index_temp < 41)
                                                    {
                                                        powerUp = "Phaser";
                                                    }
                                                    // Powerup Rocket erzeugen
                                                    else if (index_temp < 61)
                                                    {
                                                        powerUp = "Rocket";
                                                    }
                                                    // Powerup Laser erzeugen
                                                    else if (index_temp < 81)
                                                    {
                                                        powerUp = "Laser";
                                                    }
                                                    // PowerUp OneUp erzeugen
                                                    else
                                                    {
                                                        powerUp = "OneUp";
                                                    }
                                                }
                                                // Bei mehreren Powerups, Position des Powerups bestimmen
                                                int powerupX = 0;
                                                int powerupY = 0;
                                                if (i4 == 0)
                                                {
                                                    powerupY = 30;
                                                }
                                                else if (i4 == 1)
                                                {
                                                    powerupY = -30;
                                                }
                                                else if (i4 == 2)
                                                {
                                                    powerupX = 30;
                                                }
                                                else if (i4 == 3)
                                                {
                                                    powerupX = -30;
                                                }
                                                // PowerUp ausgeben
                                                ListPowerUps.Add(new ClassPowerUps(powerUp, (ListShipEnemys[i].position_x + powerupX), (ListShipEnemys[i].position_y + powerupY)));
                                            }
                                            break;
                                        }
                                    }
                                }
                            }

                            // Prüfen ob Gegner bereits als Gelöscht eingetragen
                            string[] tempTest = Regex.Split(";" + delete_string_enemys, ";" + i + ";");
                            if (tempTest.Count() == 1)
                            {
                                // Gegner löschen
                                delete_string_enemys += i + ";";
                            }
                            // Explosion erstellen
                            string explosion_type = ListEnemys[ListShipEnemys[i].enemy_type].explosion_type;
                            ListExplosions.Add(new ClassExplosions(explosion_type, -1, ListShipEnemys[i].position_x, ListShipEnemys[i].position_y));
                            // Sound explosion ausgeben
                            playSoundExplosionSmall = true;
                        }
                        // Wenn Energie nicht vollständig verbraucht, Sound Impact ausgeben
                        else
                        {
                            // Soundeffekt ausgeben
                            playSoundImpact = true;
                        }
                        // Schuss auf in die Löschliste schreiben
                        string[] temp_split = Regex.Split(";" + delete_string_shots, ";" + i2 + ";");
                        if (temp_split.Count() == 1)
                        {
                            delete_string_shots += i2 + ";";
                        }
                    }
                }
            }



            // Nicht mehr verwendete Schüsse löschen
            if (delete_string_shots.Length > 0)
            {
                string[] delete_split = Regex.Split(delete_string_shots, ";");
                for (int i = delete_split.Count() - 2; i >= 0; i--)
                {
                    try
                    {
                        ListMyShotRocket.RemoveAt(Convert.ToInt32(delete_split[i]));
                    }
                    catch
                    { }
                }
            }



            // Nicht mehr verwendete Gegner löschen
            if (delete_string_enemys.Length > 0)
            {
                string[] delete_split = Regex.Split(delete_string_enemys, ";");
                for (int i = delete_split.Count() - 2; i >= 0; i--)
                {
                    try
                    {
                        ListShipEnemys.RemoveAt(Convert.ToInt32(delete_split[i]));
                    }
                    catch
                    { }
                }
            }
            // **************************************************************************************************************





            // Hitboxen erweiterter Schüsse mit Hitbox von Endboss abgleichen
            // **************************************************************************************************************
            // Variabeln zurücksetzen
            delete_string_shots = "";
            // Wenn Endboss Szenario
            if (BossSzenario == true & BossEnergie > 0)
            {
                // Boss Hitbox erstellen
                int Boss_x_start = Boss_X - (Boss_Hitbox_Width / 2);
                int Boss_x_end = Boss_x_start + Boss_Hitbox_Width;
                int Boss_y_start = Boss_Y - (Boss_Hitbox_Height / 2);
                int Boss_y_end = Boss_y_start + Boss_Hitbox_Height;
                // Liste aller eigener Schüsse durchlaufen
                for (int i2 = 0; i2 < ListMyShotRocket.Count(); i2++)
                {
                    // Schuss Hitbox Koordinaten laden
                    int Shot_x_start = ListMyShotRocket[i2].x - (texMyShotRocket.Width / 2);
                    int Shot_x_end = Shot_x_start + texMyShotRocket.Width;
                    int Shot_y_start = ListMyShotRocket[i2].y - (texMyShotRocket.Height / 2);
                    int Shot_y_end = Shot_y_start + texMyShotRocket.Height;

                    // Hitboxen abgleichen
                    if (Match_Hitboxes(Boss_x_start, Boss_x_end, Boss_y_start, Boss_y_end, Shot_x_start, Shot_x_end, Shot_y_start, Shot_y_end) == true)
                    {
                        // Energie abziehen
                        BossEnergie = BossEnergie - MyShotRocketDamage;
                        // Punkte erhöhen
                        Points += MyShotRocketDamage;

                        // Soundeffekt ausgeben
                        playSoundImpact = true;

                        // Schuss auf in die Löschliste schreiben
                        string[] temp_split = Regex.Split(";" + delete_string_shots, ";" + i2 + ";");
                        if (temp_split.Count() == 1)
                        {
                            delete_string_shots += i2 + ";";
                        }
                    }
                }
            }



            // Nicht mehr verwendete Schüsse löschen
            if (delete_string_shots.Length > 0)
            {
                string[] delete_split = Regex.Split(delete_string_shots, ";");
                for (int i = delete_split.Count() - 2; i >= 0; i--)
                {
                    try
                    {
                        ListMyShotRocket.RemoveAt(Convert.ToInt32(delete_split[i]));
                    }
                    catch
                    { }
                }
            }
            // **************************************************************************************************************





            // Hitboxen des Powerschusses mit Hitbox der Gegner abgleichen
            // **************************************************************************************************************
            delete_string_enemys = "";
            if (PowerShotAnimation == true)
            {
                // Powerschuss Hitbox laden
                int PowerShot_x_start = PowerShotHitboxX;
                int PowerShot_x_end = PowerShot_x_start + PowerShotHitboxWidth;
                int PowerShot_y_start = PowerShotHitboxY;
                int PowerShot_y_end = PowerShot_y_start + PowerShotHitboxHeight;

                // Liste aller Gegner durchlaufen
                for (int i = 0; i < ListShipEnemys.Count(); i++)
                {
                    // Gegner Hitbox Koordinaten laden
                    int Enemy_x_start = ListShipEnemys[i].hitbox_x;
                    int Enemy_x_end = Enemy_x_start + ListShipEnemys[i].hitbox_width;
                    int Enemy_y_start = ListShipEnemys[i].hitbox_y;
                    int Enemy_y_end = Enemy_y_start + ListShipEnemys[i].hitbox_height;

                    // Hitboxen abgleichen
                    if (Match_Hitboxes(PowerShot_x_start, PowerShot_x_end, PowerShot_y_start, PowerShot_y_end, Enemy_x_start, Enemy_x_end, Enemy_y_start, Enemy_y_end) == true)
                    {
                        // Energie abziehen
                        ListShipEnemys[i].energy = ListShipEnemys[i].energy - PowerShotDamage;
                        // Punkte erhöhen
                        Points += PowerShotDamage;

                        // Wenn Energie verbraucht, Gegner löschen und Explosion erstellen
                        if (ListShipEnemys[i].energy <= 0)
                        {
                            // Wenn Gegner einer Gruppe Angehört, Abschüsse erhöhen
                            string[] split_groups = Regex.Split(ListShipEnemys[i].group_data, ";");
                            // Einzelne Gruppen des Gegners durchlaufen
                            for (int i3 = 0; i3 < split_groups.Count(); i3++)
                            {
                                // Wenn Gruppendaten vorhanden
                                if (split_groups[i3].Trim().Length > 0)
                                {
                                    // Gruppendaten ermitteln
                                    string[] group_datas = Regex.Split(split_groups[i3], ":");
                                    // Prüfen welche Gruppe
                                    for (int i4 = 0; i4 < ListEnemyGroups.Count(); i4++)
                                    {
                                        // Gruppen durchlaufen und prüfen welcher Gruppe angehört 
                                        if (ListEnemyGroups[i4].ID == Convert.ToInt32(group_datas[0]))
                                        {
                                            // Kills der Gruppe erhöhen
                                            ListEnemyGroups[i4].kills++;
                                            // Wenn anderes PowerUp vorhanden
                                            string powerUp = "Random";
                                            if (group_datas.Count() > 2)
                                            {
                                                if (group_datas[2].Trim() != "")
                                                {
                                                    ListEnemyGroups[i4].powerUp = group_datas[2];
                                                }
                                            }
                                            if (ListEnemyGroups[i4].powerUp.Trim() != "")
                                            {
                                                powerUp = ListEnemyGroups[i4].powerUp;
                                            }

                                            // Wenn PowerUp ausgegeben wird
                                            if (ListEnemyGroups[i4].kills == ListEnemyGroups[i4].killsForPowerUp)
                                            {
                                                // Wenn PowerUp Random
                                                if (powerUp == "Random")
                                                {
                                                    // Random Zahl erzeugen
                                                    Random rand = new Random();
                                                    int index_temp = rand.Next(1, 83);
                                                    // Powerup Fire erzeugen
                                                    if (index_temp < 21)
                                                    {
                                                        powerUp = "Fire";
                                                    }
                                                    // Powerup Phaser erzeugen
                                                    else if (index_temp < 41)
                                                    {
                                                        powerUp = "Phaser";
                                                    }
                                                    // Powerup Rocket erzeugen
                                                    else if (index_temp < 61)
                                                    {
                                                        powerUp = "Rocket";
                                                    }
                                                    // Powerup Laser erzeugen
                                                    else if (index_temp < 81)
                                                    {
                                                        powerUp = "Laser";
                                                    }
                                                    // PowerUp OneUp erzeugen
                                                    else
                                                    {
                                                        powerUp = "OneUp";
                                                    }
                                                }
                                                // Bei mehreren Powerups, Position des Powerups bestimmen
                                                int powerupX = 0;
                                                int powerupY = 0;
                                                if (i4 == 0)
                                                {
                                                    powerupY = 30;
                                                }
                                                else if (i4 == 1)
                                                {
                                                    powerupY = -30;
                                                }
                                                else if (i4 == 2)
                                                {
                                                    powerupX = 30;
                                                }
                                                else if (i4 == 3)
                                                {
                                                    powerupX = -30;
                                                }
                                                // PowerUp ausgeben
                                                ListPowerUps.Add(new ClassPowerUps(powerUp, (ListShipEnemys[i].position_x + powerupX), (ListShipEnemys[i].position_y + powerupY)));
                                            }
                                            break;
                                        }
                                    }
                                }
                            }

                            // Prüfen ob Gegner bereits als Gelöscht eingetragen
                            string[] tempTest = Regex.Split(";" + delete_string_enemys, ";" + i + ";");
                            if (tempTest.Count() == 1)
                            {
                                // Gegner löschen
                                delete_string_enemys += i + ";";
                            }
                            // Explosion erstellen
                            string explosion_type = ListEnemys[ListShipEnemys[i].enemy_type].explosion_type;
                            ListExplosions.Add(new ClassExplosions(explosion_type, -1, ListShipEnemys[i].position_x, ListShipEnemys[i].position_y));
                            // Sound explosion ausgeben
                            playSoundExplosionSmall = true;
                        }
                        // Wenn Energie nicht vollständig verbraucht, Sound Impact ausgeben
                        else
                        {
                            // Soundeffekt ausgeben
                            playSoundImpact = true;
                        }
                    }
                }



                // Nicht mehr verwendete Gegner löschen
                if (delete_string_enemys.Length > 0)
                {
                    string[] delete_split = Regex.Split(delete_string_enemys, ";");
                    for (int i = delete_split.Count() - 2; i >= 0; i--)
                    {
                        try
                        {
                            ListShipEnemys.RemoveAt(Convert.ToInt32(delete_split[i]));
                        }
                        catch
                        { }
                    }
                }
            }
            // **************************************************************************************************************





            // Hitboxen des Powerschusses mit Hitbox von Endboss abgleichen
            // **************************************************************************************************************
            // Variabeln zurücksetzen
            delete_string_shots = "";
            // Wenn Endboss Szenario
            if (BossSzenario == true & PowerShotAnimation == true & BossEnergie > 0)
            {
                // Powerschuss Hitbox laden
                int PowerShot_x_start = PowerShotHitboxX;
                int PowerShot_x_end = PowerShot_x_start + PowerShotHitboxWidth;
                int PowerShot_y_start = PowerShotHitboxY;
                int PowerShot_y_end = PowerShot_y_start + PowerShotHitboxHeight;

                // Endboss Hitbox laden
                int Boss_x_start = Boss_X - (Boss_Hitbox_Width / 2);
                int Boss_x_end = Boss_x_start + Boss_Hitbox_Width;
                int Boss_y_start = Boss_Y - (Boss_Hitbox_Height / 2);
                int Boss_y_end = Boss_y_start + Boss_Hitbox_Height;

                // Hitboxen abgleichen
                if (Match_Hitboxes(PowerShot_x_start, PowerShot_x_end, PowerShot_y_start, PowerShot_y_end, Boss_x_start, Boss_x_end, Boss_y_start, Boss_y_end) == true)
                {
                    // Energie abziehen
                    BossEnergie = BossEnergie - PowerShotDamage;
                    // Punkte erhöhen
                    Points += PowerShotDamage;
                }
            }
            // **************************************************************************************************************





            // Gegnerische Schüsse berechnen
            // **************************************************************************************************************
            // Neue gegnerische Schüsse erstellen // Gegner durchlaufen
            for (int i = 0; i < ListShipEnemys.Count(); i++)
            {
                // Wenn Schussdaten vorhanden
                if (ListShipEnemys[i].shot_data.Length > 0)
                {
                    // Variabeln erstellen
                    int way_frame = FrameCount - ListShipEnemys[i].frame_start;
                    // Schussdaten auflösen und Schüsse erstellen
                    string[] split_all_shots_data = Regex.Split(ListShipEnemys[i].shot_data, ";");
                    // Einzelne Schüsse durchlaufen
                    for (int i3 = 0; i3 < split_all_shots_data.Count(); i3++)
                    {
                        // Einzelnen Schuss Daten ermitteln
                        string[] split_shot_data = Regex.Split(split_all_shots_data[i3], ":");
                        // Wenn Wegframe erreicht
                        if (Convert.ToInt32(split_shot_data[0]) == way_frame)
                        {
                            // Wenn Schuss typ 1 --> Direkter Schuss --> Erzeugt Schuss in der Klasse <ClassEnemyShotDirect>
                            if (Convert.ToInt32(split_shot_data[1]) == 1)
                            {
                                // Gegnerischen Schuss ermitteln
                                CreateEnemyShot1(Convert.ToDouble(ListShipEnemys[i].position_x), Convert.ToDouble(ListShipEnemys[i].position_y), Convert.ToInt32(split_shot_data[2]));
                                // Schüsse in Klasse <ClassShipEnemys> erhöhen
                                ListShipEnemys[i].shot_number = ListShipEnemys[i].shot_number + 1;

                                // Sound ausgeben
                                playSoundEnemyShot1 = true;
                            }

                            // Wenn Schuss typ 3 --> Großer Direkter Schuss --> Erzeugt Schuss in der Klasse <ClassEnemyShotDirect>
                            if (Convert.ToInt32(split_shot_data[1]) == 3)
                            {
                                // Gegnerischen Schuss ermitteln
                                CreateEnemyShot3(Convert.ToDouble(ListShipEnemys[i].position_x), Convert.ToDouble(ListShipEnemys[i].position_y), Convert.ToInt32(split_shot_data[2]));
                                // Schüsse in Klasse <ClassShipEnemys> erhöhen
                                ListShipEnemys[i].shot_number = ListShipEnemys[i].shot_number + 1;

                                // Sound ausgeben
                                playSoundEnemyShot3 = true;
                            }

                            // Wenn Schuss typ 2 --> Dreifach Schuss --> Erzeugt drei Schüsse in der Klasse <ClassEnemyShotDirect>
                            else if (Convert.ToInt32(split_shot_data[1]) == 2)
                            {
                                // Gegnerischen Schuss ermitteln
                                CreateEnemyShot2(Convert.ToDouble(ListShipEnemys[i].position_x), Convert.ToDouble(ListShipEnemys[i].position_y), Convert.ToInt32(split_shot_data[2]));
                                // Schüsse in Klasse <ClassShipEnemys> erhöhen
                                ListShipEnemys[i].shot_number = ListShipEnemys[i].shot_number + 1;

                                // Sound ausgeben
                                playSoundEnemyShot1 = true;
                            }

                            // Wenn Schuss typ 10, 11, 12 --> Laser Schuss --> Erzeugt einen Schuss in der Klasse <ClassEnemyShotLaser>
                            else if (Convert.ToInt32(split_shot_data[1]) == 10 | Convert.ToInt32(split_shot_data[1]) == 11 | Convert.ToInt32(split_shot_data[1]) == 12)
                            {
                                int temp_type = 1;
                                if (Convert.ToInt32(split_shot_data[1]) == 11)
                                {
                                    temp_type = 2;
                                }
                                else if (Convert.ToInt32(split_shot_data[1]) == 12)
                                {
                                    temp_type = 3;
                                }
                                // Gegnerischen Schuss ermitteln
                                CreateShotEnemyLaser(temp_type, Convert.ToDouble(ListShipEnemys[i].position_x), Convert.ToDouble(ListShipEnemys[i].position_y), Convert.ToInt32(split_shot_data[2]));
                                // Schüsse in Klasse <ClassShipEnemys> erhöhen
                                ListShipEnemys[i].shot_number = ListShipEnemys[i].shot_number + 1;
                                // Sound ausgeben
                                playSoundEnemyShot2 = true;
                            }

                            // Wenn Schuss typ 13 --> Drehschuß Rechts --> Erzeugt mehrere Schüsse, die sich drehen in der Klasse <ClassEnemyShotDirect>
                            else if (Convert.ToInt32(split_shot_data[1]) == 13)
                            {
                                // Auslesen der wievielte Schuß es ist
                                int shotNumberTemp = ListShipEnemys[i].shot_number;
                                // Gegnerischen Schuss ermitteln
                                CreateEnemyShot13(Convert.ToDouble(ListShipEnemys[i].position_x), Convert.ToDouble(ListShipEnemys[i].position_y), shotNumberTemp, Convert.ToInt32(split_shot_data[2]));
                                // Schüsse in Klasse <ClassShipEnemys> erhöhen
                                ListShipEnemys[i].shot_number = ListShipEnemys[i].shot_number + 1;

                                // Sound ausgeben
                                playSoundEnemyShot1 = true;
                            }

                            // Wenn Schuss typ 14 --> Drehschuß Links --> Erzeugt mehrere Schüsse, die sich drehen in der Klasse <ClassEnemyShotDirect>
                            else if (Convert.ToInt32(split_shot_data[1]) == 14)
                            {
                                // Auslesen der wievielte Schuß es ist
                                int shotNumberTemp = ListShipEnemys[i].shot_number;
                                // Gegnerischen Schuss ermitteln
                                CreateEnemyShot14(Convert.ToDouble(ListShipEnemys[i].position_x), Convert.ToDouble(ListShipEnemys[i].position_y), shotNumberTemp, Convert.ToInt32(split_shot_data[2]));
                                // Schüsse in Klasse <ClassShipEnemys> erhöhen
                                ListShipEnemys[i].shot_number = ListShipEnemys[i].shot_number + 1;

                                // Sound ausgeben
                                playSoundEnemyShot1 = true;
                            }
                        }
                    }
                }
            }





            // Gegnerische Schüsse // Durchlaufen und bewegen // Shuss Typ 1 // Direkter Schuss
            delete_string = "";
            // Schuss typ 1, Liste durchlaufen
            for (int i = 0; i < ListEnemyShotDirect.Count(); i++)
            {
                // Schuss, Bewegung erstellen
                double x = ListEnemyShotDirect[i].x;
                double y = ListEnemyShotDirect[i].y;
                x = x + ListEnemyShotDirect[i].x_way;
                y = y + ListEnemyShotDirect[i].y_way;
                ListEnemyShotDirect[i].x = x;
                ListEnemyShotDirect[i].y = y;
                ListEnemyShotDirect[i].hitbox_x = Convert.ToInt32(x) - (ListEnemyShotDirect[i].hitbox_width / 2);
                ListEnemyShotDirect[i].hitbox_y = Convert.ToInt32(y) - (ListEnemyShotDirect[i].hitbox_height / 2);
                if (ListEnemyShotDirect[i].angel == 3)
                {
                    ListEnemyShotDirect[i].angel = 1;
                }
                else
                {
                    ListEnemyShotDirect[i].angel++;
                }
                // Nicht mehr verwendete Schüsse auf die Löschliste
                if (ListEnemyShotDirect[i].x > 520 | ListEnemyShotDirect[i].x < -50 | ListEnemyShotDirect[i].y > 850 | ListEnemyShotDirect[i].y < -50)
                {
                    delete_string += i + ";";
                }
            }

            // Nicht mehr verwendete Schüsse löschen
            if (delete_string.Length > 0)
            {
                string[] delete_split = Regex.Split(delete_string, ";");
                for (int i = delete_split.Count() - 2; i >= 0; i--)
                {
                    ListEnemyShotDirect.RemoveAt(Convert.ToInt32(delete_split[i]));
                }
            }




            // Gegnerische Schüsse // Durchlaufen und bewegen // Shuss Typ 2 // Laser Schuss
            delete_string = "";
            // Schuss typ 2, Liste durchlaufen
            for (int i = 0; i < ListEnemyShotLaser.Count(); i++)
            {
                // Schuss um die Geschwindigkeit nach unten bewegen
                ListEnemyShotLaser[i].y += ListEnemyShotLaser[i].speed;

                // Nicht mehr verwendete Schüsse auf die Löschliste
                if (ListEnemyShotLaser[i].y > 880)
                {
                    delete_string += i + ";";
                }
            }

            // Nicht mehr verwendete Schüsse löschen
            if (delete_string.Length > 0)
            {
                string[] delete_split = Regex.Split(delete_string, ";");
                for (int i = delete_split.Count() - 2; i >= 0; i--)
                {
                    ListEnemyShotLaser.RemoveAt(Convert.ToInt32(delete_split[i]));
                }
            }
            // **************************************************************************************************************





            // Gegnerische Schüsse Durchlaufen und Prüfen ob sie durch Powerschuss gelöscht werden
            // **************************************************************************************************************
            if (PowerShotAnimation == true)
            {
                // Daten Powerschuss Hitbox  erstellen
                int PowerShot_x_start = PowerShotHitboxX;
                int PowerShot_y_start = PowerShotHitboxY;
                int PowerShot_x_end = PowerShot_x_start + PowerShotHitboxWidth;
                int PowerShot_y_end = PowerShot_y_start + PowerShotHitboxHeight;



                // Liste der zu löschenden Schüsse leeren
                delete_string_shots = "";

                // Liste Schuss 1 <ListShotEnemyDirect> durchlaufen
                for (int i = 0; i < ListEnemyShotDirect.Count(); i++)
                {
                    // Gegnerische Schüsse Daten auslesen und erstellen
                    int shot_x_start = ListEnemyShotDirect[i].hitbox_x;
                    int shot_x_end = shot_x_start + ListEnemyShotDirect[i].hitbox_width;
                    int shot_y_start = ListEnemyShotDirect[i].hitbox_y;
                    int shot_y_end = shot_y_start + ListEnemyShotDirect[i].hitbox_height;

                    // Hiboxen abgleichen
                    if (Match_Hitboxes(PowerShot_x_start, PowerShot_x_end, PowerShot_y_start, PowerShot_y_end, shot_x_start, shot_x_end, shot_y_start, shot_y_end) == true)
                    {
                        // Gegnerischen Schuss löschen
                        string[] temp_Split = Regex.Split(";" + delete_string_shots, ";" + i.ToString() + ";");
                        if (temp_Split.Count() == 1)
                        {
                            delete_string_shots += i.ToString() + ";";
                        }

                        // Powerschussladung durch gelöschte Schüsse erhöhen
                        MyShip_PowerShot_Loading++;
                    }
                }

                // Nicht mehr verwendete Schüsse löschen
                if (delete_string_shots.Length > 0)
                {
                    string[] delete_split = Regex.Split(delete_string_shots, ";");
                    for (int i = delete_split.Count() - 2; i >= 0; i--)
                    {
                        ListEnemyShotDirect.RemoveAt(Convert.ToInt32(delete_split[i]));
                    }
                }



                // Liste der zu löschenden Schüsse leeren
                delete_string_shots = "";

                // Liste Schuss 2 <ListShotEnemyLaser> durchlaufen
                for (int i = 0; i < ListEnemyShotLaser.Count(); i++)
                {
                    // Gegnerische Schüsse Daten auslesen und erstellen
                    int shot_x_start = Convert.ToInt32(ListEnemyShotLaser[i].x) - (ListEnemyShotLaser[i].texture.Width / 2);
                    int shot_x_end = shot_x_start + ListEnemyShotLaser[i].texture.Width;
                    int shot_y_start = Convert.ToInt32(ListEnemyShotLaser[i].y);
                    int shot_y_end = shot_y_start + ListEnemyShotLaser[i].texture.Height;

                    // Hiboxen abgleichen
                    if (Match_Hitboxes(PowerShot_x_start, PowerShot_x_end, PowerShot_y_start, PowerShot_y_end, shot_x_start, shot_x_end, shot_y_start, shot_y_end) == true)
                    {
                        // Gegnerischen Schuss löschen
                        string[] temp_Split = Regex.Split(";" + delete_string_shots, ";" + i.ToString() + ";");
                        if (temp_Split.Count() == 1)
                        {
                            delete_string_shots += i.ToString() + ";";
                        }

                        // Powerschussladung durch gelöschte Schüsse erhöhen
                        MyShip_PowerShot_Loading = MyShip_PowerShot_Loading + 3;
                    }
                }

                // Nicht mehr verwendete Schüsse löschen
                if (delete_string_shots.Length > 0)
                {
                    string[] delete_split = Regex.Split(delete_string_shots, ";");
                    for (int i = delete_split.Count() - 2; i >= 0; i--)
                    {
                        ListEnemyShotLaser.RemoveAt(Convert.ToInt32(delete_split[i]));
                    }
                }
            }
            // **************************************************************************************************************





            // Gegnerische Treffer Ermitteln // Und Aufladung des Powerschusses errechnen
            // **************************************************************************************************************
            // Variablen erstellen
            bool PowerShot_Load = false;

            // Wenn Schiff aktiv ist
            if (MyShipIsActive == true)
            {
                // Daten von eingenem Schiff auslesen und erstellen // Todes-Hitbox
                int MyShip_x_start = MyShip_Hitbox_X;
                int MyShip_y_start = MyShip_Hitbox_Y;
                int MyShip_x_end = MyShip_x_start + MyShip_Hitbox_Width;
                int MyShip_y_end = MyShip_y_start + MyShip_Hitbox_Height;


                // Daten von eingenem Schiff auslesen und erstellen // Hitbox Powerschuss X 1
                int MyShip_PowerShot_x_start = MyShip_PowerShot_Hitbox_X;
                int MyShip_PowerShot_y_start = MyShip_PowerShot_Hitbox_Y;
                int MyShip_PowerShot_x_end = MyShip_PowerShot_x_start + MyShip_PowerShot_Hitbox_Width;
                int MyShip_PowerShot_y_end = MyShip_PowerShot_y_start + MyShip_PowerShot_Hitbox_Height;


                // Daten von eingenem Schiff auslesen und erstellen // Hitbox Powerschuss X 2
                int MyShip_PowerShot_x_start_2 = MyShip_PowerShot_Hitbox_X_2;
                int MyShip_PowerShot_y_start_2 = MyShip_PowerShot_Hitbox_Y_2;
                int MyShip_PowerShot_x_end_2 = MyShip_PowerShot_x_start_2 + MyShip_PowerShot_Hitbox_Width_2;
                int MyShip_PowerShot_y_end_2 = MyShip_PowerShot_y_start_2 + MyShip_PowerShot_Hitbox_Height_2;



                // Liste der zu löschenden Schüsse leeren
                delete_string_shots = "";

                // Liste Schuss 1 <ListShotEnemyDirect> durchlaufen
                for (int i = 0; i < ListEnemyShotDirect.Count(); i++)
                {
                    // Gegnerische Schüsse Daten auslesen und erstellen
                    int shot_x_start = ListEnemyShotDirect[i].hitbox_x;
                    int shot_x_end = shot_x_start + ListEnemyShotDirect[i].hitbox_width;
                    int shot_y_start = ListEnemyShotDirect[i].hitbox_y;
                    int shot_y_end = shot_y_start + ListEnemyShotDirect[i].hitbox_height;


                    // Innere PowerShot Hitbox prüfen // X 2
                    if (Match_Hitboxes(MyShip_PowerShot_x_start_2, MyShip_PowerShot_x_end_2, MyShip_PowerShot_y_start_2, MyShip_PowerShot_y_end_2, shot_x_start, shot_x_end, shot_y_start, shot_y_end) == true)
                    {
                        // Wenn Schuss noch nicht vollständig aufgeladen
                        if (MyShip_PowerShot_Loading < MyShip_PowerShot_Max_Loading)
                        {
                            MyShip_PowerShot_Loading = MyShip_PowerShot_Loading + 2;
                            MyShip_PowerShot_Load = MyShip_PowerShot_Load + 2;
                            PowerShot_Load = true;
                        }
                        else
                        {
                            MyShip_PowerShots++;
                            MyShip_PowerShot_Loading = 0;
                            Points = Points + (MyShip_PowerShot_Load * MyShip_PowerShot_Load);
                            MyShip_PowerShot_Load = 0;
                            playSoundPowerShotReady = true;
                        }
                        // Ladebalken, Länge berechnen
                        double t_percent = Convert.ToDouble(100) / Convert.ToDouble(MyShip_PowerShot_Max_Loading) * Convert.ToDouble(MyShip_PowerShot_Loading);
                        double t_width = Convert.ToDouble(225) / Convert.ToDouble(100) * t_percent;
                        MyShip_PowerShot_Width = Convert.ToInt32(t_width);
                    }

                    // Aussere PowerShot Hitbox prüfen // X 1 
                    if (Match_Hitboxes(MyShip_PowerShot_x_start, MyShip_PowerShot_x_end, MyShip_PowerShot_y_start, MyShip_PowerShot_y_end, shot_x_start, shot_x_end, shot_y_start, shot_y_end) == true)
                    {
                        // Wenn Schuss noch nicht vollständig aufgeladen
                        if (MyShip_PowerShot_Loading < MyShip_PowerShot_Max_Loading)
                        {
                            MyShip_PowerShot_Loading++;
                            MyShip_PowerShot_Load++;
                            PowerShot_Load = true;
                        }
                        else
                        {
                            MyShip_PowerShots++;
                            MyShip_PowerShot_Loading = 0;
                            playSoundPowerShotReady = true;
                            Points = Points + (MyShip_PowerShot_Load * MyShip_PowerShot_Load);
                            MyShip_PowerShot_Load = 0;
                        }
                        // Ladebalken, Länge berechnen
                        double t_percent = Convert.ToDouble(100) / Convert.ToDouble(MyShip_PowerShot_Max_Loading) * Convert.ToDouble(MyShip_PowerShot_Loading);
                        double t_width = Convert.ToDouble(225) / Convert.ToDouble(100) * t_percent;
                        MyShip_PowerShot_Width = Convert.ToInt32(t_width);
                    }


                    // Hitboxen, Gegnerische Schüsse mit Todes-Hitbox, eigenes Schiff abgleichen
                    if (Match_Hitboxes(MyShip_x_start, MyShip_x_end, MyShip_y_start, MyShip_y_end, shot_x_start, shot_x_end, shot_y_start, shot_y_end) == true)
                    {
                        // Wenn schiff nicht unzerstörbar
                        if (Indestructible == 0)
                        {
                            // Leben veringern
                            Lives--;
                            // PowerUps entfernen
                            if (MyShotType == "Fire")
                            {
                                if (MyShotFireLevel > 0)
                                {
                                    MyShotFireLevel--;
                                }
                            }
                            if (MyShotType == "Phaser")
                            {
                                if (MyShotPhaserLevel > 0)
                                {
                                    MyShotPhaserLevel--;
                                }
                            }
                            if (MyShotType == "Laser")
                            {
                                if (MyShotLaserLevel > 0)
                                {
                                    MyShotLaserLevel--;
                                }
                            }
                            if (MyExtensionType == "Rocket")
                            {
                                if (MyShotRocketLevel > 0)
                                {
                                    MyShotRocketLevel--;
                                }
                                else if (MyShotRocketLevel == 0)
                                {
                                    MyExtensionType = "None";
                                }
                            }

                            // Schiff auf inaktiv stellen
                            MyShipIsActive = false;
                            // Frames bis das schiff wider erseint erstellen
                            FramesToAppear = 60;
                            // Explosion erstellen
                            ListExplosions.Add(new ClassExplosions("Small", -1, MyShip_X, MyShip_Y));
                            // Sound explosion ausgeben
                            playSoundExplosionSmall = true;
                        }
                        // Gegnerischen Schuss löschen
                        string[] temp_Split = Regex.Split(";" + delete_string_shots, ";" + i.ToString() + ";");
                        if (temp_Split.Count() == 1)
                        {
                            delete_string_shots += i.ToString() + ";";
                        }
                    }
                }

                // Nicht mehr verwendete Schüsse löschen
                if (delete_string_shots.Length > 0)
                {
                    string[] delete_split = Regex.Split(delete_string_shots, ";");
                    for (int i = delete_split.Count() - 2; i >= 0; i--)
                    {
                        ListEnemyShotDirect.RemoveAt(Convert.ToInt32(delete_split[i]));
                    }
                }



                // Liste der zu löschenden Schüsse leeren
                delete_string_shots = "";

                // Liste Schuss 2 <ListShotEnemyLaser> durchlaufen
                for (int i = 0; i < ListEnemyShotLaser.Count(); i++)
                {
                    // Gegnerische Schüsse Daten auslesen und erstellen
                    int shot_x_start = Convert.ToInt32(ListEnemyShotLaser[i].x) - (ListEnemyShotLaser[i].texture.Width / 2);
                    int shot_x_end = shot_x_start + ListEnemyShotLaser[i].texture.Width;
                    int shot_y_start = Convert.ToInt32(ListEnemyShotLaser[i].y);
                    int shot_y_end = shot_y_start + ListEnemyShotLaser[i].texture.Height;


                    // Innere PowerShot Hitbox prüfen // X 2
                    if (Match_Hitboxes(MyShip_PowerShot_x_start_2, MyShip_PowerShot_x_end_2, MyShip_PowerShot_y_start_2, MyShip_PowerShot_y_end_2, shot_x_start, shot_x_end, shot_y_start, shot_y_end) == true)
                    {
                        // Wenn Schuss noch nicht vollständig aufgeladen
                        if (MyShip_PowerShot_Loading < MyShip_PowerShot_Max_Loading)
                        {
                            MyShip_PowerShot_Loading = MyShip_PowerShot_Loading + 2;
                            MyShip_PowerShot_Load = MyShip_PowerShot_Load + 2;
                            PowerShot_Load = true;
                        }
                        else
                        {
                            MyShip_PowerShots++;
                            MyShip_PowerShot_Loading = 0;
                            Points = Points + (MyShip_PowerShot_Load * MyShip_PowerShot_Load);
                            MyShip_PowerShot_Load = 0;
                            playSoundPowerShotReady = true;
                        }
                        // Ladebalken, Länge berechnen
                        double t_percent = Convert.ToDouble(100) / Convert.ToDouble(MyShip_PowerShot_Max_Loading) * Convert.ToDouble(MyShip_PowerShot_Loading);
                        double t_width = Convert.ToDouble(225) / Convert.ToDouble(100) * t_percent;
                        MyShip_PowerShot_Width = Convert.ToInt32(t_width);
                    }

                    // Aussere PowerShot Hitbox prüfen // X 1 
                    if (Match_Hitboxes(MyShip_PowerShot_x_start, MyShip_PowerShot_x_end, MyShip_PowerShot_y_start, MyShip_PowerShot_y_end, shot_x_start, shot_x_end, shot_y_start, shot_y_end) == true)
                    {
                        // Wenn Schuss noch nicht vollständig aufgeladen
                        if (MyShip_PowerShot_Loading < MyShip_PowerShot_Max_Loading)
                        {
                            MyShip_PowerShot_Loading++;
                            MyShip_PowerShot_Load++;
                            PowerShot_Load = true;
                        }
                        else
                        {
                            MyShip_PowerShots++;
                            MyShip_PowerShot_Loading = 0;
                            playSoundPowerShotReady = true;
                            Points = Points + (MyShip_PowerShot_Load * MyShip_PowerShot_Load);
                            MyShip_PowerShot_Load = 0;
                        }
                        // Ladebalken, Länge berechnen
                        double t_percent = Convert.ToDouble(100) / Convert.ToDouble(MyShip_PowerShot_Max_Loading) * Convert.ToDouble(MyShip_PowerShot_Loading);
                        double t_width = Convert.ToDouble(225) / Convert.ToDouble(100) * t_percent;
                        MyShip_PowerShot_Width = Convert.ToInt32(t_width);
                    }


                    // Hitboxen, Gegnerische Schüsse mit Todes-Hitbox, eigenes Schiff abgleichen
                    if (Match_Hitboxes(MyShip_x_start, MyShip_x_end, MyShip_y_start, MyShip_y_end, shot_x_start, shot_x_end, shot_y_start, shot_y_end) == true)
                    {
                        // Wenn schiff nicht unzerstörbar
                        if (Indestructible == 0)
                        {
                            // Leben veringern
                            Lives--;
                            // PowerUps entfernen
                            if (MyShotType == "Fire")
                            {
                                if (MyShotFireLevel > 0)
                                {
                                    MyShotFireLevel--;
                                }
                            }
                            if (MyShotType == "Phaser")
                            {
                                if (MyShotPhaserLevel > 0)
                                {
                                    MyShotPhaserLevel--;
                                }
                            }
                            if (MyShotType == "Laser")
                            {
                                if (MyShotLaserLevel > 0)
                                {
                                    MyShotLaserLevel--;
                                }
                            }
                            if (MyExtensionType == "Rocket")
                            {
                                if (MyShotRocketLevel > 0)
                                {
                                    MyShotRocketLevel--;
                                }
                                else if (MyShotRocketLevel == 0)
                                {
                                    MyExtensionType = "None";
                                }
                            }

                            // Schiff auf inaktiv stellen
                            MyShipIsActive = false;
                            // Frames bis das schiff wider erseint erstellen
                            FramesToAppear = 60;
                            // Explosion erstellen
                            ListExplosions.Add(new ClassExplosions("Small", -1, MyShip_X, MyShip_Y));
                            // Sound explosion ausgeben
                            playSoundExplosionSmall = true;
                        }
                        // Gegnerischen Schuss löschen
                        string[] temp_Split = Regex.Split(";" + delete_string_shots, ";" + i.ToString() + ";");
                        if (temp_Split.Count() == 1)
                        {
                            delete_string_shots += i.ToString() + ";";
                        }
                    }
                }

                // Nicht mehr verwendete Schüsse löschen
                if (delete_string_shots.Length > 0)
                {
                    string[] delete_split = Regex.Split(delete_string_shots, ";");
                    for (int i = delete_split.Count() - 2; i >= 0; i--)
                    {
                        ListEnemyShotLaser.RemoveAt(Convert.ToInt32(delete_split[i]));
                    }
                }



                // Liste der zu löschendne Schüsse leeren
                delete_string_enemys = "";

                // Alle Gegner durchlaufen und Hitboxen aller Gegner mit eigener Hitbox abgleichen
                for (int i = 0; i < ListShipEnemys.Count(); i++)
                {
                    // Gegnerische Hitboxen ausleden und abgleichen
                    int Enemy_x_start = ListShipEnemys[i].hitbox_x;
                    int Enemy_x_end = Enemy_x_start + ListShipEnemys[i].hitbox_width;
                    int Enemy_y_start = ListShipEnemys[i].hitbox_y;
                    int Enemy_y_end = Enemy_y_start + ListShipEnemys[i].hitbox_height;

                    // Hitboxen abgleichen
                    if (Match_Hitboxes(MyShip_x_start, MyShip_x_end, MyShip_y_start, MyShip_y_end, Enemy_x_start, Enemy_x_end, Enemy_y_start, Enemy_y_end) == true)
                    {
                        // Wenn schiff nicht unzerstörbar
                        if (Indestructible == 0)
                        {
                            // Leben veringern
                            Lives--;
                            // Schiff auf inaktiv stellen
                            MyShipIsActive = false;
                            // Frames bis das schiff wider erseint erstellen
                            FramesToAppear = 60;
                            // Explosion erstellen
                            ListExplosions.Add(new ClassExplosions("Small", -1, MyShip_X, MyShip_Y));
                            // Sound explosion ausgeben
                            playSoundExplosionSmall = true;
                        }
                        /*
                        // Gegner löschen löschen
                        string[] temp_Split = Regex.Split(";" + delete_string_shots, ";" + i.ToString() + ";");
                        if (temp_Split.Count() == 1)
                        {
                            delete_string_shots += i.ToString() + ";";
                        }
                         */
                    }
                }
            }


            // Punkte für Aufladung des Powerschusses hinzufügen
            if (PowerShot_Load == false)
            {
                if (MyShip_PowerShot_Load > 0)
                {
                    Points = Points + (MyShip_PowerShot_Load * MyShip_PowerShot_Load);
                    MyShip_PowerShot_Load = 0;
                }
            }
            // **************************************************************************************************************





            // Treffer duch Kontakt mit Endboss ermitteln
            // **************************************************************************************************************
            if (BossSzenario == true & BossEnergie > 0)
            {
                // HitboxEndboss auslesen
                int Boss_x_start = Boss_X - (Boss_Hitbox_Width / 2);
                int Boss_x_end = Boss_x_start + Boss_Hitbox_Width;
                int Boss_y_start = Boss_Y - (Boss_Hitbox_Height / 2);
                int Boss_y_end = Boss_y_start + Boss_Hitbox_Height;

                // Hitbox eigenes Schiff auslesen
                int MyShip_x_start = MyShip_Hitbox_X;
                int MyShip_y_start = MyShip_Hitbox_Y;
                int MyShip_x_end = MyShip_x_start + MyShip_Hitbox_Width;
                int MyShip_y_end = MyShip_y_start + MyShip_Hitbox_Height;

                // Hitboxen abgleichen
                if (Match_Hitboxes(Boss_x_start, Boss_x_end, Boss_y_start, Boss_y_end, MyShip_x_start, MyShip_x_end, MyShip_y_start, MyShip_y_end) == true)
                {
                    // Wenn schiff nicht unzerstörbar
                    if (Indestructible == 0)
                    {
                        // Leben veringern
                        Lives--;
                        // Schiff auf inaktiv stellen
                        MyShipIsActive = false;
                        // Frames bis das schiff wider erseint erstellen
                        FramesToAppear = 60;
                        // Explosion erstellen
                        ListExplosions.Add(new ClassExplosions("Small", -1, MyShip_X, MyShip_Y));
                        // Sound explosion ausgeben
                        playSoundExplosionSmall = true;
                    }
                }
            }
            // **************************************************************************************************************





            // Explosionen berechnen
            // **************************************************************************************************************
            // Variabeln zum löschen leeren
            delete_string = "";

            // Explosionen durchlaufen
            for (int i = 0; i < ListExplosions.Count(); i++)
            {
                // Wenn kleine Explosion // Mini
                if (ListExplosions[i].type == "Mini")
                {
                    // Count erhöhen
                    ListExplosions[i].frame++;
                    // Entsprechendes Bild erstellen
                    if (ListExplosions[i].frame < 3)
                    {
                        ListExplosions[i].Texture = texExplosionMini0;
                    }
                    else if (ListExplosions[i].frame < 6)
                    {
                        ListExplosions[i].Texture = texExplosionMini1;
                    }
                    else if (ListExplosions[i].frame < 9)
                    {
                        ListExplosions[i].Texture = texExplosionMini2;
                    }
                    else if (ListExplosions[i].frame < 12)
                    {
                        ListExplosions[i].Texture = texExplosionMini3;
                    }
                    else if (ListExplosions[i].frame < 15)
                    {
                        ListExplosions[i].Texture = texExplosionMini4;
                    }
                    else
                    {
                        delete_string += i + ";";
                    }
                }

                // Wenn kleine Explosion // Small
                if (ListExplosions[i].type == "Small")
                {
                    // Count erhöhen
                    ListExplosions[i].frame++;
                    // Entsprechendes Bild erstellen
                    if (ListExplosions[i].frame < 3)
                    {
                        ListExplosions[i].Texture = texExplosionSmall0;
                    }
                    else if (ListExplosions[i].frame < 6)
                    {
                        ListExplosions[i].Texture = texExplosionSmall1;
                    }
                    else if (ListExplosions[i].frame < 9)
                    {
                        ListExplosions[i].Texture = texExplosionSmall2;
                    }
                    else if (ListExplosions[i].frame < 12)
                    {
                        ListExplosions[i].Texture = texExplosionSmall3;
                    }
                    else if (ListExplosions[i].frame < 15)
                    {
                        ListExplosions[i].Texture = texExplosionSmall4;
                    }
                    else
                    {
                        delete_string += i + ";";
                    }
                }

                // Wenn kleine Explosion // Medium
                if (ListExplosions[i].type == "Medium")
                {
                    // Count erhöhen
                    ListExplosions[i].frame++;
                    // Entsprechendes Bild erstellen
                    if (ListExplosions[i].frame < 3)
                    {
                        ListExplosions[i].Texture = texExplosionMedium0;
                    }
                    else if (ListExplosions[i].frame < 6)
                    {
                        ListExplosions[i].Texture = texExplosionMedium1;
                    }
                    else if (ListExplosions[i].frame < 9)
                    {
                        ListExplosions[i].Texture = texExplosionMedium2;
                    }
                    else if (ListExplosions[i].frame < 12)
                    {
                        ListExplosions[i].Texture = texExplosionMedium3;
                    }
                    else if (ListExplosions[i].frame < 15)
                    {
                        ListExplosions[i].Texture = texExplosionMedium4;
                    }
                    else
                    {
                        delete_string += i + ";";
                    }
                }

                // Wenn große Explosion // Big
                else if (ListExplosions[i].type == "Big")
                {
                    // Count erhöhen
                    ListExplosions[i].frame++;
                    // Entsprechendes Bild erstellen
                    if (ListExplosions[i].frame < 3)
                    {
                        ListExplosions[i].Texture = texExplosionBig0;
                    }
                    else if (ListExplosions[i].frame < 6)
                    {
                        ListExplosions[i].Texture = texExplosionBig1;
                    }
                    else if (ListExplosions[i].frame < 9)
                    {
                        ListExplosions[i].Texture = texExplosionBig2;
                    }
                    else if (ListExplosions[i].frame < 12)
                    {
                        ListExplosions[i].Texture = texExplosionBig3;
                    }
                    else if (ListExplosions[i].frame < 15)
                    {
                        ListExplosions[i].Texture = texExplosionBig1;
                    }
                    else if (ListExplosions[i].frame < 18)
                    {
                        ListExplosions[i].Texture = texExplosionBig2;
                    }
                    else if (ListExplosions[i].frame < 21)
                    {
                        ListExplosions[i].Texture = texExplosionBig3;
                    }
                    else if (ListExplosions[i].frame < 24)
                    {
                        ListExplosions[i].Texture = texExplosionBig1;
                    }
                    else if (ListExplosions[i].frame < 27)
                    {
                        ListExplosions[i].Texture = texExplosionBig2;
                    }
                    else if (ListExplosions[i].frame < 30)
                    {
                        ListExplosions[i].Texture = texExplosionBig3;
                    }
                    else if (ListExplosions[i].frame < 33)
                    {
                        ListExplosions[i].Texture = texExplosionBig4;
                    }
                    else if (ListExplosions[i].frame < 36)
                    {
                        ListExplosions[i].Texture = texExplosionBig5;
                    }
                    else if (ListExplosions[i].frame < 39)
                    {
                        ListExplosions[i].Texture = texExplosionBig6;
                    }
                    else if (ListExplosions[i].frame < 42)
                    {
                        ListExplosions[i].Texture = texExplosionBig7;
                    }
                    else
                    {
                        delete_string += i + ";";
                    }
                }
            }




            // Nicht mehr verwendete Explosionen löschen
            if (delete_string.Length > 0)
            {
                string[] delete_split = Regex.Split(delete_string, ";");
                for (int i = delete_split.Count() - 2; i >= 0; i--)
                {
                    ListExplosions.RemoveAt(Convert.ToInt32(delete_split[i]));
                }
            }
            // **************************************************************************************************************





            // PowerUps Berechnen
            // **************************************************************************************************************
            // Variabeln zum löschen löschen
            delete_string = "";



            // PowerUps durchlaufen und Position bestimmen
            for (int i = 0; i < ListPowerUps.Count; i++)
            {
                // Frames gesamt erhöhen
                ListPowerUps[i].frame_complete++;
                // Wenn Frames gesamt > 180, Powerup Blinken lassen
                if (ListPowerUps[i].frame_complete > 180)
                {
                    if (ListPowerUps[i].frame_complete % 2 == 0)
                    {
                        ListPowerUps[i].show = false;
                    }
                    else
                    {
                        ListPowerUps[i].show = true;
                    }
                }

                // Frame erhöhen
                ListPowerUps[i].frame++;
                if (ListPowerUps[i].frame > 14)
                {
                    ListPowerUps[i].frame = 0;
                }
                // y Achse verschieben
                Random rand = new Random();
                if (rand.Next(0, 2) == 0)
                {
                    ListPowerUps[i].x += 1;
                }
                else
                {
                    ListPowerUps[i].x -= 1;
                }
                // X Achse verschieben
                ListPowerUps[i].y += 1;
                // Textur erstellen
                if (ListPowerUps[i].frame < 2)
                {
                    if (ListPowerUps[i].type == "Fire")
                    {
                        ListPowerUps[i].Texture = texPowerUpFire_1;
                    }
                    else if (ListPowerUps[i].type == "Phaser")
                    {
                        ListPowerUps[i].Texture = texPowerUpPhaser_1;
                    }
                    else if (ListPowerUps[i].type == "OneUp")
                    {
                        ListPowerUps[i].Texture = texPowerUpOneUp_1;
                    }
                    else if (ListPowerUps[i].type == "Rocket")
                    {
                        ListPowerUps[i].Texture = texPowerUpRocket_1;
                    }
                    else if (ListPowerUps[i].type == "Laser")
                    {
                        ListPowerUps[i].Texture = texPowerUpLaser_1;
                    }
                }
                else if (ListPowerUps[i].frame < 4)
                {
                    if (ListPowerUps[i].type == "Fire")
                    {
                        ListPowerUps[i].Texture = texPowerUpFire_2;
                    }
                    else if (ListPowerUps[i].type == "Phaser")
                    {
                        ListPowerUps[i].Texture = texPowerUpPhaser_2;
                    }
                    else if (ListPowerUps[i].type == "OneUp")
                    {
                        ListPowerUps[i].Texture = texPowerUpOneUp_2;
                    }
                    else if (ListPowerUps[i].type == "Rocket")
                    {
                        ListPowerUps[i].Texture = texPowerUpRocket_2;
                    }
                    else if (ListPowerUps[i].type == "Laser")
                    {
                        ListPowerUps[i].Texture = texPowerUpLaser_2;
                    }
                }
                else if (ListPowerUps[i].frame < 6)
                {
                    if (ListPowerUps[i].type == "Fire")
                    {
                        ListPowerUps[i].Texture = texPowerUpFire_3;
                    }
                    else if (ListPowerUps[i].type == "Phaser")
                    {
                        ListPowerUps[i].Texture = texPowerUpPhaser_3;
                    }
                    else if (ListPowerUps[i].type == "OneUp")
                    {
                        ListPowerUps[i].Texture = texPowerUpOneUp_3;
                    }
                    else if (ListPowerUps[i].type == "Rocket")
                    {
                        ListPowerUps[i].Texture = texPowerUpRocket_3;
                    }
                    else if (ListPowerUps[i].type == "Laser")
                    {
                        ListPowerUps[i].Texture = texPowerUpLaser_3;
                    }
                }
                else if (ListPowerUps[i].frame < 8)
                {
                    if (ListPowerUps[i].type == "Fire")
                    {
                        ListPowerUps[i].Texture = texPowerUpFire_4;
                    }
                    else if (ListPowerUps[i].type == "Phaser")
                    {
                        ListPowerUps[i].Texture = texPowerUpPhaser_4;
                    }
                    else if (ListPowerUps[i].type == "OneUp")
                    {
                        ListPowerUps[i].Texture = texPowerUpOneUp_4;
                    }
                    else if (ListPowerUps[i].type == "Rocket")
                    {
                        ListPowerUps[i].Texture = texPowerUpRocket_4;
                    }
                    else if (ListPowerUps[i].type == "Laser")
                    {
                        ListPowerUps[i].Texture = texPowerUpLaser_4;
                    }
                }
                else if (ListPowerUps[i].frame < 10)
                {
                    if (ListPowerUps[i].type == "Fire")
                    {
                        ListPowerUps[i].Texture = texPowerUpFire_5;
                    }
                    else if (ListPowerUps[i].type == "Phaser")
                    {
                        ListPowerUps[i].Texture = texPowerUpPhaser_5;
                    }
                    else if (ListPowerUps[i].type == "OneUp")
                    {
                        ListPowerUps[i].Texture = texPowerUpOneUp_5;
                    }
                    else if (ListPowerUps[i].type == "Rocket")
                    {
                        ListPowerUps[i].Texture = texPowerUpRocket_5;
                    }
                    else if (ListPowerUps[i].type == "Laser")
                    {
                        ListPowerUps[i].Texture = texPowerUpLaser_5;
                    }
                }
                else if (ListPowerUps[i].frame < 12)
                {
                    if (ListPowerUps[i].type == "Fire")
                    {
                        ListPowerUps[i].Texture = texPowerUpFire_6;
                    }
                    else if (ListPowerUps[i].type == "Phaser")
                    {
                        ListPowerUps[i].Texture = texPowerUpPhaser_6;
                    }
                    else if (ListPowerUps[i].type == "OneUp")
                    {
                        ListPowerUps[i].Texture = texPowerUpOneUp_6;
                    }
                    else if (ListPowerUps[i].type == "Rocket")
                    {
                        ListPowerUps[i].Texture = texPowerUpRocket_6;
                    }
                    else if (ListPowerUps[i].type == "Laser")
                    {
                        ListPowerUps[i].Texture = texPowerUpLaser_6;
                    }
                }
                else if (ListPowerUps[i].frame < 14)
                {
                    if (ListPowerUps[i].type == "Fire")
                    {
                        ListPowerUps[i].Texture = texPowerUpFire_7;
                    }
                    else if (ListPowerUps[i].type == "Phaser")
                    {
                        ListPowerUps[i].Texture = texPowerUpPhaser_7;
                    }
                    else if (ListPowerUps[i].type == "OneUp")
                    {
                        ListPowerUps[i].Texture = texPowerUpOneUp_7;
                    }
                    else if (ListPowerUps[i].type == "Rocket")
                    {
                        ListPowerUps[i].Texture = texPowerUpRocket_7;
                    }
                    else if (ListPowerUps[i].type == "Laser")
                    {
                        ListPowerUps[i].Texture = texPowerUpLaser_7;
                    }
                }

                // Wenn PowerUp gelöscht wird
                if (ListPowerUps[i].y > 900 | ListPowerUps[i].frame_complete > 240)
                {
                    string[] split_delet_string = Regex.Split(";" + delete_string, ";" + i.ToString() + ";");
                    if (split_delet_string.Count() == 1)
                    {
                        delete_string += i.ToString() + ";";
                    }
                }
            }



            // Hitbox aller PowerUps mit Hitbox von eigenem Schiff abgleichen
            if (MyShipIsActive == true)
            {
                // Daten von eingenem Schiff auslesen und erstellen
                int MyShip_x_start = MyShip_Hitbox_X - 20;
                int MyShip_y_start = MyShip_Hitbox_Y - 20;
                int MyShip_x_end = MyShip_x_start + MyShip_Hitbox_Width + 40;
                int MyShip_y_end = MyShip_y_start + MyShip_Hitbox_Height + 40;

                // Daten der Powerups laden
                for (int i = 0; i < ListPowerUps.Count(); i++)
                {
                    // Powerups Daten erstellen
                    int PowerUp_x_start = ListPowerUps[i].x - (ListPowerUps[i].Texture.Width / 2);
                    int PowerUp_x_end = PowerUp_x_start + ListPowerUps[i].Texture.Width;
                    int PowerUp_y_start = ListPowerUps[i].y - (ListPowerUps[i].Texture.Height / 2);
                    int PowerUp_y_end = PowerUp_y_start + ListPowerUps[i].Texture.Height;

                    // Hitboxen abgleichen
                    if (Match_Hitboxes(MyShip_x_start, MyShip_x_end, MyShip_y_start, MyShip_y_end, PowerUp_x_start, PowerUp_x_end, PowerUp_y_start, PowerUp_y_end) == true)
                    {
                        // Wenn PowerUp Fire
                        if (ListPowerUps[i].type == "Fire")
                        {
                            // Wenn Fire bereits ausgewählt
                            if (MyShotType == "Fire")
                            {
                                // Feuer erhöhen
                                if (MyShotFireLevel < 2)
                                {
                                    MyShotFireLevel++;
                                }
                            }
                            // Wenn es nicht Feuer ist
                            else
                            {
                                // Schuss auf feuer stellen
                                MyShotType = "Fire";
                            }
                            // Sound Fire ausgeben
                            playSoundFire = true;
                        }
                        // Wenn PowerUp Phaser
                        if (ListPowerUps[i].type == "Phaser")
                        {
                            // Wenn Phaser bereits ausgewählt
                            if (MyShotType == "Phaser")
                            {
                                // Phaser erhöhen
                                if (MyShotPhaserLevel < 2)
                                {
                                    MyShotPhaserLevel++;
                                }
                            }
                            // Wenn es nicht Phaser ist
                            else
                            {
                                // Schuss auf Phaser stellen
                                MyShotType = "Phaser";
                            }
                            // Sound Level Phaser
                            playSoundPhaser = true;
                        }
                        // Wenn PowerUp Laser
                        if (ListPowerUps[i].type == "Laser")
                        {
                            // Wenn Laser bereits ausgewählt
                            if (MyShotType == "Laser")
                            {
                                // Laser erhöhen
                                if (MyShotLaserLevel < 2)
                                {
                                    MyShotLaserLevel++;
                                }
                            }
                            // Wenn es nicht Laser ist
                            else
                            {
                                // Schuss auf Laser stellen
                                MyShotType = "Laser";
                            }
                            // Sound Level Phaser
                            playSoundLaser = true;
                        }
                        // Wenn PowerUp OneUp
                        if (ListPowerUps[i].type == "OneUp")
                        {
                            //Leben erhöhen
                            Lives++;
                            // Sound OneUp ausgeben
                            playSoundOneUp = true;
                        }
                        // Wenn PowerUp Rocket
                        if (ListPowerUps[i].type == "Rocket")
                        {
                            //Racketenwerfer erstellen und erhöhen
                            if (MyExtensionType != "Rocket")
                            {
                                // Raketen erstellen
                                MyExtensionType = "Rocket";
                            }
                            // Wenn Raketen bereits installiert
                            else if (MyExtensionType == "Rocket")
                            {
                                // Wenn Level < 2
                                if (MyShotRocketLevel < 2)
                                {
                                    MyShotRocketLevel++;
                                }
                            }
                            // Sound OneUp ausgeben
                            playSoundRocket = true;
                        }



                        // Eingesammelte PowerUps löschen
                        string[] split_delet_string = Regex.Split(";" + delete_string, ";" + i.ToString() + ";");
                        if (split_delet_string.Count() == 1)
                        {
                            delete_string += i.ToString() + ";";
                        }
                    }
                }
            }



            // Nicht mehr verwendete Powerups löschen
            if (delete_string.Length > 0)
            {
                string[] delete_split = Regex.Split(delete_string, ";");
                for (int i = delete_split.Count() - 2; i >= 0; i--)
                {
                    ListPowerUps.RemoveAt(Convert.ToInt32(delete_split[i]));
                }
            }
            // **************************************************************************************************************





            // Sounds ausgeben
            // **************************************************************************************************************
            if (playSoundMyShotFire == true)
            {
                sndMyShotFire.Play();
            }
            if (playSoundMyShotPhaser == true)
            {
                sndMyShotPhaser.Play();
            }
            if (playSoundMyShotLaser == true)
            {
                sndMyShotLaser.Play();
            }
            if (playSoundImpact == true)
            {
                sndImpact.Play();
            }
            if (playSoundExplosionSmall == true)
            {
                sndExplosionSmall.Play();
            }
            if (playSoundExplosionBig == true)
            {
                sndExplosionBig.Play();
            }
            if (playSoundPowerUp == true)
            {
                sndPowerUp.Play();
            }
            if (playSoundFire == true)
            {
                sndFire.Play();
            }
            if (playSoundPhaser == true)
            {
                sndPhaser.Play();
            }
            if (playSoundOneUp == true)
            {
                sndOneUp.Play();
            }
            if (playSoundRocket == true)
            {
                sndRocket.Play();
            }
            if (playSoundMyShotRocket == true)
            {
                sndMyShotRocket.Play();
            }
            if (playSoundLaser == true)
            {
                sndLaser.Play();
            }
            if (playSoundPowerShotReady == true)
            {
                sndPowerShotReady.Play();
            }
            if (playSoundMyShotPowerShot == true)
            {
                sndMyShotPowerShot.Play();
            }
            if (playSoundEnemyShot1 == true)
            {
                sndEnemyShot1Sound.Play();
            }
            if (playSoundEnemyShot2 == true)
            {
                sndEnemyShot2Sound.Play();
            }
            if (playSoundEnemyShot3 == true)
            {
                sndEnemyShot3Sound.Play();
            }
            // **************************************************************************************************************
        }






        // Methoden // Zum berrechnen des Spielverlaufs
        // **************************************************************************************************************

        // Hitbboxen abgleichen
        // **************************************************************************************************************
        bool Match_Hitboxes(int x1_start, int x1_end, int y1_start, int y1_end, int x2_start, int x2_end, int y2_start, int y2_end)
        {
            bool Match = false;
            if (((x1_start > x2_start & x1_start < x2_end) | (x1_end > x2_start & x1_end < x2_end) | (x2_start > x1_start & x2_start < x1_end) | (x2_end > x1_start & x2_end < x1_end)) & ((y1_start > y2_start & y1_start < y2_end) | (y1_end > y2_start & y1_end < y2_end) | (y2_start > y1_start & y2_start < y1_end) | (y2_end > y1_start & y2_end < y1_end)))
            {
                Match = true;
            }
            return Match;
        }
        // **************************************************************************************************************





        // Gegner Schuss typ 1 erstellen --> Direkter Schuss --> Erzeugt Schuss in der Klasse <ClassEnemyShotDirect>
        // **************************************************************************************************************
        void CreateEnemyShot1(double x, double y, int speed)
        {
            // Schuss, Bewegung berechnen
            bool invert_x = false;
            bool invert_y = false;
            double x_temp = MyShip_X;
            double y_temp = MyShip_Y;
            double x_way_complete = x_temp - x;
            if (x_way_complete < Convert.ToDouble(0))
            {
                x_way_complete = Convert.ToDouble(0) - (x_way_complete);
                invert_x = true;
            }
            double y_way_complete = y_temp - y;
            if (y_way_complete < Convert.ToDouble(0))
            {
                y_way_complete = Convert.ToDouble(0) - (y_way_complete);
                invert_y = true;
            }
            double way_complete = Math.Sqrt((x_way_complete * x_way_complete) + (y_way_complete * y_way_complete));
            double temp = Convert.ToDouble(100) / x_way_complete * way_complete;
            double x_way = Convert.ToDouble(speed) / temp * Convert.ToDouble(100);
            temp = Convert.ToDouble(100) / y_way_complete * way_complete;
            double y_way = Convert.ToDouble(speed) / temp * Convert.ToDouble(100);
            if (invert_x == true)
            {
                x_way = Convert.ToDouble(0) - x_way;
            }
            if (invert_y == true)
            {
                y_way = Convert.ToDouble(0) - y_way;
            }
            // Schuss in Klasse <ClassEnemyShotDirect> eintragen
            ListEnemyShotDirect.Add(new ClassEnemyShotDirect(x, y, x_way, y_way, 20, 20));
        }
        // **************************************************************************************************************





        // Gegner Schuss typ 3 erstellen --> Direkter Schuss Groß --> Erzeugt Schuss in der Klasse <ClassEnemyShotDirect>
        // **************************************************************************************************************
        void CreateEnemyShot3(double x, double y, int speed)
        {
            // Schuss, Bewegung berechnen
            bool invert_x = false;
            bool invert_y = false;
            double x_temp = MyShip_X;
            double y_temp = MyShip_Y;
            double x_way_complete = x_temp - x;
            if (x_way_complete < Convert.ToDouble(0))
            {
                x_way_complete = Convert.ToDouble(0) - (x_way_complete);
                invert_x = true;
            }
            double y_way_complete = y_temp - y;
            if (y_way_complete < Convert.ToDouble(0))
            {
                y_way_complete = Convert.ToDouble(0) - (y_way_complete);
                invert_y = true;
            }
            double way_complete = Math.Sqrt((x_way_complete * x_way_complete) + (y_way_complete * y_way_complete));
            double temp = Convert.ToDouble(100) / x_way_complete * way_complete;
            double x_way = Convert.ToDouble(speed) / temp * Convert.ToDouble(100);
            temp = Convert.ToDouble(100) / y_way_complete * way_complete;
            double y_way = Convert.ToDouble(speed) / temp * Convert.ToDouble(100);
            if (invert_x == true)
            {
                x_way = Convert.ToDouble(0) - x_way;
            }
            if (invert_y == true)
            {
                y_way = Convert.ToDouble(0) - y_way;
            }
            // Schuss in Klasse <ClassEnemyShotDirect> eintragen
            ListEnemyShotDirect.Add(new ClassEnemyShotDirect(x, y, x_way, y_way, 40, 40));
        }
        // **************************************************************************************************************





        // Gegner Schuss typ 2 erstellen --> Dreifach-Schuss --> Erzeugt drei Schüsse in der Klasse <ClassEnemyShotDirect>
        // **************************************************************************************************************
        void CreateEnemyShot2(double x, double y, int speed)
        {
            // Schuss Mitte, Bewegung erstellen
            double x_way = 0;
            double y_way = speed;
            // Schuss in Klasse <ClassEnemyShotDirect> eintragen
            ListEnemyShotDirect.Add(new ClassEnemyShotDirect(x, y, x_way, y_way, 20, 20));

            // Schuss Rechts erstellen
            double way_complete = Math.Sqrt((speed * speed) + ((speed / 2) * (speed / 2)));
            double temp = Convert.ToDouble(100) / speed * way_complete;
            x_way = Convert.ToDouble(speed / 2) / temp * Convert.ToDouble(100);
            temp = Convert.ToDouble(100) / speed * way_complete;
            y_way = Convert.ToDouble(speed) / temp * Convert.ToDouble(100);
            // Schuss in Klasse <ClassEnemyShotDirect> eintragen
            ListEnemyShotDirect.Add(new ClassEnemyShotDirect(x, y, x_way, y_way, 20, 20));

            // Schuss Links erstellen
            x_way = 0 - x_way;
            // Schuss in Klasse <ClassEnemyShotDirect> eintragen
            ListEnemyShotDirect.Add(new ClassEnemyShotDirect(x, y, x_way, y_way, 20, 20));
        }
        // **************************************************************************************************************





        // Gegner Schuss typ 13 und 14 erstellen --> Dreh-Schuss Links und Rechts --> Erzeugt Schüsse in der Klasse <ClassEnemyShotDirect>
        // **************************************************************************************************************
        // Schuß 13 // Drehschuß Rechts
        void CreateEnemyShot13(double x, double y, int shotNumber, int speed)
        {
            // Wenn schuß größer als 7 ist
            for (int i = 0; 0 == 0; i = 0)
            {
                // Schuß nach Nummer einstellen
                if (shotNumber > 7)
                {
                    shotNumber -= 8;
                }
                else
                {
                    break;
                }
            }

            // Schuß Daten erstellen
            double x_way = 0;
            double y_way = 0;

            // Wenn Schuß Nummer 0 // Schuß gerade nach unten
            if (shotNumber == 0)
            {
                y_way = speed;
            }
            // Wenn Schuß Nummer 1 // Schuß Unten links
            else if (shotNumber == 1)
            {
                // Schuß berrechnen
                double wayXY = Math.Sqrt((Convert.ToDouble(speed) * Convert.ToDouble(speed)) / Convert.ToDouble(2));
                x_way = 0 - wayXY;
                y_way = wayXY;
            }
            // Wenn Schuß Nummer 3 // Schuß Links
            else if (shotNumber == 2)
            {
                x_way = 0 - speed;
            }
            // Wenn Schuß Nummer 4 // Schuß Links Oben
            else if (shotNumber == 3)
            {
                // Schuß berrechnen
                double wayXY = Math.Sqrt((Convert.ToDouble(speed) * Convert.ToDouble(speed)) / Convert.ToDouble(2));
                x_way = 0 - wayXY;
                y_way = 0 - wayXY;
            }
            // Wenn Schuß Nummer 4 // Schuß Oben
            else if (shotNumber == 4)
            {
                y_way = 0 - speed;
            }
            // Wenn Schuß Nummer 5 // Schuß Oben Rechts
            else if (shotNumber == 5)
            {
                // Schuß berrechnen
                double wayXY = Math.Sqrt((Convert.ToDouble(speed) * Convert.ToDouble(speed)) / Convert.ToDouble(2));
                x_way = 0 + wayXY;
                y_way = 0 - wayXY;
            }
            // Wenn Schuß Nummer 6 // Schuß Rechts
            else if (shotNumber == 6)
            {
                x_way = 0 + speed;
            }
            // Wenn Schuß Nummer 7 // Schuß Rechts unten
            else if (shotNumber == 7)
            {
                // Schuß berrechnen
                double wayXY = Math.Sqrt((Convert.ToDouble(speed) * Convert.ToDouble(speed)) / Convert.ToDouble(2));
                x_way = 0 + wayXY;
                y_way = 0 + wayXY;
            }

            // Schuss in Klasse <ClassEnemyShotDirect> eintragen
            ListEnemyShotDirect.Add(new ClassEnemyShotDirect(x, y, x_way, y_way, 20, 20));
        }



        // Schuß 14 // Drehschuß Links
        void CreateEnemyShot14(double x, double y, int shotNumber, int speed)
        {
            // Wenn schuß größer als 7 ist
            for (int i = 0; 0 == 0; i = 0)
            {
                // Schuß nach Nummer einstellen
                if (shotNumber > 7)
                {
                    shotNumber -= 8;
                }
                else
                {
                    break;
                }
            }

            // Schuß Daten erstellen
            double x_way = 0;
            double y_way = 0;

            // Wenn Schuß Nummer 0 // Schuß gerade nach unten
            if (shotNumber == 0)
            {
                y_way = speed;
            }
            // Wenn Schuß Nummer 1 // Schuß Unten Rechts
            else if (shotNumber == 1)
            {
                // Schuß berrechnen
                double wayXY = Math.Sqrt((Convert.ToDouble(speed) * Convert.ToDouble(speed)) / Convert.ToDouble(2));
                x_way = 0 + wayXY;
                y_way = wayXY;
            }
            // Wenn Schuß Nummer 3 // Schuß Rechts
            else if (shotNumber == 2)
            {
                x_way = speed;
            }
            // Wenn Schuß Nummer 4 // Schuß Rechts Oben
            else if (shotNumber == 3)
            {
                // Schuß berrechnen
                double wayXY = Math.Sqrt((Convert.ToDouble(speed) * Convert.ToDouble(speed)) / Convert.ToDouble(2));
                x_way = 0 + wayXY;
                y_way = 0 - wayXY;
            }
            // Wenn Schuß Nummer 4 // Schuß Oben
            else if (shotNumber == 4)
            {
                y_way = 0 - speed;
            }
            // Wenn Schuß Nummer 5 // Schuß Oben Links
            else if (shotNumber == 5)
            {
                // Schuß berrechnen
                double wayXY = Math.Sqrt((Convert.ToDouble(speed) * Convert.ToDouble(speed)) / Convert.ToDouble(2));
                x_way = 0 - wayXY;
                y_way = 0 - wayXY;
            }
            // Wenn Schuß Nummer 6 // Schuß Links
            else if (shotNumber == 6)
            {
                x_way = 0 - speed;
            }
            // Wenn Schuß Nummer 7 // Schuß Rechts unten
            else if (shotNumber == 7)
            {
                // Schuß berrechnen
                double wayXY = Math.Sqrt((Convert.ToDouble(speed) * Convert.ToDouble(speed)) / Convert.ToDouble(2));
                x_way = 0 - wayXY;
                y_way = 0 + wayXY;
            }

            // Schuss in Klasse <ClassEnemyShotDirect> eintragen
            ListEnemyShotDirect.Add(new ClassEnemyShotDirect(x, y, x_way, y_way, 20, 20));
        }
        // **************************************************************************************************************





        // Gegner Schuss typ 10, 11, 12 erstellen -->  Laser Schuss --> Erzeugt einen Schuss in der Klasse <ClassEnemyShotLaser>
        // **************************************************************************************************************
        void CreateShotEnemyLaser(int type, double x, double y, int speed)
        {
            // Texture nach Typ laden
            Texture2D tempTexShotLaser;
            if (type == 1)
            {
                tempTexShotLaser = texEnemyShot2_1;
            }
            else if (type == 2)
            {
                tempTexShotLaser = texEnemyShot2_2;
            }
            else
            {
                tempTexShotLaser = texEnemyShot2_3;
            }
            // Schuss in Liste eintragen
            ListEnemyShotLaser.Add(new ClassEnemyShotLaser(tempTexShotLaser, type, x, y, speed));
        }
        // **************************************************************************************************************
        // **************************************************************************************************************
        // ------------------------------------------------------------------------------------------------------------------------------------





    }





}
