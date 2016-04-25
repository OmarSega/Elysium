using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;

namespace Elysium
{
    class HeroControl
    {
        // Attributes
        ArrayList Heroes;            // Holds all the enemies.
        bool firstPlayerActive;      // Indicates if the player is active
        List<BasicSprite> indicator; // Used as indicator
        SpriteFont font;             // Font used on the indicators 

        // Properties
        public int Count
        {
            get { return Heroes.Count; }
        }

        // Constructor
        public HeroControl()
        {
            Heroes = new ArrayList();
            indicator = new List<BasicSprite>();

            // Add first player
            Spaceship player1 = new Spaceship();
            player1.setKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right);
            player1.setShotKey(Keys.Space);
            player1.setPos(new Vector2(50, 200));
            Heroes.Add(player1);
            firstPlayerActive = true;

            // Add indicators
            BasicSprite lifeIndicator1 = new BasicSprite();
            BasicSprite lifeIndicator2 = new BasicSprite();
            lifeIndicator1.Init("Life_Indicator.png");
            lifeIndicator2.Init("Life_Indicator.png");

            indicator.Add(lifeIndicator1);
            indicator.Add(lifeIndicator2);
        }
        // Methods
        public void LoadContent(ContentManager Content)
        {
            // Create a single player by default.
            ((Spaceship)Heroes[0]).LoadContent(Content);
            font = Content.Load<SpriteFont>("myFont");

            // Load content for indicators
            indicator[0].LoadContent(Content);
            indicator[1].LoadContent(Content);
            indicator[0].setPos(10, 20);
            indicator[0].setSize(20, 20);
            indicator[1].setPos(810, 20);
            indicator[1].setSize(20, 20);
        }
        public void Update(GameTime gameTime, ContentManager Content)
        {
            // Check if we are asked to create a new hero
            if (Keyboard.GetState().IsKeyDown(Keys.P) && Heroes.Count == 1)
                AddPlayer(Content);

            // Check if we need to remove any ships
            for (int i = 0; i < Heroes.Count; i++)
            {
                if (((Spaceship)Heroes[i]).Life <= 0)
                    Heroes.RemoveAt(i);
            }

            // Finally, update all heroes
            for (int i = 0; i < Heroes.Count; i++)
                ((Spaceship)Heroes[i]).Update(gameTime, Content);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw ships
            for (int i = 0; i < Heroes.Count; i++)
                ((Spaceship)Heroes[i]).Draw(spriteBatch);

            // Draw indicators, it's complicated :(
            for (int i = 0; i < Heroes.Count; i++)
            {
                indicator[i].Draw(spriteBatch);
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "Player " + (i + 1) + " lives: " +
                    ((Spaceship)Heroes[i]).Life,
                    new Vector2(40 + 800 * i, 20), Color.White);
                spriteBatch.End();
            }
        }

        // Player handling methods
        public void ShipCollision(ArrayList shots)
        {
            foreach (Spaceship heroe in Heroes)
            {
                foreach (AutoSprite shot in shots)
                {
                    heroe.Collision(shot.Pos);
                }
            }
        }
        void AddPlayer(ContentManager Content)
        {
            // Add new player to game
            if (firstPlayerActive)
            {
                Spaceship player2 = new Spaceship();
                player2.LoadContent(Content);
                player2.setKeys(Keys.W, Keys.S, Keys.A, Keys.D);
                player2.setShotKey(Keys.E);
                player2.setPos(new Vector2(50, 400));
                Heroes.Add(player2);
            }
            else
            {
                Spaceship player1 = new Spaceship();
                player1.LoadContent(Content);
                player1.setKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right);
                player1.setShotKey(Keys.Space);
                player1.setPos(new Vector2(50, 200));
                Heroes.Add(player1);
            }
        }

        public ArrayList getHeroes()
        {
            return Heroes;
        }
    }
}
