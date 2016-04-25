// Title: BasicAnimatedSprite
// Descripcition:
//   Extends the BasicSprite class to support creating an animated sprite, 
//   its functionality includes: loading textures from single or multiple
//   files.
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elysium
{
    class BasicAnimatedSprite : BasicSprite
    {
        // Animation control
        int frameCount;         // Total number of frames available
        int rowCount;           // Number of rows in a SpriteSheet
        int currentFrame;       // Frame currently displayed.
        int currentRow;         // Row currently displayed.
        float timer;            // Needed to render animations correctly
        float timePerFrame;     // The time a single frame will be shown.

        // Texture
        ArrayList textureList;  // Holds all textures, if they are in different files
        int frameWidth;         // Specify the animation's frame width.
        int frameHeight;        // Specify the animation's frame height.
        string dirname;         // Path directory

        // Operation mode flags and error checking
        bool singleFile;        // Wether we are using a spritesheet or not.
        bool loadedSingle;      // Singals a single file has been loaded.
        bool loadedMul;         // Singals multiple files have been loaded.

        // Constructor
        public BasicAnimatedSprite()
        {
            textureList = new ArrayList();
        }

        // Methods
        public override void LoadContent(ContentManager Content)
        {
            // Common time initialization
            currentFrame = 0;
            timer = 0;

            if (singleFile)
            {
                if (loadedSingle)
                {
                    currentRow = 0;
                    image = Content.Load<Texture2D>(filename);
                    pos = new Rectangle(0, 0, frameWidth, frameHeight);
                    source = new Rectangle(0, 0, frameWidth, frameHeight);
                }
            }
            else if (loadedMul)
            {
                int w = 0;
                int h = 0;

                for (int k = 1; k <= frameCount; k++)
                {
                    Texture2D tex;
                    tex = Content.Load<Texture2D>(dirname + "/" + filename + k.ToString("00"));
                    textureList.Add(tex);
                    w = tex.Width;
                    h = tex.Height;
                }

                pos = new Rectangle(0, 0, w, h);
                source = new Rectangle(0, 0, w, h);
            }
        }
        public void Init(string dirname, string filename, int frames,
            float timeFrame)
        {
            // Load content from multiple files
            this.dirname = dirname;
            this.filename = filename;
            frameCount = frames;
            timePerFrame = timeFrame;
            singleFile = false;
            loadedMul = true;
        }
        public void Init(string filename, int framesX, int framesY,
            float timeFrame, int width, int height)
        {
            // Load content from a sprite sheet
            this.filename = filename;
            frameCount = framesX;   // The number of frames along X
            rowCount = framesY;     // The number of rows along Y
            frameWidth = width;
            frameHeight = height;
            timePerFrame = timeFrame;

            singleFile = true;
            loadedSingle = true;
        }
        public void Update(GameTime gameTime)
        {
            // Keep track of the time, necessary for the animations.
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= timePerFrame)
            {
                // Increment current frame
                currentFrame = (currentFrame + 1) % frameCount;
                timer -= timePerFrame;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (singleFile)
            {
                // Calculate position of the frame that will be shown
                int xTex, yTex;
                xTex = currentFrame * frameWidth;
                yTex = currentRow * frameHeight;
                source.X = xTex;
                source.Y = yTex;

                source = new Rectangle(xTex, yTex, frameWidth, frameHeight);
                base.Draw(spriteBatch);
            }
            else
            {
                image = (Texture2D)textureList[currentFrame];
                base.Draw(spriteBatch);
            }
        }
        public void setCurrentRow(int row)
        {
            // Change the SpriteSheet's row currently displayed
            currentRow = row;
        }
    }
}
