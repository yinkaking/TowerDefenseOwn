using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TowerDefense
{
    class PlayingState : GameObjectList
    {
        SpriteGameObject background;
        SpriteGameObject homeBase;

        public PlayingState()
        {
            background = new SpriteGameObject("spr_background");
            this.Add(background);

            homeBase = new SpriteGameObject("spr_homebase");
            homeBase.Origin = homeBase.Sprite.Center;
            homeBase.Position = new Vector2(900, 340);
            this.Add(homeBase);
        }
    }
}
