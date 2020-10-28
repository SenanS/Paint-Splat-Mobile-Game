using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Control the player's position
/// Nothing needs to change
/// </summary>
public class ButtonIsClicked : MonoBehaviour
{
    
    public bool ButtonState;
    // Start is called before the first frame update
    void Start()
    {
        ButtonState = false;
    }
    public void Clickme() {
        print("You have pressed the button!");
        ButtonState = true;
    }

}
