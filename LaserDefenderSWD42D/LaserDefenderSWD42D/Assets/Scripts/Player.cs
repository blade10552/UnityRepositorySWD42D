using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        /* var is used to declare variables at runtime due to being unsure of the type of data at design
         * time. In this case, we know that GetAxis() returns a float value.
         * GetAxis() returns a negative value if the user pressed on the left arrow key or the a key and
         * returns a positive value if the user pressed on the right arrow key or the d key.
         */
        var deltaX = Input.GetAxis("Horizontal");
        var newXPos = transform.position.x + deltaX * Time.deltaTime * moveSpeed;

        var deltaY = Input.GetAxis("Vertical");
        var newYPos = transform.position.y + deltaY * Time.deltaTime * moveSpeed;

        transform.position = new Vector2(newXPos, newYPos);
    }
}
