using Windows.UI.Xaml.Media.Imaging;

namespace CourseWork_2.Emotions
{
    public class EmotionResultDisplayItem
    {
        public WriteableBitmap CroppedImage { get; set; }
        public string Emotion { get; set; }
        public double Score { get; set; }
        public string EmotionString
        {
            get { return Emotion + ":" + Score.ToString("0.000"); }
        }
        public string PercentScore
        {
            get { return Score + "%"; }
        }
    }
}
