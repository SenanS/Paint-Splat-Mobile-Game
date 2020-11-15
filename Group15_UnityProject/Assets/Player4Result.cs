using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class Player4Result : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GameObject PA = GameObject.Find("PointArray");
        SyncList<int> PL = ((pointarray)GameObject.Find("PointArray").GetComponent("pointarray")).PL;
        this.GetComponent<Text>().text = PL[3].ToString() + " Score!!";

    }

}