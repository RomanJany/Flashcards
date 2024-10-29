using Flashcards.Models;
using Flashcards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Commands
{
    public class PreviousFlashCardCommand : BaseCommand
    {
        private readonly FlashCardSet _flashCardSet;

        public PreviousFlashCardCommand(FlashCardSet flashCardSet)
        {
            _flashCardSet = flashCardSet;
        }

        public event Action PreviousFlashCardSelected;

        public override void Execute(object? parameter)
        {
            if (parameter != null && (int)parameter != 0)
            {
                PreviousFlashCardSelected?.Invoke();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            if (parameter != null && (int)parameter > 0)
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
