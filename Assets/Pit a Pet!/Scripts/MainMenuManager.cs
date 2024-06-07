using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject newGamePopup; // 펫 이름 설정 팝업
    public InputField petNameInput; // 펫 이름 입력 필드
    public PetManager petManager;   // PetManager 참조

    void Start()
    {
        newGamePopup.SetActive(false); // 시작할 때 팝업 비활성화
    }

    // '처음부터' 버튼 클릭 시 호출될 메서드
    public void OnNewGameButtonClicked()
    {
        newGamePopup.SetActive(true); // 팝업 활성화
    }

    // '이어하기' 버튼 클릭 시 호출될 메서드
    public void OnContinueButtonClicked()
    {
        petManager.LoadPet(); // 이전에 저장한 데이터를 로드
        GameManager.instance.GameStart(); // 게임 시작
        SceneManager.LoadScene("MainGameScene"); // 메인 게임 씬으로 전환
    }

    // 팝업의 '확인' 버튼 클릭 시 호출될 메서드
    public void OnConfirmNameButtonClicked()
    {
        string petName = petNameInput.text;
        if (!string.IsNullOrEmpty(petName))
        {
            petManager.CreatePet(petName); // 새로운 펫 생성
            newGamePopup.SetActive(false); // 팝업 비활성화
            GameManager.instance.GameStart(); // 게임 시작
            SceneManager.LoadScene("MainGameScene"); // 메인 게임 씬으로 전환
        }
        else
        {
            // 이름이 비어있는 경우 경고 메시지를 표시할 수 있습니다.
        }
    }
}
