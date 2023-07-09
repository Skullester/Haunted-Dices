using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dice : MonoBehaviour
{
    public void RollDice()
    {
        int randomNumber = GetRandomNumber();
    }

    int GetRandomNumber()
    {
        int minScore = 1,
            maxScore = 12;
        return Random.Range(minScore, maxScore + 1);
    }
}
