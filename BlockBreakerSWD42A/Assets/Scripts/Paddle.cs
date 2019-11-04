using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float xMin = 1f;
    [SerializeField] float xMax = 15f;

    Vector2 paddlePosition;


    // Start is called before the first frame update
    void Start()
    {
        paddlePosition = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        float mousePos = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        //set the mousePos to a limit between 1 and 15
        float limitMousePos = Mathf.Clamp(mousePos, xMin, xMax);

        paddlePosition.x = limitMousePos;

        this.transform.position = paddlePosition;
    }
}
