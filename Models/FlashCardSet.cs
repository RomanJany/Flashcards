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
            Name = "";
        }
        public FlashCardSet() : this(new Collection<FlashCard>())
        {
            
        }

        public Collection<FlashCard> FlashCards { get; private set; }

        public string Name { get; set; }

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
            if (FlashCards.Count > 0)
            {
                JsonObject jsonObject = new JsonObject();
                JsonArray jsonArray = new JsonArray();

                jsonObject.Add("Name", Name);
                jsonObject.Add("FlashCards", jsonArray);

                for (int i = 0; i < FlashCards.Count; i++)
                {
                    JsonObject newObject = new JsonObject(); ;
                    newObject["FrontText"] = FlashCards[i].FrontText;
                    newObject["FrontImage"] = ImageToBase64(FlashCards[i].FrontImage);
                    newObject["BackText"] = FlashCards[i].BackText;
                    newObject["BackImage"] = ImageToBase64(FlashCards[i].BackImage);

                    jsonArray.Add(newObject);
                }

                File.WriteAllText(fileName, jsonObject.ToJsonString());
            }
        }

        public void Open(string fileName)
        {
            Collection<FlashCard> flashCards = new Collection<FlashCard>();
            JsonNode node = JsonNode.Parse(File.ReadAllText(fileName));

            // Check if the first node is an object
            try
            {
                node.AsObject();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidDataException();
            }         
            
            // Check for property FlashCards
            if (node.AsObject().TryGetPropertyValue("FlashCards", out JsonNode flashCardArray))
            {
                // Check if FlashCards property is an array
                try
                {
                    flashCardArray.AsArray();
                }
                catch (InvalidOperationException)
                {
                    throw new InvalidDataException();
                }

                // Get properties of every flashcard inside the set
                for (int i = 0; i < flashCardArray.AsArray().Count(); i++)
                {
                    JsonNode flashCard = flashCardArray.AsArray()[i];

                    try
                    {
                        flashCard.AsObject();
                    }
                    catch (InvalidOperationException)
                    {
                        throw new InvalidDataException();
                    }

                    if ((flashCard.AsObject().TryGetPropertyValue("FrontText", out JsonNode frontText)) &&
                        (flashCard.AsObject().TryGetPropertyValue("FrontImage", out JsonNode frontImage)) &&
                        (flashCard.AsObject().TryGetPropertyValue("BackText", out JsonNode backText)) &&
                        (flashCard.AsObject().TryGetPropertyValue("BackImage", out JsonNode backImage)))
                    {
                        try
                        {
                            flashCards.Add(new FlashCard
                            {
                                FrontText = (string)frontText,
                                FrontImage = Base64ToImage((string)frontImage),
                                BackText = (string)backText,
                                BackImage = Base64ToImage((string)backImage)
                            });
                        }
                        catch
                        {
                            throw new InvalidDataException();
                        }
                    }
                    else
                    {
                        throw new InvalidDataException();
                    }
                }

                // Save Flashcard set name
                if (node.AsObject().TryGetPropertyValue("Name", out JsonNode FlashCardSetName))
                {
                    try
                    {
                        Name = (string)FlashCardSetName;
                    }
                    catch
                    {
                        throw new InvalidDataException();
                    }
                }
                else
                {
                    throw new InvalidDataException();
                }

                // Save Flashcard set
                FlashCards = flashCards;
            }
            else
            {
                throw new InvalidDataException();
            }
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

        private BitmapImage Base64ToImage(string imageString)
        {
            if (imageString == "")
            {
                return null;
            }

            using MemoryStream stream = new MemoryStream();
            byte[] bytes = Convert.FromBase64String(imageString);

            stream.Write(bytes, 0, bytes.Length);

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSource = stream;
            bitmapImage.EndInit();

            return bitmapImage;
        }
    }
}
