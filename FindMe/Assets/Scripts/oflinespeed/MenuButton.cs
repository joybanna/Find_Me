using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {

    public GameObject lobbymenuO;
    public GameObject lobbymenuT;

    // Use this for initialization
    void Start () {
        lobbymenuO.SetActive(false);
        lobbymenuT.SetActive(false);
    }


    public void onClick_GameStart()
    {
        lobbymenuO.SetActive(true);
        lobbymenuT.SetActive(true);
    }

    public void onClick_Close()
    {
        Application.Quit();
    }

}
