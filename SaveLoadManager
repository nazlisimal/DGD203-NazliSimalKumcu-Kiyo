using System;
using System.Collections.Generic;
using System.IO;

namespace Kiyo
{
    class SaveLoadManager
    {
        private const string SaveFilePath = "savefile.txt";

        public bool Save(string location, bool artifact, List<string> inventory)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(SaveFilePath))
                {
                    writer.WriteLine(location);
                    writer.WriteLine(artifact);
                    writer.WriteLine(string.Join(",", inventory));
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Load(out string location, out bool artifact, out List<string> inventory)
        {
            location = string.Empty;
            artifact = false;
            inventory = new List<string>();

            if (!File.Exists(SaveFilePath))
                return false;

            try
            {
                using (StreamReader reader = new StreamReader(SaveFilePath))
                {
                    location = reader.ReadLine();
                    artifact = bool.Parse(reader.ReadLine());
                    inventory = new List<string>(reader.ReadLine().Split(","));
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
