using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �U������p�I�u�W�F�N�g
    [SerializeField] GameObject attackHit = null;
    // �ڒn����pColliderCall
    [SerializeField] ColliderCallReceiver footColliderCall = null;
    // �W�����v��
    [SerializeField] float jumpPower = 20f;
    // �A�j���[�^�[
    Animator animator = null;
    // ���W�b�h�{�e�B
    Rigidbody rb = null;
    // �U���A�j���[�V�������t���O
    bool isAttack = false;
    // �ڒn�t���O
    bool isGround = false;

    // Start is called before the first frame update
    void Start()
    {
        // Animator���擾���ۊ�
        animator = GetComponent<Animator>();
        // Rigidbody�̎擾
        rb = GetComponent<Rigidbody>();
        // �U������p�I�u�W�F�N�g���\��
        attackHit.SetActive(false);
        // FootShepre�̃C�x���g�o�^
        footColliderCall.TriggerStayEvent.AddListener(OnFootTriggerStay);
        footColliderCall.TriggerExitEvent.AddListener(OnFootTriggerExit);
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

    /// <summary>
    /// �W�����v�{�_���R�[���o�b�N
    /// </summary>
    public void OnJumpButtonCliked()
    {
        if (isGround)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    /// <summary>
    /// FootSphere�g���K�[�X�e�C�R�[��
    /// </summary>
    /// <param name="col">�N�������R���C�_�[</param>
    void OnFootTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Ground")
        {
            if(!isGround) isGround = true;
            if (!animator.GetBool("isGround")) animator.SetBool("isGround", true);
        }
    }

    /// <summary>
    /// FootSphere�g���K�[�C�O�W�b�g�R�[��
    /// </summary>
    /// <param name="col">�N�������R���C�_�[</param>
    void OnFootTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Ground")
        {
            isGround = false;
            animator.SetBool("isGround", false);
        }
    }
}
