using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsMove : MonoBehaviour
{
    public float speed = 10f;
    private float leftEdge;

    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 20f;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime * GameManager.gameSpeedIncrease;

        if(transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
