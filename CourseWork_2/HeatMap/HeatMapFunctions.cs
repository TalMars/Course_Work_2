using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml.Media.Imaging;

namespace CourseWork_2.HeatMap
{
    public static class HeatMapFunctions
    {

        public static async Task<WriteableBitmap> CreateProcessHeatMap(WriteableBitmap source, List<HeatPoint> heatPoints)
        {
            WriteableBitmap intensityBitmap = await DrawPictureHeatDot(source.PixelWidth, source.PixelHeight, heatPoints);
            WriteableBitmap colorizeBitmap = await Colorize(intensityBitmap);
            WriteableBitmap blitBitmap = BlitBitmaps(source, colorizeBitmap); //merge screen and heatMap(transparent)

            return blitBitmap;
        }

        private static async Task<WriteableBitmap> DrawPictureHeatDot(int width, int height, List<HeatPoint> heatPoints)
        {
            WriteableBitmap whiteBitmap = new WriteableBitmap(width, height); //creating transparent bitmap
            whiteBitmap.Clear(Colors.Transparent);

            Uri heatPoint1 = new Uri("ms-appx:///Resources/HeatPointIntensive.png");

            WriteableBitmap heatDot = await BitmapFactory.New(0, 0).FromContent(heatPoint1);
            var file = await StorageFile.GetFileFromApplicationUriAsync(heatPoint1);
            var streamFile = await file.OpenReadAsync();
            double scale = 1.5;
            WriteableBitmap scaleHeatDot = await Resize((int)(heatDot.PixelWidth * scale), (int)(heatDot.PixelHeight * scale), streamFile); //get heatDot from picture in "Resource" folder

            foreach (HeatPoint point in heatPoints)
            {
                whiteBitmap = await BlitHeatPoints(point.X, point.Y, whiteBitmap, scaleHeatDot); //drawing heatDots
            }

            return whiteBitmap;
        }

        private static async Task<WriteableBitmap> Colorize(WriteableBitmap wrBitmap)
        {
            WriteableBitmap colorMask = await BitmapFactory.New(0, 0).FromContent(new Uri("ms-appx:///Resources/intensity-mask.jpg")); //get mask colors from picture in "Resource" folder

            Color[][] remapTable = RemapTableCreation(colorMask); //creating remap table based on mask colors(every shade of black is associated with a different color)

            int width = wrBitmap.PixelWidth;
            int height = wrBitmap.PixelHeight;

            using (var buffer = wrBitmap.PixelBuffer.AsStream())
            {
                byte[] pixels = new byte[4 * width * height];
                buffer.Read(pixels, 0, pixels.Length);

                //Colorize bitmap with heatDots based on remap table
                for (int index = 0; index < pixels.Length; index += 4)
                {
                    byte a = pixels[index + 3];

                    if (a > 0)
                    {
                        Color pixelIntensityColor = new Color();
                        pixelIntensityColor.B = pixels[index + 0];
                        pixelIntensityColor.G = pixels[index + 1];
                        pixelIntensityColor.R = pixels[index + 2];
                        pixelIntensityColor.A = a;

                        Color pixelColorizeColor = SearchColorFromRemapTable(remapTable, pixelIntensityColor);

                        pixels[index + 0] = pixelColorizeColor.B;
                        pixels[index + 1] = pixelColorizeColor.G;
                        pixels[index + 2] = pixelColorizeColor.R;
                        pixels[index + 3] = a;

                    }
                }
                buffer.Position = 0;
                await buffer.WriteAsync(pixels, 0, pixels.Length);
            }

            return wrBitmap;
        }

        private static WriteableBitmap BlitBitmaps(WriteableBitmap bitmap1, WriteableBitmap bitmap2)
        {
            bitmap1.Blit(new Windows.Foundation.Rect(0, 0, bitmap1.PixelWidth, bitmap1.PixelHeight), bitmap2,
                new Windows.Foundation.Rect(0, 0, bitmap2.PixelWidth, bitmap2.PixelHeight));
            //merge 2 bitmaps
            return bitmap1;
        }

        private static Color SearchColorFromRemapTable(Color[][] remapTable, Color color)
        {
            Color resultColor;

            for (int i = 0; i < 255; i++)
            {
                if (remapTable[0][i].Equals(color))
                {
                    resultColor = remapTable[1][i];
                }
            }

            if (resultColor == null)
                System.Diagnostics.Debug.WriteLine("Error! Don't have color in remapTable:(");

            return resultColor;
        }

        private static Color[][] RemapTableCreation(WriteableBitmap maskBitmap)
        {
            Color[][] remapTable = new Color[2][];
            remapTable[0] = new Color[256];
            remapTable[1] = new Color[256];

            for (int X = 0; X <= 255; X++)
            {
                remapTable[0][X] = Color.FromArgb((byte)X, 0, 0, 0);
                if (X < (maskBitmap.PixelWidth))
                    remapTable[1][X] = maskBitmap.GetPixel((maskBitmap.PixelWidth) - X, 0);
                else
                    remapTable[1][X] = maskBitmap.GetPixel(0, 0);
            }

            return remapTable;
        }

