using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Commands
{
    public class NewFlashCardCommand : BaseCommand
    {
        private readonly Navigation _navigation;

        public NewFlashCardCommand(Navigation navigation)
        {
            _navigation = navigation;
        }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
