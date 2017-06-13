using UnityEngine;
using System.Collections;
using Assets;
using UnityEngine.SceneManagement;

public class CameraMover : MonoBehaviour
{
   float actualSpeed;
    // Use this for initialization
    void Start()
    {
        actualSpeed = MainScript.Player.ActualSpeed;
        if (MainScript.Player.Level == 1)
        {
            PlayerPrefs.SetInt("lastLevel", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MainScript.Player.Level % 4 != 0 || PlayerPrefs.GetInt("lastLevel") == MainScript.Player.Level)
        {
            Vector3 pos = transform.position;
            pos.y = MainScript.Player.PlayerBody.transform.position.y + 0.3f;
            transform.position = pos;
            actualSpeed = MainScript.Player.ActualSpeed;

        }
        else
        {
            var actualSpeed = MainScript.Player.ActualSpeed;
            MainScript.Player.ActualSpeed = actualSpeed + 0.02f;
            var player = GameObject.Find("Player");
            if (Mathf.Abs(player.transform.position.y)> Mathf.Abs(transform.position.y + Camera.main.orthographicSize))
            {
                MainScript.Player.ActualSpeed = 0;
                PlayerPrefs.SetInt("Score", MainScript.Player.Points);
                PlayerPrefs.SetInt("Lives", MainScript.Player.Lives);
                PlayerPrefs.SetInt("Level", MainScript.Player.Level);
                PlayerPrefs.SetInt("lastLevel", MainScript.Player.Level);
                PlayerPrefs.SetInt("PreviousScene", 1);
                SceneManager.LoadScene(2);
            }
        } 

    }

}
