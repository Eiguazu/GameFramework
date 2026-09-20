using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework.Content.Engine
{
    public class Animation
    {
        //
        private string currentAnimation;
        // Current frame of animation sequence.
        private int currentFrame;

        // Time since animation last changed frames. 
        private double animationTimer;

        // How long each fram should stay on the screen (defuault is 0.15).
        public double frameDuration { get; set; } = 0.15;

        // Starts a animation.
        public void Play(string animationName)
        {
            currentAnimation = animationName;
            currentFrame = 0;
            animationTimer = 0;
        }

        //updates the animation and returns current texture.
        public Texture2D Update(GameTime gameTime)
        {
            if (string.IsNullOrEmpty(currentAnimation))
            {
                return null;
            }

            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (animationTimer >= frameDuration)
            {
                currentFrame++;
                animationTimer = 0;
                int animationLength = AssetManager.Instance.GetAnimationLength(currentAnimation);

                if (currentFrame >= animationLength)
                {
                    currentFrame = 0;
                }

            }

            // Texture2D for the current frame
            return AssetManager.Instance.GetAnimationFrame(currentAnimation, currentFrame);
        }
    }
}
