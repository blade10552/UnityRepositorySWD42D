using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        /* To load the next scene we need to know the current scene index (order)
         * GetActiveScene method returns the whole scene object with all of its properties (information 
         * about the scene). Though, we only need the current index/order so we called only the buildIndex
         * from the scene.
         */

        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
