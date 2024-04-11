using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Animator m_UILobbyItem1Animator;
    [SerializeField] private Animator m_UILobbyItem2Animator;
    [SerializeField] private Animator m_UILobbyItem3Animator;
    [SerializeField] private Animator m_UILobbyItem4Animator;
    [SerializeField] private Animator m_UILobbyItem5Animator;
    [SerializeField] private Animator m_SpinAnimator;
    [SerializeField] private Animator m_GiftAnimator;

    [SerializeField] private GameObject m_CommingSoon;

    [SerializeField] private Animator m_CommingAnimator;

    [SerializeField] private Button[] m_CommingSoonButtons;

    private bool m_IsInitialized = false;

    void Start()
    {
        m_CommingSoon.SetActive(false);

        m_CommingSoonButtons[0].onClick.AddListener(() => CommingSool());
        m_CommingSoonButtons[1].onClick.AddListener(() => CommingSool());

        Initialize();
    }

    private  void CommingSool()
    {
        m_CommingSoon.SetActive(true);
        m_CommingAnimator.SetBool("IsComingSoon", true);

        StartCoroutine(CommingSoon());
    }

    IEnumerator CommingSoon()
    {
        yield return new WaitForSeconds(2f);

        m_CommingAnimator.SetBool("IsComingSoon", false);

        yield return new WaitForSeconds(1f);
        m_CommingSoon.SetActive(false);

    }

    void Initialize()
    {
        if (m_UILobbyItem1Animator == null || m_UILobbyItem2Animator == null ||
            m_UILobbyItem3Animator == null || m_UILobbyItem4Animator == null ||
            m_UILobbyItem5Animator == null || m_SpinAnimator == null ||
            m_GiftAnimator == null)
        {
            Debug.LogError("One or more Animator references are not assigned!");
            return;
        }

        SetUIElementsActive(false);
        StartCoroutine(ActivateUIElements());
        m_IsInitialized = true;
    }

    void OnDisable()
    {
        if (m_IsInitialized)
            StopAllCoroutines();
    }

    IEnumerator ActivateUIElements()
    {
        yield return new WaitForSeconds(0f);

        SetUIElementsActive(true);

        yield return new WaitForSeconds(10f);

        SetUIElementsActive(false);
    }

    void SetUIElementsActive(bool isActive)
    {
        SetAnimatorState(m_UILobbyItem1Animator, "UI1", isActive);
        SetAnimatorState(m_UILobbyItem2Animator, "UI2", isActive);
        SetAnimatorState(m_UILobbyItem3Animator, "UI3", isActive);
        SetAnimatorState(m_UILobbyItem4Animator, "UI4", isActive);
        SetAnimatorState(m_UILobbyItem5Animator, "UI5", isActive);
        SetAnimatorState(m_SpinAnimator, "IsSpin", isActive);
        SetAnimatorState(m_GiftAnimator, "IsGift", isActive);
    }

    void SetAnimatorState(Animator animator, string parameterName, bool state)
    {
        if (animator != null)
            animator.SetBool(parameterName, state);
    }
}
