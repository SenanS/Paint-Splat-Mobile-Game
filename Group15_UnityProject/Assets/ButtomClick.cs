using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;

public class ButtomClick : NetworkBehaviour
{
    public int i = 0;
    public GameObject TracePrefab;
    public Transform TraceSpawn;
    ButtonIsClicked Buttonflag;
    public bool ButtonState=false;
    float[] XArray = new float[20];
    float[] YArray = new float[20];

    void Update() {
        if (isLocalPlayer == false) {
            return;
        }
        //GameObject Button = GameObject.Find("Button");
        Buttonflag = (ButtonIsClicked)GameObject.Find("Button").GetComponent("ButtonIsClicked");//this is a bool, if 
        if (Buttonflag.ButtonState)
        {
            //CmdShoot();
            Cmdjudgeandshoot();
            Buttonflag.ButtonState = false;
        }

    }

    //[Command]
    //public void CmdShoot()
    //{

    //    GameObject container = GameObject.Find("MovingTile");    
    //    GameObject Trace = Instantiate(TracePrefab, TraceSpawn.position, TraceSpawn.rotation) as GameObject;
    //    //Trace.transform.parent = container.transform;
    //    //Trace.transform.Translate(container.transform.position);
    //    NetworkServer.Spawn(Trace);

    //}

    [Command]// This function run in the host, whenever which client press the button, host will run this function
    public void Cmdjudgeandshoot()
    {
        
        GameObject container = GameObject.Find("MovingTile");
        bool flag = false;
        if (this.transform.position.x < container.transform.position.x + 92 && transform.position.x > container.transform.position.x - 92
       && transform.position.y < container.transform.position.y + 52 && transform.position.y > container.transform.position.y - 65)
        {

            for (int m = 0; m <= i; m++)
            {
                if (this.transform.position.x <= XArray[m] + 20 && this.transform.position.x >= XArray[m] - 20
                    && this.transform.position.y <= YArray[m] + 20 && this.transform.position.y >= YArray[m] - 20)
                {
                    flag = true;
                    GameObject Failed = GameObject.Find("Failed!!");//Show the hint, but it just show in the host
                    GameObject FailedInstance = Instantiate(Failed);
                    FailedInstance.transform.position = new Vector2(190, 140);
                    FailedInstance.transform.localScale = new Vector2(50, 50);
                    Destroy(FailedInstance, 1.0f);
                }
            }

            if (!flag)//you shoot it successful
            {
                print("You Shoot It!!!");                    
                GameObject Trace = Instantiate(TracePrefab, TraceSpawn.position, TraceSpawn.rotation) as GameObject;
/////////////////////////////////////////////////////////////////////////////////////////////////////////               
                //Trace.transform.parent = container.transform;//If want the trace follow the tile , cancel this cite and let the trace be the child of the tile(continer is the moving tile)
                //Trace.transform.Translate(container.transform.position);
                NetworkServer.Spawn(Trace);              
/////////////////////////////////////////////////////////////////////////////////////////////////////

                XArray[i] = this.transform.position.x;
                YArray[i] = this.transform.position.y;
                i = i + 1;
                GameObject Great = GameObject.Find("Great!!");//Show the hint, but it just show in the host
                GameObject GreatInstance = Instantiate(Great);
                GreatInstance.transform.position = new Vector2(190, 140);
                GreatInstance.transform.localScale = new Vector2(50, 50);             
                Destroy(GreatInstance, 1.0f);
            }
        }
        else
        {
            print("You Miss It!!");
            GameObject Missed = GameObject.Find("Missed!!");//Show the hint, but it just show in the host
            GameObject MissedInstance = Instantiate(Missed);
            MissedInstance.transform.position = new Vector2(190, 140);
            MissedInstance.transform.localScale = new Vector2(50, 50);   
            Destroy(MissedInstance, 1.0f);
        }
    }


}

