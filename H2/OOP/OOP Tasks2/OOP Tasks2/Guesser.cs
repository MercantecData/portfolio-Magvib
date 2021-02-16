using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Tasks2
{
    public class Guesser
    {
        public bool guessedCorrectly = false;
        public bool timeRanOut = false;
        public string guess;
        public int randomNumber;
        public int numberTo;
        public int coutdown;

        public Guesser(int numberTo = 10, int timerInSec = 100)
        {
            // Time in seckunds
            this.coutdown = timerInSec;

            // Gets random number
            var rand = new Random();
            this.randomNumber = rand.Next(1, numberTo);
            this.numberTo = numberTo;

            // Information displayed on screen
            Console.WriteLine("Guess a number between 1 and " + this.numberTo);
            Console.WriteLine("Timer: " + this.coutdown + " Sec");

            // Starts countdown
            Countdown();


            // While loop so you can keep trying until you guess correctly or the countdown is 0s
            while (!this.guessedCorrectly || !this.timeRanOut)
            {
                this.guess = Console.ReadLine();

                int number = 0;

                try
                {
                    number = Int32.Parse(this.guess);
                } catch
                {
                    continue;
                }

                if (number == this.randomNumber)
                {
                    this.coutdown = 0;
                    this.guessedCorrectly = true;
                }
            }
        }

        public async Task Countdown()
        {
            Console.Clear();
            Console.WriteLine("Guess a number between 1 and " + this.numberTo);
            Console.WriteLine("Timer: " + this.coutdown + " Sec");
            Console.Write("Guess: ");

            await Task.Delay(1000);
            this.coutdown = this.coutdown - 1;

            if(this.coutdown == 0)
            {
                this.timeRanOut = true;
                Console.Clear();
                Console.WriteLine("Time ran out");
                return;
            }

            if(this.guessedCorrectly)
            {
                Console.Clear();
                Console.WriteLine("You guessed the correct number: " + this.randomNumber);
                return;
            }

            Countdown();
        }
    }
}
