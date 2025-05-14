using System.Collections;
using System;
using System.Threading;
using System.Collections.Generic;

namespace AIChatbot
{
    public class ResponseSystem
    {
        private string user_name = string.Empty;
        private string user_asking = string.Empty;
        Dictionary<string, List<string>> replies = new Dictionary<string, List<string>>();
        HashSet<string> ignore = new HashSet<string>();
        int delayTime = 0;
        string username;
        Boolean interest_in_phishing = false;
        Boolean interest_in_browsing = false;
        Boolean interest_in_password = false;
        public ResponseSystem()
        {
            store_replies();
            store_ignores();
            response();
        }

        public void response()
        {
            do
            {
                //prompting the user for the question
                Console.WriteLine("========================");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Chatbot->:");
                DelayText("Do you have any questions? If not, you can type 'exit' to leave the application.", 30);

                Console.WriteLine("========================");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(username + "->:");
                string question = Console.ReadLine().ToLower();

                //IF statements that check if the user is interested in a certain topic

                if (question.Contains("interested") || question.Contains("interest") || question.Contains("curious"))
                {
                    if (question.Contains("phishing"))
                    {
                        interest_in_phishing = true;
                        Console.WriteLine(interest_phishing());
                    }
                    else if (question.Contains("browsing"))
                    {
                        interest_in_browsing = true;
                        Console.WriteLine(interest_browsing());
                    }
                    else if (question.Contains("password"))
                    {
                        interest_in_password = true;
                        Console.WriteLine(interest_password());
                    }
                }
                else if (question.Contains("tips"))
                {
                    if (question.Contains("phishing"))
                    {
                        Console.WriteLine("========================");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Chatbot->:");
                        string phishingTip = tips_phishing();
                        DelayText(phishingTip);
                    }
                    else if (question.Contains("browsing"))
                    {
                        Console.WriteLine("========================");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Chatbot->:");
                        string browsingTip = tips_browsing();
                        DelayText(browsingTip);
                    }
                    else if (question.Contains("password"))
                    {
                        Console.WriteLine("========================");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Chatbot->:");
                        string passwordTip = tips_password();
                        DelayText(passwordTip);
                    }

                }
                else if (question.Contains("worried") || question.Contains("unsure") || question.Contains("concerned"))
                {
                    if (question.Contains("phishing"))
                    {
                        Console.WriteLine("========================");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Chatbot->:");
                        string phishingWorry = worried_phishing();
                        DelayText(phishingWorry);
                    }
                    else if (question.Contains("browsing"))
                    {
                        Console.WriteLine("========================");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Chatbot->:");
                        string browsingWorry = worried_browsing();
                        DelayText(browsingWorry);
                    }
                    else if (question.Contains("password"))
                    {
                        Console.WriteLine("========================");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Chatbot->:");
                        string passwordWorry = worried_password();
                        DelayText(passwordWorry);
                    }
                }

                else
                {
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
                        string keyword = word.ToLower();
                        if (replies.ContainsKey(keyword))
                        {
                            foreach (var message in replies[keyword])
                            {
                                messages += message + "\n";
                                found = true;
                            }
                        }
                    }

                    if (question != "exit")
                    {
                        //display error message or answers
                        if (found == true)
                        {
                            if (interest_in_phishing == true || interest_in_browsing == true || interest_in_password == true)
                            {
                                if (interest_in_phishing == true && messages.Contains("Phishing"))
                                {
                                    Console.WriteLine("========================");
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write("Chatbot->:");
                                    DelayText("You previously spoke about an interest in phishing.", 30);
                                    DelayText(messages, 30);
                                }
                                else if (interest_in_browsing == true && messages.Contains("Browsing"))
                                {
                                    Console.WriteLine("========================");
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write("Chatbot->:");
                                    DelayText("You previously spoke about an interest in browsing.", 30);
                                    DelayText(messages, 30);
                                }
                                else if (interest_in_password == true && messages.Contains("Password"))
                                {
                                    Console.WriteLine("========================");
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write("Chatbot->:");
                                    DelayText("You previously spoke about an interest in phishing.", 30);
                                    DelayText(messages, 30);
                                }
                            }
                            else
                            {
                                //display
                                Console.WriteLine("========================");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("Chatbot->:");
                                DelayText(messages, 30);
                            }
                        }
                        else
                        {
                            //This will display if the question is not understood
                            Console.WriteLine("========================");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Chatbot->:");
                            DelayText("I'm sorry, I am not familiar with that subject. Hopefully, I will next time.", 30);
                        }
                    }
                    else
                    {
                        //exit application
                        Console.WriteLine("========================");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Chatbot->:");
                        DelayText("Thank you for using AI Chatbot, goodbye.", 30);
                        System.Environment.Exit(0);
                    }
                }
            } while (user_asking != "exit");//Conditional that loops as long as the user does not type exit
        }
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

