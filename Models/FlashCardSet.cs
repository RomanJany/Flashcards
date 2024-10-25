using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.IO;
using System.Windows.Media.Imaging;

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

        public void Save(string fileName)
        {
            JsonObject jsonObject = new JsonObject();
            JsonArray jsonArray = new JsonArray();
            jsonObject.Add("FlashCards", jsonArray);

            for (int i = 0; i < FlashCards.Count; i++)
            {
                JsonObject newObject = new JsonObject(); ;
                newObject["FrontText"] = FlashCards[i].FrontText;
                newObject["FrontImage"] = "";
                newObject["BackText"] = FlashCards[i].BackText;
                newObject["BackImage"] = "";

                jsonArray.Add(newObject);
            }        

            File.WriteAllText(fileName, jsonObject.ToJsonString());
        }

        public void Open(string filename)
        {
            throw new NotImplementedException();
        }

        private string ImageToBase64(BitmapImage image)
        {
            if (image == null)
            {
                return "";
            }
            else
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                using MemoryStream stream = new MemoryStream();

                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);

                return Convert.ToBase64String(stream.ToArray());
            }
        }
    }
}
