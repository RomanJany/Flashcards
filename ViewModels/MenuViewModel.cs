﻿using Flashcards.Commands;
using Notepad.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Flashcards.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private readonly Navigation _navigation;
        public MenuViewModel(Navigation navigation)
        {
            _navigation = navigation;

            goToSelectCommand = new GoToSelectCommand(_navigation);
            goToEditCommand = new GoToEditCommand(_navigation);
        }

        public ICommand goToSelectCommand { get; }
        public ICommand goToEditCommand { get; }
    }
}
