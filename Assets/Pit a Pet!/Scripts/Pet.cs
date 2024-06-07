using UnityEngine;

[System.Serializable]
public class Pet
{
    // 펫의 속성
    public string name;
    public float hunger;       // 배고픔 (0~100)
    public float happiness;    // 행복도 (0~100)
    public float clean;  // 청결도 (0~100)
    public float energy;       // 에너지 (0~100)

    public Level level;

    // 생성자
    public Pet(string petName)
    {
        name = petName;
        hunger = 50;
        happiness = 50;
        clean = 50;
        energy = 50;
        level = new Level();
    }

    public Pet(PetData data)
    {
        name = data.name;
        hunger = data.hunger;
        happiness = data.happiness;
        clean = data.clean;
        energy = data.energy;
        level = new Level(data.level, data.affection);
    }


    // 음식 주기
    public void Feed(float amount)
    {
        hunger = Mathf.Clamp(hunger + amount, 0, 100);
        level.IncreaseAffection(5.0f);
    }

    // 놀기
    public void Play(float amount)
    {
        happiness = Mathf.Clamp(happiness + amount, 0, 100);
        energy = Mathf.Clamp(energy - amount, 0, 100);
        level.IncreaseAffection(10.0f);
    }

    // 씻기
    public void Wash(float amount)
    {
        clean = Mathf.Clamp(clean + amount, 0, 100);
        energy = Mathf.Clamp(energy - amount, 0, 100);
        level.IncreaseAffection(10.0f);
    }

    // 치료하기
    public void Care(float amount)
    {
        hunger = Mathf.Clamp(hunger + amount, 0, 100);
        clean = Mathf.Clamp(clean + amount, 0, 100);
        energy = Mathf.Clamp(energy + amount, 0, 100);
    }
}