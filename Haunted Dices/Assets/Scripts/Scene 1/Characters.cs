using UnityEngine;

public class Characters : MonoBehaviour
{
    private static int countOfSkills = 2;
    public int Index;
    public string[] Skills = new string[countOfSkills];
    public static int Hp;

    public Characters(int index, int skillIndex)
    {
        Index = index;
    }

    public string Print()
    {
        return Index.ToString();
    }

    public void UseSkill(string skillName) { }
}
