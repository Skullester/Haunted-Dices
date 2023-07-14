using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    [SerializeField]
    private Sprite[] diceSprites;

    [SerializeField]
    private Image imgDice;
    public static int counterHighScores;

    private void Start()
    {
        counterHighScores = 5;
    }

    private void Update()
    {
        if (Interaction.s_buttonIndex == 0 && SwitchingCharacter.indexOfCharacter == 0)
            imgDice.sprite = diceSprites[0];
        else if (Interaction.s_buttonIndex == 1 && SwitchingCharacter.indexOfCharacter == 0)
            imgDice.sprite = diceSprites[1];
        else if (Interaction.s_buttonIndex == 0 && SwitchingCharacter.indexOfCharacter == 1)
            imgDice.sprite = diceSprites[2];
        else if (Interaction.s_buttonIndex == 1 && SwitchingCharacter.indexOfCharacter == 1)
            imgDice.sprite = diceSprites[3];
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
