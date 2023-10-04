using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;

namespace DuplicateFileFinderCs {
    /// <summary>
    /// Kokofthesos
    /// </summary>
    public static class Mole {

        /// <summary>
        /// Return all duplicate files found in "path" 
        /// </summary>
        /// <param name="path">ughh/param>
        public static Dictionary<string, string> DigIn(string path) {
            Console.WriteLine("The Nibdz is digging...");

            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            Dictionary<string, string> FileHashPair = new();
            Dictionary<string, string> duplicateHashes = new();
            foreach (string filePath in files) {
                using (MD5 md5 = MD5.Create())
                using (FileStream stream = File.OpenRead(filePath)) {
                    byte[] hashData = md5.ComputeHash(stream);
                    string hash = BitConverter.ToString(hashData).Replace("-", "").ToLowerInvariant();
                    FileHashPair.Add(filePath, hash);
                }
            }

            duplicateHashes = FileHashPair
                .GroupBy(kv => kv.Value)
                .Where(group => group.Count() > 1)
                .SelectMany(group => group)
                .ToDictionary(kv => kv.Key, kv => kv.Value);


            return duplicateHashes;
        }
    }
}
