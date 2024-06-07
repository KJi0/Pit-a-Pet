using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject optionPanel;
    public Image popupImage;  // �˾� �̹���
    private Text popupText;   // �˾� �ؽ�Ʈ (Image ���� �ؽ�Ʈ ������Ʈ)

    public GameObject newGamePopup; // �� �̸� ���� �˾�
    public InputField petNameInput; // �� �̸� �Է� �ʵ�
    public Button newGameConfirmButton; // Ȯ�� ��ư

    public Slider hungerSlider;
    public Slider happinessSlider;
    public Slider cleanSlider;
    public Slider energySlider;
    public Slider affectionSlider;
    public Text levelText;
    public Text levelUpText;
    public Text petNameText;

    public Color normalColor = Color.green;   // ���� ������ �����̴� ����
    public Color criticalColor = Color.red;

    // ���� ���¸� �����ϴ� ����
    private float previousHunger;
    private float previousHappiness;
    private float previousClean;
    private float previousEnergy;
    private float previousAffection;
    void Start()
    {
        // Image ���� Text ������Ʈ�� ã���ϴ�.
        popupText = popupImage.GetComponentInChildren<Text>();
        popupImage.gameObject.SetActive(false);
        optionPanel.SetActive(false);
        newGamePopup.SetActive(false);
    }
    
    public void UpdateUI(Pet pet)
    {
        if (pet == null)
        {
            Debug.LogError("Pet is null in UpdateUI.");
            return;
        }

        if (pet.level == null)
        {
            Debug.LogError("Pet level is null in UpdateUI.");
            return;
        }

        bool isUpdated = false;

        // ���°� ����Ǿ����� üũ
        if (previousHunger != pet.hunger)
        {
            hungerSlider.value = pet.hunger;
            previousHunger = pet.hunger;
            isUpdated = true;
        }

        if (previousHappiness != pet.happiness)
        {
            happinessSlider.value = pet.happiness;
            previousHappiness = pet.happiness;
            isUpdated = true;
        }

        if (previousClean != pet.clean)
        {
            cleanSlider.value = pet.clean;
            previousClean = pet.clean;
            isUpdated = true;
        }

        if (previousEnergy != pet.energy)
        {
            energySlider.value = pet.energy;
            previousEnergy = pet.energy;
            isUpdated = true;
        }

        if (previousAffection != pet.level.currentAffection)
        {
            affectionSlider.value = pet.level.currentAffection;
            previousAffection = pet.level.currentAffection;
            isUpdated = true;
        }

        // �����̴� ���� ������Ʈ
        UpdateSliderColor(hungerSlider, pet.hunger);
        UpdateSliderColor(happinessSlider, pet.happiness);
        UpdateSliderColor(cleanSlider, pet.clean);
        UpdateSliderColor(energySlider, pet.energy);

        // ���°� ������Ʈ�� ��쿡�� �α� ���
        if (isUpdated)
        {
            Debug.Log($"Sliders Updated - Hunger: {pet.hunger}, Happiness: {pet.happiness}, Clean: {pet.clean}, Energy: {pet.energy}, Affection: {pet.level.currentAffection}");
        }
    }

    private void UpdateSliderColor(Slider slider, float value)
    {
        Image fill = slider.fillRect.GetComponent<Image>();
        if (fill != null)
        {
            fill.color = value <= 30 ? criticalColor : normalColor;
        }
    }

    public void UpdatePetName(string name)
    {
        petNameText.text = name; // �� �̸� UI ������Ʈ
    }
    public void ShowNewGamePopup()
    {
        newGamePopup.SetActive(true);
        newGamePopup.transform.SetAsLastSibling(); // �˾��� �� ������ ������
    }

    public void HideNewGamePopup()
    {
        newGamePopup.SetActive(false);
    }
    public void ShowPopup(string message)
    {
        StartCoroutine(ShowPopupCoroutine(message));
    }

    private IEnumerator ShowPopupCoroutine(string message)
    {
        popupText.text = message;
        popupImage.gameObject.SetActive(true);
        popupImage.transform.SetAsLastSibling();


        yield return new WaitForSeconds(2.0f); // 2�� ���� �˾� ǥ��

        popupImage.gameObject.SetActive(false);
    }
    public void UpdateLevelText(int level)
    {
        levelText.text = "Lv." + level;
    }

    public void ShowLevelUpText()
    {
        StartCoroutine(ShowLevelUpTextCoroutine());
    }

    private IEnumerator ShowLevelUpTextCoroutine()
    {
        levelUpText.gameObject.SetActive(true);

        yield return new WaitForSeconds(5.0f); // 5�� ���� Level Up �ؽ�Ʈ ǥ��

        levelUpText.gameObject.SetActive(false);
    }
    public void ShowOptionPanel()
    {
        optionPanel.SetActive(true);
    }

    public void HideOptionPanel()
    {
        optionPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
