using Flashcards.Commands;
using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Flashcards.ViewModels
{
    public class SelectViewModel : BaseViewModel
    {
        private readonly Navigation _navigation;
        public SelectViewModel(Navigation navigation)
        {
            _navigation = navigation;

            goToBrowseCommand = new GoToBrowseCommand(_navigation);
            newFlashCardSetCommand = new NewFlashCardCommand(_navigation);
        }

        public ICommand goToBrowseCommand { get; }
        public ICommand newFlashCardSetCommand { get; }
    }
}
