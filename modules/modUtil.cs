using DiscordRichPresence.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRichPresence.modules
{
    public class modUtil
    {
        private static readonly IFolder folders = new IFolder();

        /// <summary>
        /// Return IFolder object instance which utilizes the enum Folder
        /// </summary>
        /// <returns>Object instance of IFolder</returns>
        public static IFolder GetFolders()
        {
            return folders;
        }

        public static void throwError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
