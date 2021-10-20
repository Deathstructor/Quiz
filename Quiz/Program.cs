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
            Console.WriteLine("This quiz consists of 30 questions with no specific topic,");
            Console.WriteLine("and 10 questions will be randomly picked for you to answer.");
            Console.WriteLine("You will be given three alternatives for each question.");
            Console.WriteLine("To choose your answer you need to type in the letter next");
            Console.WriteLine("to the alternative (A, B or C), or the full answer.");
            Console.WriteLine("If you don't enter anything, your answer will be registered");
            Console.WriteLine("as an incorrect answer, so make sure that you choose an answer!");
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
            for (var i = 0; i < 10; i++)
            {
                Random rdm = new Random();

                RetryQ:
                    int nextQ = rdm.Next(10);

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
                
                
                
                questions[nextQ] = fileRead[nextQ].Split(";");
                Console.WriteLine(questions[nextQ][0]);
                Console.WriteLine($"a) {questions[nextQ][a]}     b) {questions[nextQ][b]}     c) {questions[nextQ][c]}");
                answerInput = Console.ReadLine().ToLower();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                
                if (questions[nextQ][a] == questions[nextQ][1] && answerInput == "a")
                {
                    Console.WriteLine("Correct answer!");
                    score++;
                } else if(questions[nextQ][b] == questions[nextQ][1] && answerInput == "b")
                {
                    Console.WriteLine("Correct answer!");
                    score++;
                } else if (questions[nextQ][c] == questions[nextQ][1] && answerInput == "c")
                {
                    Console.WriteLine("Correct answer!");
                    score++;
                } else if(answerInput == questions[nextQ][1])
                {
                    Console.WriteLine("Correct answer!");
                    score++;
                } else
                {
                    Console.WriteLine("Wrong answer!");                   
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

            if (score <= 3)
            {
                Console.WriteLine($"Your final score is {score}");
                Console.WriteLine("Your score is pretty not very good, there's deffinately room improvement!");
            } else if(score >= 4 && score <= 6)
            {
                Console.WriteLine($"Your final score is {score}");
                Console.WriteLine("Your score is okay, but you can deffinately do better!");
            }else if(score >= 7 && score <= 9)
            {
                Console.WriteLine($"Your final score is {score}");
                Console.WriteLine("Your score is pretty good! Maybe try to reach maximum score next time? :)");
            } else if (score == 10)
            {
                Console.WriteLine($"Your final score is {score}!");
                Console.WriteLine("You scored a perfect score! Congratulations! :D");
            }

            Console.ReadLine();
        }
    }
}