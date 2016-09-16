using ISBNDB_WPF_Example.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ISBNDB_WPF_Example.ViewModel
{
    class BookViewModel : BaseViewModel
    {
        public BookViewModel()
        {
            Book = new Book();
            RaisePropertyChangedEvent("Book");
            //Book.GetDataFromISBN("0061031321");
            
        }

        public Book Book { get; set; }
        
        public ICommand GetDataFromISBNCommand
        {
            get { return new DelegateCommand(Book.GetDataFromISBN); }
        }

    }
}
