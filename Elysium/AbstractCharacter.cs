// Title: AbstractSprite
// Descripcition:
//   Permits establishing a global configuration for Animated Characters and 
//   derived classes.
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Elysium
{
    // Animation states
    enum SideDirection
    {
        STAND_LEFT, STAND_RIGHT, STAND_UP, STAND_DOWN,
        RUN_LEFT, RUN_RIGHT, RUN_UP, RUN_DOWN, AGONY
    };
    abstract class AbstractCharacter : BasicMonogame
    {
        // Animation sprites
        protected BasicSprite standLeft, standRight, standUp, standDown;
        protected BasicAnimatedSprite moveLeft, moveRight, moveUp, moveDown;
        protected SideDirection dir;

        // Movement attributes
        protected int incX, incY; // Position increment
        protected Vector2 pos;    // Character's (x,y) position

        // Global configuration attributes
        protected static Rectangle wnd;

        // Methods
        public abstract void LoadContent(ContentManager Content);
        public abstract void Draw(SpriteBatch spriteBatch);
        public static void SetLimits(int width, int height)
        {
            // Static method to keep all elements on screen, the default po-
            // sition is the origin.
            AbstractSprite.SetLimits(width, height);
            wnd = new Rectangle(0, 0, width, height);
        }
    }
}