        //analog from WriteableBitmapEx:Blit(AdditiveMode) method
        private async static Task<WriteableBitmap> BlitHeatPoints(int xCenter, int yCenter, WriteableBitmap source, WriteableBitmap heatDot)
        {
            int width = source.PixelWidth;
            int height = source.PixelHeight;

            //read source Bitmap PixelBuffer
            using (var buffer = source.PixelBuffer.AsStream())
            {
                byte[] pixels = new byte[4 * width * height];
                buffer.Read(pixels, 0, pixels.Length);

                //read heatDot Bitmap PixelBuffer
                using (var bufferHeatDot = heatDot.PixelBuffer.AsStream())
                {
                    byte[] pixelsHeatDot = new byte[4 * heatDot.PixelHeight * heatDot.PixelWidth];
                    bufferHeatDot.Read(pixelsHeatDot, 0, pixelsHeatDot.Length);

                    int iBuffer = ((yCenter * width) + xCenter) * 4;    //start point for drawing heatdot

                    //Borders for put start point when dot not placed
                    bool topBorder = yCenter >= heatDot.PixelHeight / 2;
                    bool bottomBorder = (yCenter + heatDot.PixelHeight / 2) <= height;
                    bool leftBorder = xCenter >= heatDot.PixelWidth / 2;
                    bool rightBorder = (xCenter + heatDot.PixelWidth / 2) <= width;
                    if (topBorder && leftBorder && bottomBorder && rightBorder)
                    {
                        iBuffer = iBuffer - (width * heatDot.PixelWidth / 2 + heatDot.PixelWidth / 2) * 4; //change start point on left top corner
                    }
                    else  //replace start point if out from border
                    {
                        if (!bottomBorder)
                            iBuffer = iBuffer - (width * heatDot.PixelHeight) * 4;

                        if (!rightBorder)
                            iBuffer = iBuffer - (heatDot.PixelWidth) * 4;
                    }
                    //drawing heatDot on source bitmap
                    for (int y = 0; y < heatDot.PixelHeight; y++)
                    {
                        for (int x = 0; x < heatDot.PixelWidth; x++)
                        {
                            byte aHeatDot = pixelsHeatDot[(x + y * heatDot.PixelWidth) * 4 + 3];
                            byte aScreen = pixels[iBuffer + 3];

                            //additive mode
                            if ((aScreen + aHeatDot) > 255)
                                pixels[iBuffer + 3] = 254; //changing:not transparent pixel, because 255 and 0 bits it's transparent:(
                            else
                                pixels[iBuffer + 3] = (byte)(aHeatDot * 0.9 + aScreen); //sum bits for add intensive |  "0.9" for not strong intensive

                            iBuffer += 4;
                        }
                        iBuffer += (width - heatDot.PixelWidth) * 4;
                    }
                }
                //write in PixelBuffer
                buffer.Position = 0;
                await buffer.WriteAsync(pixels, 0, pixels.Length);
            }

            return source;
        }

        public async static Task<WriteableBitmap> Resize(int width, int height, IRandomAccessStream source) //create bitmap with specified width and height
        {
            WriteableBitmap small = new WriteableBitmap(width, height);
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(source);
            BitmapTransform transform = new BitmapTransform();
            transform.ScaledHeight = (uint)height;
            transform.ScaledWidth = (uint)width;
            PixelDataProvider pixelData = await decoder.GetPixelDataAsync(
                BitmapPixelFormat.Bgra8,
                BitmapAlphaMode.Straight,
                transform,
                ExifOrientationMode.RespectExifOrientation,
                ColorManagementMode.DoNotColorManage);
            pixelData.DetachPixelData().CopyTo(small.PixelBuffer);
            return small;
        }

        public static byte[] AsByteArray(WriteableBitmap bitmap)
        {
            using (Stream stream = bitmap.PixelBuffer.AsStream())
            {
                MemoryStream memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public static BitmapImage AsBitmapImage(byte[] byteArray)
        {
            if (byteArray != null)
            {
                using (var stream = new InMemoryRandomAccessStream())
                {
                    stream.WriteAsync(byteArray.AsBuffer()).GetResults();
                    var image = new BitmapImage();
                    stream.Seek(0);
                    image.SetSource(stream);
                    return image;
                }
            }

            return null;
        }

        public static async Task<byte[]> AsByteArrayFromStream(IRandomAccessStream stream)
        {
            var reader = new DataReader(stream.GetInputStreamAt(0));
            var bytes = new byte[stream.Size];
            await reader.LoadAsync((uint)stream.Size);
            reader.ReadBytes(bytes);

            return bytes;
        }

        public static async Task<WriteableBitmap> AsWrBitmapImage(byte[] byteArray, int width, int height)
        {
            var wb = new WriteableBitmap(width, height);
            using (Stream stream = wb.PixelBuffer.AsStream())
            {
                await stream.WriteAsync(byteArray, 0, byteArray.Length);
            }

            return wb;
        }
    }
}
