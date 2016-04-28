// Title: BasicSprite
// Description:
//   Allows the creation of a sprite with minimal functionality i. e., load
//   textures, modify its position, dimensions and collision detection.
//
//   Provides the underlying base to create more advanced types such as Basic
//   AnimatedSprite and AnimatedCharacter.
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Elysium
{
    class BasicSprite : AbstractSprite
    {
        // Properties
        public Rectangle Pos
        {
            set { pos = value; }
            get { return pos; }
        }
        public bool collStat
        {
            // Return collision status
            set { collision = value; }
            get { return collision; }
        }
        public bool cRight
        {
            set { collisionRight = value; }
            get { return collisionRight; }
        }
        public bool cLeft
        {
            set { collisionLeft = value; }
            get { return collisionLeft; }
        }
        public bool cUp
        {
            set { collisionUp = value; }
            get { return collisionUp; }
        }
        public bool cDown
        {
            set { collisionDown = value; }
            get { return collisionDown; }
        }

        // Methods
        public void Init(string filename)
        {
            this.filename = filename;
            loaded = true;
        }
        public override void LoadContent(ContentManager Content)
        {
            // Load texture image, set default position and size to the
            // origin and the image's dimensions respectively if the content
            // has already been loaded.
            if (loaded)
            {
                image = Content.Load<Texture2D>(filename);
                // POSITION rectangle
                // (x, y) will be the position on-screen and width, height will be the size on-screen
                pos = new Rectangle(0, 0, image.Width, image.Height);

                // SOURCE rectangle
                // (x,y) will be the position of the source rectangle with respect to the image
                // and width, height should be the size of the image when displaying an entire image
                // NOTE: (x,y) will NOT move/change with "pos"
                source = new Rectangle(0, 0, image.Width, image.Height);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (collision)
                color = Color.Red;
            else
                color = Color.White;

            spriteBatch.Begin();
            spriteBatch.Draw(image, pos, source, color);
            spriteBatch.End();
            collision = false;
        }
        public void setPos(int x, int y)
        {
            pos.X = x;
            pos.Y = y;
        }
        public bool Collision(Rectangle recIn)
        {
            // Detect wether a collision has ocurred.
            if (collision == false)
                collision = pos.Intersects(recIn);

            //if (collision)
            //{
            //    // Determine direction of collision by placing a rectangle
            //    // on the Sprite's edges and checking if it is intersected
            //    // by rectIn.
            //    Rectangle collisionHandler = new Rectangle();
            //    collisionHandler = pos;

            //    // Prepare collision handler to check for collsions from the
            //    // left or right
            //    collisionHandler.Width = 1;
            //    collisionHandler.Height -= 2;
            //    collisionHandler.Y += 1;

            //    // Left side
            //    if (collisionHandler.Intersects(recIn))
            //        collisionLeft = true;

            //    // Right side
            //    collisionHandler.X = pos.X + pos.Width - 1;
            //    if (collisionHandler.Intersects(recIn))
            //        collisionRight = true;

            //    // Prepare collision handler to check for collsions from the
            //    // top or bottom
            //    collisionHandler = pos;
            //    collisionHandler.Height = pos.Height - 2;
            //    collisionHandler.Y += 1;

            //    // Top side
            //    if (collisionHandler.Intersects(recIn))
            //        collisionUp = true;

            //    // Bottom side
            //    collisionHandler.Y = pos.Y + pos.Height - 1;
            //    if (collisionHandler.Intersects(recIn))
            //        collisionDown = true;
            //}
            return collision;
        }
        public void setSize(int width, int height)
        {
            // Set Sprite size, it is not recommendable to use this with ani-
            // mated sprites.
            pos.Width = width;
            pos.Height = height;
        }
    }
}