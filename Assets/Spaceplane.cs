﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    class SpacePlane : Enemy
    {
        public static int Propability =10;
        public static int score = 100;
        public SpacePlane(float health, float posx, float posy,int speed)
        {
            this.Health = health;
            this.Speed = speed;
            this.GameObject = GameObject.Instantiate(Resources.Load("Prefabs/SpacePlanePrefab", typeof(GameObject))) as GameObject;
            this.GameObject.transform.position = new Vector2(posx, posy);
            this.IsFlyingOver = true;
            base.Score = score;
            MainScript.enemies.Add(this);
        }
    }
}
