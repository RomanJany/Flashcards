using Flashcards.Models;
using Flashcards.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Commands
{
    public class GoToBrowseCommand : BaseCommand
    {
        private readonly Navigation _navigation;
        private readonly Collection<FlashCardSet> _flashCardSets;

        public GoToBrowseCommand(Navigation navigation, Collection<FlashCardSet> flashCardSets)
        {
            _navigation = navigation;
            _flashCardSets = flashCardSets;
        }

        public override void Execute(object? parameter)
        {
            if (parameter != null && (int)parameter != -1)
            {
                _navigation.CurrentViewModel = new BrowseViewModel(_navigation, _flashCardSets[(int)parameter]);
            }
        }

        public override bool CanExecute(object? parameter)
        {
            if (parameter != null && (int)parameter != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
