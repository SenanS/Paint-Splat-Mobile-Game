using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FindPointArray : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] PointsArray = GloblePointArray.PointArray;
        print(PointsArray[0] + "," + PointsArray[1] + "," + PointsArray[2] + "," + PointsArray[3]);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
