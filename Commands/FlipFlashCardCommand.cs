using Flashcards.Models;
using Flashcards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Commands
{
    public class FlipFlashCardCommand : BaseCommand
    {
        public FlipFlashCardCommand()
        {
        }

        public event Action FlashCardFlipped;

        public override void Execute(object? parameter)
        {  
            FlashCardFlipped?.Invoke();           
        }
    }
}
