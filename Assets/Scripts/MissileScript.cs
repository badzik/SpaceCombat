using UnityEngine;
using System.Collections;
using Assets;

public class MissileScript : MonoBehaviour
{

    bool seen = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Renderer>().isVisible)
            seen = true;

        if (seen && !GetComponent<Renderer>().isVisible)
        {
            MainScript.missiles.Remove(MainScript.missiles.Find(x => x.GameObject.Equals(gameObject)));
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if ((collider.tag == "Terrain" || collider.tag == "Finish" ))
        {
            if (gameObject.name == "RocketMissilePrefab(Clone)" || gameObject.name =="RocketExplosionPrefab(Clone)")
            {
                var missile = MainScript.missiles.Find(x => x.GameObject == gameObject);
                CheckTypeOfMissile(ref missile);
            }
            else
            {
                MainScript.missiles.Remove(MainScript.missiles.Find(x => x.GameObject.Equals(gameObject)));
                Destroy(gameObject);
            }

        }
    }
    public static void CheckTypeOfMissile(ref Missile missilie)
    {
        if (missilie.GameObject.name == "NormalMissilePrefab(Clone)")
        {
            MainScript.missiles.Remove(missilie);
            Destroy(missilie.GameObject);
        }
        if (missilie.GameObject.name == "LaserMissilePrefab(Clone)")
        {
            //probably lasser don't get more options but...
        }
        if (missilie.GameObject.name == "RocketMissilePrefab(Clone)")
        {
            RocketExplosion re = new RocketExplosion(250);
            re.GameObject.transform.position = new Vector2(missilie.GameObject.transform.position.x, missilie.GameObject.transform.position.y);
            MainScript.missiles.Remove(missilie);
            Destroy(missilie.GameObject);
        }
        if (missilie.GameObject.name == "RocketExplosionPrefab(Clone)")
        {
            Destroy(missilie.GameObject, 2.5f);
            MainScript.missiles.Remove(missilie);
        }
    }
}
