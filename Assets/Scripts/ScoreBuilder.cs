using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreBuilder", menuName = "ScoreBuilder")]
public class ScoreBuilder : ScriptableObject
{
    public DigitBuilder digitBuilder;

    public List<GameObject> Build(int number, Vector2 posistion)
    {
        List<GameObject> score =  new List<GameObject>();
        List<int> digits = GetDigits(number);

        foreach(int digit in digits)
        {
            score.Add(digitBuilder.Build(digit, posistion));
            posistion.x -= 0.5f;
        }

        return score;
    }

    private List<int> GetDigits(int num)
    {
        List<int> listOfInts = new List<int>();

        if (num == 0) listOfInts.Add(0);

        while (num > 0)
        {
            listOfInts.Add(num % 10);
            num = num / 10;
        }

        return listOfInts;
    }
}
