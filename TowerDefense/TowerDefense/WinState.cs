using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    class WinState : GameObjectList
    {
        SpriteGameObject background = new SpriteGameObject("spr_win");
        public WinState()
        {
            this.Add(background);
        }
    }
}
