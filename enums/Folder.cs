using System.Collections.Generic;

namespace DiscordRichPresence.enums
{
    /// <summary>
    /// Enum describing all available types of folders
    /// </summary>
    public enum Folder
    {
        LOG
    };

    public class IFolder
    {
        private static Dictionary<Folder, String> folders = new Dictionary<Folder, String>();

        /// <summary>
        /// Initialize folder paths based on all available enums of type Folder
        /// </summary>
        public IFolder()
        {
            foreach(Folder folder in Enum.GetValues(typeof(Folder)))
            {
                folders[folder] = Application.StartupPath + folder.ToString().ToLower() + "\\";
            }
        }

        /// <summary>
        /// Retrieve a single path based on the enum Folder
        /// </summary>
        /// <param name="folder">Pass the enum type to retrieve the path</param>
        /// <returns>Path based on the provided enum</returns>
        public String GetPath(Folder folder)
        {
            return folders[folder];
        }

        /// <summary>
        /// Create a list of all paths based on enums of type Folder
        /// </summary>
        /// <returns>List with all folder paths</returns>
        public List<String> GetPaths()
        {
            return folders.Values.ToList<String>();
        }
    }
}