using System;
using System.Drawing;

namespace AIChatbot
{
    public class ImageToAscii
    {
        public ImageToAscii()
        {
            //File location
            string imagePath = @"C:\\Year2\\SEM1\\PROG\\C#\\AIChatbot\\Lock.jpg";
            Bitmap image = new Bitmap(imagePath);

            //Calling the the other two methods
            Bitmap grayScale = ConvertToGrayscale(image);
            string asciiArt = ConvertToAscii(grayScale);

            Console.WriteLine(asciiArt);
        }
        //This method will convert the image to grayscale
        public static Bitmap ConvertToGrayscale(Bitmap original)
        {
            Bitmap grayscale = new Bitmap(original.Width, original.Height);
            //For Loop to iterate through the pixels based on image width and height
            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    //This block will recognize the color of every pixel and convert it to an equal gray scale value
                    Color pixelColor = original.GetPixel(x, y);
                    int grayScaleValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    Color newColor = Color.FromArgb(grayScaleValue, grayScaleValue, grayScaleValue);
                    grayscale.SetPixel(x, y, newColor);
                }
            }
            return grayscale;
        }

        //This method will the image into ASCII
        public static string ConvertToAscii(Bitmap image)
        {
            string asciiArt = "";

            for (int y = 0; y < image.Height; y += 35)
            {
                for (int x = 0; x < image.Width; x += 10)
                {
                    //This block will convert the image to an ASCII pixel by pixel
                    Color pixelColor = image.GetPixel(x, y);
                    int brightness = (int)(pixelColor.GetBrightness() * 5);
                    asciiArt += GenerateAsciiChar(brightness);
                }
                asciiArt += "\n";
            }
            return asciiArt;
        }

        public static char GenerateAsciiChar(int brightness)
        {
            //These are the characters that will be used to display the ASCII image
            char[] asciiChars = { ' ', '.', ':', '-', '=', '+', '*', '#', };

            return asciiChars[brightness];
        }
    }
}