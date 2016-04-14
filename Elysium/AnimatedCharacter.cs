// Title: AnimatedCharacter
// Descripcition:
//   Provides the base functionality for an animated character, in conjunc-
//   tion with the BasicSprite and BasicAnimatedSprite class forms a layered
//   sprite capable of displaying both static and animated states.
//   
//   It is assumed all sprites have the same dimensions and position, most 
//   attributes and functionality are determined by the leftmost BasicSprite.
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Elysium
{
    class AnimatedCharacter : AbstractCharacter
    {
        // Properties
        public bool collStat
        {
            // Return collision status
            set { standLeft.collStat = value; }
            get { return standLeft.collStat; }
        }

        // Constructor
        public AnimatedCharacter()
        {
            dir = SideDirection.STAND_RIGHT;

            standLeft = new BasicSprite();
            standRight = new BasicSprite();
            standUp = new BasicSprite();
            standDown = new BasicSprite();

            moveLeft = new BasicAnimatedSprite();
            moveRight = new BasicAnimatedSprite();
            moveUp = new BasicAnimatedSprite();
            moveDown = new BasicAnimatedSprite();
        }

        // Methods
        public override void LoadContent(ContentManager Content)
        {
            // Load content for all Sprites
            standLeft.LoadContent(Content);
            standRight.LoadContent(Content);
            standUp.LoadContent(Content);
            standDown.LoadContent(Content);

            moveLeft.LoadContent(Content);
            moveRight.LoadContent(Content);
            moveUp.LoadContent(Content);
            moveDown.LoadContent(Content);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (dir == SideDirection.RUN_RIGHT)
                moveRight.Draw(spriteBatch);
            else if (dir == SideDirection.STAND_RIGHT)
                standRight.Draw(spriteBatch);
            else if (dir == SideDirection.RUN_LEFT)
                moveLeft.Draw(spriteBatch);
            else if (dir == SideDirection.STAND_LEFT)
                standLeft.Draw(spriteBatch);
            else if (dir == SideDirection.RUN_UP)
                moveUp.Draw(spriteBatch);
            else if (dir == SideDirection.STAND_UP)
                standUp.Draw(spriteBatch);
            else if (dir == SideDirection.RUN_DOWN)
                moveDown.Draw(spriteBatch);
            else if (dir == SideDirection.STAND_DOWN)
                standDown.Draw(spriteBatch);
        }
        public virtual void Update(GameTime gameTime)
        {
            // Choose new default state based on the previous state
            if (dir == SideDirection.RUN_RIGHT)
                dir = SideDirection.STAND_RIGHT;
            else if (dir == SideDirection.RUN_LEFT)
                dir = SideDirection.STAND_LEFT;
            else if (dir == SideDirection.RUN_UP)
                dir = SideDirection.STAND_UP;
            else if (dir == SideDirection.RUN_DOWN)
                dir = SideDirection.STAND_DOWN;
        }

        // Movement modifiers
        public void setPos(Vector2 newPos)
        {
            // Convert vector to rectangle and update this objects position.
            Rectangle newPosition = moveLeft.Pos;
            newPosition.X = (int)newPos.X;
            newPosition.Y = (int)newPos.Y;
            pos = newPos;

            // Update sprites position
            standLeft.Pos = newPosition;
            standRight.Pos = newPosition;
            standUp.Pos = newPosition;
            standDown.Pos = newPosition;

            moveLeft.Pos = newPosition;
            moveRight.Pos = newPosition;
            moveUp.Pos = newPosition;
            moveDown.Pos = newPosition;
        }
        public void setIncrement(int x, int y)
        {
            // Set position increment
            incX = x;
            incY = y;
        }

        // Collision handling
        public bool Collision(Rectangle rectIn)
        {
            return standLeft.Collision(rectIn);
        }
        public Rectangle getRect()
        {
            return standLeft.Pos;
        }

        // Initialize content
        public void InitStand(SideDirection dir, string filename)
        {
            if (dir == SideDirection.STAND_RIGHT)
                standRight.Init(filename);
            else if (dir == SideDirection.STAND_LEFT)
                standLeft.Init(filename);
            else if (dir == SideDirection.STAND_UP)
                standUp.Init(filename);
            else if (dir == SideDirection.STAND_DOWN)
                standDown.Init(filename);
        }
        public void InitMove(SideDirection dir, string dirname, string
            filename, int frames, float timeFrame)
        {
            // Load content from multiple files
            if (dir == SideDirection.RUN_RIGHT)
                moveRight.Init(dirname, filename, frames, timeFrame);
            else if (dir == SideDirection.RUN_LEFT)
                moveLeft.Init(dirname, filename, frames, timeFrame);
            else if (dir == SideDirection.RUN_UP)
                moveUp.Init(dirname, filename, frames, timeFrame);
            else if (dir == SideDirection.RUN_DOWN)
                moveDown.Init(dirname, filename, frames, timeFrame);
        }
        public void InitMove(SideDirection dir, string filename, int framesX,
            int framesY, float timeFrame, int width, int height)
        {
            // Load content from a SpriteSheet
            if (dir == SideDirection.RUN_RIGHT)
                moveRight.Init(filename, framesX, framesY, timeFrame, width, height);
            else if (dir == SideDirection.RUN_LEFT)
                moveLeft.Init(filename, framesX, framesY, timeFrame, width, height);
            else if (dir == SideDirection.RUN_UP)
                moveUp.Init(filename, framesX, framesY, timeFrame, width, height);
            else if (dir == SideDirection.RUN_DOWN)
                moveDown.Init(filename, framesX, framesY, timeFrame, width, height);
        }
        protected void contnInsdeWnd()
        {
            // Does not allow and Animated Character to go past the window
            // boundaries.
            if (pos.X < 0)
                pos.X = 0;
            else if ((pos.X + moveLeft.Pos.Width) >= wnd.Width)
                pos.X = wnd.Width - moveLeft.Pos.Width;

            if (pos.Y < 0)
                pos.Y = 0;
            else if ((pos.Y + moveLeft.Pos.Height) >= wnd.Height)
                pos.Y = wnd.Height - moveLeft.Pos.Height;

            setPos(pos);
        }
    }
}
