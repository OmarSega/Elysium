// Title: AnimatedCharacter
// Descripcition:
//   Provides the base functionality for an animated character, in conjunc-
//   tion with the BasicSprite and BasicAnimatedSprite class forms a layered
//   sprite capable of displaying both static and animated states.
//   
//   It is assumed all sprites have the same dimensions and position, most 
//   attributes and functionality are determined by the leftmost BasicSprite.
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elysium
{
    // Animation states
    enum SideDirection
    {
        STAND_LEFT, STAND_RIGHT, STAND_UP, STAND_DOWN,
        RUN_LEFT, RUN_RIGHT, RUN_UP, RUN_DOWN, AGONY
    };
    class AnimatedCharacter
    {
    }
}
