using UnityEngine;

[System.Serializable]
public class Pet
{
    // ���� �Ӽ�
    public string name;
    public float hunger;       // ����� (0~100)
    public float happiness;    // �ູ�� (0~100)
    public float clean;  // û�ᵵ (0~100)
    public float energy;       // ������ (0~100)

    public Level level;

    // ������
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


    // ���� �ֱ�
    public void Feed(float amount)
    {
        hunger = Mathf.Clamp(hunger + amount, 0, 100);
        level.IncreaseAffection(5.0f);
    }

    // ���
    public void Play(float amount)
    {
        happiness = Mathf.Clamp(happiness + amount, 0, 100);
        energy = Mathf.Clamp(energy - amount, 0, 100);
        level.IncreaseAffection(10.0f);
    }

    // �ı�
    public void Wash(float amount)
    {
        clean = Mathf.Clamp(clean + amount, 0, 100);
        energy = Mathf.Clamp(energy - amount, 0, 100);
        level.IncreaseAffection(10.0f);
    }

    // ġ���ϱ�
    public void Care(float amount)
    {
        hunger = Mathf.Clamp(hunger + amount, 0, 100);
        clean = Mathf.Clamp(clean + amount, 0, 100);
        energy = Mathf.Clamp(energy + amount, 0, 100);
    }
}