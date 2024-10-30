using Flashcards.Models;
using Flashcards.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Flashcards.Commands
{
    public class OpenFlashCardFolderCommand : BaseCommand
    {
        public OpenFlashCardFolderCommand()
        {
        }

        public override void Execute(object? parameter)
        {
            Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory + "FlashcardSets");
        }
    }
}
