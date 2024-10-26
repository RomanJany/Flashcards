using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.ViewModels
{
    public class SelectViewModel : BaseViewModel
    {
        private readonly Navigation _navigation;
        public SelectViewModel(Navigation navigation)
        {
            _navigation = navigation;
        }
    }
}
