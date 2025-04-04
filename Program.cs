using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace AIChatbot
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ASCII Image
            ImageToAscii imageToAscii = new ImageToAscii();

            //Voice Greeting
            SoundPlayer sound = new SoundPlayer(@"C:\\Year2\\SEM1\\PROG\\0330.WAV");
            sound.PlaySync();

            //Text-Based Greeting
            Greeting greeting = new Greeting();
        }
    }
} 