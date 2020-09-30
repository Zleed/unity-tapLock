using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject game;

    public GameObject menu { get; set; }

    private void OnMouseDown()
    {
        Instantiate(game);
        Destroy(menu);
    }

}
