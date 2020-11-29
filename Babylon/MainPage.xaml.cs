using System;
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
        DateTime startDate = DateTime.Now;

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

            DirectoryInfo dirInfo = new DirectoryInfo(workingDir);
            System.IO.FileInfo[] fileNames = dirInfo.GetFiles("*.md*");

            foreach (System.IO.FileInfo fi in fileNames)
            {
                Note newNote = new Note();
                newNote.Name = fi.Name;
                newNote.CreationDate = fi.CreationTime;

                string text = System.IO.File.ReadAllText(fi.FullName);

                newNote.Details.Add(new Detail()
                {
                    Title = fi.Name,
                    Abstract = text,
                });

                Notes.Add(newNote);

            }

            Console.WriteLine(Notes);
            cvsNotes.Source = Notes;

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

            Console.WriteLine(zettelkastenNotesDirName);

            return zettelkastenNotesDirName;
        }


    }

    public class Note
    {
        public Note()
        {
            Details = new ObservableCollection<Detail>();
        }

        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public ObservableCollection<Detail> Details { get; set; }
    }

    public class Detail
    {
        public string Title { get; set; }
        public string Abstract { get; set; }
        public bool Complete { get; set; }
        public string Note { get; set; }
    }

}
