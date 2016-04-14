// Title: AutoCharacter
// Descripcition:
//   Base functionality for animated characters with autonomous movement, con-
//   tinuously updates the characters position and dinamically changes direc-
//   tion based on whether the position increment attribute is a positive in-
//   teger or not.
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elysium
{
    class AutoCharacter : AnimatedCharacter
    {
        public override void Update(GameTime gameTime)
        {
            // Choose new default state and contain inside window
            base.Update(gameTime);

            // Movement
            pos.X += incX;
            pos.Y += incY;

            // Update only the sprite which has the same orientation as the
            // movement
            if (incX > 0)
            {
                dir = SideDirection.RUN_RIGHT;
                moveRight.Update(gameTime);
            }
            else
            {
                dir = SideDirection.RUN_LEFT;
                moveLeft.Update(gameTime);
            }

            // If the Sprite gets to the edge of the screen, bounce.
            if ((pos.Y + moveLeft.Pos.Height) > wnd.Height || pos.Y < 0)
                incY *= -1;

            else if ((pos.X + moveLeft.Pos.Width) > wnd.Width || pos.X < 0)
                incX *= -1;

            contnInsdeWnd();
        }
    }
}
