using Flashcards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Xps.Packaging;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Flashcards.ViewModels
{
    public class BrowseViewModel : BaseViewModel
    {
        private readonly Navigation _navigation;
        private readonly FlashCardSet _flashCardSet;
        public BrowseViewModel(Navigation navigation, FlashCardSet flashCardSet)
        {
            _navigation = navigation;
            _flashCardSet = flashCardSet;

            CurrentFlashCardIndex = 0;
            FrontSide = true;
        }

        private int _currentFlashCardIndex;
        public int CurrentFlashCardIndex
        {
            get
            {
                return _currentFlashCardIndex;
            }
            set
            {
                if (value >= 0 && value < _flashCardSet.FlashCards.Count)
                {
                    _currentFlashCardIndex = value;

                    FrontSide = true;
                }
                OnPropertyChanged(nameof(CurrentFlashCardIndex));
                FrontSide = FrontSide;
            }
        }

        public FlashCard CurrentFlashCard
        {
            get
            {
                return _flashCardSet.FlashCards[CurrentFlashCardIndex];
            }
        }

        public string CurrentText
        {
            get
            {
                if (FrontSide)
                {
                    return CurrentFlashCard.FrontText;
                }
                else
                {
                    return CurrentFlashCard.BackText;
                }
            }
            set
            {
                if (FrontSide)
                {
                    CurrentFlashCard.FrontText = value;
                }
                else
                {
                    CurrentFlashCard.BackText = value;
                }
                OnPropertyChanged(nameof(CurrentText));
            }
        }

        public BitmapImage CurrentImage
        {
            get
            {
                if (FrontSide)
                {
                    return CurrentFlashCard.FrontImage;
                }
                else
                {
                    return CurrentFlashCard.BackImage;
                }
            }
            set
            {
                if (FrontSide)
                {
                    CurrentFlashCard.FrontImage = value;
                }
                else
                {
                    CurrentFlashCard.BackImage = value;
                }
                OnPropertyChanged(nameof(CurrentImage));
                OnPropertyChanged(nameof(HasImage));
                OnPropertyChanged(nameof(NHasImage));
            }
        }

        public Visibility HasImage
        {
            get
            {
                if (CurrentImage == null)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }
        public Visibility NHasImage
        {
            get
            {
                if (HasImage == Visibility.Visible)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        private bool _frontSide;
        public bool FrontSide
        {
            get
            {
                return _frontSide;
            }
            set
            {
                _frontSide = value;

                OnPropertyChanged(nameof(HasImage));
                OnPropertyChanged(nameof(NHasImage));
                OnPropertyChanged(nameof(CurrentText));
                OnPropertyChanged(nameof(CurrentImage));
            }
        }
    }    
}
