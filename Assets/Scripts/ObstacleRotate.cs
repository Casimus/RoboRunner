using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotate : MonoBehaviour
{
    [SerializeField]
    [Range(0.5f,5)]
    private float rotationSpeed = 2f;

    private void Start()
    {
        rotationSpeed = 
            Random.Range(0.5f * rotationSpeed, 1.5f * rotationSpeed);
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsInGame) return;

        transform.Rotate(new Vector3(0, 0, rotationSpeed));
    }
}
