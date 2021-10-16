using System.IO;
using System;


namespace Quiz
{
    class Program
    {
        static void Main() {
            Console.WriteLine("Welcome to this completely random quiz!");

            Console.ReadLine();
            frågor();
        }



        static void frågor()
        {
            string[] fileRead = File.ReadAllLines(@"..\QnA.txt");
            string[][] questions = new string[fileRead.Length][];

            int score = 0;
            string answerInput = "";

            for (var i = 0; i < fileRead.Length; i++)
            {
                Random rdm = new Random();
                int a = rdm.Next(1, 4);
                int b = rdm.Next(1, 4);
                int c = rdm.Next(1, 4);

                questions[i] = fileRead[i].Split(";");
                Console.WriteLine(questions[i][0]);
                Console.WriteLine($"a) {questions[i][a]},     b) {questions[i][b]},     c) {questions[i][c]}");
                answerInput = Console.ReadLine();

                if (answerInput == questions[i][1])
                {
                    score++;
                }

                Console.WriteLine();
                Console.WriteLine($"Your score is {score}.");
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}