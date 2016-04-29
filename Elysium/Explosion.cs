using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elysium
{
    class Explosion : BasicAnimatedSprite
    {
        // Attributes
        bool active;    // Flag an explosion as removable.
        float timer;    // Keeps track of time

        // Properties
        public bool Active
        {
            get { return active; }
        }

        // Constructor
        public Explosion()
        {
            Init("fire.png", 16, 0, 0.064f, 64, 64);
            active = true;
        }

        // Method
        public override void Update(GameTime gameTime)
        {

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > 1)
            {
                active = false;
            }
            base.Update(gameTime);
        }
    }
}
