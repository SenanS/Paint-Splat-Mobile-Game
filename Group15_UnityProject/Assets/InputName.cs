using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class InputName : MonoBehaviour
{
<<<<<<< Updated upstream
<<<<<<< Updated upstream

    public string player_name = "";
    

=======
    public string name;
>>>>>>> Stashed changes
=======
    public string name;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        player_name = inp;
=======
        name = inp;
>>>>>>> Stashed changes
=======
        name = inp;
>>>>>>> Stashed changes

    }

}
