using System.Collections.Generic;
using System.IO;
using System;


namespace Quiz
{
    class Program
    {
        static void Main() {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Hello and welcome to this completely random quiz!");
            Console.WriteLine();
            Console.WriteLine("You will be given three alternatives for each question.");
            Console.WriteLine("To choose your answer you need to typ in the letter next");
            Console.WriteLine("to the alternative (A, B or C).");
            Console.WriteLine();
            Console.WriteLine("Good luck! :)");
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Press 'Enter' to continue.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();


        
            string[] fileRead = File.ReadAllLines(@"..\QnA.txt");
            string[][] questions = new string[fileRead.Length][];

            int score = 0;
            string answerInput = "";

            List<int> randomQuestion = new List<int>();
            for (var i = 0; i < fileRead.Length; i++)
            {
                Random rdm = new Random();

                Retry:
                    int next = rdm.Next(15);
                    i = next;

                    if (randomQuestion.Contains(next))
                    {
                        goto Retry;
                    } else
                    {
                        randomQuestion.Add(next);
                    }

                questions[i] = fileRead[i].Split(";");
                Console.WriteLine(questions[i][0]);
                Console.WriteLine($"a) {questions[i][1]}     b) {questions[i][2]}     c) {questions[i][3]}");
                answerInput = Console.ReadLine();

                if (answerInput == questions[i][1])
                {
                    score++;
                }

                Console.WriteLine();
                Console.WriteLine($"Your score is {score}");
                Console.WriteLine();
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Press 'Enter' to continue.");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
            }
            Console.ReadLine();
        }
    }
}