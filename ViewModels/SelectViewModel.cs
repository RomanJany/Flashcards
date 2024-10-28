using Flashcards.Commands;
using Flashcards.Models;
using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Flashcards.ViewModels
{
    public class SelectViewModel : BaseViewModel
    {
        private readonly Navigation _navigation;
        public SelectViewModel(Navigation navigation)
        {
            _navigation = navigation;
            FlashCardSets = new Collection<FlashCardSet>();

            goToBrowseCommand = new GoToBrowseCommand(_navigation);
            newFlashCardSetCommand = new NewFlashCardSetCommand(_navigation);
            goToEditCommand = new GoToEditCommand(_navigation, FlashCardSets);
            deleteFlashCardSetCommand = new DeleteFlashCardSetCommand(FlashCardSets);
          
            GetFlashCardsFromFolder();
        }

        public Collection<FlashCardSet> FlashCardSets { get; private set; }
        public Collection<string> FlashCardSetNames
        {
            get
            {
                Collection<string> names = new Collection<string>();

                for (int i = 0; i < FlashCardSets.Count; i++)
                {
                    names.Add(FlashCardSets[i].Name);
                }

                return names;
            }
        }

        public void GetFlashCardsFromFolder()
        {
            FlashCardSets.Clear();

            string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "/FlashcardSets", "*.json");

            for (int i = 0; i < files.Length; i++)
            {
                FlashCardSet flashCardSet = new FlashCardSet();
                try
                {
                    flashCardSet.Open(files[i]);

                    if (flashCardSet.Name == FileNameFromPath(files[i]))
                    {
                        FlashCardSets.Add(flashCardSet);
                    }                    
                }
                catch
                {

                }
            }

            OnPropertyChanged(nameof(FlashCardSetNames));
        }

        private string FileNameFromPath(string path)
        {
            int length = path.Split("\\").Last().Split(".").Length;

            if (length == 1)
            {
                return path.Split("\\").Last().Split(".")[0];
            }
            else
            {
                return path.Split("\\").Last().Split(".")[length-2];
            }            
        }

        public ICommand goToBrowseCommand { get; }
        public ICommand newFlashCardSetCommand { get; }
        public ICommand goToEditCommand { get; }
        public ICommand deleteFlashCardSetCommand { get; }
    }
}
