using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly Navigation _navigation;
        public BaseViewModel CurrentViewModel => _navigation.CurrentViewModel;

        public MainViewModel(Navigation navigation)
        {
            _navigation = navigation;
        }
    }
}
