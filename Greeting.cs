using System;
using System.Threading;

namespace AIChatbot
{
    public class Greeting
    {
        public Greeting()
        {
            interaction();
        }

        public void interaction()
        {
            Console.WriteLine("========================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Chatbot->:");
            DelayText("Hello. How are you? I'm ChatBot and I am here to help you with any queries you might have regarding password safety, phishing and safe browsing."
                + "Let's start by introducing each other. What is your name?", 30);

            Console.WriteLine("========================");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("User->:");
            String username = Console.ReadLine();

            Console.WriteLine("========================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Chatbot->:");
            DelayText("Hello, " + username + ", how are you?", 30);

            Console.WriteLine("========================");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(username + "->:");
            Console.ReadLine();

            Console.WriteLine("========================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Chatbot->:");
            DelayText("Unfortunately, I am a robot so I do not have any feelings whatsoever.", 30);
        }

        int delayTime;
        private void DelayText(string text, int? customDelay = null)
        {
            int actualDelay = customDelay ?? delayTime;

            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(actualDelay);
            }
            Console.WriteLine();//to move to the next line
        }
    }
}