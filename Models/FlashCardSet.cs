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

        public void Add(FlashCard flashCard)
        {
            FlashCards.Add(flashCard);
        }

        public void Remove(int index)
        {       
            FlashCards.RemoveAt(index);
        }

        public void Clear()
        {
            FlashCards.Clear();
        }

        public void Save(string filename)
        {
            throw new NotImplementedException();
        }

        public void Open(string filename)
        {
            throw new NotImplementedException();
        }
    }
}
