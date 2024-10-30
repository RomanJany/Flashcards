using Flashcards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Xps.Packaging;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using Flashcards.Commands;

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

            _random = new Random();
            OnNextFlashCardSelected();
            FrontSide = true;

            goToSelectCommand = new GoToSelectCommand(_navigation);
            nextFlashCardCommand = new NextFlashCardCommand(_flashCardSet);
            ((NextFlashCardCommand)nextFlashCardCommand).NextFlashCardSelected += OnNextFlashCardSelected;
        }

        private void OnNextFlashCardSelected()
        {
            FlashCard oldFlashCard = CurrentFlashCard;
            CurrentFlashCard = _flashCardSet.FlashCards[_random.Next(_flashCardSet.FlashCards.Count)];

            if (_flashCardSet.FlashCards.Count > 1 && oldFlashCard != null)
            {
                while (oldFlashCard.GetHashCode() == CurrentFlashCard.GetHashCode())
                {
                    CurrentFlashCard = _flashCardSet.FlashCards[_random.Next(_flashCardSet.FlashCards.Count)];
                }
            }
        }

        private Random _random;

        public int nIndex
        {
            get
            {
                return -1;
            }
        }

        private FlashCard _currentFlashCard;
        public FlashCard CurrentFlashCard
        {
            get
            {
                return _currentFlashCard;
            }
            set
            {
                _currentFlashCard = value;

                FrontSide = true;
                OnPropertyChanged(nameof(CurrentFlashCard));
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

        public ICommand goToSelectCommand { get; }
        public ICommand nextFlashCardCommand { get; }
    }    
}
