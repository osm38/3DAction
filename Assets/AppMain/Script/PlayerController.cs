using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �U������p�I�u�W�F�N�g
    [SerializeField] GameObject attackHit = null;
    // �A�j���[�^�[
    Animator animator = null;
    // �U���A�j���[�V�������t���O
    bool isAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        // Animator���擾���ۊ�
        animator = GetComponent<Animator>();
        // �U������p�I�u�W�F�N�g���\��
        attackHit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// �U���{�^���N���b�N�R�[���o�b�N
    /// </summary>
    public void OnAttackButtonClicked()
    {
        if (!isAttack)
        {
            // Animation��isAttack�g���K�[���N��
            animator.SetTrigger("isAttack");
            // �U���J�n
            isAttack = true;
        }
    }

    /// <summary>
    /// �U���A�j���[�V����Hit�C�x���g�R�[��
    /// </summary>
    void Anim_AttackHit()
    {
        Debug.Log("Hit");
        // �U������p�I�u�W�F�N�g��\��
        attackHit.SetActive(true);
    }

    /// <summary>
    /// �U���A�j���[�V�����I���C�x���g�R�[��
    /// </summary>
    void Anim_AttackEnd()
    {
        Debug.Log("End");
        // �U������p�I�u�W�F�N�g���\��
        attackHit.SetActive(false);
        // �U���I��
        isAttack = false;
    }
}
