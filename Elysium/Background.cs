using Microsoft.Xna.Framework;

namespace Elysium
{
    class Background : BasicAnimatedSprite
    {
        // Constructor
        public Background()
        {
            //setPos(0, 0);
            //color = Color.White;
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
