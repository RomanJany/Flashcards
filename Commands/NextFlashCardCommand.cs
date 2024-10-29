using Flashcards.Models;
using Flashcards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Commands
{
    public class NextFlashCardCommand : BaseCommand
    {
        private readonly FlashCardSet _flashCardSet;

        public NextFlashCardCommand(FlashCardSet flashCardSet)
        {
            _flashCardSet = flashCardSet;
        }

        public event Action NextFlashCardSelected;

        public override void Execute(object? parameter)
        {
            if (parameter != null && _flashCardSet.FlashCards.Count > (int)parameter + 1)
            {
                NextFlashCardSelected?.Invoke();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            if (parameter != null && _flashCardSet.FlashCards.Count > (int)parameter + 1)
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
