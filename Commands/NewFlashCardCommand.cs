using Flashcards.Models;
using Flashcards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Commands
{
    public class NewFlashCardCommand : BaseCommand
    {
        private readonly FlashCardSet _flashCardSet;

        public NewFlashCardCommand(FlashCardSet flashCardSet)
        {
            _flashCardSet = flashCardSet;
        }

        public event Action FlashCardAdded;

        public override void Execute(object? parameter)
        {
            _flashCardSet.Add(new FlashCard { FrontText="", FrontImage=null, BackText="", BackImage=null });
            FlashCardAdded?.Invoke();
        }
    }
}
