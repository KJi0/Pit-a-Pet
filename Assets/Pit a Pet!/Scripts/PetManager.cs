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

    // �� ���� �� �ʱ�ȭ
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

    // �ֱ������� ���� ����
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

    // �� ���� �ڵ� ������Ʈ ����
    public void StartStatusUpdate()
    {
        InvokeRepeating("DecreaseStatusPeriodically", 30, 30); // 30�� �Ŀ� ȣ��, 30�ʸ��� ���� ����
    }

    // '���ֱ�' ��ư Ŭ�� �� ȣ��� �޼���
    public void FeedButtonClicked()
    {
        if (currentPet != null)
        {
            currentPet.Feed(5.0f); // �������� 5��ŭ ����
            uiManager.ShowPopup("�������� +5 �����Ͽ����ϴ�."); // �˾� ǥ��
            UpdateUI();
        }
    }

    // '����ֱ�' ��ư Ŭ�� �� ȣ��� �޼���
    public void PlayButtonClicked()
    {
        if (currentPet != null)
        {
            if (currentPet.energy <= 30)
            {
                uiManager.ShowPopup($"���� ü���� �����մϴ�.");
            }
            else
            {
                currentPet.Play(10.0f); // �ູ���� 10��ŭ ����
                uiManager.ShowPopup("�ູ���� +10 �����Ͽ����ϴ�."); // �˾� ǥ��
                UpdateUI();
            }
        }
    }

    // '�ı�' ��ư Ŭ�� �� ȣ��� �޼���
    public void WashButtonClicked()
    {
        if (currentPet != null)
        {
            currentPet.Wash(20.0f); // û�ᵵ 20 ����, ������ 20 ����
            uiManager.ShowPopup("û�ᵵ�� +20 �����Ͽ����ϴ�."); // �˾� ǥ��
            UpdateUI();
        }
    }

    // 'ġ���ϱ�' ��ư Ŭ�� �� ȣ��� �޼���
    public void CareButtonClicked()
    {
        if (currentPet != null)
        {
            currentPet.Care(30.0f); // ������, û�ᵵ, ������ 30 ����
            uiManager.ShowPopup("������, û�ᵵ, �������� +30 �����Ͽ����ϴ�."); // �˾� ǥ��
            UpdateUI();
        }
    }

    // �� ���� ���� �� �ε�
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
        // ������ ������Ʈ�Ǹ� UI�� ������Ʈ�մϴ�.
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
        uiManager.ShowPopup("������ ����Ǿ����ϴ�.");
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
    }

}
