using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class Crystal
    {
        private GameObject gameObject;
        public static int Propability = 15;
        public Crystal(float x, float y)
        {
            this.GameObject = GameObject.Instantiate(Resources.Load("Prefabs/CrystalPrefab", typeof(GameObject))) as GameObject;
            this.GameObject.transform.position = new Vector2(x, y);
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -20 * MainScript.Player.DefaultSpeed);
            MainScript.crystals.Add(this);
        }

        public GameObject GameObject
        {
            get { return gameObject; }
            set { gameObject = value; }
        }
    }
}
