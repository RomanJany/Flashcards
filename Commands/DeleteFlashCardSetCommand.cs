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
    public class DeleteFlashCardSetCommand : BaseCommand
    {
        private readonly Collection<FlashCardSet> _flashCardSets;

        public DeleteFlashCardSetCommand(Collection<FlashCardSet> flashCardSets)
        {
            _flashCardSets = flashCardSets;
        }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
