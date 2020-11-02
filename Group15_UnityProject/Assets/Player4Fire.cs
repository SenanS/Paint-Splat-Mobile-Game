using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;

public class Player4Fire : NetworkBehaviour
{
    public GameObject TracePrefab;
    public GameObject Great;
    public GameObject Fail;
    public GameObject Miss;
    ButtonIsClicked Buttonflag;
    public bool ButtonState = false;

    void Update()
    {
        if (isLocalPlayer == false)
        {
            return;
        }
        Buttonflag = (ButtonIsClicked)GameObject.Find("Button").GetComponent("ButtonIsClicked");//this is a bool, if 
        if (Buttonflag.ButtonState)
        {
            Judge();
            Buttonflag.ButtonState = false;
        }

    }

   
    void CmdGenerateTrace()
    {
        GameObject container = GameObject.Find("MovingTile");
        List<GameObject> TracesLists = ((RandomMove)container.GetComponent("RandomMove")).TracesList;
        GameObject Trace = Instantiate(TracePrefab, this.transform.position, this.transform.rotation) as GameObject;
        NetworkServer.Spawn(Trace);
        TracesLists.Add(Trace);
        print(TracesLists.Count);
    }

    [Command]
    void Judge()
    {
        GameObject container = GameObject.Find("MovingTile");
        List<GameObject> TracesLists = ((RandomMove)container.GetComponent("RandomMove")).TracesList;
        if (this.transform.position.x < container.transform.position.x + 92 && transform.position.x > container.transform.position.x - 92
       && transform.position.y < container.transform.position.y + 52 && transform.position.y > container.transform.position.y - 65)
        {
            for (int m = 0; m < TracesLists.Count; m++)
            {
                if (this.transform.position.x <= TracesLists[m].transform.position.x + 20 && this.transform.position.x >= TracesLists[m].transform.position.x - 20
                    && this.transform.position.y <= TracesLists[m].transform.position.y + 20 && this.transform.position.y >= TracesLists[m].transform.position.y - 20)
                {
                    GeneralFailHint();                  
                    return;
                }
            }
            GeneralSuccessHint();
            CmdGenerateTrace();
            return;
        }
        else
        {
            GeneralMissHint();
            return;

        }
    }

    void GeneralSuccessHint()
    {
        GameObject GreatInstance = Instantiate(Great);
        GreatInstance.transform.position = new Vector2(190, 140);
        GreatInstance.transform.localScale = new Vector2(50, 50);
        NetworkServer.Spawn(GreatInstance);
        Destroy(GreatInstance, 1.0f);
    }
    void GeneralMissHint()
    {
        GameObject MissedInstance = Instantiate(Miss);
        MissedInstance.transform.position = new Vector2(190, 140);
        MissedInstance.transform.localScale = new Vector2(50, 50);
        NetworkServer.Spawn(MissedInstance);
        Destroy(MissedInstance, 1.0f);
    }

    void GeneralFailHint()
    {
        GameObject FailedInstance = Instantiate(Fail);
        FailedInstance.transform.position = new Vector2(190, 140);
        FailedInstance.transform.localScale = new Vector2(50, 50);
        NetworkServer.Spawn(FailedInstance);
        Destroy(FailedInstance, 1.0f);
    }

}
