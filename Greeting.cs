using System;
using System.Collections;
using System.Threading;

namespace AIChatbot
{
    public class Greeting
    {
        //global variable declaration
        private string user_name = string.Empty;
        private string user_asking = string.Empty;
        ArrayList replies = new ArrayList();
        ArrayList ignore = new ArrayList();
        int delayTime;

        public Greeting()
        {
            greeting();
        }

        public void greeting()
        {
            Console.WriteLine("========================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Chatbot->:");
            Console.WriteLine("Hello. How are you? I'm ChatBot and I am here to help you with any queries you might have regarding password safety, phishing and safe browsing."
                + "Let's start by introducing each other. What is your name?", 30);

            Console.WriteLine("========================");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("User->:");
            String username = Console.ReadLine();

            Console.WriteLine("========================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Chatbot->:");
            Console.WriteLine("Hello, " + username + ", how are you?", 30);

            Console.WriteLine("========================");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(username + "->:");
            Console.ReadLine();

            Console.WriteLine("========================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Chatbot->:");
            Console.WriteLine("Unfortunately, I am a robot so I do not have any feelings whatsoever.", 30);
            //call both methods to auto store values
            store_ignores();
            store_replies();

            do
            {


                //prompting the user for the question
                Console.WriteLine("========================");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Chatbot->:");
                Console.WriteLine("Do you have any questions? If not, you can type 'exit' to leave the application.", 30);

                Console.WriteLine("========================");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(username + "->:");
                string question = Console.ReadLine().ToLower();

                //making use of split function to store each word
                string[] store_word = question.Split(' ');
                ArrayList store_final_words = new ArrayList();

                //for loop to check the words to store
                foreach (string word in store_word)
                {
                    //if statement to check if words store in 1D array are not ignored
                    if (!ignore.Contains(word.ToLower()))
                    {
                        //store the not ignored words
                        store_final_words.Add(word);
                    }
                }

                //temp variables
                Boolean found = false;
                string messages = string.Empty;

                //for loop to get final answer
                foreach (string word in store_final_words)
                {
                    //search answer by a word from the temp array list
                    foreach (string reply in replies)
                    {
                        //if statement to check if word found in replies
                        if (reply.Contains(word))
                        {
                            //append the answers
                            messages += reply + "\n";
                            found = true;
                        }
                    }
                }

                if (question != "exit")
                {
                    //display error message or answers
                    if (found)
                    {
                        //display
                        Console.WriteLine("========================");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Chatbot->:");
                        Console.WriteLine(messages, 30);
                    }
                    else
                    {
                        //This will display if the question is not understood
                        Console.WriteLine("========================");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Chatbot->:");
                        Console.WriteLine("I'm sorry, I am not familiar with that subject. Hopefully, I will next time.", 30);
                    }
                }
                else
                {
                    //exit application
                    Console.WriteLine("========================");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Chatbot->:");
                    Console.WriteLine("Thank you for using AI Chatbot, goodbye.", 30);
                    System.Environment.Exit(0);
                }

                //user_asking = question;
                //answer(user_asking);

            } while (user_asking != "exit");
        }


        //storing replies method
        private void store_replies()
        {
            //store values of replies
            replies.Add("Safe Browsing Practices: Keep Your Browser and Plugins Up-to-Date. Updates often include security patches that address vulnerabilities that hackers could exploit.");
            replies.Add("Safe Browsing Practices: Use a VPN(Virtual Private Network). A VPN encrypts your internet traffic, making it harder for hackers to intercept your data.");
            replies.Add("Safe Browsing Practices: Install and Use Antivirus Software. Antivirus software helps detect and remove malware and viruses that can compromise your device and data.");

            replies.Add("Password: Never reuse passwords across different accounts. If one is compromised, others could be at risk.");
            replies.Add("Password: Enable Multi-Factor Authentication(MFA) for an additional layer of security beyond just passwords.");
            replies.Add("Password: Avoid common passwords like '12345' or 'abcde'. Hackers use automated tools to crack them easily.");

            replies.Add("Phishing: Phishing is used to deceive victims into clicking on malicious links, downloading harmful attachments, or entering sensitive information on fake websites.");
            replies.Add("Phishing :A good way to protect yourself is never download attachments or click on links in unsolicited emails. Cybercriminals often disguise malware in these files.");
            replies.Add("Phishing: You can protect yourself by being cautious of emails that claim your account is at risk and demand urgent action. Verify directly with the company instead.");
        }

        //ignore words method
        private void store_ignores()
        {
            //store values of ignore
            ignore.Add("tell");
            ignore.Add("me");
            ignore.Add("about");
            ignore.Add("recognize");
            ignore.Add("what");
            ignore.Add("is");
            ignore.Add("about");
            ignore.Add("safe");
            ignore.Add("can");
            ignore.Add("I");
            ignore.Add("ask");
            ignore.Add("questions");
            ignore.Add("other");
            ignore.Add("how");
            ignore.Add("to");
            ignore.Add("do");
            ignore.Add("does");
            ignore.Add("the");
            ignore.Add("explain");
            ignore.Add("define");
            ignore.Add("between");
            ignore.Add("mean");
            ignore.Add("why");
            ignore.Add("when");
            ignore.Add("where");
            ignore.Add("who");
            ignore.Add("which");
            ignore.Add("give");
            ignore.Add("more");
            ignore.Add("example");
            ignore.Add("detail");
        }
    }
}