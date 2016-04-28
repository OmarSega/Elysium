using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elysium
{
    class PowerUp : AutoSprite
    {
        // Atributes
        int lifeUp; // Health given to a spaceship

        // Properties
        public int LifeIncrement
        {
            get { return lifeUp; }
        }

        // Constructor
        public PowerUp(int lives) : base("")
        {
            // Choose the texture according to how many lives it'll regenerate
            switch (lives)
            {
                case 1:
                    Init("Heart_1.png");
                    break;
                case 2:
                    Init("Heart_2.png");
                    break;
                case 3:
                    Init("Heart_3.png");
                    break;
                case 4:
                    Init("Heart_4.png");
                    break;
                case 5:
                    Init("Heart_5.png");
                    break;
                default:
                    Init("Heart_1.png");
                    break;
            }

            // Movement configuration
            incX = -1;
            incY = 0;
            lifeUp = lives;
        }
    }
}
