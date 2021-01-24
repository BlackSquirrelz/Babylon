using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babylon
{
    class Note
    {
        public Note(string title, string summary, string noteBody, string reference, DateTime creationDate)
        {
            Title = title;
            Summary = summary;
            NoteBody = noteBody;
            Reference = reference;
            CreationDate = creationDate;

        }


        // Linking one note to another note
        private void CreateLinkage()
        {
            //TODO: Get the latest Link ID from the Database
            DateTime current = DateTime.Now;
            long link_id = current.Ticks;
            Link newLink = new Link(link_id, 1, 1);
        }
        
        // Removing a relationship from a note
        private void DeleteLinkage()
        {
            //DeleteLink.GetLinkID();
            System.Diagnostics.Debug.WriteLine("Delete Link Button was pressed");
        }

        // This method is to create the thickness of the Relationship
        public int GetLinks()
        {
            int numberLinks = 10;
            return numberLinks;
        }


        public string Title { get; set; }
        public string Summary { get; set; }
        public string NoteBody { get; set; }
        public string Reference { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
