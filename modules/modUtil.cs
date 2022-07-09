using DiscordRichPresence.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRichPresence.modules
{
    public class modUtil
    {
        private static readonly IFolder folders = new IFolder();
        private static readonly string confContent = @"<?xml version=""1.0"" encoding=""utf-8"" ?><configuration><appSettings><Port>{port}</Port></appSettings></configuration>";

        /// <summary>
        /// Return IFolder object instance which utilizes the enum Folder
        /// </summary>
        /// <returns>Object instance of IFolder</returns>
        public static IFolder GetFolders()
        {
            return folders;
        }

        public static string ConfContent()
        {
            return confContent;
        }

        /// <summary>
        /// Create a message box popup with the error message
        /// </summary>
        /// <param name="message"></param>
        public static void throwError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Encrypt a message 
        /// </summary>
        /// <param name="plainText">Raw message that needs to be encrypted</param>
        /// <param name="key">AES key value</param>
        /// <param name="iv">AES iv value</param>
        /// <returns>Encrypted message in bytes</returns>
        public static byte[] Encrypt(string plainText, byte[] key, byte[] iv)
        {
            byte[] encrypted = null;
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        /// <summary>
        /// Decrypt an encrypted message
        /// </summary>
        /// <param name="cipherText">Encrypted byte message</param>
        /// <param name="key">AES key value</param>
        /// <param name="iv">AES iv value</param>
        /// <returns></returns>
        public static string Decrypt(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}
