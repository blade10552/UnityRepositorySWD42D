using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] int hitCount = 1;
    [SerializeField] AudioClip breakSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
     //   this.gameObject.GetComponent<AudioSource>().Play();
        hitCount--;
        Debug.Log("Block Destroyed");
        if (hitCount <= 0)
        {
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            Destroy(this.gameObject);
        }

    }
}
