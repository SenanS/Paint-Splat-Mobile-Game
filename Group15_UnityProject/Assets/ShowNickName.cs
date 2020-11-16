using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowNickName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string NickName = GlobeNickName.NickName;
        this.GetComponent<Text>().text = NickName;
    }


}
