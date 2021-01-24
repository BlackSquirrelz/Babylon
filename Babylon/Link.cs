using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babylon
{
    class Link
    {
        public Link(long linkId, int source, int target)
        {
            SourceID = linkId;
            SourceNoteID = source;
            TargetNoteID = target;
            
        }


        public long SourceID { get; set; }
        public int SourceNoteID { get; set; }
        public int TargetNoteID { get; set; }

        // ToDo: Create a method to create links to other notes

        // ToDo: Create a method to delete links from other notes

    }
}
