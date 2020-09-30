using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAfterLoader : MonoBehaviour
{

    public Sprite sprite;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }

}
