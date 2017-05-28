using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets
{
    class SceneScript : MonoBehaviour
    {
        public void changeToScene(int sceneNumber)
        {
            SceneManager.LoadScene(sceneNumber);    
        }

        public void muteAllSounds(bool istriggered)
        {
            if (!istriggered)
            {
               AudioListener.pause = true;
            }
        }
    }
}
