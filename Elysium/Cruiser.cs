using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elysium
{
    class Cruiser : AutoCharacter
    {
        // Attributes
        int life;

        // Constructor
        public Cruiser()
        {
            //
            // Initialize content for character in all its states.
            InitStand(SideDirection.STAND_LEFT, "Ship2_Enemigo.png");
            InitStand(SideDirection.STAND_RIGHT, "Ship2_Enemigo.png");
            InitStand(SideDirection.STAND_UP, "Ship2_Enemigo.png");
            InitStand(SideDirection.STAND_DOWN, "Ship2_Enemigo.png");

            InitMove(SideDirection.RUN_LEFT, "Ship2_Enemigo", 1, 0, 1, 80, 77);
            InitMove(SideDirection.RUN_LEFT, "Ship2_Enemigo", 1, 0, 1, 80, 77);
            InitMove(SideDirection.RUN_RIGHT, "Ship2_Enemigo", 1, 0, 1, 80, 77);
            InitMove(SideDirection.RUN_UP, "Ship2_Enemigo", 1, 0, 1, 80, 77);
            InitMove(SideDirection.RUN_DOWN, "Ship2_Enemigo", 1, 0, 1, 80, 77);

            // Configuration
            life = 2;
            incX = 4;
            incY = 4;
        }
    }
}
