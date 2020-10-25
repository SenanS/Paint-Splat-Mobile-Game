using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomClick : MonoBehaviour
{
    public VJPlayer CrossHair;
    public int i = 0;
    float[] XArray = new float[20];
    float[] YArray = new float[20];
    //float timeCounter;
    public void Click() {
        Invoke("judgeandshoot", 0.2f);       
    }


    public void judgeandshoot()
    {   
        bool flag = false;
        if (CrossHair.transform.position.x < transform.position.x + 92 && CrossHair.transform.position.x > transform.position.x - 92
       && CrossHair.transform.position.y < transform.position.y + 52 && CrossHair.transform.position.y > transform.position.y - 65)
        {
            for (int m = 0; m <= i; m++) {
                if (CrossHair.transform.position.x <= XArray[m] + 20 && CrossHair.transform.position.x >= XArray[m] - 20
                    && CrossHair.transform.position.y <= YArray[m] + 20 && CrossHair.transform.position.y >= YArray[m] - 20)
                {
                    //print("这块有人射过了！！！");
                    flag = true;
                    GameObject Failed = GameObject.Find("Failed!!");
                    GameObject FailedInstance = Instantiate(Failed);
                    FailedInstance.transform.position = new Vector2(190, 140);
                    FailedInstance.transform.localScale = new Vector2(50, 50);
                    //delete word
                    Destroy(FailedInstance, 1.0f);
                }
            }

            if (!flag) { 
                print("You Shoot It!!!");
                GameObject container = GameObject.Find("MovingTile");
                GameObject Tracy = GameObject.Find("PurpleTracy");
                GameObject Instance = Instantiate(Tracy);
                Instance.transform.parent = container.transform;
                Instance.transform.position = CrossHair.transform.position;
                Instance.transform.localScale = new Vector2(0.1f, 0.1f);                                    
                XArray[i] = CrossHair.transform.position.x;
                YArray[i] = CrossHair.transform.position.y;
                //print("坐标为：" + XArray[i]+","+YArray[i]);
                i =i+1;

                GameObject Great= GameObject.Find("Great!!");
                GameObject GreatInstance = Instantiate(Great);                
                GreatInstance.transform.position = new Vector2(190, 140);
                GreatInstance.transform.localScale = new Vector2(50, 50);
                //delete word
                Destroy(GreatInstance,1.0f);
            }
        }
        else
        {
            print("You Miss It!!");
            GameObject Missed = GameObject.Find("Missed!!");
            GameObject MissedInstance = Instantiate(Missed);
            MissedInstance.transform.position = new Vector2(190, 140);
            MissedInstance.transform.localScale = new Vector2(50, 50);
            //delete word
            Destroy(MissedInstance, 1.0f);
        }
    }

}
