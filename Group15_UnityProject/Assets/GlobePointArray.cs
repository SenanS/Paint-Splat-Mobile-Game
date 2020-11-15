using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GloblePointArray: NetworkBehaviour
{
    //[SyncVar]
    public static int[] PointArray = new int[] { 0, 0, 0, 0 };
}