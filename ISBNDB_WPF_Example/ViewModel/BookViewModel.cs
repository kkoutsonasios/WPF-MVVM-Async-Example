using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBNDB_WPF_Example.ViewModel
{
    class BookViewModel : BaseViewModel
    {
        private ObservableCollection<string> _searchHistory = new ObservableCollection<string>();

        public ObservableCollection<string> SearchHistory
        { get { return _searchHistory; } private set { } }


    }
}
