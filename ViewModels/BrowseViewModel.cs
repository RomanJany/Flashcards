using Flashcards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.ViewModels
{
    public class BrowseViewModel : BaseViewModel
    {
        private readonly Navigation _navigation;
        private readonly FlashCardSet _flashCardSet;
        public BrowseViewModel(Navigation navigation, FlashCardSet flashCardSet)
        {
            _navigation = navigation;
            _flashCardSet = flashCardSet;
        }
    }
}
