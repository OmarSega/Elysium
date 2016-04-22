// Title: AutoSprite
// Descripcition:
//   Base functionality for sprites which are not animated but move across
//   the screen
//   This class can be used to instatiate shots, asteroids and powerups.
using Microsoft.Xna.Framework;

namespace Elysium
{
    class AutoSprite : BasicSprite
    {
        // Attributes
        protected int incX, incY; // Position increment

        public AutoSprite(string filename)
        {
            Init(filename);
            incX = 1;
            incY = 1;
        }

        // Methods
        public virtual void Update(GameTime gameTime)
        {
            // Movement
            pos.X += incX;
            pos.Y += incY;
        }
        public void setIncrement(int x, int y)
        {
            // Set position increment
            incX = x;
            incY = y;
        }
    }
}
