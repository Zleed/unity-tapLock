using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGame : MonoBehaviour
{
    public GameObject menu;
    public GameObject adManager;

    void Start()
    {
        Instantiate(adManager);
        Instantiate(menu);
    }

}
