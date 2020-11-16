using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class InputName : MonoBehaviour
{

    public string player_name = "";
    string NickName = GlobeNickName.NickName;

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

        print("User Name:" + inp);
        NickName = inp;
        print(NickName);

    }

}
