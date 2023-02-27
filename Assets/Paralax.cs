using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private MeshRenderer wallBckgnd;

    public float paralaxAnimSpeedWall = 1; 

    // Start is called before the first frame update
    void Start()
    {
        wallBckgnd = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameStatus == 1)
        {
            wallBckgnd.material.mainTextureOffset += new Vector2(paralaxAnimSpeedWall * Time.deltaTime, 0);
        }
    }
}
