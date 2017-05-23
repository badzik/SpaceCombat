﻿using UnityEngine;
using System.Collections;
using Assets;

public class EnemyScript : MonoBehaviour
{

    int probability;
    // Use this for initialization
    void Start()
    {
        probability = Random.Range(1 + MainScript.Player.Level, 100 + MainScript.Player.Level);
        if (gameObject.name == "TankPrefab(Clone)")
        {
            gameObject.GetComponent<Animator>().speed = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        var enemy = MainScript.enemies.Find(x => x.GameObject == gameObject);
        if (gameObject.name == "TankPrefab(Clone)" && gameObject.GetComponent<Rigidbody2D>().velocity != new Vector2(0,0))
        {
            enemy.GameObject.GetComponent<Animator>().speed = 1;
        }
        if (((Camera.main.transform.position.y + (Camera.main.orthographicSize) / 1.5) > gameObject.transform.position.y) && probability >= 50) //&& MainScript.Player.Level != 1
        {
            if (gameObject.name == "SpacePlanePrefab(Clone)")
            {
                int rotation = (enemy.Speed > 0) ? 180 : 360;
                gameObject.transform.localRotation = Quaternion.Euler(0, rotation, 0);
            }
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(enemy.Speed * MainScript.Player.DefaultSpeed, 0);
        }
        if ((Camera.main.transform.position.y - Camera.main.orthographicSize) > gameObject.transform.position.y)
        {
            MainScript.enemies.Remove(MainScript.enemies.Find(x => x.GameObject.Equals(gameObject)));
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if ((collider.tag == "Terrain" || collider.tag == "Finish") && gameObject.name != "SpacePlanePrefab(Clone)")
        {
            int rotation = 180;
            var enemySpeed = MainScript.enemies.Find(x => x.GameObject.Equals(gameObject)).Speed *= -1;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(enemySpeed * MainScript.Player.DefaultSpeed, 0);
            if (enemySpeed < 0 && gameObject.name == "TankPrefab(Clone)")
            {
                rotation += rotation;

            }
            if (enemySpeed > 0 && gameObject.name == "RedEnemyPrefab(Clone)")
            {
                rotation += rotation;

            }
            if (enemySpeed > 0 && gameObject.name == "RedEnemyrPrefab(Clone)")
            {
                rotation += rotation;
            }
            gameObject.transform.localRotation = Quaternion.Euler(0, rotation, 0);
        }

        if (collider.tag == "Missile" || collider.tag == "Player")
        {
            Enemy enemy = MainScript.enemies.Find(x => x.GameObject.Equals(gameObject));
            if (collider.tag == "Player")
            {
                enemy.Health = 0f;
            }
            else
            {
                Missile missile;
                missile = MainScript.missiles.Find(x => x.GameObject.GetComponent<Collider2D>().Equals(collider));
                float damage = missile.Damage;
                enemy.Health -= damage;
                MissileScript.CheckTypeOfMissile(ref missile);
            }
            if (enemy.Health <= 0)
            {
                MainScript.KillEnemy(enemy);
            }
        }
    }
}
