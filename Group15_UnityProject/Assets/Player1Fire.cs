using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;

public class Player1Fire : NetworkBehaviour
{
    public GameObject TracePrefab;
    ButtonIsClicked Buttonflag;
    public bool ButtonState = false;
    public List<GameObject> Player1Traces = new List<GameObject>();
    void Update()
    {
        if (isLocalPlayer == false)
        {
            return;
        }
        Buttonflag = (ButtonIsClicked)GameObject.Find("Button").GetComponent("ButtonIsClicked");//this is a bool, if 
        if (Buttonflag.ButtonState)
        {
            bool Flag = Judge();
            if (Flag)
            {
                CmdGenerateTrace();
                Flag = false;
            }
            Buttonflag.ButtonState = false;
        }

    }

    [Command]
    void CmdGenerateTrace()
    {
        GameObject Trace = Instantiate(TracePrefab, this.transform.position, this.transform.rotation) as GameObject;
        NetworkServer.Spawn(Trace);
        Player1Traces.Add(Trace);
    }

    bool Judge()
    {
        GameObject container = GameObject.Find("MovingTile");

        if (this.transform.position.x < container.transform.position.x + 92 && transform.position.x > container.transform.position.x - 92
       && transform.position.y < container.transform.position.y + 52 && transform.position.y > container.transform.position.y - 65)
        {
            if (Player2HaveShootedHere()) { GeneralFailHint(); return false; }

            if (Player3HaveShootedHere()) { GeneralFailHint(); return false; }

            if (Player4HaveShootedHere()) { GeneralFailHint(); return false; }

            for (int m = 0; m < Player1Traces.Count; m++)
            {
                if (this.transform.position.x <= Player1Traces[m].transform.position.x + 20 && this.transform.position.x >= Player1Traces[m].transform.position.x - 20
                    && this.transform.position.y <= Player1Traces[m].transform.position.y + 20 && this.transform.position.y >= Player1Traces[m].transform.position.y - 20)
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


    bool Player2HaveShootedHere()
    {
        if (GameObject.Find("Player#2"))
        {           
            List<GameObject> Player2Traces = ((Player2Fire)GameObject.Find("Player#2").GetComponent("Player2Fire")).Player2Traces;
            for (int m = 0; m < Player2Traces.Count; m++)
            {
                if (this.transform.position.x <= Player2Traces[m].transform.position.x + 20 && this.transform.position.x >= Player2Traces[m].transform.position.x - 20
                    && this.transform.position.y <= Player2Traces[m].transform.position.y + 20 && this.transform.position.y >= Player2Traces[m].transform.position.y - 20)
                {
                    return true;
                }
            }
        }
        return false;
    }

    bool Player3HaveShootedHere()
    {
        if (GameObject.Find("Player#3"))
        {
            List<GameObject> Player3Traces = ((Player3Fire)GameObject.Find("Player#3").GetComponent("Player3Fire")).Player3Traces;
            for (int m = 0; m < Player3Traces.Count; m++)
            {
                if (this.transform.position.x <= Player3Traces[m].transform.position.x + 20 && this.transform.position.x >= Player3Traces[m].transform.position.x - 20
                    && this.transform.position.y <= Player3Traces[m].transform.position.y + 20 && this.transform.position.y >= Player3Traces[m].transform.position.y - 20)
                {
                    return true;
                }
            }
        }
        return false;
    }

    bool Player4HaveShootedHere()
    {
        if (GameObject.Find("Player#4"))
        {
            List<GameObject> Player4Traces = ((Player4Fire)GameObject.Find("Player#4").GetComponent("Player4Fire")).Player4Traces;
            for (int m = 0; m < Player4Traces.Count; m++)
            {
                if (this.transform.position.x <= Player4Traces[m].transform.position.x + 20 && this.transform.position.x >= Player4Traces[m].transform.position.x - 20
                    && this.transform.position.y <= Player4Traces[m].transform.position.y + 20 && this.transform.position.y >= Player4Traces[m].transform.position.y - 20)
                {
                    return true;
                }
            }
        }
        return false;
    }


}