// Title: Background
// Description:
//   Level backdrop, can scroll horizontally from right to left indefinitely.
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Elysium
{
    class Background : BasicSprite
    {
        // Attributes
        int limit;  // How far on the x plane we can set the origin of the 
                    // source rectangle without getting of of the image.
        float posX; // Current position of the source rectangle.
        float timer;// Manage background transitions.
                    
        // Methods
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
            limit = image.Width - wnd.Width - 641;
        }
        public void setSize(GraphicsDeviceManager graphics)
        {
            // Match background and viewport size
            pos.Width = graphics.GraphicsDevice.Viewport.Width;
            pos.Height = graphics.GraphicsDevice.Viewport.Height;
            int limit = image.Width - wnd.Width;
        }
        public void Update(GameTime gameTime)
        {
            // Keep track track of elapsed game time
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Calculate new source position without scrolling thorugh the
            // image at the speed of light.
            if(timer > 0.15f)
            {
                posX += 0.1f;
                source.X = (12 + source.X) % limit;
                timer = 0;
            }
        }
    }
}
