using Microsoft.Xna.Framework;

namespace GameFramework.Content.Engine
{
    public class Timer
    {
        // Timer for controlling the movement of the enemy.
        protected bool timer = false;

        // Wait time in milliseconds for the timer.
        protected int wait = 0;

        // Method to check if the timer is still running based on the elapsed game time and the specified wait time in seconds.
        public bool gameTimer(GameTime gameTime, double seconds)
        {
            if (wait <= 0)
            {
                wait = (int)(seconds * 1000);
            }

            wait -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (wait <= 0)
            {
                wait = 0;
                return false;
            }
            return true;
        }
    }
}
