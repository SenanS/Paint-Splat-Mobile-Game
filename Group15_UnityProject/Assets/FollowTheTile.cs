using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheTile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent = GameObject.Find("MovingTile").transform;//The Problem Code(Make the Trace follow the Moving Tile)   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
