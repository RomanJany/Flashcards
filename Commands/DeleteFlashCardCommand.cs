using Flashcards.Models;
using Flashcards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Commands
{
    public class DeleteFlashCardCommand : BaseCommand
    {
        private readonly FlashCardSet _flashCardSet;

        public DeleteFlashCardCommand(FlashCardSet flashCardSet)
        {
            _flashCardSet = flashCardSet;
        }

        public event Action FlashCardDeleted;

        public override void Execute(object? parameter)
        {
            if (parameter != null)
            {
                _flashCardSet.Remove((int)parameter);
                FlashCardDeleted?.Invoke();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            if (_flashCardSet.FlashCards.Count > 1)
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
