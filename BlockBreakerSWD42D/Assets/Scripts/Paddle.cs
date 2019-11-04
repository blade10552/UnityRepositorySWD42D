using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float ScreenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        float mousePosition = Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        Debug.Log(mousePosition);
        float limitMousePosition = Mathf.Clamp(mousePosition, minX, maxX);
        Debug.Log(limitMousePosition);
        //print(Input.mousePosition.x);
        Vector2 paddlePosition = new Vector2(limitMousePosition, transform.transform.position.y);
         transform.position = paddlePosition;
        

        
        //teacher`s solution
        //float xPoint = Input.mousePosition.x;
        //transform.position = Camera.main.ScreenToViewportPoint(new Vector3(xPoint,0,0)) -new Vector3 (0,-1,Camera.main.transform.position.z);

    }

 //   void OnCollisionEnter2D(Collision2D other)
 //   {
      //  if other.gameObject==
 //       this.GetComponent<AudioSource>().Play();

//    }
}
