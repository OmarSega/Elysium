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
            InitStand(SideDirection.STAND_LEFT, "sShip_Heroe.png");
            InitStand(SideDirection.STAND_RIGHT, "sShip_Heroe.png");
            InitStand(SideDirection.STAND_UP, "sShip_Heroe.png");
            InitStand(SideDirection.STAND_DOWN, "sShip_Heroe.png");

            InitMove(SideDirection.RUN_LEFT, "sShip_Heroe.png", 1, 0, 1, 80, 77);
            InitMove(SideDirection.RUN_LEFT, "sShip_Heroe.png", 1, 0, 1, 80, 77);
            InitMove(SideDirection.RUN_RIGHT, "sShip_Heroe.png", 1, 0, 1, 80, 77);
            InitMove(SideDirection.RUN_UP, "sShip_Heroe.png", 1, 0, 1, 80, 77);
            InitMove(SideDirection.RUN_DOWN, "sShip_Heroe.png", 1, 0, 1, 80, 77);

            // Configuration
            life = 2;
            incX = 4;
            incY = 4;
        }
    }
}
