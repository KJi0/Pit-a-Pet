using UnityEngine;

public class Level
{

    public delegate void LevelUpEventHandler(int level);
    public event LevelUpEventHandler OnLevelUp;

    public int currentLevel;
    public float currentAffection;
    private const float affectionThreshold = 100.0f;

    public int CurrentLevel => currentLevel;
    public float CurrentAffection => currentAffection;

    // 애정도와 레벨 초기화를 위한 생성자 추가
    public Level(int startingLevel, float startingAffection)
    {
        currentLevel = startingLevel;
        currentAffection = startingAffection;
    }

    public Level()
    {
        currentLevel = 1;
        currentAffection = 0;
    }

    public void IncreaseAffection(float amount)
    {
        currentAffection += amount;
        if (currentAffection >= affectionThreshold)
        {
            currentLevel++;
            currentAffection = 0;
            OnLevelUp?.Invoke(currentLevel);
        }
    }
}
