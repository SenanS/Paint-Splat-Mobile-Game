using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class pointarray : NetworkBehaviour
{
    
    //[SyncList<int>] public List<int> PL = new List<int>() { 0, 0, 0, 0 };
    public SyncList<int> PL = new SyncList<int>() { 0, 0, 0, 0 };
    //[SyncVar]
    public int PL1=5;

}
