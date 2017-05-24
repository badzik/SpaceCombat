using UnityEngine;
using System.Collections;
using Assets;

public class BridgeScript : MonoBehaviour
{

    public static bool bridgeDestroyed;

    // Use this for initialization
    void Start()
    {
        bridgeDestroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Missile")
        {
            bridgeDestroyed = true;
            gameObject.SetActive(false);
            GameObject bigExplosion = GameObject.Instantiate(Resources.Load("Prefabs/BridgeExplosionPrefab", typeof(GameObject))) as GameObject;
            bigExplosion.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            Destroy(bigExplosion, 2);
            MainScript.Player.Points += 500;
            GameObject.Find("BGLooper").GetComponent<GroundLooperScript>().NextLevel();
        }
    }
}
