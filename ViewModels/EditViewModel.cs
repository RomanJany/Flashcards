using Flashcards.Commands;
using Flashcards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Flashcards.ViewModels
{
    public class EditViewModel : BaseViewModel
    {
        private readonly Navigation _navigation;
        private readonly FlashCardSet _flashCardSet;
        public EditViewModel(Navigation navigation, FlashCardSet flashCardSet)
        {
            _navigation = navigation;
            _flashCardSet = flashCardSet;

            HasImage = Visibility.Collapsed;

            goToSelectCommand = new GoToSelectCommand(_navigation);
        }

        private Visibility _hasImage;
        public Visibility HasImage
        {
            get
            {
                return _hasImage;
            }
            set
            {
                _hasImage = value;
                OnPropertyChanged(nameof(HasImage));
                OnPropertyChanged(nameof(NHasImage));
            }
        }
        public Visibility NHasImage
        {
            get
            {
                if (_hasImage == Visibility.Visible)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        public ICommand goToSelectCommand { get; }
    }
}
