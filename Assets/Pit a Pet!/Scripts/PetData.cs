[System.Serializable]
public class PetData
{
    public string name;
    public float hunger;
    public float happiness;
    public float clean;
    public float energy;
    public int level;
    public float affection;

    public PetData(Pet pet)
    {
        name = pet.name;
        hunger = pet.hunger;
        happiness = pet.happiness;
        clean = pet.clean;
        energy = pet.energy;
        level = pet.level.CurrentLevel;
        affection = pet.level.CurrentAffection;
    }
}
