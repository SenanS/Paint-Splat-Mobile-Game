using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;

public class ButtomClick : NetworkBehaviour
{
    public int i = 0;
    public GameObject TracePrefab;
    //public Transform TraceSpawn;
    ButtonIsClicked Buttonflag;
    public bool ButtonState=false;
    public float[] XArray = new float[20];
    public float[] YArray = new float[20];
    //public List<GameObject.transform.position> Positions = new List<GameObject.transform.position>();
    public List<GameObject> Traces = new List<GameObject> ();
    public GameObject MyTrace;

    void Update() {
        if (isLocalPlayer == false) {
            return;
        }
        Buttonflag = (ButtonIsClicked)GameObject.Find("Button").GetComponent("ButtonIsClicked");//this is a bool, if 
        if (Buttonflag.ButtonState)
        {
            bool Flag = Judge(XArray, YArray);
            if (Flag)
            {
                CmdGenerateTrace();
                
                Flag = false;
            }
            Buttonflag.ButtonState = false;
        }

    }

    [Command]
    void CmdGenerateTrace() {
            GameObject Trace = Instantiate(TracePrefab, this.transform.position, this.transform.rotation) as GameObject;
            NetworkServer.Spawn(Trace);             
            //Trace.transform.parent = GameObject.Find("MovingTile").transform;//The Problem Code(Make the Trace follow the Moving Tile)       
            XArray[i] = this.transform.position.x;
            YArray[i] = this.transform.position.y;
            i = i + 1;
            
               
    }

    bool Judge(float[] XArray,float[] YArray) {
        GameObject container = GameObject.Find("MovingTile");
        if (this.transform.position.x < container.transform.position.x + 92 && transform.position.x > container.transform.position.x - 92
       && transform.position.y < container.transform.position.y + 52 && transform.position.y > container.transform.position.y - 65)
        {
            for (int m = 0; m <= i; m++)
            {
                if (this.transform.position.x <= XArray[m] + 20 && this.transform.position.x >= XArray[m] - 20
                    && this.transform.position.y <= YArray[m] + 20 && this.transform.position.y >= YArray[m] - 20)
                {
                    GeneralFailHint();
                    return false;
                }
            }
            GeneralSuccessHint();
            return true;
        }
        else
        {
            GeneralMissHint();
            return false;
            
        }
    }

    void GeneralSuccessHint() {        
        GameObject Great = GameObject.Find("Great!!");
        GameObject GreatInstance = Instantiate(Great);
        GreatInstance.transform.position = new Vector2(190, 140);
        GreatInstance.transform.localScale = new Vector2(50, 50);
        Destroy(GreatInstance, 1.0f);
    }
    void GeneralMissHint()
    {
        GameObject Missed = GameObject.Find("Missed!!");
        GameObject MissedInstance = Instantiate(Missed);
        MissedInstance.transform.position = new Vector2(190, 140);
        MissedInstance.transform.localScale = new Vector2(50, 50);
        Destroy(MissedInstance, 1.0f);
    }

    void GeneralFailHint() {
        GameObject Failed = GameObject.Find("Failed!!");
        GameObject FailedInstance = Instantiate(Failed);
        FailedInstance.transform.position = new Vector2(190, 140);
        FailedInstance.transform.localScale = new Vector2(50, 50);
        Destroy(FailedInstance, 1.0f);
    }


}

