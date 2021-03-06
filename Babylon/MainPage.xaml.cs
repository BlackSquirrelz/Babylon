﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Babylon
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();

            // Configure the working directory first...
            string zettelkastenNotesDirName = SetupWorkspace();

            PopulateNotes(zettelkastenNotesDirName);
        }

        private void PopulateNotes(string workingDir )
        {
            List<Note> Notes = new List<Note>();

            ObservableCollection<Note> Details = new ObservableCollection<Note>();

            DirectoryInfo dirInfo = new DirectoryInfo(workingDir);
            System.IO.FileInfo[] fileNames = dirInfo.GetFiles("*.md*");

            foreach (System.IO.FileInfo fi in fileNames)
            {
                string text = System.IO.File.ReadAllText(fi.FullName);

                // Create new Object "newNote" and add Values to it.
                Note newNote = new Note(fi.Name, "Summary", text, "Coming Soon...", fi.CreationTime);
                Notes.Add(newNote);
                Details.Add(newNote);

            }
            
            cvsNotes.Source = Notes;

        }


        private void DeleteNote(int noteID)
        {
            System.Diagnostics.Debug.WriteLine("Note Deletion was requested"); 
        }

        private void EditNote(int noteID)
        {
            System.Diagnostics.Debug.WriteLine("Edit Note was requested");
        }


        //TODO: In a further iteration, and during setup, ask the user which directory they would like as their notes directory.
        public string SetupWorkspace()
        {
            string userDirectory = "T:\\01_Documents\\02_Zettelkasten\\Notes\\";

            // See if the Notes directory exists already and if not create it. This will be the directory for all the permanent notes according to the Zettelkasten principle.
            if (!System.IO.Directory.Exists(userDirectory))
            {
                System.IO.Directory.CreateDirectory(userDirectory);
            }

            System.IO.Directory.SetCurrentDirectory(userDirectory);
            string zettelkastenNotesDirName = System.IO.Directory.GetCurrentDirectory();

            System.Diagnostics.Debug.WriteLine(zettelkastenNotesDirName);

            return zettelkastenNotesDirName;
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Button Clicked");
        }

        private void GridView_DragOver(object sender, DragEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"dragging {e.DataView.GetType()}");
            
            //UIElement element = e.DataView.
        }

        private async void Grid_Drop(object sender, DragEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("item dropped");
        }

    }

}
