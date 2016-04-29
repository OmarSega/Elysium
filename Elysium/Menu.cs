using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Elysium
{

    /// <summary>
    /// Menu that awaits user input to start the game. Contains two buttons
    /// Play and Exit.
    /// </summary>
    class Menu
    {
        // Attributes
        BasicSprite Start;          // Start button, will redirect the user to Level 1
        BasicSprite Start_hover;    // Start button's hover state
        BasicSprite Exit;           // Will end the game
        BasicSprite Exit_hover;     // Exit button's hover state
        BasicSprite background;     // Logo and background
        bool isMouseOverStart;      // Hover state flag for start button
        bool isMouseOverExit;       // Hover state flag for exit button
        Rectangle areaStart;        // Area on which the button will switch to hover state
        Rectangle areaExit;

        // Constructor
        public Menu()
        {
            // Initialize buttons
            Start = new BasicSprite();
            Start_hover = new BasicSprite();
            Exit = new BasicSprite();
            Exit_hover = new BasicSprite();
            background = new BasicSprite();

            Start.Init("Menu_textures/Start");
            Start_hover.Init("Menu_textures/Start_Over");
            Exit.Init("Menu_textures/Quit");
            Exit_hover.Init("Menu_textures/Quit_Over");
            background.Init("Menu_textures/Menu_background");
        }

        // Methods
        public void LoadContent(ContentManager Content)
        {
            // Load content for buttons
            Start.LoadContent(Content);
            Start_hover.LoadContent(Content);
            Exit.LoadContent(Content);
            Exit_hover.LoadContent(Content);
            background.LoadContent(Content);

            // Configure buttons
            Start.setPos(300, 300);
            Start_hover.setPos(300, 300);
            Exit.setPos(575, 300);
            Exit_hover.setPos(575, 300);
            background.setPos(0, 0);

            Start.setSize(150, 150);
            Start_hover.setSize(150, 150);
            Exit.setSize(150, 150);
            Exit_hover.setSize(150, 150);
            background.setSize(1028, 578);

            // Define area where where buttons will be marked as active
            areaStart = Start.Pos;
            areaExit = Exit.Pos;
        }
        public SceneManagement Update()
        {
            //  Get the position of the mouse, switch the state of a button
            //  if necessary and select appropiate return value.

            if (areaStart.Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {
                isMouseOverStart = true;
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    return SceneManagement.LEVEL_1;

            }
            else
                isMouseOverStart = false;

            if (areaExit.Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {
                isMouseOverExit = true;
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    return SceneManagement.EXIT;
            }
            else
                isMouseOverExit = false;

            return SceneManagement.MENU;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            // Draw all elements
            background.Draw(spritebatch);

            // Draw correct button state based on the position of the mouse
            // relative to the control area.
            if (isMouseOverStart)
                Start_hover.Draw(spritebatch);
            else
                Start.Draw(spritebatch);

            if (isMouseOverExit)
                Exit_hover.Draw(spritebatch);
            else
                Exit.Draw(spritebatch);
        }
    }
}