﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TowerDefense
{
    class PlayingState : GameObjectList
    {
        SpriteGameObject background;
        public SpriteGameObject homeBase;
        public GameObjectList ufos = new GameObjectList();
        List<Vector2> ufoPositions = new List<Vector2>();
        GameObjectList cannons = new GameObjectList();
        GameObjectList bullets = new GameObjectList();

        public PlayingState()
        {
            ufoPositions.Add(new Vector2(20, 20));
            ufoPositions.Add(new Vector2(-100, 600));
            ufoPositions.Add(new Vector2(-300, 300));
            ufoPositions.Add(new Vector2(800, -500));
            ufoPositions.Add(new Vector2(700, 1000));

            background = new SpriteGameObject("spr_background");
            this.Add(background);

            homeBase = new SpriteGameObject("spr_homebase");
            homeBase.Origin = homeBase.Sprite.Center;
            homeBase.Position = new Vector2(900, 340);
            this.Add(homeBase);

            for(int i = 0; i < 5; i++)
            {
                ufos.Add(new Ufo(ufoPositions.ElementAt(i), homeBase));
            }
            this.Add(ufos);
            this.Add(cannons);
            this.Add(bullets);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.MouseLeftButtonPressed())
            {
                cannons.Add(new AutoFireCannon(inputHelper.MousePosition));
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            for(int i = 0; i < cannons.Objects.Count; i++)
            {
                if ((cannons.Objects.ElementAt(i) as AutoFireCannon).hasFired)
                {
                    bullets.Add(new Bullet(
                        (cannons.Objects.ElementAt(i) as AutoFireCannon).Position,
                        (cannons.Objects.ElementAt(i) as AutoFireCannon).AngularDirection * 120)
                    );
                }
            }

            for(int i = 0; i < bullets.Objects.Count; i++)
            {
                for(int j = 0; j < ufos.Objects.Count; j++)
                {
                    if ((bullets.Objects.ElementAt(i) as Bullet).
                        CollidesWith((ufos.Objects.ElementAt(j) as Ufo)))
                    {
                        bullets.Objects.ElementAt(i).Visible = false;
                        ufos.Objects.ElementAt(j).Visible = false;
                    }
                }
            }

            if(ufos.Objects.All(c => (c.Visible == false)))
            {
                TowerDefense.GameStateManager.SwitchTo("winState");
            }
            if(ufos.Objects.Any(c => (c.Visible) && ((c as Ufo).CollidesWith(homeBase))))
            {
                TowerDefense.GameStateManager.SwitchTo("gameOverState");
            }

        }
    }
}
