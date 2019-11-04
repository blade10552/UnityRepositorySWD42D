using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        /* Using PlayOneShot would not play the break sound since the block would
         * have been destroyed and so would the AudioSource.
         * PlayClipAtPoint sets the AudioClip in a position and plays it there.
         * */
        Destroy(this.gameObject);
    }
    
}
