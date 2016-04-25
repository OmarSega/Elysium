// Title: AbstractSprite
// Descripcition:
//   Permits establishing a global configuration for Basic Sprites and derived
//   classes.
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Elysium
{
    abstract class AbstractSprite : BasicMonogame
    {
        // Core attributes
        protected Texture2D image;      // Texture image for sprite
        protected Rectangle pos;        // Sprite's position, size, dest. rectangle
        protected Rectangle source;     // Source region drawn by Draw method
        protected string filename;      // Texture 
        protected bool loaded = false;  // Singals if an image has been loaded.
        protected Color color;          // Color used when not colliding

        // Collision attributes
        protected bool collision;       // Collision flag
        protected bool collisionRight;  // Collision from the right flag
        protected bool collisionLeft;   // Collision from the left flag
        protected bool collisionUp;     // Collision from the up flag
        protected bool collisionDown;   // Collision from the right flag
        Color collisionColor;           // Color mask for collisions

        // Global configuration attributes
        protected static Rectangle wnd;

        // Methods
        public abstract void LoadContent(ContentManager Content);
        public abstract void Draw(SpriteBatch spriteBatch);
        public static void SetLimits(int width, int height)
        {
            // Static method to keep all elements on screen, the default po-
            // sition is the origin.
            wnd = new Rectangle(0, 0, width, height);
        }
    }
}
