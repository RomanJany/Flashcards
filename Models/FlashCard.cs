using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Flashcards.Models
{
    public class FlashCard
    {
        public required string FrontText { get; set; }
        public required BitmapImage FrontImage { get; set; }
        public required string BackText { get; set; }
        public required BitmapImage BackImage { get; set; }
    }
}
