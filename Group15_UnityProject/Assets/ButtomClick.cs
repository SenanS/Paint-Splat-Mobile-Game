//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Networking;
//using Mirror;

//public class ButtomClick : NetworkBehaviour
//{
//    public int i = 0;
//    public GameObject TracePrefab;
//    ButtonIsClicked Buttonflag;
//    public bool ButtonState = false;
//    public List<GameObject> Traces = new List<GameObject>();
//    public float[] XArray;
//    public float[] YArray;
//    void Update()
//    {
//        if (isLocalPlayer == false)
//        {
//            return;
//        }
//        Buttonflag = (ButtonIsClicked)GameObject.Find("Button").GetComponent("ButtonIsClicked");//this is a bool, if 
//        if (Buttonflag.ButtonState)
//        {
//            bool Flag = CmdJudge();
//            if (Flag)
//            {
//                CmdGenerateTrace();
//                Flag = false;
//            }

//            Buttonflag.ButtonState = false;
//        }

//    }

//    [Command]
//    void CmdGenerateTrace()
//    {
//        GameObject Trace = Instantiate(TracePrefab, this.transform.position, this.transform.rotation) as GameObject;
//        NetworkServer.Spawn(Trace);
//        //Traces.Add(Trace);
//        //i = i + 1;
//    }

//    bool CmdJudge()
//    {
//        GameObject container = GameObject.Find("MovingTile");
//        if (this.transform.position.x < container.transform.position.x + 92 && transform.position.x > container.transform.position.x - 92
//       && transform.position.y < container.transform.position.y + 52 && transform.position.y > container.transform.position.y - 65)
//        {
//            for (int m = 0; m < i; m++)
//            {
//                if (this.transform.position.x <= (XArray[m]+ container.transform.position.x + 20) && this.transform.position.x>=(XArray[m] + container.transform.position.x - 20)
//                    && this.transform.position.y <= (YArray[m] + container.transform.position.y + 20) && this.transform.position.y >=(YArray[m] + container.transform.position.y - 20))
//                {
//                    GeneralFailHint();
//                    return false;
//                }
//            }
//            GeneralSuccessHint();
//            XArray[i] = this.transform.position.x- container.transform.position.x;
//            YArray[i] = this.transform.position.y - container.transform.position.y;
//            i = i + 1;           
//            return true;
//        }
//        else
//        {
//            GeneralMissHint();
//            return false;

//        }
//    }

//    void GeneralSuccessHint()
//    {
//        GameObject Great = GameObject.Find("Great!!");
//        GameObject GreatInstance = Instantiate(Great);
//        GreatInstance.transform.position = new Vector2(190, 140);
//        GreatInstance.transform.localScale = new Vector2(50, 50);
//        Destroy(GreatInstance, 1.0f);
//    }
//    void GeneralMissHint()
//    {
//        GameObject Missed = GameObject.Find("Missed!!");
//        GameObject MissedInstance = Instantiate(Missed);
//        MissedInstance.transform.position = new Vector2(190, 140);
//        MissedInstance.transform.localScale = new Vector2(50, 50);
//        Destroy(MissedInstance, 1.0f);
//    }

//    void GeneralFailHint()
//    {
//        GameObject Failed = GameObject.Find("Failed!!");
//        GameObject FailedInstance = Instantiate(Failed);
//        FailedInstance.transform.position = new Vector2(190, 140);
//        FailedInstance.transform.localScale = new Vector2(50, 50);
//        Destroy(FailedInstance, 1.0f);
//    }


//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;

public class ButtomClick : NetworkBehaviour
{
    public int i = 0;
    public GameObject TracePrefab;
    ButtonIsClicked Buttonflag;
    public bool ButtonState = false;
    public List<GameObject> Traces = new List<GameObject>();
    void Update()
    {
        if (isLocalPlayer == false)
        {
            return;
        }
        Buttonflag = (ButtonIsClicked)GameObject.Find("Button").GetComponent("ButtonIsClicked");//this is a bool, if 
        if (Buttonflag.ButtonState)//if button is clicked
        {
            bool Flag = Judge();//whether can the shoot is succesful or fail
            if (Flag)
            {
                CmdGenerateTrace();
                GeneralSuccessHint();
                Flag = false;
            }
            else
            {
                GeneralFailHint();
            }
            Buttonflag.ButtonState = false;
        }

    }

    [Command]
    void CmdGenerateTrace()
    {
        GameObject Trace = Instantiate(TracePrefab, this.transform.position, this.transform.rotation) as GameObject;
        NetworkServer.Spawn(Trace);
        Traces.Add(Trace);
        i = i + 1;
    }

    bool Judge()
    {
        GameObject container = GameObject.Find("MovingTile");
        if (this.transform.position.x < container.transform.position.x + 92 && transform.position.x > container.transform.position.x - 92
       && transform.position.y < container.transform.position.y + 52 && transform.position.y > container.transform.position.y - 65)
        {
            for (int m = 0; m < i; m++)
            {
                if (this.transform.position.x <= Traces[m].transform.position.x + 20 && this.transform.position.x >= Traces[m].transform.position.x - 20
                    && this.transform.position.y <= Traces[m].transform.position.y + 20 && this.transform.position.y >= Traces[m].transform.position.y - 20)
                {
                    return false;
                }
            }

            return true;
        }
        else
        {
            return false;

        }
    }

    void GeneralSuccessHint()
    {
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

    void GeneralFailHint()
    {
        GameObject Failed = GameObject.Find("Failed!!");
        GameObject FailedInstance = Instantiate(Failed);
        FailedInstance.transform.position = new Vector2(190, 140);
        FailedInstance.transform.localScale = new Vector2(50, 50);
        Destroy(FailedInstance, 1.0f);
    }


}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Networking;
//using Mirror;

//public class ButtomClick : NetworkBehaviour
//{
//    public int i = 0;
//    public GameObject TracePrefab;
//    ButtonIsClicked Buttonflag;
//    public bool ButtonState = false;
//    public List<GameObject> Traces = new List<GameObject>();

//    void Update()
//    {
//        if (isLocalPlayer == false)
//        {
//            return;
//        }
//        Buttonflag = (ButtonIsClicked)GameObject.Find("Button").GetComponent("ButtonIsClicked");//this is a bool, if 
//        if (Buttonflag.ButtonState)
//        {
//            CmdJudge();
//            Buttonflag.ButtonState = false;
//        }
//    }

//    [Command]
//    void CmdJudge()
//    {
//       // List<GameObject> Traces = new List<GameObject>();
//        GameObject container = GameObject.Find("MovingTile");

//        if (this.transform.position.x < container.transform.position.x + 92 && transform.position.x > container.transform.position.x - 92
//       && transform.position.y < container.transform.position.y + 52 && transform.position.y > container.transform.position.y - 65)
//        {
//            for (int m = 0; m < i; m++)
//            {
//                if (this.transform.position.x <= Traces[m].transform.position.x + 25 && this.transform.position.x >= Traces[m].transform.position.x - 25
//                    && this.transform.position.y <= Traces[m].transform.position.y + 25 && this.transform.position.y >= Traces[m].transform.position.y - 25)
//                {
//                    return;
//                }
//            }
//            GameObject Trace = Instantiate(TracePrefab, this.transform.position, this.transform.rotation) as GameObject;
//            NetworkServer.Spawn(Trace);
//            //Traces[i] = Trace;
//            Traces.Add(Trace);
//            i = i + 1;
//        }
//        else
//        {
//            return;
//        }
//    }

//}

