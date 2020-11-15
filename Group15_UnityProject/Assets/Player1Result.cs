using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class Player1Result : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SyncList<int> PL = ((pointarray)GameObject.Find("PointArray").GetComponent("pointarray")).PL;
        this.GetComponent<Text>().text = PL[0].ToString() + " Score!!";
    }

}
