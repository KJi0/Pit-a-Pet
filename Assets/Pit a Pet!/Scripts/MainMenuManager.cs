using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject newGamePopup; // �� �̸� ���� �˾�
    public InputField petNameInput; // �� �̸� �Է� �ʵ�
    public PetManager petManager;   // PetManager ����

    void Start()
    {
        newGamePopup.SetActive(false); // ������ �� �˾� ��Ȱ��ȭ
    }

    // 'ó������' ��ư Ŭ�� �� ȣ��� �޼���
    public void OnNewGameButtonClicked()
    {
        newGamePopup.SetActive(true); // �˾� Ȱ��ȭ
    }

    // '�̾��ϱ�' ��ư Ŭ�� �� ȣ��� �޼���
    public void OnContinueButtonClicked()
    {
        petManager.LoadPet(); // ������ ������ �����͸� �ε�
        GameManager.instance.GameStart(); // ���� ����
        SceneManager.LoadScene("MainGameScene"); // ���� ���� ������ ��ȯ
    }

    // �˾��� 'Ȯ��' ��ư Ŭ�� �� ȣ��� �޼���
    public void OnConfirmNameButtonClicked()
    {
        string petName = petNameInput.text;
        if (!string.IsNullOrEmpty(petName))
        {
            petManager.CreatePet(petName); // ���ο� �� ����
            newGamePopup.SetActive(false); // �˾� ��Ȱ��ȭ
            GameManager.instance.GameStart(); // ���� ����
            SceneManager.LoadScene("MainGameScene"); // ���� ���� ������ ��ȯ
        }
        else
        {
            // �̸��� ����ִ� ��� ��� �޽����� ǥ���� �� �ֽ��ϴ�.
        }
    }
}
