using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void RollDice()
    {
        int randomNumber = GetRandomNumber();
        Debug.Log(randomNumber);
    }

    int GetRandomNumber()
    {
        int minScore = 1,
            maxScore = 12;
        return Random.Range(minScore, maxScore + 1);
    }
}
