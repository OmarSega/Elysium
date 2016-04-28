// Title: Explosion
// Description:
//   Animation shown when an enemy has been hit. It is expected to removed
//   once the animation ends.
using Microsoft.Xna.Framework;

namespace Elysium
{
    class Explosion : BasicAnimatedSprite
    {
        // Attributes
        bool active; // Flag to remove the animation.
        float timer; // Variable to keep track of time.

        // Properties
        bool Active
        {
            // Flag to remove the animation
            get { return active; }
            set { active = value; }
        }

        // Constructor
        public Explosion()
        {
            Init("fire.png", 16, 0, 0.0625f, 65, 64);
            active = true;
            timer = 0;
        }

        // Methods
        public void Update(GameTime gameTime, Rectangle pos)
        {
            // After one second, flag this explosion as removable
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > 1)
            {
                active = false;
            }

            // Switch between frames.
            Update(gameTime);
        }
    }
}
