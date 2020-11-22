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

            PopulateNotes();
        }

        private void PopulateNotes()
        {
            /*string filepath = "T:\01_Documents\02_Zettelkasten\Notes";*/

            List<Note> Notes = new List<Note>();

            Note newNote = new Note();
            newNote.Name = "Some Note";
            newNote.Details.Add(new Detail()
            {
                Title = "Very first note...",
                Abstract = "This is my first note....",
                Complete = true,
                CreationDate = startDate.AddDays(2)
            });
            Notes.Add(newNote);

            newNote = new Note();
            newNote.Name = "Babylon";
            newNote.Details.Add(new Detail(){ Title="Creation of Notes", Abstract = "Another Note", Complete=false, CreationDate=startDate });
            Notes.Add(newNote);

            newNote = new Note();
            newNote.Name = "ABC";
            newNote.Details.Add(new Detail() { Title="This is the last Note", Abstract = "LAst Note", Complete = false, CreationDate = startDate });
            Notes.Add(newNote);

            newNote = new Note();
            newNote.Name = "Pengjuan";
            newNote.Details.Add(new Detail() { Title = "This is another test", Abstract = "In this note we discuss the thing....", Complete = false, CreationDate = startDate });
            Notes.Add(newNote);

            cvsNotes.Source = Notes;

        }

    }

    public class Note
    {
        public Note()
        {
            Details = new ObservableCollection<Detail>();
        }

        public string Name { get; set; }
        public ObservableCollection<Detail> Details { get; set; }
    }

    public class Detail
    {
        public string Title { get; set; }
        public string Abstract { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Complete { get; set; }
        public string Note { get; set; }
    }

}
