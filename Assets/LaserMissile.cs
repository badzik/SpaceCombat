﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    class LaserMissile : Missile
    {
        public LaserMissile(float damage)
        {
            this.CoolDown = 30;
            this.Damage = damage;
            this.GameObject = GameObject.Instantiate(Resources.Load("Prefabs/LaserMissilePrefab", typeof(GameObject))) as GameObject;
            this.GameObject.AddComponent<MissileScript>();
            this.GameObject.transform.position = new Vector2(MainScript.Player.PlayerBody.position.x, MainScript.Player.PlayerBody.position.y + MainScript.Player.PlayerBody.GetComponent<BoxCollider2D>().size.y);
            this.GameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1500 * MainScript.Player.DefaultSpeed);
            MainScript.missiles.Add(this);
        }
    }
}
