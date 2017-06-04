using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class Player
    {
        private Rigidbody2D playerBody;
        private float fuelLevel;
        private int lives;
        private float defaultSpeed;
        private float actualSpeed;
        private bool destroyed;
        private int points;
        private int level;
        private int choosenMissile;
        private float maxHealth;
        private float currentHealth;
        private int crystalPoints;

        private int normalMissileLvl;
        private int laserMissileLvl;
        private int rocketMissileLvl;
        private int armorLvl;

        public Player(Rigidbody2D playerBody,float maxHealth,int normalMLvl, int laserLvl, int rocketLvl, int armorLvl)
        {
            this.playerBody = playerBody;
            fuelLevel = 100;
            lives = 3;
            defaultSpeed = 0.04f;
            actualSpeed = defaultSpeed;
            destroyed = false;
            points = 0;
            crystalPoints = 0;
            level = 1;
            choosenMissile = 0;
            this.maxHealth = maxHealth;
            currentHealth = maxHealth;
            this.normalMissileLvl = normalMLvl;
            this.laserMissileLvl = laserLvl;
            this.rocketMissileLvl = rocketLvl;
            this.armorLvl = armorLvl;
        }

        internal void UpdateBoxCollider()
        {
            Vector3 actualSize;
            actualSize = PlayerBody.GetComponent<SpriteRenderer>().bounds.size;
            PlayerBody.GetComponent<BoxCollider2D>().size = new Vector2(actualSize.x,actualSize.y);
        }

        public Rigidbody2D PlayerBody {
            get
            {
                return playerBody;
            }
            private set
            {
                playerBody = value;
            }
        }
        public float FuelLevel {
            get
            {
                return fuelLevel;
            }
            set
            {
                fuelLevel = value;
            }
        }

        public int Lives
        {
            get
            {
                return lives;
            }
            set
            {
                lives = value;
            }
        }

        public float DefaultSpeed
        {
            get
            {
                return defaultSpeed;
            }
            set
            {
                defaultSpeed = value;
            }
        }

        public float ActualSpeed
        {
            get
            {
                return actualSpeed;
            }
            set
            {
                actualSpeed = value;
            }
        }

        public bool Destroyed
        {
            get { return destroyed; }
            set { destroyed = value; }
        }

        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
            }
        }


        public int CrystalPoints
        {
            get
            {
                return crystalPoints;
            }
            set
            {
                crystalPoints = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }

        public int ChoosenMissile
        {
            get
            {
                return choosenMissile;
            }
            set
            {
                if(value>=0 && value<3)
                {
                    choosenMissile = value;
                }else
                {
                    choosenMissile = 0;
                }
            }
        }

        public float MaxHealth
        {
            get
            {
                return maxHealth;
            }
            set
            {
                maxHealth = value;
            }
        }

        public float CurrentHealth
        {
            get
            {
                return currentHealth;
            }
            set
            {
                if (value > maxHealth)
                {
                    currentHealth = maxHealth;
                }else
                {
                    currentHealth = value;
                }
            }
        }

        public int NormalMissileLvl
        {
            get { return normalMissileLvl; }
            set { normalMissileLvl = value; }
        }

        public int LaserMissileLvl
        {
            get { return laserMissileLvl; }
            set { laserMissileLvl = value; }
        }

        public int RocketMissileLvl
        {
            get { return rocketMissileLvl; }
            set { rocketMissileLvl = value; }
        }

        public int ArmorLvl
        {
            get { return armorLvl; }
            set { armorLvl = value; }
        }

    }
}
