using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] List<Vector3> hit1Blocks = new List<Vector3>();
    [SerializeField] List<Vector3> hit2Blocks = new List<Vector3>();
    [SerializeField] GameObject hit1Prefab;
    [SerializeField] GameObject hit2Prefab;

    // Start is called before the first frame update
    void Start()
    {

      
        for (int i=0; i<hit1Blocks.Count; i++)
        {
            Instantiate(hit1Prefab, hit1Blocks[i], Quaternion.identity);

        }


        for (int i = 0; i < hit2Blocks.Count; i++)
        {
            Instantiate(hit2Prefab, hit2Blocks[i], Quaternion.identity);

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
