using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;
/// <summary>
/// This Script control the Tile move randomly
/// Nothing needs to change 
/// </summary>
public class RandomMove : NetworkBehaviour
{
    [SyncVar]
    public List<GameObject> TracesList = new List<GameObject>();
    float stopTime;//暂停时间
    float moveTime;//移动时间
    float vel_x, vel_y;//速度
                              
    float maxPos_x = 285;
    float maxPos_y = 465;
    float minPos_x = 92;
    float minPos_y = 240;
    float timeCounter1;//移动的计时器
    float timeCounter2;//暂停的计时器
    void Start()
    {
        Change();
    }
    // Update is called once per frame
    void Update()
    {
        timeCounter1 += Time.deltaTime;
        //如果移动的计时器小于移动时间，则进行移动，否则暂停计时器累加，当暂停计时器大于暂停时间时，重置
        if (timeCounter1 < moveTime)
        {
            transform.Translate(vel_x, vel_y, 0, Space.Self);
        }
        else
        {
            timeCounter2 += Time.deltaTime;
            if (timeCounter2 > stopTime)
            {
                Change();
                timeCounter1 = 0;
                timeCounter2 = 0;
            }
        }
        Check();
    }
    //对参数赋值
    void Change()
    {
        stopTime = Random.Range(0, 1f);
        //moveTime = 0;
        moveTime = Random.Range(2, 3.4f);
        //vel_x = Random.Range(1, 10);
        //vel_y = Random.Range(1, 10);
        //stopTime = 0;
        //moveTime = 20;
        vel_x = 0.5F;
        vel_y = 0.5F;
    }
    //判断是否达到边界，达到边界则将速度改为负的
    void Check()
    {
        //如果到达预设的界限位置值，调换速度方向并让它当前的坐标位置等于这个临界边的位置值
        if (transform.localPosition.x > maxPos_x)
        {
            vel_x = -vel_x;
            transform.localPosition = new Vector3(maxPos_x, transform.localPosition.y, 0);
        }
        if (transform.localPosition.x < minPos_x)
        {
            vel_x = -vel_x;
            transform.localPosition = new Vector3(minPos_x, transform.localPosition.y, 0);
        }
        if (transform.localPosition.y > maxPos_y)
        {
            vel_y = -vel_y;
            transform.localPosition = new Vector3(transform.localPosition.x, maxPos_y, 0);
        }
        if (transform.localPosition.y < minPos_y)
        {
            vel_y = -vel_y;
            transform.localPosition = new Vector3(transform.localPosition.x, minPos_y, 0);
        }
    }


}