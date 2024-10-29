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
    public class GoToEditCommand : BaseCommand
    {
        private readonly Navigation _navigation;
        private readonly Collection<FlashCardSet> _flashCardSets;

        public GoToEditCommand(Navigation navigation, Collection<FlashCardSet> flashCardSets)
        {
            _navigation = navigation;
            _flashCardSets = flashCardSets;
        }

        public override void Execute(object? parameter)
        {            
            if (parameter != null && (int)parameter != -1)
            {
                _navigation.CurrentViewModel = new EditViewModel(_navigation, _flashCardSets[(int)parameter]);
            }
        }
    }
}
