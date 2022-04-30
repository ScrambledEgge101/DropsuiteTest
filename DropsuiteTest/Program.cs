using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            // Get the folder path from the user
            string folderPath = Program.GetFolderPath();
            string[] filePaths = Directory.GetFiles(folderPath, string.Empty, SearchOption.AllDirectories);
            int mostIdenticalFiles = Program.LargestQuantityOfFilesWithIdenticalContent(filePaths, out string mostFrequentString);
            Program.WriteResults(mostIdenticalFiles, mostFrequentString);
            Console.ReadLine();
        }

        /// <summary>
        /// Asks the user for a folder path and returns it if it exists.
        /// </summary>
        /// <returns>The foldder path the user entered.</returns>
        private static string GetFolderPath()
        {
            // Initialize a variable to hold the path the user selects
            string selectedPath = null;

            // Loop as long as the user does not enter "q"
            while ("q" != selectedPath)
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

        /// <summary>
        /// Writes the results of the operation to the console window.
        /// </summary>
        /// <param name="count">The largest number of files with the same contents.</param>
        /// <param name="commonString">The string that all of those files had in common.</param>
        private static void WriteResults(int count, string commonString)
        {
            // Write the string and count to the console window
            Console.WriteLine($"{commonString} {count}");
        }

        /// <summary>
        /// Retrieves the largest number of files that have the same contents, as well as their contents.
        /// </summary>
        /// <param name="filePathsToCompareAgainst">The paths of files to compare with each other.</param>
        /// <param name="fileContents">The file contents of those files returned as an out parameter.</param>
        /// <returns>The largest quantity of files with the same contents.</returns>
        private static int LargestQuantityOfFilesWithIdenticalContent(string[] filePathsToCompareAgainst, out string fileContents)
        {
            // Set up a dictionary to contain the file contents and how many files have those contents
            Dictionary<string, int> fileContentsAndNumberOfSameFiles = new Dictionary<string, int>();

            // Loop through each file and compare them to all the ones before
            foreach (string filePath in filePathsToCompareAgainst)
            {
                // Read all the file contents from the file path we are iterating on
                string contents = File.ReadAllText(filePath);

                // If the contents of this file exist in the dictionary, add one to the count
                // Otherwise, add the contents to the dictionary with an initial value of 1 file
                if (fileContentsAndNumberOfSameFiles.ContainsKey(contents))
                    fileContentsAndNumberOfSameFiles[contents]++;
                else
                    fileContentsAndNumberOfSameFiles.Add(contents, 1);
            }

            // Sort the dictionary so that the largest value (number of files) is at the top, and grab that one, which is the contents of
            // the most frequently-occurring string and the amount of times that string appeared
            KeyValuePair<string, int> contentsAndQuantity = fileContentsAndNumberOfSameFiles.OrderByDescending(f => f.Value).First();
            fileContents = contentsAndQuantity.Key;
            return contentsAndQuantity.Value;
        }
    }
}
