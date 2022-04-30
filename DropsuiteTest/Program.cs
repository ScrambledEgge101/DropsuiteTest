using System;
using System.IO;

namespace DropsuiteTest
{
    /// <summary>
    /// The main program class, containing the main method.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main method amd application's starting point.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Get the folder path from the user
            string folderPath = Program.GetFolderPath();
        }

        /// <summary>
        /// Asks the user for a folder path and returns it if it exists.
        /// </summary>
        /// <returns>A folder path.</returns>
        private static string GetFolderPath()
        {
            // Initialize a variable to hold the path the user selects
            string selectedPath = null;

            // Loop as long as the user does not enter "q"
            while (selectedPath != "q")
            {
                // Write instructions to the console
                Console.WriteLine("Enter the parent path of the folder you would like to scan, or q to quit:");

                // Give the user an opportunity to enter a folder path
                selectedPath = Console.ReadLine();

                // Return the selected folder path if it exists
                if (Directory.Exists(selectedPath))
                    return selectedPath;
                else
                    Console.WriteLine("That folder does not exist. Make sure the directory exists and you didn't make any typos");
            }

            // If the user entered "q", exit the program
            Environment.Exit(0);
            return null;
        }
    }
}
