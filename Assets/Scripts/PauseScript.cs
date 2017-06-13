using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {
    public GameObject PauseBackground;
    public GameObject PauseMenu;
    public GameObject PauseButton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPausePressed()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        PauseBackground.SetActive(true);
        PauseMenu.SetActive(true);
        PauseButton.SetActive(false);
    }

    public void OnResumePressed()
    {
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("isMute?") == 0) AudioListener.pause = false;
        PauseBackground.SetActive(false);
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
    }

    public void OnExitPressed()
    {
        PlayerPrefs.DeleteKey("Lives");
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Level");
        MainScript.saveData();
        Container.i.SavedLevel = 1;
        SceneManager.LoadScene(0);
    }
}
