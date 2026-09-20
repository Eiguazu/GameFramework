using Microsoft.Xna.Framework;

namespace GameFramework.Content.Engine
{
    public class Timer
    {
        // Wait time in milliseconds for the timer.
        protected double wait = 0;

        // Tracks whether a countdown is in progress.
        private bool running = false; 

        //True while a countdown is in progress.
        public bool IsRunning
        {
            get { return running; }
        }

        // Method to check if the timer is still running based on the elapsed game time and the specified wait time in seconds.
       public bool GameTimer(GameTime gameTime, double seconds)
        {
            if (!running)
            {
                wait = seconds;
                running = true;
            }

            wait -= gameTime.ElapsedGameTime.TotalSeconds;

            if (wait <= 0)
            {
                wait = 0;
                running = false;
                return false;
            }

            return true;
        }


        // Cancels the current countdown.
        public void Reset()
        {
            wait = 0;
            running = false;
        }
    }
}
