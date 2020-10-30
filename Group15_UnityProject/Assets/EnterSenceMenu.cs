using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterSenceMenu : MonoBehaviour
{
    Renderer rend;

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        string player_name = GameObject.Find("InputField").GetComponent<InputName>().player_name;

        if (player_name.Length > 0)
        {
            SceneManager.LoadScene("1.Menu");//level1为我们要切换到的场景
        }
        rend = GameObject.Find("Warning Sprite").GetComponent<Renderer>();
        rend.enabled = true;
        //GameObject.Find("Warning").Renderer<>(true);





    }

    // Update is called once per frame
    void Update()
    {

    }
}

