using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework.Content.Engine
{
    public class Animation
    {
        // String of the current animation that identifies it in the dictionary. 
        private string currentAnimation;
        // Current frame of animation sequence.
        private int currentFrame;

        // Time since animation last changed frames. 
        private double animationTimer;

        // True if the current animation repeats, false if it plays once
        private bool looping;

        // True once a play animation has reached its last frome. Falso for looping.
        public bool IsFinished { get; private set; }

        // How long each fram should stay on the screen (defuault is 0.15).
        public double frameDuration { get; set; } = 0.15;

        // Plays a animation on repeat. 
        public void PlayLoop(string animationName)
        {
            bool restart = false;
            Play(animationName, true, restart);
        }

        // Plays animation once and holds on the last frame. 
        public void PlayOnce(string animationName)
        {
            bool restart = false;
            Play(animationName, false, restart);
        }

        // Shared setup for both play methods.
        public void Play(string animationName, bool loop, bool restart)
        {
            if (currentAnimation == animationName && looping == loop && !restart)
            {
                return;
            }

            currentAnimation = animationName;
            looping = loop;
            currentFrame = 0;
            animationTimer = 0;
            IsFinished = false;
        }

        //updates the animation and returns current texture.
        public Texture2D Update(GameTime gameTime)
        {
            if (string.IsNullOrEmpty(currentAnimation))
            {
                return null;
            }

            if (!IsFinished)
            {
                animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

                if (animationTimer >= frameDuration)
                {
                    currentFrame++;
                    animationTimer = 0;
                }
            }

            int animationLength = AssetManager.Instance.GetAnimationLength(currentAnimation);
            if (currentFrame >= animationLength)
            {
                if (looping)
                {
                    currentFrame = 0;
                }
                else
                {
                    currentFrame = animationLength - 1;
                    IsFinished = true;
                }
            }




            // Texture2D for the current frame
            return AssetManager.Instance.GetAnimationFrame(currentAnimation, currentFrame);
        }
    }
}
