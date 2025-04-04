using System;
using System.Collections;

namespace filter_split
{
    public class filter_all
    {
        //declare variables
        ArrayList replies = new ArrayList();
        ArrayList ignore = new ArrayList();

        //constructor
        public filter_all()
        {
            //call both methods to auto store values
            store_ignores();
            store_replies();

            //prompting the user for the question
            Console.WriteLine("Enter your question.");
            string question = Console.ReadLine();

            //making use of split function to store each word
            string[] store_word = question.Split(' ');
            ArrayList store_final_words = new ArrayList();

            //for loop to check the words to store
            foreach (string word in store_word)
            {
                //if statement to check if words store in 1D array are not ignored
                if (!ignore.Contains(word))
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

            //display error message or answers
            if (found)
            {
                //display
                Console.WriteLine(messages);
            }
            else
            {
                Console.WriteLine("Search something related to security.");
            }
        }

        //storing replies method
        private void store_replies()
        {
            //store values of replies
            replies.Add("password needs to be protected and kept safe");
            replies.Add("sql injection is very los based on rate");
            replies.Add("attacking phones is based on phishing");
        }

        //ignore words method
        private void store_ignores()
        {
            //store values of ignore
            ignore.Add("tell");
            ignore.Add("me");
            ignore.Add("about");
        }
    }
}