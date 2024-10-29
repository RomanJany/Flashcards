using Flashcards.Models;
using Flashcards.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Flashcards.Commands
{
    public class RemoveImageCommand : BaseCommand
    {
        private EditViewModel _editViewModel;

        public RemoveImageCommand(EditViewModel viewModel)
        {
            _editViewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _editViewModel.CurrentImage = null;          
        }

        public override bool CanExecute(object? parameter)
        {
            if (_editViewModel.CurrentImage != null)
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
