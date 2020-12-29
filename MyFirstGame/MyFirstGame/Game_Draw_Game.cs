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





        // Level // Spielverlauf zeichnen
        // ------------------------------------------------------------------------------------------------------------------------------------
        void Draw_Level()
        {
            // Background // Hintergrundbild
            // **************************************************************************************************************
            spriteBatch.Draw(texBackground, new Vector2(0, Background_Position), Color.White);
            // **************************************************************************************************************





            // Hintergundanimationen durchlaufen und zeichnen
            // **************************************************************************************************************
            for (int i = 0; i < ListBackgroundAnimation.Count(); i++)
            {
                spriteBatch.Draw(texBackgroundAnimation, new Vector2(ListBackgroundAnimation[i].x, ListBackgroundAnimation[i].y), Color.White);
            }
            // **************************************************************************************************************





            // Powershot zeichnen // Unter Gegner
            // **************************************************************************************************************
            // Wenn eigenes Schiff aktiv und Powerschuss-Animtaion läuft
            bool PowerShot_drawed = false;
            if (MyShipIsActive == true & PowerShotAnimation == true)
            {
                if (PowerShotAnimationFrame < 15)
                {
                    // Wenn Powerschuss noch aufbaut
                    spriteBatch.Draw(texMyShotPowerShot, new Vector2(MyShip_X - (texMyShotPowerShot.Width / 2), MyShip_Y - 120), Color.White);
                }
                else
                {
                    if (PowerShotAnimationFrame % 2 == 0)
                    {
                        // Powerschuss Strahl
                        spriteBatch.Draw(texMyShotPowerShot, new Vector2(MyShip_X - (texMyShotPowerShot.Width / 2), MyShip_Y - 20 - texMyShotPowerShot.Height), null, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1);
                        PowerShot_drawed = true;
                    }
                }
            }
            // **************************************************************************************************************





            // PowerUps durchlaufen und zeichnen
            // **************************************************************************************************************
            for (int i = 0; i < ListPowerUps.Count(); i++)
            {
                // PowerUp zeichnen
                if (ListPowerUps[i].show == true)
                {
                    spriteBatch.Draw(ListPowerUps[i].Texture, new Vector2(ListPowerUps[i].x - (ListPowerUps[i].Texture.Width / 2), ListPowerUps[i].y - (ListPowerUps[i].Texture.Height / 2)), null, Color.White);
                }
                // DEBUG Hitbox anzeigen
                if (DEBUG == true)
                {
                    HitboxRectangle.Width = ListPowerUps[i].Texture.Width;
                    HitboxRectangle.Height = ListPowerUps[i].Texture.Height;
                    HitboxRectangle.X = ListPowerUps[i].x - (ListPowerUps[i].Texture.Width / 2);
                    HitboxRectangle.Y = ListPowerUps[i].y - (ListPowerUps[i].Texture.Height / 2);
                    spriteBatch.Draw(HitboxTexture, HitboxRectangle, Color.Bisque);
                }
            }
            // **************************************************************************************************************





            // ShipEnemys // Gegnerische Schiffe
            // **************************************************************************************************************
            for (int i = 0; i < ListShipEnemys.Count(); i++)
            {

                // Prüfvariable ob Standard geladen wird
                bool load_just = true;
                // Ausrichtung des Schiffes erstellen und ausgeben
                if (ListShipEnemys[i].sprite == "left")
                {
                    spriteBatch.Draw(ListEnemyTextures[ListShipEnemys[i].enemy_type].left, new Vector2(ListShipEnemys[i].position_x, ListShipEnemys[i].position_y), null, Color.White, ListShipEnemys[i].rotation, new Vector2(ListEnemyTextures[ListShipEnemys[i].enemy_type].left.Width / 2, ListEnemyTextures[ListShipEnemys[i].enemy_type].left.Height / 2), 1, SpriteEffects.None, 0);
                    load_just = false;
                }
                else if (ListShipEnemys[i].sprite == "right")
                {
                    spriteBatch.Draw(ListEnemyTextures[ListShipEnemys[i].enemy_type].right, new Vector2(ListShipEnemys[i].position_x, ListShipEnemys[i].position_y), null, Color.White, ListShipEnemys[i].rotation, new Vector2(ListEnemyTextures[ListShipEnemys[i].enemy_type].right.Width / 2, ListEnemyTextures[ListShipEnemys[i].enemy_type].right.Height / 2), 1, SpriteEffects.None, 0);
                    load_just = false;
                }

                if (load_just == true)
                {
                    spriteBatch.Draw(ListEnemyTextures[ListShipEnemys[i].enemy_type].just, new Vector2(ListShipEnemys[i].position_x, ListShipEnemys[i].position_y), null, Color.White, ListShipEnemys[i].rotation, new Vector2(ListEnemyTextures[ListShipEnemys[i].enemy_type].just.Width / 2, ListEnemyTextures[ListShipEnemys[i].enemy_type].just.Height / 2), 1, SpriteEffects.None, 0);
                }



                // DEBUG Hitbox anzeigen
                if (DEBUG == true)
                {
                    HitboxRectangle.Width = ListShipEnemys[i].hitbox_width;
                    HitboxRectangle.Height = ListShipEnemys[i].hitbox_height;
                    HitboxRectangle.X = ListShipEnemys[i].hitbox_x;
                    HitboxRectangle.Y = ListShipEnemys[i].hitbox_y;
                    spriteBatch.Draw(HitboxTexture, HitboxRectangle, Color.Orange);
                }
            }
            // **************************************************************************************************************





            // Endboss Szenario
            // **************************************************************************************************************
            // Endboss zeichnen
            if (BossSzenario == true & DrawBoss == true)
            {
                spriteBatch.Draw(texBoss, new Vector2(Boss_X - (texBoss.Width / 2), Boss_Y - (texBoss.Height / 2)), null, Color.White);

                // DEBUG Hitbox anzeigen
                if (DEBUG == true)
                {
                    HitboxRectangle.Width = Boss_Hitbox_Width;
                    HitboxRectangle.Height = Boss_Hitbox_Height;
                    HitboxRectangle.X = Boss_X - (Boss_Hitbox_Width / 2);
                    HitboxRectangle.Y = Boss_Y - (Boss_Hitbox_Height / 2);
                    spriteBatch.Draw(HitboxTexture, HitboxRectangle, Color.Cyan);
                }
            }
            // **************************************************************************************************************





            // ListMyShotRocket // Erweiterte Schüsse durchlaufen und zeichnen
            // **************************************************************************************************************
            for (int i = 0; i < ListMyShotRocket.Count(); i++)
            {
                // Position der Raketen ermitteln und zeichen
                spriteBatch.Draw(texMyShotRocket, new Vector2(ListMyShotRocket[i].x - (texMyShotRocket.Width / 2), ListMyShotRocket[i].y - (texMyShotRocket.Height / 2)), null, Color.White);
                // Rauch zeichnen
                if (ListMyShotRocket[i].smoke1_y != -1000)
                {
                    spriteBatch.Draw(texSmoke1, new Vector2(ListMyShotRocket[i].x - (texSmoke1.Width / 2), ListMyShotRocket[i].smoke1_y - (texSmoke1.Height / 2)), null, Color.White);
                }
                if (ListMyShotRocket[i].smoke2_y != -1000)
                {
                    spriteBatch.Draw(texSmoke2, new Vector2(ListMyShotRocket[i].x - (texSmoke2.Width / 2), ListMyShotRocket[i].smoke2_y - (texSmoke2.Height / 2)), null, Color.White);
                }
                if (ListMyShotRocket[i].smoke3_y != -1000)
                {
                    spriteBatch.Draw(texSmoke3, new Vector2(ListMyShotRocket[i].x - (texSmoke3.Width / 2), ListMyShotRocket[i].smoke3_y - (texSmoke3.Height / 2)), null, Color.White);
                }
                if (ListMyShotRocket[i].smoke4_y != -1000)
                {
                    spriteBatch.Draw(texSmoke4, new Vector2(ListMyShotRocket[i].x - (texSmoke4.Width / 2), ListMyShotRocket[i].smoke4_y - (texSmoke4.Height / 2)), null, Color.White);
                }
                if (ListMyShotRocket[i].smoke5_y != -1000)
                {
                    spriteBatch.Draw(texSmoke5, new Vector2(ListMyShotRocket[i].x - (texSmoke5.Width / 2), ListMyShotRocket[i].smoke5_y - (texSmoke5.Height / 2)), null, Color.White);
                }// DEBUG Hitbox anzeigen
                if (DEBUG == true)
                {
                    HitboxRectangle.Width = texMyShotRocket.Width;
                    HitboxRectangle.Height = texMyShotRocket.Height;
                    HitboxRectangle.X = ListMyShotRocket[i].x - (HitboxRectangle.Width / 2);
                    HitboxRectangle.Y = ListMyShotRocket[i].y - (HitboxRectangle.Height / 2);
                    spriteBatch.Draw(HitboxTexture, HitboxRectangle, Color.Cyan);
                }
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
                    // DEBUG MODE // Hitbox des Powerschusses anzeigen + 1
                    if (DEBUG == true)
                    {
                        HitboxRectangle.Width = MyShip_PowerShot_Hitbox_Width;
                        HitboxRectangle.Height = MyShip_PowerShot_Hitbox_Height; ;
                        HitboxRectangle.X = MyShip_PowerShot_Hitbox_X;
                        HitboxRectangle.Y = MyShip_PowerShot_Hitbox_Y;
                        spriteBatch.Draw(HitboxTexture, HitboxRectangle, Color.Green);
                    }
                    // DEBUG MODE // Hitbox des Powerschusses anzeigen + 2
                    if (DEBUG == true)
                    {
                        HitboxRectangle.Width = MyShip_PowerShot_Hitbox_Width_2;
                        HitboxRectangle.Height = MyShip_PowerShot_Hitbox_Height_2; ;
                        HitboxRectangle.X = MyShip_PowerShot_Hitbox_X_2;
                        HitboxRectangle.Y = MyShip_PowerShot_Hitbox_Y_2;
                        spriteBatch.Draw(HitboxTexture, HitboxRectangle, Color.Orange);
                    }
                    // DEBUG MODE // Hitbox anzeigen
                    if (DEBUG == true)
                    {
                        HitboxRectangle.Width = MyShip_Hitbox_Width;
                        HitboxRectangle.Height = MyShip_Hitbox_Height; ;
                        HitboxRectangle.X = MyShip_Hitbox_X;
                        HitboxRectangle.Y = MyShip_Hitbox_Y;
                        spriteBatch.Draw(HitboxTexture, HitboxRectangle, Color.Red);
                    }
                }
            }
            // **************************************************************************************************************





            // Powershot zeichnen // Über andere Gegner
            // **************************************************************************************************************
            // Wenn eigenes Schiff aktiv und Powerschuss-Animtaion läuft
            if (MyShipIsActive == true & PowerShotAnimation == true)
            {
                if (PowerShotAnimationFrame >= 15)
                {
                    if (PowerShot_drawed == false)
                    {
                        spriteBatch.Draw(texMyShotPowerShot, new Vector2(MyShip_X - (texMyShotPowerShot.Width / 2), MyShip_Y - 20 - texMyShotPowerShot.Height), null, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.FlipHorizontally, 1);
                    }
                }
                if (DEBUG == true)
                {
                    HitboxRectangle.Width = PowerShotHitboxWidth;
                    HitboxRectangle.Height = PowerShotHitboxHeight;
                    HitboxRectangle.X = PowerShotHitboxX;
                    HitboxRectangle.Y = PowerShotHitboxY;
                    spriteBatch.Draw(HitboxTexture, HitboxRectangle, Color.BurlyWood);
                }
            }
            // **************************************************************************************************************





            // ListMyShots // Schüsse durchlaufen und zeichnen
            // **************************************************************************************************************
            for (int x = 0; x < ListMyShots.Count(); x++)
            {
                // Schuss Feuer
                if (ListMyShots[x].type == "Fire")
                {
                    // Schuss zeichnen
                    spriteBatch.Draw(texMyShotFire, new Vector2(ListMyShots[x].x + (texMyShotFire.Width / 2), ListMyShots[x].y - (texMyShotFire.Height / 2)), null, Color.White, ListMyShots[x].angle, new Vector2(texMyShotFire.Width, texMyShotFire.Width), 1.0f, SpriteEffects.None, 1);
                    // DEBUG MODE // Hitbox anzeigen
                    if (DEBUG == true)
                    {
                        HitboxRectangle.Width = ListMyShots[x].hitbox_width;
                        HitboxRectangle.Height = ListMyShots[x].hitbox_height;
                        HitboxRectangle.X = ListMyShots[x].hitbox_x;
                        HitboxRectangle.Y = ListMyShots[x].hitbox_y;
                        spriteBatch.Draw(HitboxTexture, HitboxRectangle, Color.Red);
                    }
                }

                // Schuss Phaser
                if (ListMyShots[x].type == "Phaser")
                {
                    // Schuss zeichnen
                    spriteBatch.Draw(texMyShotPhaser, new Vector2(ListMyShots[x].x + (texMyShotPhaser.Width / 2), ListMyShots[x].y - (texMyShotPhaser.Height / 2)), null, Color.White, ListMyShots[x].angle, new Vector2(texMyShotPhaser.Width, texMyShotPhaser.Width), 1.0f, SpriteEffects.None, 1);
                    // DEBUG MODE // Hitbox anzeigen
                    if (DEBUG == true)
                    {
                        HitboxRectangle.Width = ListMyShots[x].hitbox_width;
                        HitboxRectangle.Height = ListMyShots[x].hitbox_height;
                        HitboxRectangle.X = ListMyShots[x].hitbox_x;
                        HitboxRectangle.Y = ListMyShots[x].hitbox_y;
                        spriteBatch.Draw(HitboxTexture, HitboxRectangle, Color.Red);
                    }
                }

                // Schuss Laser
                if (ListMyShots[x].type == "Laser")
                {
                    // Bei Laser Level 1
                    if (ListMyShots[x].level == 1)
                    {
                        // Schuss zeichnen
                        spriteBatch.Draw(texMyShotLaser1, new Vector2(ListMyShots[x].x + (texMyShotLaser1.Width / 2), ListMyShots[x].y - (texMyShotLaser1.Height / 2)), null, Color.White, ListMyShots[x].angle, new Vector2(texMyShotLaser1.Width, texMyShotLaser1.Width), 1.0f, SpriteEffects.None, 1);
                    }
                    // Bei Laser Level 2
                    if (ListMyShots[x].level == 2)
                    {
                        // Schuss zeichnen
                        spriteBatch.Draw(texMyShotLaser2, new Vector2(ListMyShots[x].x + (texMyShotLaser2.Width / 2), ListMyShots[x].y - (texMyShotLaser2.Height / 2)), null, Color.White, ListMyShots[x].angle, new Vector2(texMyShotLaser2.Width, texMyShotLaser2.Width), 1.0f, SpriteEffects.None, 1);
                    }
                    // Bei Laser Level 3
                    if (ListMyShots[x].level == 3)
                    {
                        // Schuss zeichnen
                        spriteBatch.Draw(texMyShotLaser3, new Vector2(ListMyShots[x].x + (texMyShotLaser3.Width / 2), ListMyShots[x].y - (texMyShotLaser3.Height / 2)), null, Color.White, ListMyShots[x].angle, new Vector2(texMyShotLaser3.Width, texMyShotLaser3.Width), 1.0f, SpriteEffects.None, 1);
                    }

                    // DEBUG MODE // Hitbox anzeigen
                    if (DEBUG == true)
                    {
                        HitboxRectangle.Width = ListMyShots[x].hitbox_width;
                        HitboxRectangle.Height = ListMyShots[x].hitbox_height;
                        HitboxRectangle.X = ListMyShots[x].hitbox_x;
                        HitboxRectangle.Y = ListMyShots[x].hitbox_y;
                        spriteBatch.Draw(HitboxTexture, HitboxRectangle, Color.BlueViolet);
                    }
                }
            }
            // **************************************************************************************************************





            // Enemy Shots // Gegnerische Schüsse durchlaufen und zeichnen
            // **************************************************************************************************************
            // Schuss typ 1 --> Direkter Schuss --> <ClassEnemyShotDirect> Durchlaufen und zeichnen
            for (int i = 0; i < ListEnemyShotDirect.Count(); i++)
            {
                // Bei kleinem Schuß
                if (ListEnemyShotDirect[i].hitbox_height == 20)
                {
                    // Schuss auswählen und zeichnen
                    if (ListEnemyShotDirect[i].angel == 1)
                    {
                        spriteBatch.Draw(texEnemyShot1, new Vector2(Convert.ToInt32(ListEnemyShotDirect[i].x) + (texEnemyShot1.Width / 2), Convert.ToInt32(ListEnemyShotDirect[i].y + (texEnemyShot1.Height / 2))), null, Color.White, 0.0f, new Vector2(texEnemyShot1.Width, texEnemyShot1.Height), 1.0f, SpriteEffects.None, 1);
                    }
                    else if (ListEnemyShotDirect[i].angel == 2)
                    {
                        spriteBatch.Draw(texEnemyShot1, new Vector2(Convert.ToInt32(ListEnemyShotDirect[i].x) + (texEnemyShot1.Width / 2), Convert.ToInt32(ListEnemyShotDirect[i].y + (texEnemyShot1.Height / 2))), null, Color.White, 0.0f, new Vector2(texEnemyShot1.Width, texEnemyShot1.Height), 1.0f, SpriteEffects.FlipHorizontally, 1);
                    }
                    else if (ListEnemyShotDirect[i].angel == 3)
                    {
                        spriteBatch.Draw(texEnemyShot1, new Vector2(Convert.ToInt32(ListEnemyShotDirect[i].x) + (texEnemyShot1.Width / 2), Convert.ToInt32(ListEnemyShotDirect[i].y + (texEnemyShot1.Height / 2))), null, Color.White, 0.0f, new Vector2(texEnemyShot1.Width, texEnemyShot1.Height), 1.0f, SpriteEffects.FlipVertically, 1);
                    }
                    // DEBUG MODE // Hitbox anzeigen
                    if (DEBUG == true)
                    {
                        HitboxRectangle.Width = ListEnemyShotDirect[i].hitbox_width;
                        HitboxRectangle.Height = ListEnemyShotDirect[i].hitbox_height;
                        HitboxRectangle.X = ListEnemyShotDirect[i].hitbox_x;
                        HitboxRectangle.Y = ListEnemyShotDirect[i].hitbox_y;
                        spriteBatch.Draw(HitboxTexture, HitboxRectangle, Color.Aquamarine);
                    }
                }

                // Bei großem Schuß
                else if (ListEnemyShotDirect[i].hitbox_height == 40)
                {
                    // Schuss auswählen und zeichnen
                    if (ListEnemyShotDirect[i].angel == 1)
                    {
                        spriteBatch.Draw(texEnemyShot1_2, new Vector2(Convert.ToInt32(ListEnemyShotDirect[i].x) + (texEnemyShot1_2.Width / 2), Convert.ToInt32(ListEnemyShotDirect[i].y + (texEnemyShot1_2.Height / 2))), null, Color.White, 0.0f, new Vector2(texEnemyShot1_2.Width, texEnemyShot1_2.Height), 1.0f, SpriteEffects.None, 1);
                    }
                    else if (ListEnemyShotDirect[i].angel == 2)
                    {
                        spriteBatch.Draw(texEnemyShot1_2, new Vector2(Convert.ToInt32(ListEnemyShotDirect[i].x) + (texEnemyShot1_2.Width / 2), Convert.ToInt32(ListEnemyShotDirect[i].y + (texEnemyShot1_2.Height / 2))), null, Color.White, 0.0f, new Vector2(texEnemyShot1_2.Width, texEnemyShot1_2.Height), 1.0f, SpriteEffects.FlipHorizontally, 1);
                    }
                    else if (ListEnemyShotDirect[i].angel == 3)
                    {
                        spriteBatch.Draw(texEnemyShot1_2, new Vector2(Convert.ToInt32(ListEnemyShotDirect[i].x) + (texEnemyShot1_2.Width / 2), Convert.ToInt32(ListEnemyShotDirect[i].y + (texEnemyShot1_2.Height / 2))), null, Color.White, 0.0f, new Vector2(texEnemyShot1_2.Width, texEnemyShot1_2.Height), 1.0f, SpriteEffects.FlipVertically, 1);
                    }
                    // DEBUG MODE // Hitbox anzeigen
                    if (DEBUG == true)
                    {
                        HitboxRectangle.Width = ListEnemyShotDirect[i].hitbox_width;
                        HitboxRectangle.Height = ListEnemyShotDirect[i].hitbox_height;
                        HitboxRectangle.X = ListEnemyShotDirect[i].hitbox_x;
                        HitboxRectangle.Y = ListEnemyShotDirect[i].hitbox_y;
                        spriteBatch.Draw(HitboxTexture, HitboxRectangle, Color.Aquamarine);
                    }
                }
            }



            // Schuss typ 2 --> Laser Schuss --> <ClassEnemyShotLaser> Durchlaufen und zeichnen
            for (int i = 0; i < ListEnemyShotLaser.Count(); i++)
            {
                // Schuss auswählen und zeichnen
                spriteBatch.Draw(ListEnemyShotLaser[i].texture, new Vector2(Convert.ToInt32(ListEnemyShotLaser[i].x) - (ListEnemyShotLaser[i].texture.Width / 2), Convert.ToInt32(ListEnemyShotLaser[i].y)), Color.White);
                // DEBUG MODE // Hitbox anzeigen
                if (DEBUG == true)
                {
                    HitboxRectangle.Width = ListEnemyShotLaser[i].texture.Width;
                    HitboxRectangle.Height = ListEnemyShotLaser[i].texture.Height;
                    HitboxRectangle.X = Convert.ToInt32(ListEnemyShotLaser[i].x) - (ListEnemyShotLaser[i].texture.Width / 2);
                    HitboxRectangle.Y = Convert.ToInt32(ListEnemyShotLaser[i].y);
                    spriteBatch.Draw(HitboxTexture, HitboxRectangle, Color.BlanchedAlmond);
                }
            }
            // **************************************************************************************************************





            // ListExplosions // Explosionen durchlaufen und zeichen
            // **************************************************************************************************************
            for (int x = 0; x < ListExplosions.Count(); x++)
            {
                // Explosionen zeichnen
                spriteBatch.Draw(ListExplosions[x].Texture, new Vector2(ListExplosions[x].x - (ListExplosions[x].Texture.Width / 2), ListExplosions[x].y - (ListExplosions[x].Texture.Height / 2)), Color.White);
            }
            // **************************************************************************************************************





            // Anzeige zeichnen
            // **************************************************************************************************************
            // Display
            spriteBatch.Draw(texDisplay, new Vector2(0, Display_Y), null, Color.White);
            // Waffe
            spriteBatch.Draw(texDisplay_Weapon, new Vector2(74, 2 + Display_Content_Y), null, Color.White);
            // Level Waffe
            spriteBatch.Draw(texDisplay_LevelShot, new Vector2(138, 3 + Display_Content_Y), null, Color.White);


            // Level Extension
            if (Display_Show_Extension == true)
            {
                spriteBatch.Draw(texDisplay_Extension, new Vector2(155, 3 + Display_Content_Y), null, Color.White);
                spriteBatch.Draw(texDisplay_LevelExtension, new Vector2(186, 3 + Display_Content_Y), null, Color.White);
            }

            // Powerschuss Bar ausgeben
            spriteBatch.Draw(texDisplay_PowerShotBar, new Rectangle((204 + MyShip_PowerShot_Width), 5 + Display_Content_Y, (224 - MyShip_PowerShot_Width), 26), Color.White);


            // Leben ausgeben
            spriteBatch.DrawString(fntDisplay, Lives.ToString(), new Vector2(29, 2 + Display_Content_Y), Color.Black);

            // Punkte Ausgeben
            spriteBatch.DrawString(fntDisplay, Points.ToString(), new Vector2(209, 2 + Display_Content_Y), Color.Black);

            // Anzahl Powerschüsse ausgeben
            spriteBatch.DrawString(fntDisplay, MyShip_PowerShots.ToString(), new Vector2(441, 2 + Display_Content_Y), Color.Black);

            // Warnung zeichnen
            if (ShowWarning == true)
            {
                spriteBatch.Draw(texWarning, new Vector2(0, 400), null, Color.White);
            }
            // **************************************************************************************************************





            // Endboss Zeit ausgeben
            // **************************************************************************************************************
            if (BossTimeString != "")
            {
                Color BossTimeColor = new Color(0.8f, 0.8f, 0.8f, 0.8f);
                Vector2 FontOrigin = fntBossTime.MeasureString(BossTimeString) / 2;
                spriteBatch.DrawString(fntBossTime, BossTimeString.ToString(), new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, 60 + Display_Content_Y), Color.LightGray, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
            }
            // **************************************************************************************************************
        }
        // ------------------------------------------------------------------------------------------------------------------------------------
    }
}
