using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Models
{
    public class FlashCardSet
    {
        public FlashCardSet(Collection<FlashCard> flashCards)
        {
            FlashCards = flashCards;
        }
        public FlashCardSet() : this(new Collection<FlashCard>())
        {
            
        }

        public Collection<FlashCard> FlashCards { get; }
        private Random _random = new Random();
        public FlashCard RandomFlashCard
        {
            get
            {
                return FlashCards[_random.Next(FlashCards.Count)];
            }
        }
    }
}
