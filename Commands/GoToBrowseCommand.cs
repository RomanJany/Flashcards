using Notepad.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Commands
{
    public class GoToBrowseCommand : BaseCommand
    {
        private Navigation _navigation;

        public GoToBrowseCommand(Navigation navigation)
        {
            _navigation = navigation;
        }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
