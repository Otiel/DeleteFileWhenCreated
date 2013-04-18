using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace DeleteFileWhenCreated {

    static class Program {

        /// <summary>
        /// The file to delete.
        /// </summary>
        private static String fileToDelete;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            // For debug purposes
            //args = new String[] { @"C:\Users\Public\Desktop\New Text Document.txt" };

            if (args.Length != 1) {
                return;
            }

            // Fetch arg
            fileToDelete = args[0];
            String folderToWatch = Path.GetDirectoryName(fileToDelete);

            // Create a new FileSystemWatcher and set its properties
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = folderToWatch;
            // Watch for changes in LastAccess and LastWrite times, and the renaming of files or 
            // directories
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite |
                NotifyFilters.FileName | NotifyFilters.DirectoryName;

            // Add event handlers
            //watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreated);
            //watcher.Deleted += new FileSystemEventHandler(OnChanged);
            //watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching
            watcher.EnableRaisingEvents = true;

            if (File.Exists(fileToDelete)) {
                File.Delete(fileToDelete);
            }

            // Run indefinitely
            Application.Run();
        }

        /// <summary>
        /// Called when a watched file is created.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="e">The <see cref="FileSystemEventArgs"/> instance containing the event 
        /// data.</param>
        private static void OnCreated(object source, FileSystemEventArgs e) {
            try {
                if (File.Exists(fileToDelete)) {
                    File.Delete(fileToDelete);
                }
            } catch {
                // Exception occured, probably because the file is locked by another process

                // Wait 1 sec
                Thread.Sleep(1000);
                // ... then retry to delete
                if (File.Exists(fileToDelete)) {
                    File.Delete(fileToDelete);
                }
            }
        }
    }
}