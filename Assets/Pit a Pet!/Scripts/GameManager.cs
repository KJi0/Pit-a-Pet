using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("#Game Control")]
    public bool isLive;
    public PetManager petManager;

    void Awake()
    {
        instance = this;
    }

    public void GameStart()
    {
        isLive = true;
        AudioManager.instance.PlayBgm(true);

        if (petManager != null)
        {
            petManager.StartStatusUpdate(); // 펫의 자동 상태 업데이트 시작
        }
    }

    public void GameEnd()
    {
        AudioManager.instance.PlayBgm(false);
    }
}
