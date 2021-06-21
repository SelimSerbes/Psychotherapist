using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychotherapist_Hmwrk4_
{

    class Program
    {
        public static void firstUppercase(ref string b)
        {
            string a = "";
            a = b.Substring(0, 1);

            b = b.Remove(0, 1);                             //First letter -- Uppercase
                                                            
            b = b.Insert(0, a.ToUpper());

        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int random, random2 = 5;
            bool flag = false;
            string[] computer = new string[30];
            string user_negative_word = "", repetitive_string = "", user_lastsentence = "";
            string[] userwords = null;
            string[] lastsentence = null;
            string user = "";
            char[] punctuations = { '.', ',', ';', '’', '"', '?', '!', '-', '{', '}', '(', ')', '[', ']' };
            string[] stop_words = { "a", "after", "again", "all", "am", "and", "any", "are", "as", "at", "be",
                "been", "before", "between", "both", "but", "by", "can", "could", "for", "from", "had", "has",
                "he", "her", "here", "him", "in", "into", "I", "is", "it", "me", "my", "of", "on", "our", "she",
                "so", "such", "than", "that", "the", "then", "they", "this", "to", "until", "we", "was", "were",
                "with", "you" ," "};
            string[] negative_words = {"stress", "depression", "sad", "angry", "hate", "pain", "abnormal", "abort",
                "abuse", "brittle", "hurt", "scared", "afraid", "upset", "confused", "lonely", "tired", "vulnerable",
                "guilty", "anxiety", "disappointment", "regret", "awful", "sick", "regretful", "unhappy", "sorrowful",
                "troubled", "worried", "annoyed"};
            string[] question_words = { "why", "who", "when", "where", "what", "how" };
            Console.WriteLine("\n                   Please follow the spelling rules(Especially,Use punctuation mark.)\n\n");

            while (!user.Contains("i have to go now"))          //the part of termination of speech.
            {
                int counter = 0;
                int temp = 0, temp3 = 0;
                Console.Write("User     : ");
                user = Console.ReadLine();
                user = user.ToLower();
                user = user.Replace("ı", "I");
                user = user.Replace("!", ".");
                user = user.Replace("?", ".");
                string space = "";
                lastsentence = user.Split('.');
                
                for (int i = 0; i < question_words.Length; i++)
                {
                    if (user.Contains(question_words[i]))
                    {
                        random2 = rnd.Next(0, 2);                              //Rule2 Control
                    }
                }


                for (int j = 0; j < punctuations.Length; j++)
                {
                    if (user.Contains(punctuations[j]))
                    {
                        space = Convert.ToString(punctuations[j]);              //the part of ignoring of punctuation.
                        user = user.Replace(space, "");
                    }
                }
                userwords = user.Split(' ');
                for (int j = 0; j < negative_words.Length; j++)
                {
                    if (user.Contains(negative_words[j]))
                    {
                        user_negative_word = negative_words[j];   //Rule 3 Control
                        counter = j;
                    }
                }

                for (int i = 0; i < userwords.Length; i++)
                {
                    flag = false;
                    for (int k = 0; k < stop_words.Length; k++)
                    {
                        if (userwords[i] == stop_words[k])
                        {
                            flag = true;
                            break;
                        }

                    }
                    if (flag == false)                                                  //Rule 1 Control                
                    {
                        temp3 = 0;
                        string temp2 = userwords[i];
                        for (int j = 0; j < userwords.Length; j++)
                        {
                            if (temp2 == userwords[j])
                            {
                                temp3++;
                            }
                        }
                        if (temp3 >= 2)
                        {
                            repetitive_string = userwords[i];
                            break;
                        }
                    }
                    if (temp >= 2)
                    {
                        break;
                    }
                } 
                if (!(user.Contains(negative_words[counter]) && user.Contains("yes")))
                {
                    for (int i = 0; i < lastsentence.Length - 1; i++)
                    {
                        user_lastsentence = lastsentence[i];                        //Rule 4 Last sentence
                    }
                    if (user_lastsentence.Contains("yes ")) { user_lastsentence = user_lastsentence.Remove(0, 4); }
                    else if (user_lastsentence.Contains("yes")) { user_lastsentence = user_lastsentence.Remove(0, 3); }
                    Array.Clear(lastsentence, 0, lastsentence.Length);

                    computer = user_lastsentence.Split(' ');
                    for (int i = 0; i < computer.Length; i++)
                    {
                        if (computer[i] == "I") { computer[i] = "you"; }
                        else if (computer[i] == "my") { computer[i] = "your"; }
                        else if (computer[i] == "am") { computer[i] = "are"; }      //Rule 4 Converting pronoun
                        else if (computer[i] == "me") { computer[i] = "you"; }
                        else if (computer[i] == "myself") { computer[i] = "yourself";}
                    }
                    random = rnd.Next(0, 2);
                    if (random == 0) //You say ...?                 //Rule 4  -- part of "You say"  
                    {
                        if (user.Contains("hello"))
                        {
                            // firstUppercase(ref computer[0]);
                            // firstUppercase(ref computer[3]);

                            Console.Write("Program  : You say ");
                            for (int i = 0; i < computer.Count(); i++)         
                            {
                                Console.Write(computer[i] + " ");
                            }
                            Console.WriteLine("?");
                        }
                        else if (temp3 >= 2)
                        {
                            Console.WriteLine("Program  : Do you love " + repetitive_string + "?");    //Rule 1 is happening
                        }
                        else if (random2 == 0)
                        {
                            Console.WriteLine("Program  : Do you often think about this question?"); 
                            random2 = 5;
                        }
                        else if (random2 == 1)                                                      //Rule 2 is happening
                        {
                            Console.WriteLine("Program  : Why do you want to know?");
                            random2 = 5;
                        }
                        else if (user.Contains("I have to go"))
                        { break; }
                        else
                        {
                            for (int i = 0; i < computer.Count(); i++)
                            {
                                if (i == 0)
                                {
                                    Console.Write("Program  : You say ");
                                }
                                Console.Write(computer[i] + " ");

                            }
                            Console.WriteLine("?");
                        }
                    }
                    else if (random == 1) //, right ?               //Rule 4 -- right ?
                    {
                        if (user.Contains("hello"))
                        {
                            Console.Write("Program  : ");
                            //firstUppercase(ref computer[0]);
                            //firstUppercase(ref computer[3]);
                            for (int i = 0; i < computer.Count(); i++)
                            {
                                Console.Write(computer[i] + " ");
                            }
                            Console.WriteLine(", right?");
                        }
                        else if (temp3 >= 2)
                        {
                            Console.WriteLine("Program  : Do you love " + repetitive_string + "?");    //Rule 1 is happening
                        }
                        else if (random2 == 0)
                        {
                            Console.WriteLine("Program  : Do you often think about this question?");   
                            random2 = 5;
                        }
                        else if (random2 == 1)                                      //Rule 2 is happening
                        {
                            Console.WriteLine("Program  : Why do you want to know?");
                            random2 = 5;
                        }
                        else if (user.Contains("I have to go"))
                        { break; }
                        else
                        {
                            //firstUppercase(ref computer[0]);
                            Console.Write("Program  : ");
                            for (int i = 0; i < computer.Count(); i++)
                            {
                                Console.Write(computer[i] + " ");
                            }
                            Console.WriteLine(", right?");
                        }
                    }
                    Array.Clear(computer, 0, computer.Length);
                }
                else if (user.Contains(negative_words[counter]))          //Rule 3 is happening
                {
                    for (int j = 0; j < negative_words.Length; j++)
                    {
                        if (user.Contains(negative_words[j]))
                        {
                            temp += 1;
                            user_negative_word = negative_words[j];
                            if (temp == 1)
                            {
                                Console.WriteLine("Program  : " + "Being " + user_negative_word + " is bad for your health. How long do you feel "
                                + user_negative_word + "? Why do you feel " + user_negative_word + "?");
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Program  : See you later man.");
            Console.ReadLine();

        }
    }
}

