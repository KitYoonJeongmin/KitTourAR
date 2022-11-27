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
        // �ִϸ��̼� ���
        m_Animator.Play("Bubble");
    }

    public void OnEnterNextScene()
    {
        // �ִϸ��̼��� ���� �� ó��
        KumohMark.SetActive(false);
    }

    #endregion Methods
}
