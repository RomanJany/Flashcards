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
            ((DeleteFlashCardCommand)deleteFlashCardCommand).FlashCardDeleted += OnFlashCardDeleted;
        }

        private void OnFlashCardAdded()
        {
            CurrentFlashCardIndex = _flashCardSet.FlashCards.Count - 1;
        }

        private void OnFlashCardDeleted()
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

        public FlashCard CurrentFlashCard
        {
            get
            {
                return _flashCardSet.FlashCards[CurrentFlashCardIndex];
            }
        }

        private string _currentText;
        public string CurrentText
        {
            get
            {
                return _currentText;
            }
            set
            {
                _currentText = value;
                OnPropertyChanged(nameof(CurrentText));
            }
        }

        private BitmapImage _currentImage;
        public BitmapImage CurrentImage
        {
            get
            {
                return _currentImage;
            }
            set
            {
                _currentImage = value;
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
                _flashCardSideUpdate();
                OnPropertyChanged(nameof(HasImage));
                OnPropertyChanged(nameof(NHasImage));
            }
        }

        private void _flashCardSideUpdate()
        {
            if (FrontSide)
            {
                CurrentText = CurrentFlashCard.FrontText;
                CurrentImage = CurrentFlashCard.FrontImage;
            }
            else
            {
                CurrentText = CurrentFlashCard.BackText;
                CurrentImage = CurrentFlashCard.BackImage;
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
    }
}
