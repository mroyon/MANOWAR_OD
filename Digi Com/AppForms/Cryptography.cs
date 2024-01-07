using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digi_Com.AppForms
{
    public class Cryptography
    {//  Call this function to remove the key from memory after use for security
        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);

        /// <summary>
        /// Creates a random salt that will be used to encrypt your file. This method is required on FileEncrypt.
        /// </summary>
        /// <returns></returns>
        public static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    // Fille the buffer with the generated data
                    rng.GetBytes(data);
                }
            }

            return data;
        }

        /// <summary>
        /// Encrypts a file from its path and a plain password.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="password"></param>
        public void FileEncrypt(string inputFile, string password)
        {
            FileInfo fileOriginal = new FileInfo(inputFile);
            string encryptedString = File.ReadAllText(fileOriginal.FullName);

            string directoryPath = fileOriginal.Directory.FullName;
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileOriginal.FullName);
            string fileExtension = Path.GetExtension(fileOriginal.FullName);
            long fileSize = fileOriginal.Length;

            string outputPath = Path.Combine(directoryPath, fileNameWithoutExtension + fileExtension + ".aes");
            File.WriteAllText(outputPath, encryptedString);

        }

        /// <summary>
        /// Decrypts an encrypted file with the FileEncrypt method through its path and the plain password.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        /// <param name="password"></param>
        public void FileDecrypt(string inputFile, string outputFile, string password)
        {
            FileInfo fileOriginal = new FileInfo(inputFile);
            string encryptedString = File.ReadAllText(fileOriginal.FullName);

            string directoryPath = fileOriginal.Directory.FullName;
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileOriginal.FullName);
            string fileExtension = Path.GetExtension(fileOriginal.FullName);
            long fileSize = fileOriginal.Length;


        }
    }

}



