﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace CourseWork_2.Emotions
{
    public class EmotionResultDisplayItem
    {
        public WriteableBitmap CroppedImage { get; set; }
        public string Emotion { get; set; }
        public float Score { get; set; }
        public string EmotionString
        {
            get { return Emotion + ":" + Score.ToString("0.000"); }
        }
    }
}