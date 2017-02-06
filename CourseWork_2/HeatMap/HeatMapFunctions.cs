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
            WriteableBitmap blitBitmap = BlitBitmaps(source, colorizeBitmap);

            return blitBitmap;
        }

        private static async Task<WriteableBitmap> DrawPictureHeatDot(int width, int height, List<HeatPoint> heatPoints)
        {
            WriteableBitmap whiteBitmap = new WriteableBitmap(width, height);
            whiteBitmap.Clear(Colors.Transparent);

            Uri heatPoint1 = new Uri("ms-appx:///Resources/HeatPointIntensive.png");
            //Uri heatPoint2 = new Uri("ms-appx:///Resources/HeatPointIntensity.png");

            WriteableBitmap heatDot = await BitmapFactory.New(0, 0).FromContent(heatPoint1);
            var file = await StorageFile.GetFileFromApplicationUriAsync(heatPoint1);
            var streamFile = await file.OpenReadAsync();
            double scale = 1.5;
            WriteableBitmap scaleHeatDot = await Resize((int)(heatDot.PixelWidth * scale), (int)(heatDot.PixelHeight * scale), streamFile);

            foreach (HeatPoint point in heatPoints)
            {
                //whiteBitmap.Blit(new Windows.Foundation.Rect(point.X, point.Y, scaleHeatDot.PixelWidth, scaleHeatDot.PixelHeight),
                //    scaleHeatDot, new Windows.Foundation.Rect(0, 0, scaleHeatDot.PixelWidth, scaleHeatDot.PixelHeight), WriteableBitmapExtensions.BlendMode.Additive); //work: Additive
                whiteBitmap = await BlitHeatPoints(point.X, point.Y, whiteBitmap, scaleHeatDot);
            }

            return whiteBitmap;
        }

        private static async Task<WriteableBitmap> Colorize(WriteableBitmap wrBitmap)
        {
            WriteableBitmap colorMask = await BitmapFactory.New(0, 0).FromContent(new Uri("ms-appx:///Resources/intensity-mask.jpg"));

            Color[][] remapTable = RemapTableCreation(colorMask);

            int width = wrBitmap.PixelWidth;
            int height = wrBitmap.PixelHeight;

            using (var buffer = wrBitmap.PixelBuffer.AsStream())
            {
                byte[] pixels = new byte[4 * width * height];
                buffer.Read(pixels, 0, pixels.Length);

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
                        iBuffer = iBuffer - (width * heatDot.PixelWidth / 2 - heatDot.PixelWidth / 2) * 4;
                    }
                    else
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
                                pixels[iBuffer + 3] = 254; //changing:not transparent pixel, because 256 and 0 bits it's transparent:(
                            else
                                pixels[iBuffer + 3] = (byte)(aHeatDot * 0.9 + aScreen); //sum bits for add intensive |  "/2" for not strong intensive

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

        public async static Task<WriteableBitmap> Resize(int width, int height, IRandomAccessStream source)
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

        public async static Task<WriteableBitmap> ResizeWritableBitmap(WriteableBitmap baseWriteBitmap, uint width, uint height)
        {
            // Get the pixel buffer of the writable bitmap in bytes
            Stream stream = baseWriteBitmap.PixelBuffer.AsStream();
            byte[] pixels = new byte[(uint)stream.Length];
            await stream.ReadAsync(pixels, 0, pixels.Length);
            //Encoding the data of the PixelBuffer we have from the writable bitmap
            var inMemoryRandomStream = new InMemoryRandomAccessStream();
            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, inMemoryRandomStream);
            encoder.SetPixelData(BitmapPixelFormat.Rgba8, BitmapAlphaMode.Ignore, width, height, 96, 96, pixels);
            await encoder.FlushAsync();
            // At this point we have an encoded image in inMemoryRandomStream
            // We apply the transform and decode
            var transform = new BitmapTransform
            {
                ScaledWidth = width,
                ScaledHeight = height
            };
            inMemoryRandomStream.Seek(0);
            var decoder = await BitmapDecoder.CreateAsync(inMemoryRandomStream);
            var pixelData = await decoder.GetPixelDataAsync(
                            BitmapPixelFormat.Rgba8,
                            BitmapAlphaMode.Straight,
                            transform,
                            ExifOrientationMode.IgnoreExifOrientation,
                            ColorManagementMode.DoNotColorManage);
            //An array containing the decoded image data
            var sourceDecodedPixels = pixelData.DetachPixelData();
            // Approach 1 : Encoding the image buffer again:
            //Encoding data
            var inMemoryRandomStream2 = new InMemoryRandomAccessStream();
            var encoder2 = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, inMemoryRandomStream2);
            encoder2.SetPixelData(BitmapPixelFormat.Rgba8, BitmapAlphaMode.Ignore, width, height, 96, 96, sourceDecodedPixels);
            await encoder2.FlushAsync();
            inMemoryRandomStream2.Seek(0);
            // finally the resized writablebitmap
            var bitmap = new WriteableBitmap((int)width, (int)height);
            await bitmap.SetSourceAsync(inMemoryRandomStream2);
            return bitmap;
        }
    }
}
