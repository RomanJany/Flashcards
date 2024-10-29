using Flashcards.Models;
using Flashcards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Commands
{
    public class NewFlashCardSetCommand : BaseCommand
    {
        private readonly Navigation _navigation;

        public NewFlashCardSetCommand(Navigation navigation)
        {
            _navigation = navigation;
        }

        public override void Execute(object? parameter)
        {
            FlashCardSet flashCardSet = new FlashCardSet();
            flashCardSet.Add(new FlashCard { FrontText="", FrontImage=null, BackText="", BackImage=null});
            _navigation.CurrentViewModel = new EditViewModel(_navigation, flashCardSet);
        }
    }
}
