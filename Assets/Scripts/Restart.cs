using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public GameObject game { get; set; }

    public void OnMouseDown()
    {
        Destroy(game);
    }
}