        private void store_replies()
        {
            //store values of replies
            replies["browsing"] = new List<string> { "Safe Browsing Practices: Keep Your Browser and Plugins Up-to-Date. Updates often include security patches that address vulnerabilities that hackers could exploit." };
            replies["browsing"] = new List<string> { "Safe Browsing Practices: Use a VPN(Virtual Private Network). A VPN encrypts your internet traffic, making it harder for hackers to intercept your data." };
            replies["browsing"] = new List<string> { "Safe Browsing Practices: Install and Use Antivirus Software. Antivirus software helps detect and remove malware and viruses that can compromise your device and data." };

            replies["password"] = new List<string> { "Password: Never reuse passwords across different accounts. If one is compromised, others could be at risk." };
            replies["password"] = new List<string> { "Password: Enable Multi-Factor Authentication(MFA) for an additional layer of security beyond just passwords." };
            replies["password"] = new List<string> { "Password: Avoid common passwords like '12345' or 'abcde'. Hackers use automated tools to crack them easily." };

            replies["phishing"] = new List<string> { "Phishing: Phishing is used to deceive victims into clicking on malicious links, downloading harmful attachments, or entering sensitive information on fake websites." };
            replies["phishing"] = new List<string> { "Phishing: A good way to protect yourself is never download attachments or click on links in unsolicited emails. Cybercriminals often disguise malware in these files." };
            replies["phishing"] = new List<string> { "Phishing: You can protect yourself by being cautious of emails that claim your account is at risk and demand urgent action. Verify directly with the company instead." };
        }

        private void store_ignores()
        {
            //store values of ignore
            string[] ignoredWords = {
                "tell", "me", "about", "recognize", "what", "is", "safe", "can", "i", "ask", "questions", "other",
                "how", "to", "do", "does", "the", "explain", "define", "between", "mean", "why", "when", "where",
                "who", "which", "give", "more", "example", "detail"
            };

            foreach (var word in ignoredWords)
            {
                ignore.Add(word);
            }
        }

        public string tips_phishing()
        {
            List<string> tips = new List<string>();

            tips.Add("Be cautious of unexpected emaols with urgent requests for personal information.");
            tips.Add("Always check email addresses and domain names carefully.");
            tips.Add("Never click links or open attachments in suspicious messages");

            Random get_Index = new Random();
            int found_Index = get_Index.Next(0, tips.Count);

            return tips[found_Index];
        }

        public string tips_password()
        {
            List<string> tips = new List<string>();

            tips.Add("Make sure your password is atleast 12 characters long, 14 or more is usually better");
            tips.Add("Combine uppercase and lowercase letters, numbers, and symbols.");
            tips.Add("Do not use dictionary words or common phrases.");


            Random get_Index = new Random();
            int found_Index = get_Index.Next(0, tips.Count);

            return tips[found_Index];
        }

        public string tips_browsing()
        {
            List<string> tips = new List<string>();

            tips.Add("Always keep your operating system up-to-date to patch security vulnerabilities.");
            tips.Add("Make use of VPN to encrypt your internet traffic, especially on public Wi-Fi");
            tips.Add("Regularly clear your browser's cache and cookies to prevent data collection.");

            Random get_Index = new Random();
            int found_Index = get_Index.Next(0, tips.Count);

            return tips[found_Index];
        }

        public string worried_phishing()
        {
            List<string> worried = new List<string>();

            worried.Add("It's okay to feel that way. The emails can be very deceiving.");
            worried.Add("Understandably so. It tends to be hard to recognise dodgy emails if you do not have the proper awareness to recognise them.");

            Random get_Index = new Random();
            int found_Index = get_Index.Next(0, worried.Count);

            return worried[found_Index];
        }

        public string worried_browsing()
        {
            List<string> worried = new List<string>();

            worried.Add("It's okay to feel that way. The internet is filled with bad people with malicious tendencies.");
            worried.Add("Understandably so. The internet is a broad entity with many vulnerabilities.");

            Random get_Index = new Random();
            int found_Index = get_Index.Next(0, worried.Count);

            return worried[found_Index];
        }

        public string worried_password()
        {
            List<string> worried = new List<string>();

            worried.Add("It's okay to feel that way. Many people tend to feel the same way about this topic.");
            worried.Add("Understandably so. Passwords are usually our only security from people trying access our personal information.");

            Random get_Index = new Random();
            int found_Index = get_Index.Next(0, worried.Count);

            return worried[found_Index];
        }

        public string interest_phishing()
        {
            List<string> interest = new List<string>();

            interest.Add("That's great to hear! I will remember that next time.");
            interest.Add("Awesome! It is very wise to teach yourself about such topics.");

            Random get_Index = new Random();
            int found_Index = get_Index.Next(0, interest.Count);

            return interest[found_Index];
        }
        public string interest_browsing()
        {
            List<string> interest = new List<string>();

            interest.Add("That's great to hear! I will remember that next time.");
            interest.Add("Awesome! It is very wise to teach yourself about such topics.");

            Random get_Index = new Random();
            int found_Index = get_Index.Next(0, interest.Count);

            return interest[found_Index];
        }
        public string interest_password()
        {
            List<string> interest = new List<string>();

            interest.Add("That's great to hear! I will remember that next time.");
            interest.Add("Awesome! It is very wise to teach yourself about such topics.");

            Random get_Index = new Random();
            int found_Index = get_Index.Next(0, interest.Count);

            return interest[found_Index];
        }
    }
}