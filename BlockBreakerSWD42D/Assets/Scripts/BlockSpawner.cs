using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    GameObject[] blocks;
    GameObject randomBlock;

    Vector2 blockPosition, startingPosition; //Vector2 since we need to store the x and y coordinates

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        LoadBlocksFromResources();
        PrintBlocksOnXAndY();
    }

    void LoadBlocksFromResources()
    {
        blocks = Resources.LoadAll<GameObject>("Blocks");
        /* The Resources class handles the functionality related to loading resources from our 
         * assets folder so that they can be referred to from our script.
         * To work with this class we need a folder named "Resources" in our Assets.
         * LoadAll() loads all of the resources found in the path and returns an array.
         * The type used to store prefabs is GameObject.
         */

        blockPosition = transform.position;
    }

    void GetRandomBlock()
    {
        int randomNumber = Random.Range(0, blocks.Length);
        randomBlock = blocks[randomNumber];
    }

    void SpawnBlock()
    {
        Instantiate(randomBlock, blockPosition, transform.rotation);
    }

    void PrintBlocksOnXAndY()
    {
        for (int y = 5; y > 1; y--)
        {
            for (int x = 1; x < 8; x++)
            {
                GetRandomBlock();
                SpawnBlock();
                blockPosition.x += 2;
            }

            blockPosition.x = startingPosition.x;
            // take the position back to the most left (the first block of a row)

            blockPosition.y -= 2;
            // go down to the next row
        }
    }
}
