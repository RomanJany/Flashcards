using Flashcards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
    }
}
