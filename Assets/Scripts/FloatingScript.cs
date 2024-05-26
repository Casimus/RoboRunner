using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScript : MonoBehaviour
{
    [SerializeField] private float height = 0.5f;

    private const int FRAMES = 25;
    private bool isUp = true;
    private int counter = 0;

    private void FixedUpdate()
    {
        Vector3 move = isUp ? new Vector3(0,height/ FRAMES,0) : new Vector3(0,-height/FRAMES,0);

        transform.position += move;
        counter++;

        if (counter == FRAMES)
        {
            counter = 0;
            isUp = !isUp;
        }

    }
}
