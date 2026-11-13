using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField] private int currentLevel;

    [SerializeField] private int experience;

    [SerializeField] private int experienceToLevel;

    private void Awake()
    {
        currentLevel = 1;
    }

    public void GainExp(int addExperience)
    {
        experience += addExperience;
        if(experience >= experienceToLevel)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        currentLevel++;
        experienceToLevel *= 2;
    }
}
