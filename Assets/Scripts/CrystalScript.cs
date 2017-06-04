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
                crystalSound.GetComponent<AudioSource>().Play();
                GameObject crystalPoints = GameObject.Instantiate(Resources.Load("Prefabs/CristalPointsCanvasPrefab", typeof(GameObject))) as GameObject;
                crystalPoints.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                Destroy(gameObject);
                Destroy(crystalPoints, 2);
            }
            if (collider.tag == "Terrain")
            {
                Destroy(gameObject);
            }
        }
    }
}
