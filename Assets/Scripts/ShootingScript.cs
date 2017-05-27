using UnityEngine;
using System.Collections;
using Assets;

public class ShootingScript : MonoBehaviour
{

    private int shootCooldown;
    private Rect topLeft;
    private Rect topRight;
    private Rect bottomRight;
    private GameObject normalSound;
    private GameObject rocketSound;
    private GameObject laserSound;

    // Use this for initialization
    void Start()
    {
        shootCooldown = 0;
        normalSound = GameObject.Instantiate(Resources.Load("Prefabs/NormalMissileSoundPrefab", typeof(GameObject))) as GameObject;
        rocketSound= GameObject.Instantiate(Resources.Load("Prefabs/NormalMissileSoundPrefab", typeof(GameObject))) as GameObject;
        laserSound = GameObject.Instantiate(Resources.Load("Prefabs/NormalMissileSoundPrefab", typeof(GameObject))) as GameObject;
        topLeft = new Rect(0, Screen.height / 2, Screen.width / 2, Screen.height / 2);
        topRight = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height / 2);
        bottomRight = new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetButtonDown("Fire1") && shootCooldown <= 0) //for keyboard shooting
        if (Input.touchCount > 0 && shootCooldown <= 0 && !MainScript.Player.Destroyed /*&& !MainScript.start*/)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                var touchPos = Input.GetTouch(i).position;
                if (Input.GetTouch(i).phase == TouchPhase.Began && (topLeft.Contains(touchPos) || topRight.Contains(touchPos) || bottomRight.Contains(touchPos)))
                {
                    switch(MainScript.Player.ChoosenMissile)
                    {
                        case (0):
                            {
                                NormalMissile nm = new NormalMissile(100);
                                shootCooldown = nm.CoolDown;
                                normalSound.GetComponent<AudioSource>().Play();
                                break;
                            }
                        case (1):
                            {
                                //need to add rocket missile prefab first
                                break;
                            }
                        case (2):
                            {
                                LaserMissile lm = new LaserMissile(130);
                                shootCooldown = lm.CoolDown;
                                laserSound.GetComponent<AudioSource>().Play();
                                break;
                            }
                    }

                }
            }
        }
    }

    void FixedUpdate()
    {
        if (shootCooldown >= 0) shootCooldown--;
    }
}
