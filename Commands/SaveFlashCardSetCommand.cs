using Flashcards.Models;
using Flashcards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Flashcards.Commands
{
    public class SaveFlashCardSetCommand : BaseCommand
    {
        private readonly FlashCardSet _flashCardSet;

        public SaveFlashCardSetCommand(FlashCardSet flashCardSet)
        {
            _flashCardSet = flashCardSet;
        }

        public override void Execute(object? parameter)
        {
            if (_flashCardSet.Name != "")
            {
                _flashCardSet.Save(AppDomain.CurrentDomain.BaseDirectory + "/FlashcardSets/" + _flashCardSet.Name + ".json");
                MessageBox.Show("Flashcard set saved");
            }
            else
            {
                MessageBox.Show("Enter Name");
            }
        }
    }
}
