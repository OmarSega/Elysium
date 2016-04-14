using Microsoft.Xna.Framework;

namespace Elysium
{
    class Background : BasicSprite
    {
        // Constructor
        public Background()
        {
            Init("background.jpg");
        }
        // Methods
        public void setSize(GraphicsDeviceManager graphics)
        {
            // Match background and viewport sizr
            pos.Width = graphics.GraphicsDevice.Viewport.Width;
            pos.Height = graphics.GraphicsDevice.Viewport.Height;
        }
    }
}
