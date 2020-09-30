using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "DigitBuilder", menuName = "DigitBuilder")]
public class DigitBuilder : ScriptableObject
{
    public Sprite[] sprites;
    public GameObject digit;

    public GameObject Build(int number, Vector2 position)
    {
        GameObject newDigit = Instantiate(digit, position, Quaternion.identity);
        newDigit.GetComponent<SpriteRenderer>().sprite = sprites[number];
        return newDigit;
    }
}
