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
            //Recorded voice greeting when application launches
            VoiceGreeting voice_greeting = new VoiceGreeting();

            //ASCII Representation of logo
            ImageToAscii ascii = new ImageToAscii();

            //Welcoming the user with an interactive experience
            Greeting welcome = new Greeting();

            //Response to the user's questions
            ResponseSystem response = new ResponseSystem();
        }
    }
}