using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    class GameOverState : GameObjectList
    {
        SpriteGameObject background = new SpriteGameObject("spr_gameover");
        public GameOverState()
        {
            this.Add(background);
        }
    }
}
