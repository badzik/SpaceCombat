using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    class Tank : Enemy
    {
        public static int Propability = 35;
        public static int score = 30;
        public Tank(float health,float posx,float posy,int speed)
        {
            this.Health = health;
            this.GameObject= GameObject.Instantiate(Resources.Load("Prefabs/TankPrefab", typeof(GameObject))) as GameObject;
            this.GameObject.transform.position = new Vector2(posx, posy);
            this.IsFlyingOver = false;
            this.Speed = speed;
            base.Score = score;
            MainScript.enemies.Add(this);
        }
    }
}
