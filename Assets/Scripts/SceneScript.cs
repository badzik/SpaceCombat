using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets
{
    class SceneScript : MonoBehaviour
    {
        public Toggle SoundToggle;
        public void changeToScene(int sceneNumber)
        {
            muteAllSounds(SoundToggle.isOn);
            if (sceneNumber == 2) PlayerPrefs.SetInt("PreviousScene", 0);
            SceneManager.LoadScene(sceneNumber);    
        }

        public void muteAllSounds(bool istriggered)
        {
            if (!istriggered)
            {
                PlayerPrefs.SetInt("isMute?", 1);
                AudioListener.pause = true;
            }
            else
            {
                PlayerPrefs.SetInt("isMute?", 0);
            }
        }
    }
}
