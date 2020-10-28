using UnityEngine;
using System.Collections;
using Mirror;
//using VJStick;

public class VJPlayer : NetworkBehaviour
{
    
    //public override void OnStartLocalPlayer() {
    //    GetComponent<SpriteRenderer>().color = Color.red;
    //}

    public float moveSpeed = 05f;
    VJStick jsMovement;

    private Vector3 direction;
    private float xMin, xMax, yMin, yMax;

    [SyncVar(hook = nameof(SetColor))]
    Color PlayerColor = Color.black;

    void Update()
    {
        if (isLocalPlayer == false)
        {
            return;
        }
        GameObject JoyStickHandler =  GameObject.Find("JoyStickHandler");
        jsMovement = (VJStick)JoyStickHandler.GetComponent("VJStick");

        
        direction = jsMovement.InputDirection; //InputDirection can be used as per the need of your project

        if (direction.magnitude != 0)
        {
            transform.position += direction * moveSpeed;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), Mathf.Clamp(transform.position.y, yMin, yMax), 0f);//to restric movement of player
        }
    }

    void Start()
    {
        PlayerColor = new Color(Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f);      
        //Initialization of boundaries
        xMax = Screen.width - 25; // I used 50 because the size of player is 100*100
        xMin = 25;
        yMax = Screen.height - 25;
        yMin = 185;
    }

    //private void SetColor(Color PlayerColor, Color color)
    //{
    //    GetComponent<SpriteRenderer>().color = color;
    //}
    void SetColor(Color oldColor, Color newColor)
    {
        GetComponent<SpriteRenderer>().color = newColor;
    }
}