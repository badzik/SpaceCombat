using UnityEngine;
using System.Collections;
using Assets;

public class ShootingScript : MonoBehaviour
{

    private int shootCooldown;

    private GameObject normalSound;
    private GameObject rocketSound;
    private GameObject laserSound;

    // Use this for initialization
    void Start()
    {
        shootCooldown = 0;
        normalSound = GameObject.Instantiate(Resources.Load("Prefabs/NormalMissileSoundPrefab", typeof(GameObject))) as GameObject;
        rocketSound= GameObject.Instantiate(Resources.Load("Prefabs/RocketMissileSoundPrefab", typeof(GameObject))) as GameObject;
        laserSound = GameObject.Instantiate(Resources.Load("Prefabs/LaserMissileSoundPrefab", typeof(GameObject))) as GameObject;
        if (MainScript.Player.RocketMissileLvl == 0) GameObject.Find("RocketShoot").SetActive(false);
        if (MainScript.Player.LaserMissileLvl == 0) GameObject.Find("LaserShoot").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void ShootingHandler(int w)
    {
        if(shootCooldown <= 0)
        {
            switch (w)
            {
                case (0):
                    {
                        NormalMissile nm = new NormalMissile(50+(MainScript.Player.NormalMissileLvl*10));
                        shootCooldown = nm.CoolDown;
                        normalSound.GetComponent<AudioSource>().Play();
                        break;
                    }
                case (1):
                    {
                        RocketMissile rm = new RocketMissile(150 + (MainScript.Player.RocketMissileLvl * 10));
                        shootCooldown = rm.CoolDown;
                        rocketSound.GetComponent<AudioSource>().Play();
                        break;
                    }
                case (2):
                    {
                        LaserMissile lm = new LaserMissile(100 + (MainScript.Player.LaserMissileLvl * 10));
                        shootCooldown = lm.CoolDown;
                        laserSound.GetComponent<AudioSource>().Play();
                        break;
                    }
            }
        }
    }

    void FixedUpdate()
    {
        if (shootCooldown >= 0) shootCooldown--;
    }
}
