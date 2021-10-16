using System.IO;
using System;
using System.Collections.Generic;


namespace Quiz
{
    class Program
    {
        static void Main()
        {
            string[] fileRead = File.ReadAllLines(@"..\QnA.txt");
            string[][] frågor = new string[fileRead.Length][];

            int score = 0;
            string answerInput = "";

            for (var i = 0; i < fileRead.Length; i++)
            {
                frågor[i] = fileRead[i].Split(";");
                Console.WriteLine(frågor[i][0]);
                answerInput = Console.ReadLine();

                if (answerInput == frågor[i][1])
                {
                    score++;
                }
            }

            Console.ReadLine();
        }
    }
}


// Console.WriteLine(fileRead[0].Split(";")[0]);