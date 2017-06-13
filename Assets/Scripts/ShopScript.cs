using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{

    int armorLvl, normalMissileLvl, laserLvl, rocketLvl;
    int tempArmorLvl, tempNormalMissileLvl, tempLaserLvl, tempRocketLvl;
    int crystals, tempCrystals;
    int armorCost, normalMissileCost, laserMissileCost, rocketMissileCost;

    bool[][] activeKeys;
    // Use this for initialization
    void Start()
    {
        activeKeys = new bool[4][];
        for (int i = 0; i < 4; i++)
        {
            activeKeys[i] = new bool[2];
        }

        if (PlayerPrefs.HasKey("normalMissileLvl")) normalMissileLvl = PlayerPrefs.GetInt("normalMissileLvl");
        else normalMissileLvl = 1;
        if (PlayerPrefs.HasKey("laserMissileLvl")) laserLvl = PlayerPrefs.GetInt("laserMissileLvl");
        else laserLvl = 0;
        if (PlayerPrefs.HasKey("rocketMissileLvl")) rocketLvl = PlayerPrefs.GetInt("rocketMissileLvl");
        else rocketLvl = 0;
        if (PlayerPrefs.HasKey("armorLvl")) armorLvl = PlayerPrefs.GetInt("armorLvl");
        else armorLvl = 1;
        if (PlayerPrefs.HasKey("Crystal")) crystals = PlayerPrefs.GetInt("Crystal");
        else crystals = 0;

        tempArmorLvl = armorLvl;
        tempLaserLvl = laserLvl;
        tempNormalMissileLvl = normalMissileLvl;
        tempRocketLvl = rocketLvl;
        tempCrystals = crystals;

        refreshLvls();
        adjustCosts();
        adjustPlusesAndMinuses();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonPressed(string name)
    {
        if (name == "NormalMissilePlus" && activeKeys[0][1])
        {
            tempNormalMissileLvl += 1;
            tempCrystals -= normalMissileCost;
            refreshLvls();
            adjustCosts();
            adjustPlusesAndMinuses();
        }
        if (name == "NormalMissileMinus" && activeKeys[0][0])
        {
            tempCrystals += calcNormalMissileCost(tempNormalMissileLvl);
            tempNormalMissileLvl -= 1;
            refreshLvls();
            adjustCosts();
            adjustPlusesAndMinuses();
        }


        if (name == "LaserMissilePlus" && activeKeys[1][1])
        {
            tempLaserLvl += 1;
            tempCrystals -= laserMissileCost;
            refreshLvls();
            adjustCosts();
            adjustPlusesAndMinuses();
        }
        if (name == "LaserMissileMinus" && activeKeys[1][0])
        {
            tempCrystals += calcLaserMissileCost(tempLaserLvl);
            tempLaserLvl -= 1;
            refreshLvls();
            adjustCosts();
            adjustPlusesAndMinuses();
        }


        if (name == "RocketMissilePlus" && activeKeys[2][1])
        {
            tempRocketLvl += 1;
            tempCrystals -= rocketMissileCost;
            refreshLvls();
            adjustCosts();
            adjustPlusesAndMinuses();
        }
        if (name == "RocketMissileMinus" && activeKeys[2][0])
        {
            tempCrystals += calcRocketMissileCost(tempRocketLvl);
            tempRocketLvl -= 1;
            refreshLvls();
            adjustCosts();
            adjustPlusesAndMinuses();
        }


        if (name == "ArmorPlus" && activeKeys[3][1])
        {
            tempArmorLvl += 1;
            tempCrystals -= armorCost;
            refreshLvls();
            adjustCosts();
            adjustPlusesAndMinuses();
        }
        if (name == "ArmorMinus" && activeKeys[3][0])
        {
            tempCrystals += calcArmorCost(tempArmorLvl);
            tempArmorLvl -= 1;
            refreshLvls();
            adjustCosts();
            adjustPlusesAndMinuses();
        }
    }

    public void Exit()
    {
        if (PlayerPrefs.HasKey("PreviousScene"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("PreviousScene"));
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Accept()
    {
        PlayerPrefs.SetInt("Crystal", tempCrystals);
        PlayerPrefs.SetInt("normalMissileLvl", tempNormalMissileLvl);
        PlayerPrefs.SetInt("laserMissileLvl", tempLaserLvl);
        PlayerPrefs.SetInt("rocketMissileLvl", tempRocketLvl);
        PlayerPrefs.SetInt("armorLvl", tempArmorLvl);

        if (PlayerPrefs.HasKey("PreviousScene"))
        {

            SceneManager.LoadScene(PlayerPrefs.GetInt("PreviousScene"));

        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void WatchAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("", new ShowOptions() { resultCallback = handleAdResult });
        }
    }

    private void handleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                {
                    crystals += 200;
                    tempCrystals = crystals;
                    break;
                }
            case ShowResult.Skipped:
                {
                    crystals += 100;
                    tempCrystals = crystals;
                    break;
                }
        }
        refreshLvls();
        adjustCosts();
        adjustPlusesAndMinuses();
    }

    private void refreshLvls()
    {
        GameObject.Find("NormalMissileLvl").GetComponent<Text>().text = tempNormalMissileLvl.ToString();
        GameObject.Find("LaserMissileLvl").GetComponent<Text>().text = tempLaserLvl.ToString();
        GameObject.Find("RocketMissileLvl").GetComponent<Text>().text = tempRocketLvl.ToString();
        GameObject.Find("ArmorLvl").GetComponent<Text>().text = tempArmorLvl.ToString();
        GameObject.Find("Crystals").GetComponent<Text>().text = tempCrystals.ToString();
    }

    private void adjustCosts()
    {
        armorCost = calcNormalMissileCost(tempArmorLvl + 1);
        normalMissileCost = calcNormalMissileCost(tempNormalMissileLvl + 1);
        laserMissileCost = calcLaserMissileCost(tempLaserLvl + 1);
        rocketMissileCost = calcRocketMissileCost(tempRocketLvl + 1);
        GameObject.Find("NormalMissileCost").GetComponent<Text>().text = "Cost: " + normalMissileCost;
        GameObject.Find("LaserMissileCost").GetComponent<Text>().text = "Cost: " + laserMissileCost;
        GameObject.Find("RocketMissileCost").GetComponent<Text>().text = "Cost: " + rocketMissileCost;
        GameObject.Find("ArmorCost").GetComponent<Text>().text = "Cost: " + armorCost;
    }

    private void adjustPlusesAndMinuses()
    {
        //NormalMissile
        if (tempNormalMissileLvl > normalMissileLvl)
        {
            GameObject.Find("NormalMissileMinus").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/Shop/minus");
            activeKeys[0][0] = true;
        }
        else
        {
            GameObject.Find("NormalMissileMinus").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/Shop/bwMinus");
            activeKeys[0][0] = false;
        }
        if (tempCrystals >= normalMissileCost)
        {
            GameObject.Find("NormalMissilePlus").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/Shop/plus");
            activeKeys[0][1] = true;
        }
        else
        {
            GameObject.Find("NormalMissilePlus").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/Shop/bwPlus");
            activeKeys[0][1] = false;
        }

        //Laser
        if (tempLaserLvl > laserLvl)
        {
            GameObject.Find("LaserMissileMinus").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/Shop/minus");
            activeKeys[1][0] = true;
        }
        else
        {
            GameObject.Find("LaserMissileMinus").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/Shop/bwMinus");
            activeKeys[1][0] = false;
        }
        if (tempCrystals >= laserMissileCost)
        {
            GameObject.Find("LaserMissilePlus").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/Shop/plus");
            activeKeys[1][1] = true;
        }
        else
        {
            GameObject.Find("LaserMissilePlus").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/Shop/bwPlus");
            activeKeys[1][1] = false;
        }

        //Rocket
        if (tempRocketLvl > rocketLvl)
        {
            GameObject.Find("RocketMissileMinus").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/Shop/minus");
            activeKeys[2][0] = true;
        }
        else
        {
            GameObject.Find("RocketMissileMinus").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/Shop/bwMinus");
            activeKeys[2][0] = false;
        }
        if (tempCrystals >= rocketMissileCost)
        {
            GameObject.Find("RocketMissilePlus").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/Shop/plus");
            activeKeys[2][1] = true;
        }
        else
        {
            GameObject.Find("RocketMissilePlus").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/Shop/bwPlus");
            activeKeys[2][1] = false;
        }

        //Armor
        if (tempArmorLvl > armorLvl)
        {
            GameObject.Find("ArmorMinus").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/Shop/minus");
            activeKeys[3][0] = true;
        }
        else
        {
            GameObject.Find("ArmorMinus").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/Shop/bwMinus");
            activeKeys[3][0] = false;
        }
        if (tempCrystals >= armorCost)
        {
            GameObject.Find("ArmorPlus").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/Shop/plus");
            activeKeys[3][1] = true;
        }
        else
        {
            GameObject.Find("ArmorPlus").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Sprites/Shop/bwPlus");
            activeKeys[3][1] = false;
        }
    }

    private int calcNormalMissileCost(int lvl)
    {
        return 100 * lvl;
    }

    private int calcLaserMissileCost(int lvl)
    {
        return 100 * lvl;
    }

    private int calcRocketMissileCost(int lvl)
    {
        return 100 * lvl;
    }

    private int calcArmorCost(int lvl)
    {
        return 100 * lvl;
    }

}
