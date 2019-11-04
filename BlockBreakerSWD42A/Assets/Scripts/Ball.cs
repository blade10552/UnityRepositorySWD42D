using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle myPaddle;

    Vector2 paddleToBallDistance;

    bool hasStarted = false;

    //create an array of AudioClip sounds
    [SerializeField] AudioClip[] ballSounds;

    //play sound on Collision
    private void OnCollisionEnter2D(Collision2D coll)
    {
        int randomNumber = UnityEngine.Random.Range(0, ballSounds.Length);

        GetComponent<AudioSource>().PlayOneShot(ballSounds[randomNumber]);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallDistance = this.transform.position - myPaddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)// hasStarted == false
        {
            LockBallToPaddle();
            LaunchBallOnMouseClick();
        }

        

    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            //shoot the ball
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 15f);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = myPaddle.transform.position;
        //set the Ball Position to the Paddle Position + the distance
        this.transform.position = paddlePosition + paddleToBallDistance;
    }
}
