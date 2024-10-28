﻿using Flashcards.Commands;
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

            goToBrowseCommand = new GoToBrowseCommand(_navigation);
            newFlashCardSetCommand = new NewFlashCardSetCommand(_navigation);

            FlashCardSets = new Collection<FlashCardSet>();
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

                    FlashCardSets.Add(flashCardSet);
                }
                catch
                {

                }
            }

            OnPropertyChanged(nameof(FlashCardSetNames));
        }

        public ICommand goToBrowseCommand { get; }
        public ICommand newFlashCardSetCommand { get; }
    }
}
