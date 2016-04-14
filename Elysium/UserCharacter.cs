// Title: UserCharacter
// Description:
//   Base functionality for user controlled animated characters, permits es-
//   blishing control keys as well as updating the character's position de-
//   pending on which of the said keys is being pressed and dinamically chan-
//   ging the character's direction.
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Elysium
{
    class UserCharacter : AnimatedCharacter
    {
        // Atributes
        Keys Up, Down, Left, Right;

        // Methods
        public override void Update(GameTime gameTime)
        {
            // Handle user input, set new position for all Sprites
            if (Keyboard.GetState().IsKeyDown(Left))
            {
                dir = SideDirection.RUN_LEFT;
                pos.X -= incX;
                setPos(pos);
            }
            else if (Keyboard.GetState().IsKeyDown(Right))
            {
                dir = SideDirection.RUN_RIGHT;
                pos.X += incX;
                setPos(pos);
            }
            else if (Keyboard.GetState().IsKeyDown(Up))
            {
                dir = SideDirection.RUN_UP;
                pos.Y -= incY;
                setPos(pos);
            }
            else if (Keyboard.GetState().IsKeyDown(Down))
            {
                dir = SideDirection.RUN_DOWN;
                pos.Y += incY;
                setPos(pos);
            }

            // Choose new default state and contain inside window
            contnInsdeWnd();
            base.Update(gameTime);
        }
        public void setKeys(Keys up, Keys down, Keys left, Keys right)
        {
            // Set the control keys for the Sprite.
            Up = up;
            Down = down;
            Left = left;
            Right = right;
        }
    }
}
