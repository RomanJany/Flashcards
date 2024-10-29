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
    public class AddImageCommand : BaseCommand
    {
        private EditViewModel _editViewModel;

        public AddImageCommand(EditViewModel viewModel)
        {
            _editViewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    BitmapImage bitmapImage = new BitmapImage(new Uri(openFileDialog.FileName));
                    _editViewModel.CurrentImage = bitmapImage;
                }
                catch { }                                                                
            }            
        }

        public override bool CanExecute(object? parameter)
        {
            if (_editViewModel.CurrentImage == null)
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
