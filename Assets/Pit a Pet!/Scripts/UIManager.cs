using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject optionPanel;
    public Image popupImage;  // 팝업 이미지
    private Text popupText;   // 팝업 텍스트 (Image 안의 텍스트 컴포넌트)

    public GameObject newGamePopup; // 펫 이름 설정 팝업
    public InputField petNameInput; // 펫 이름 입력 필드
    public Button newGameConfirmButton; // 확인 버튼

    public Slider hungerSlider;
    public Slider happinessSlider;
    public Slider cleanSlider;
    public Slider energySlider;
    public Slider affectionSlider;
    public Text levelText;
    public Text levelUpText;
    public Text petNameText;

    public Color normalColor = Color.green;   // 정상 상태의 슬라이더 색상
    public Color criticalColor = Color.red;

    // 이전 상태를 저장하는 변수
    private float previousHunger;
    private float previousHappiness;
    private float previousClean;
    private float previousEnergy;
    private float previousAffection;
    void Start()
    {
        // Image 안의 Text 컴포넌트를 찾습니다.
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

        // 상태가 변경되었는지 체크
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

        // 슬라이더 색상 업데이트
        UpdateSliderColor(hungerSlider, pet.hunger);
        UpdateSliderColor(happinessSlider, pet.happiness);
        UpdateSliderColor(cleanSlider, pet.clean);
        UpdateSliderColor(energySlider, pet.energy);

        // 상태가 업데이트된 경우에만 로그 출력
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
        petNameText.text = name; // 펫 이름 UI 업데이트
    }
    public void ShowNewGamePopup()
    {
        newGamePopup.SetActive(true);
        newGamePopup.transform.SetAsLastSibling(); // 팝업을 맨 앞으로 가져옴
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


        yield return new WaitForSeconds(2.0f); // 2초 동안 팝업 표시

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

        yield return new WaitForSeconds(5.0f); // 5초 동안 Level Up 텍스트 표시

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
