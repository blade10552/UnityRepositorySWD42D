using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle mypaddle;
    [SerializeField] float xVelocity = 2f;
    [SerializeField] float yVelocity = 15f;

    [SerializeField] AudioClip[] ballsounds; 


    Vector2 paddleToBallDistance;

    bool hasStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallDistance = this.transform.position - mypaddle.transform.position;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!hasStarted)
        {
            LockBalltoPaddle();
            LaunchOnMouseClick();
        }


    }


    void LockBalltoPaddle()
    {
        Vector2 mypaddleposition = new Vector2(mypaddle.transform.position.x, mypaddle.transform.position.y);

        this.transform.position = mypaddleposition + paddleToBallDistance;

    }


    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity + Random.Range(0.0f, 2f) , yVelocity + Random.Range(0.0f,2f));
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //  if other.gameObject==
        if (other.gameObject.tag == "Wall")
        {
            AudioClip clip = ballsounds[0];
            this.GetComponent<AudioSource>().PlayOneShot(clip);
        }

        if (other.gameObject.name == "Paddle")
        {
            AudioClip clip = ballsounds[1];
            this.GetComponent<AudioSource>().PlayOneShot(clip);
        }



    }


}
