using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    class RocketExplosion : Missile
    {
        public RocketExplosion(float damage)
        {
            this.CoolDown = 0;
            this.Damage = damage;
            this.GameObject = GameObject.Instantiate(Resources.Load("Prefabs/RocketExplosionPrefab", typeof(GameObject))) as GameObject;
            this.GameObject.AddComponent<MissileScript>();
            MainScript.missiles.Add(this);
        }
    }
}
