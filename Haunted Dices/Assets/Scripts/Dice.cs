using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private bool isCollision;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (!isCollision)
            RotateCube();
    }

    public void RollDice()
    {
        isCollision = false;
        int randomNumber = GetRandomNumber();
        Debug.Log(randomNumber);
    }

    int GetRandomNumber()
    {
        int minScore = 1,
            maxScore = 12;
        return Random.Range(minScore, maxScore + 1);
    }

    void RotateCube()
    {
        transform.Rotate(new Vector3(0f, -20f, -80f) * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isCollision = true;
    }
}
