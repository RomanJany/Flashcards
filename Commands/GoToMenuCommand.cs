using Flashcards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Commands
{
    public class GoToMenuCommand : BaseCommand
    {
        private Navigation _navigation;

        public GoToMenuCommand(Navigation navigation)
        {
            _navigation = navigation;
        }

        public override void Execute(object? parameter)
        {
            _navigation.CurrentViewModel = new MenuViewModel(_navigation);
        }
    }
}
