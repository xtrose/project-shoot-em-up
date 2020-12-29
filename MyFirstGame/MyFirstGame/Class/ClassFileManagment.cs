using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;






// Namespace
namespace MyFirstGame
{




    // Klasse zum erstellen und laden von Dateien
    class ClassFileManagment
    {




        
        // Variablen
        // ---------------------------------------------------------------------------------------------------
        // Iso Store Variablen
        public static IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
        public static IsolatedStorageFileStream filestream;
        public static StreamReader streamReader;
        public static StreamWriter streamWriter;
        // ---------------------------------------------------------------------------------------------------





        // Datei laden, erstellen, überschreiben
        // ---------------------------------------------------------------------------------------------------
        public static string loadCreateOverwrite(string path, string data, bool write)
        {
            // Ausgabe erstellen
            string output = "";


            // Wenn Datei bereits besteht
            if (file.FileExists(path))
            {
                // Wenn Datei geladen wird
                if (!write)
                {
                    filestream = file.OpenFile(path, FileMode.Open);
                    streamReader = new StreamReader(filestream);
                    output = streamReader.ReadToEnd();
                    filestream.Close();
                    output = output.Trim();
                }
                // Wenn Datei überschrieben wird
                else
                {
                    filestream = file.CreateFile(path);
                    streamWriter = new StreamWriter(filestream);
                    streamWriter.WriteLine(data);
                    streamWriter.Flush();
                    filestream.Close();
                    output = data;
                }
            }
            // Wenn Datei noch nicht besteht
            else if (write)
            {
                filestream = file.CreateFile(path);
                streamWriter = new StreamWriter(filestream);
                streamWriter.WriteLine(data);
                streamWriter.Flush();
                filestream.Close();
                output = data;
            }


            // Ausgabe
            return output;
        }
        // ---------------------------------------------------------------------------------------------------





        // Ordner allen Dateien und Unterorden löschen
        // ---------------------------------------------------------------------------------------------------
        public static void deleteFolder(string path)
        {
            // Alle Dateien und Ordner laden
            string[] files = file.GetFileNames(path + "/");
            string[] directorys = file.GetDirectoryNames(path + "/");


            // Alle Dateien durchlaufen und löschen
            for (int i = 0; i < files.Count(); i++)
            {
                file.DeleteFile(path + "/" + files[i]);
            }


            // Alle Ordner durchlaufen und löschen
            for (int i = 0; i < directorys.Count(); i++)
            {
                deleteFolder(path + "/" + directorys[i]);
            }


            // Ordner löschen
            file.DeleteDirectory(path);
        }
        // ---------------------------------------------------------------------------------------------------





        // Ordner allen Dateien und Unterorden löschen
        // ---------------------------------------------------------------------------------------------------
        public static void copyIsoStoreToIsoStore(string pathSource, string pathTarget)
        {
            // Ordner erstellen // pathTarget
            if (!file.DirectoryExists(pathTarget))
            {
                file.CreateDirectory(pathTarget);
            }


            // Ordner und Dateien laden // pathSource
            string[] files = file.GetFileNames(pathSource);
            string[] folders = file.GetDirectoryNames(pathSource);


            // Dateien kopieren
            for (int i = 0; i < files.Count(); i++)
            {
                if (file.FileExists(pathSource + files[i]))
                {
                    if (file.DirectoryExists(pathTarget + "/"))
                    {

                    }
                }
                file.CopyFile(pathSource + files[i], pathTarget + "/" + files[i]);
            }


            // Ordner durchlaufen und kopieren
            for (int i = 0; i < folders.Count(); i++)
            {
                copyIsoStoreToIsoStore(pathSource + folders[i] + "/", pathTarget + "/" + folders[i]);
            }
        }
        // ---------------------------------------------------------------------------------------------------





    }





}
