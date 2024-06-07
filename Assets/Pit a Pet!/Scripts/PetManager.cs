using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetManager : MonoBehaviour
{
    public Pet currentPet;
    public UIManager uiManager;

    void Start()
    {
        if (currentPet != null && currentPet.level != null)
        {
            currentPet.level.OnLevelUp += HandleLevelUp;
        }
    }

    // 펫 생성 및 초기화
    public void CreatePetFromName()
    {
        string petName = uiManager.petNameInput.text;
        if (!string.IsNullOrEmpty(petName))
        {
            CreatePet(petName);
            GameManager.instance.GameStart();
            uiManager.UpdatePetName(petName);
        }
    }
    public void CreatePet(string name)
    {
        currentPet = new Pet(name);
        if (currentPet.level != null)
        {
            currentPet.level.OnLevelUp += HandleLevelUp;
        }
        UpdateUI();
    }

    // 주기적으로 상태 감소
    void DecreaseStatusPeriodically()
    {
        if (currentPet != null)
        {
            currentPet.hunger = Mathf.Clamp(currentPet.hunger - 5, 0, 100);
            currentPet.clean = Mathf.Clamp(currentPet.clean - 5, 0, 100);
            currentPet.happiness = Mathf.Clamp(currentPet.happiness - 5, 0, 100);
            currentPet.energy = Mathf.Clamp(currentPet.energy + 10, 0, 100);

            UpdateUI();
        }
    }

    // 펫 상태 자동 업데이트 시작
    public void StartStatusUpdate()
    {
        InvokeRepeating("DecreaseStatusPeriodically", 30, 30); // 30초 후에 호출, 30초마다 상태 감소
    }

    // '밥주기' 버튼 클릭 시 호출될 메서드
    public void FeedButtonClicked()
    {
        if (currentPet != null)
        {
            currentPet.Feed(5.0f); // 포만감을 5만큼 증가
            uiManager.ShowPopup("포만감이 +5 증가하였습니다."); // 팝업 표시
            UpdateUI();
        }
    }

    // '놀아주기' 버튼 클릭 시 호출될 메서드
    public void PlayButtonClicked()
    {
        if (currentPet != null)
        {
            if (currentPet.energy <= 30)
            {
                uiManager.ShowPopup($"펫의 체력이 부족합니다.");
            }
            else
            {
                currentPet.Play(10.0f); // 행복도를 10만큼 증가
                uiManager.ShowPopup("행복도가 +10 증가하였습니다."); // 팝업 표시
                UpdateUI();
            }
        }
    }

    // '씻기' 버튼 클릭 시 호출될 메서드
    public void WashButtonClicked()
    {
        if (currentPet != null)
        {
            currentPet.Wash(20.0f); // 청결도 20 증가, 에너지 20 감소
            uiManager.ShowPopup("청결도가 +20 증가하였습니다."); // 팝업 표시
            UpdateUI();
        }
    }

    // '치료하기' 버튼 클릭 시 호출될 메서드
    public void CareButtonClicked()
    {
        if (currentPet != null)
        {
            currentPet.Care(30.0f); // 에너지, 청결도, 포만감 30 증가
            uiManager.ShowPopup("포만감, 청결도, 에너지가 +30 증가하였습니다."); // 팝업 표시
            UpdateUI();
        }
    }

    // 펫 상태 저장 및 로드
    public void SavePet()
    {
        if (currentPet != null)
        {
            SaveLoadManager.SaveGame(currentPet);
        }
    }

    public void LoadPet()
    {
        currentPet = SaveLoadManager.LoadGame();
        if (currentPet != null && currentPet.level != null)
        {
            currentPet.level.OnLevelUp += HandleLevelUp;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        if (currentPet != null)
        {
            uiManager.UpdateUI(currentPet);
        }
    }

    void HandleLevelUp(int level)
    {
        // 레벨이 업데이트되면 UI를 업데이트합니다.
        uiManager.UpdateLevelText(level);
    }

    public void UpdateLevelText()
    {
        if (currentPet != null && currentPet.level != null)
        {
            uiManager.UpdateLevelText(currentPet.level.CurrentLevel);
        }
    }
    public void SaveButtonClicked()
    {
        SavePet();
        uiManager.ShowPopup("게임이 저장되었습니다.");
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
    }

}
