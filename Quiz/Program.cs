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
            List<int> randomAnswer = new List<int>();
            for (var i = 0; i < fileRead.Length; i++)
            {
                Random rdm = new Random();

                RetryQ:
                    int nextQ = rdm.Next(15);
                    i = nextQ;

                    if (randomQuestion.Contains(nextQ))
                    {
                        goto RetryQ;
                    } else
                    {
                        randomQuestion.Add(nextQ);
                    }
                
                RetryA:
                    int a = rdm.Next(1, 4);
                    int b = rdm.Next(1, 4);
                    int c = rdm.Next(1, 4);

                    if (b == a || c == a || b == c)
                    {
                        goto RetryA;
                    }
                    

                questions[i] = fileRead[i].Split(";");
                Console.WriteLine(questions[i][0]);
                Console.WriteLine($"a) {questions[i][a]}     b) {questions[i][b]}     c) {questions[i][c]}");
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