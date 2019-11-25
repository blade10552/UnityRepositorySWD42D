using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX; //type used for prefabs is GameObject

    Level level; // level is a copy/instance of the Level class 
    //(we need to use it to access its elements
    // e.g. variables and methods)

    GameStatus gameStatus;

    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();

        level = FindObjectOfType<Level>();
        /* The FindObjectOfType method looks for an object in the hierarchy containing the script 
         * having the same name as the class written in between <>
         */

        if(tag == "breakable")
            level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        /* Using PlayOneShot would not play the break sound since the block would
         * have been destroyed and so would the AudioSource.
         * PlayClipAtPoint sets the AudioClip in a position and plays it there.
         * */

        if (tag == "breakable")
        {
            TriggerSparklesVFX();
            level.BlockDestroyed();
            Destroy(this.gameObject);
            /* The gameObject keyword with a g lowercase is referring to the object in which this
             * current script is attached [in this case we are referring to the current Block]
             * The GameObject keyword with a G uppercase refers to the GameObject class/type
             * storing all general data and methods related to Unity game objects
             */
        }
    }

    void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        /* The Instantiate method creates a copy of the object passed as the first arguement/parameter
         * [in our case blockSparklesVFX] - it replicates the duplicate task we do in the editor
         * We need to also indicate the position so that the copy is placed in the same position as
         * the block which is currently being destroyed.
         */

        Destroy(sparkles, 1f);
    }
    
}
