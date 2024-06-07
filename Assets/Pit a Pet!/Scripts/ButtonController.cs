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
        yield return new WaitForSeconds(3f); // 3�� ���
        animator.SetBool("Click", false); // 3�� �� "Click" �Ķ���͸� false�� �����Ͽ� default �ִϸ��̼��� ���
    }
}
