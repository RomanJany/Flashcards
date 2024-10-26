using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private readonly Navigation _navigation;
        public MenuViewModel(Navigation navigation)
        {
            _navigation = navigation;
        }
    }
}
