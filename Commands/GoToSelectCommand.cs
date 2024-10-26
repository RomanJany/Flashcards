using Flashcards.ViewModels;
using Notepad.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Commands
{
    public class GoToSelectCommand : BaseCommand
    {
        private Navigation _navigation;

        public GoToSelectCommand(Navigation navigation)
        {
            _navigation = navigation;
        }

        public override void Execute(object? parameter)
        {
            _navigation.CurrentViewModel = new SelectViewModel(_navigation);
        }
    }
}
