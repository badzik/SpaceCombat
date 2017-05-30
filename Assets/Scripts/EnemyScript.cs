using UnityEngine;
using System.Collections;
using Assets;

public class EnemyScript : MonoBehaviour
{
    private SpriteRenderer myRenderer;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;
    private const int whiteTime = 5;
    private int whiteCounter;
    private bool isWhite;
    private GameObject playerHit;

    int probability;
    // Use this for initialization
    void Start()
    {
        playerHit = GameObject.Instantiate(Resources.Load("Prefabs/PlayerHitSoundPrefab", typeof(GameObject))) as GameObject;
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default");
        isWhite = false;
        whiteCounter = 0;

        probability = Random.Range(1 + MainScript.Player.Level, 100 + MainScript.Player.Level);
        if (gameObject.name == "TankPrefab(Clone)")
        {
            gameObject.GetComponent<Animator>().speed = 0;
        }
    }

    void FixedUpdate()
    {
        if (isWhite)
        {
            whiteCounter++;
            if (whiteCounter >= whiteTime)
            {
                normalSprite();
                isWhite = false;
                whiteCounter = 0;
            }
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
            if (enemySpeed > 0 && gameObject.name == "RedEnemyPrefab(Clone)")
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
                if(MainScript.Player.CurrentHealth >= 1)
                {
                    playerHit.GetComponent<AudioSource>().Play();
                }
                enemy.Health = 0f;
            }
            else
            {
                Missile missile;
                missile = MainScript.missiles.Find(x => x.GameObject.GetComponent<Collider2D>().Equals(collider));
                float damage = missile.Damage;
                enemy.Health -= damage;
                MissileScript.CheckTypeOfMissile(ref missile);
                whiteSprite();
                isWhite = true;
            }
            if (enemy.Health <= 0)
            {
                MainScript.KillEnemy(enemy);
            }
        }
    }


    void whiteSprite()
    {
        myRenderer.material.shader = shaderGUItext;
        myRenderer.color = Color.white;
    }

    void normalSprite()
    {
        myRenderer.material.shader = shaderSpritesDefault;
        myRenderer.color = Color.white;
    }
}
