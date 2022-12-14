using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public GameObject KumohMark;

    #region Fields
    #endregion Fields

    #region Members
    private Animator m_Animator;

    #endregion Members


    #region Methods
    void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void EnterNextScene()
    {
        // 애니메이션 재생
        m_Animator.Play("Bubble");
    }

    public void OnEnterNextScene()
    {
        // 애니메이션이 끝난 후 처리
        KumohMark.SetActive(false);
    }

    #endregion Methods
}
