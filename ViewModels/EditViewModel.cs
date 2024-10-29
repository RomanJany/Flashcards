using Flashcards.Commands;
using Flashcards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

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

            CurrentFlashCardIndex = 0;
            FrontSide = true;

            goToSelectCommand = new GoToSelectCommand(_navigation);
            newFlashCardCommand = new NewFlashCardCommand(_flashCardSet);
            ((NewFlashCardCommand)newFlashCardCommand).FlashCardAdded += OnFlashCardAdded;
            deleteFlashCardCommand = new DeleteFlashCardCommand(_flashCardSet);
            ((DeleteFlashCardCommand)deleteFlashCardCommand).FlashCardDeleted += OnPreviousFlashCardSelected;
            nextFlashCardCommand = new NextFlashCardCommand(_flashCardSet);
            ((NextFlashCardCommand)nextFlashCardCommand).NextFlashCardSelected += OnNextFlashCardSelected;
            previousFlashCardCommand = new PreviousFlashCardCommand(_flashCardSet);
            ((PreviousFlashCardCommand)previousFlashCardCommand).PreviousFlashCardSelected += OnPreviousFlashCardSelected;
            saveFlashCardSetCommand = new SaveFlashCardSetCommand(_flashCardSet);
            flipFlashCardCommand = new FlipFlashCardCommand();
            ((FlipFlashCardCommand)flipFlashCardCommand).FlashCardFlipped += OnFlashCardFlipped;
        }

        private void OnFlashCardFlipped()
        {
            FrontSide = !FrontSide;
        }

        private void OnNextFlashCardSelected()
        {
            CurrentFlashCardIndex++;
        }

        private void OnFlashCardAdded()
        {
            CurrentFlashCardIndex = _flashCardSet.FlashCards.Count - 1;
        }

        private void OnPreviousFlashCardSelected()
        {
            CurrentFlashCardIndex--;
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
            }
        }

        public string FlashCardSetName
        {
            get
            {
                return _flashCardSet.Name;
            }
            set
            {
                _flashCardSet.Name = value;
                OnPropertyChanged(nameof(FlashCardSetName));
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
                OnPropertyChanged(nameof(FlipButtonText));              
            }
        }
        public string FlipButtonText
        {
            get
            {
                if (FrontSide)
                {
                    return "Flip (Front)";
                }
                else
                {
                    return "Flip (Back)";
                }
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

        public ICommand goToSelectCommand { get; }
        public ICommand newFlashCardCommand { get; }
        public ICommand deleteFlashCardCommand { get; }
        public ICommand nextFlashCardCommand { get; }
        public ICommand previousFlashCardCommand { get; }
        public ICommand saveFlashCardSetCommand { get; }
        public ICommand flipFlashCardCommand { get; }
    }
}
