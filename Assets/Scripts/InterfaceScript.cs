
using UnityEngine;

namespace Assets.Scripts
{
    class InterfaceScript : MonoBehaviour
    {
        static float minX = -1.95f, maxX = 1.95f;
        private GameObject fuelIndicator;
        void Start()
        {
            fuelIndicator = GameObject.Find("FuelIndicator");
            adjustChoosenMissileBoxes(MainScript.Player.ChoosenMissile);
        }

        void FixedUpdate()
        {
            float resut = (MainScript.Player.FuelLevel * (maxX - minX)) / 100;
            fuelIndicator.transform.position = new Vector3(minX + resut, fuelIndicator.transform.position.y);
        }

        void Update()
        {
            int i = 0;
            while (i < Input.touchCount)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), -Vector2.up);
                    if (hit.collider != null)
                    {
                        if (hit.collider.tag == "NormalMissile")
                        {
                            MainScript.Player.ChoosenMissile = 0;
                            adjustChoosenMissileBoxes(0);
                        }
                        if (hit.collider.tag == "RocketMissile")
                        {
                            MainScript.Player.ChoosenMissile = 1;
                            adjustChoosenMissileBoxes(1);
                        }
                        if (hit.collider.tag == "LaserMissile")
                        {
                            MainScript.Player.ChoosenMissile = 2;
                            adjustChoosenMissileBoxes(2);
                        }
                    }
                }
                ++i;
            }
        }

        private void adjustChoosenMissileBoxes(int weapon)
        {
            GameObject normalBox = GameObject.FindGameObjectWithTag("NormalMissile");
            GameObject rocketBox = GameObject.FindGameObjectWithTag("RocketMissile");
            GameObject laserBox = GameObject.FindGameObjectWithTag("LaserMissile");

            normalBox.GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/WeaponSelect/normalMissileBox", typeof(Sprite)) as Sprite;
            rocketBox.GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/WeaponSelect/rocketMissileBox", typeof(Sprite)) as Sprite;
            laserBox.GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/WeaponSelect/laserMissileBox", typeof(Sprite)) as Sprite;

            switch(weapon)
            {
                case (0):
                    {
                        normalBox.GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/WeaponSelect/normalMissileChoosen", typeof(Sprite)) as Sprite;
                        break;
                    }
                case (1):
                    {
                        rocketBox.GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/WeaponSelect/rocketMissileChoosen", typeof(Sprite)) as Sprite;
                        break;
                    }
                case (2):
                    {
                        laserBox.GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/WeaponSelect/laserMissileChoosen", typeof(Sprite)) as Sprite;
                        break;
                    }
            }

        }
    }
}
