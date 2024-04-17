using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    [SerializeField] private GameObject floorTileLeft;
    [SerializeField] private GameObject floorTileRight;

    [SerializeField] private GameObject[] tiles;

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsInGame) return;

        floorTileLeft.transform.position -= 
            new Vector3(GameManager.Instance.GetWorldSpeed(),0,0);
        floorTileRight.transform.position -=
            new Vector3(GameManager.Instance.GetWorldSpeed(), 0, 0);

        if (floorTileRight.transform.position.x < 0)
        {
            //floorTileLeft.transform.position += new Vector3(18f, 0, 0);

            var newTile = Instantiate(tiles[UnityEngine.Random.Range(0, tiles.Length)],
                floorTileRight.transform.position + new Vector3(18f, 0, 0),
                Quaternion.identity, 
                gameObject.transform);

            Destroy(floorTileLeft);

            floorTileLeft = floorTileRight;
            floorTileRight = newTile;
            
        }
    }
}
