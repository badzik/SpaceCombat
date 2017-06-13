using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class CrystalScript : MonoBehaviour
    {
        private GameObject crystalSound;
        void Start()
        {
            crystalSound = GameObject.Instantiate(Resources.Load("Prefabs/CrystalSoundPrefab", typeof(GameObject))) as GameObject;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.tag == "Player")
            {
                MainScript.Player.CrystalPoints += 50;
                MainScript.Player.Points += 50;
                crystalSound.GetComponent<AudioSource>().Play();
                GameObject crystalPoints = GameObject.Instantiate(Resources.Load("Prefabs/CristalPointsCanvasPrefab", typeof(GameObject))) as GameObject;
                GameObject particles = GameObject.Instantiate(Resources.Load("Prefabs/CollectParitcles", typeof(GameObject))) as GameObject;
                crystalPoints.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                particles.transform.position= new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                MainScript.crystals.Remove(MainScript.crystals.Find(x => x.GameObject.Equals(gameObject)));
                Destroy(gameObject);
                Destroy(crystalPoints, 2);
                Destroy(particles, 3);
            }
            if (collider.tag == "Terrain")
            {
                Destroy(gameObject);
            }
        }
    }
}
