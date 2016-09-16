using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBNDB_WPF_Example.Model
{
    public class Book
    {
        public Book()
        {
            //this.Title = string.Empty;
            this.Title = "Test String!";
            this.TitleLong = string.Empty;
            this.AuthorsText = string.Empty;
            this.PublisherText = string.Empty;
        }

        public string Title { get; set; }
        public string TitleLong{ get; set; }
        public string AuthorsText { get; set; }
        public string PublisherText { get; set; }
    }
}
