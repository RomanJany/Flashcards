using Flashcards.Models;
using Flashcards.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Commands
{
    public class DeleteFlashCardSetCommand : BaseCommand
    {
        private readonly Collection<FlashCardSet> _flashCardSets;

        public DeleteFlashCardSetCommand(Collection<FlashCardSet> flashCardSets)
        {
            _flashCardSets = flashCardSets;
        }

        public override void Execute(object? parameter)
        {
            if (parameter != null)
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/FlashcardSets/" + _flashCardSets[(int)parameter].Name + ".json");

                _flashCardSets.RemoveAt((int)parameter);

                FileDeleted?.Invoke();
            }
        }

        public event Action FileDeleted;

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
