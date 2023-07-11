using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dice : MonoBehaviour
{
    public static int counterHighScores;

    private void Start()
    {
        counterHighScores = 5;
    }

    public static int GetRandomNumber()
    {
        int minScore = 1,
            maxScore = 12;
        int randomNumber = Random.Range(minScore, maxScore + 1);
        if (randomNumber > counterHighScores)
        {
            randomNumber = Random.Range(minScore, maxScore - counterHighScores + 1);
            counterHighScores--;
        }
        return randomNumber;
    }
}
