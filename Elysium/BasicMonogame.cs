// Title: BasicMonogame
// Description:
//   Interface that enforces the pattern used by the MonoGame framework. All
//   derived classes must implement the methods defined here.
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Elysium
{
    interface BasicMonogame
    {
        void LoadContent(ContentManager Content);
        void Draw(SpriteBatch spriteBatch);
    }
}
