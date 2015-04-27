﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceImpact.GameEngine.BaseGameElements;

namespace SpaceImpact.GameEngine
{
    public class Enemy: GameObject, IMotion
    {
        public List<Laser> _lasers = new List<Laser>();

        public Enemy(int x, int y, int life) : base(x, y, life) { }

        public void Motion(int dx, int dy)
        {
            if (this.CanMotion(dx, dy) == false)
            {
                throw new ArgumentException("Enemy cannot be moved to the specified positon");
            }

            this.X += dx;
            this.Y += dy;
        }

        public bool CanMotion(int dx, int dy)
        {
            int newX = this.X + dx;
            int newY = this.Y + dy;
            if (this.BattleSpace != null)
            {
                return this.BattleSpace.CanLocated(this, newX, newY);
            }
            else
            {
                return false;
            }
        }

        public new int IsAlive()
        {
            return (this.Life > 0 ? 1 : 0);
        }

        //public void EnemyShoot(Enemy enemy)
        //{
        //    var laser = new Laser(enemy.X + 1, enemy.Y, 1);
        //    this.BattleSpace.AddGameObject(laser);
        //    _lasers.Add(laser);
        //}
    }
}
