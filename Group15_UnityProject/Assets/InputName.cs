using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class InputName : MonoBehaviour
{

    public string player_name = "";
    

    void Start()
    {

        transform.GetComponent<InputField>().onValueChanged.AddListener(Changed_Value);

        transform.GetComponent<InputField>().onEndEdit.AddListener(End_Value);

    }

    public void Changed_Value(string inp)
    {

        print("Inputing:" + inp);

    }

    public void End_Value(string inp)
    {

        //string NickNam = GlobeNickName.NickName;
        //NickNam = inp;
        GlobeNickName.NickName=inp;
        print("User Name:" + GlobeNickName.NickName);
        //print(NickName);

    }

}
