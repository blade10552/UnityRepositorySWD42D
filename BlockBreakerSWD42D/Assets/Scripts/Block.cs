using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    Level level; // level is a copy/instance of the Level class (we need to use it to access its elements
    // e.g. variables and methods)

    void Start()
    {
        level = FindObjectOfType<Level>();
        /* The FindObjectOfType method looks for an object in the hierarchy containing the script 
         * having the same name as the class written in between <>
         */
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        /* Using PlayOneShot would not play the break sound since the block would
         * have been destroyed and so would the AudioSource.
         * PlayClipAtPoint sets the AudioClip in a position and plays it there.
         * */
        level.BlockDestroyed();
        Destroy(this.gameObject);
    }
    
}
