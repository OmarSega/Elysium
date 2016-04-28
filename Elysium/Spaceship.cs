// Title: Spaceship
// Description:
//   A spaceship is able to move freely horizontally and vertically, it is ar-
//   med with a laser cannon that can be fired horizontally unrestrictedly 
//   (the shots are stored on the Shots arraylist).
// 
//   It's health can be replenished whe it collides with a power up. The ob-
//   jects of the spaceship class are meant to be controlled by the user and 
//   will have three lives by default.
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Collections;
using System.Collections.Generic;  

namespace Elysium
{
    class Spaceship : UserCharacter
    {
        // Attributes
        int life;                   // Ship's stamina
        public ArrayList Shots;     // Shots fired by the spaceship
        float timeSinceLastShot;    // Ancillary variable to control shot instantiation
        float timeBetweenShots;     // Time between shots
        Keys shotKey;               // Key used to shoot
        List<SoundEffect> SoundEffects;

        // Properties
        public int Life
        {
            set { life = value; }
            get { return life; }
        }
        public Keys leftKey
        {
            get { return Left; }
        }

        // Constructor
        public Spaceship()
        {
            // Initialize content for character in all its states.
            InitStand(SideDirection.STAND_LEFT, "sShip_Heroe.png");
            InitStand(SideDirection.STAND_RIGHT, "sShip_Heroe.png");
            InitStand(SideDirection.STAND_UP, "sShip_Heroe.png");
            InitStand(SideDirection.STAND_DOWN, "sShip_Heroe.png");

            InitMove(SideDirection.RUN_LEFT, "sShip_Heroe.png", 1, 0, 1, 80, 77);
            InitMove(SideDirection.RUN_RIGHT, "sShip_Heroe.png", 1, 0, 1, 80, 77);
            InitMove(SideDirection.RUN_UP, "sShip_Heroe.png", 1, 0, 1, 80, 77);
            InitMove(SideDirection.RUN_DOWN, "sShip_Heroe.png", 1, 0, 1, 80, 77);

            // Configuration
            life = 3;
            incX = 4; incY = 4;
            timeBetweenShots = 0.5f;
            shotKey = Keys.Space;
            Shots = new ArrayList();
            SoundEffects = new List<SoundEffect>();
        }

        // Methods
        public override void LoadContent(ContentManager Content)
        {
            // Load textures and sound effects
            SoundEffects.Add(Content.Load<SoundEffect>("laser.wav"));
            base.LoadContent(Content);
        }
        public void Update(GameTime gameTime, ContentManager Content)
        {
            // Keep track track of elapsed game time
            timeSinceLastShot += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Generate enable shots every
            if (Keyboard.GetState().IsKeyDown(shotKey) && timeSinceLastShot > timeBetweenShots)
                createShot(Content);

            // Update shots and remove if they are off the screen
            for (int i = 0; i < Shots.Count; i++)
            {
                ((AutoSprite)Shots[i]).Update(gameTime);
                if (((AutoSprite)Shots[i]).Pos.X > wnd.Width)
                    Shots.RemoveAt(i);
            }

            if (collStat)
            {
                life--;
                collStat = false;
            }

            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            // Draw ships
            base.Draw(spriteBatch);

            // Draw shots
            for (int i = 0; i < Shots.Count; i++)
                ((AutoSprite)Shots[i]).Draw(spriteBatch);
        }

        // Configuration methods
        public void setShotKey(Keys key)
        {
            // Establish which key will be used to shoot
            shotKey = key;
        }
        void createShot(ContentManager Content)
        {
            // Configure and add new shot to Shots arraylist
            AutoSprite shot = new AutoSprite("Shot_Heroe.png");
            shot.LoadContent(Content);
            shot.setSize(5, 9);
            shot.setIncrement(9, 0);
            shot.setPos((int)pos.X + standLeft.Pos.Width, (int)pos.Y + standLeft.Pos.Height / 2);
            Shots.Add(shot);
            timeSinceLastShot = 0f;

            var instance = SoundEffects[0].CreateInstance();
            instance.Volume = 0.4f;
            instance.Play();
        }

        // Collision methods
        public ArrayList getShots()
        {
            return Shots;
        }
        public void removeShotAt(int i)
        {
            Shots.RemoveAt(i);
        }
    }
}
