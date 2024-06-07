using System.Collections;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    public void OnFeedButtonClicked()
    {
        animator.SetBool("Click", true);
        StartCoroutine(ResetClickParameter());
    }
    public void OnPlayButtonClicked()
    {
        animator.SetBool("Click", true);
        StartCoroutine(ResetClickParameter());
    }
    public void OnWashButtonClicked()
    {
        animator.SetBool("Click", true);
        StartCoroutine(ResetClickParameter());
    }
    public void OnCareButtonClicked()
    {
        animator.SetBool("Click", true);
        StartCoroutine(ResetClickParameter());
    }

    private IEnumerator ResetClickParameter()
    {
        yield return new WaitForSeconds(3f); // 3초 대기
        animator.SetBool("Click", false); // 3초 후 "Click" 파라미터를 false로 설정하여 default 애니메이션을 재생
    }
}
