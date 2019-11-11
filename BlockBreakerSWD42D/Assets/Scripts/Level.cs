using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; // storing the total amount of blocks in the scene
    SceneLoader sceneLoader; //sceneLoader is a copy/instance of the SceneLoader class

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++; // breakableBlocks = breakableBlocks + 1;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--; // breakableBlocks = breakableBlocks - 1;

        if (breakableBlocks <= 0)
        {
            //load the next scene
            sceneLoader.LoadNextScene();
        }
    }

}
