using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour {

    //public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        
        if (Input.GetButtonDown("Jump"))
        {
            OnJumpInputDown();
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            OnPlayerAttack();
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
    public Animator m_anim;
    [SerializeField]
    private bool below = false;
    [SerializeField]
    private bool isDoubleJumping;

    public GameObject prefabsBullet;
    public Transform m_trfPositionSpawnBullet;
    // nhấn xuống
    public void OnJumpInputDown()
    {
        if (below)
        {
            ChangeState(animationState.jump);
            moveDirection.y = jumpSpeed;
            isDoubleJumping = false;
            below = false;
        }
        else if (!below && isDoubleJumping == false)
        {
            ChangeState(animationState.doubleJump);
            moveDirection.y = jumpSpeed;
            isDoubleJumping = true;
        }
    }
    animationState m_currentState = animationState.none;
    public void ChangeState(animationState _state)
    {
        if(m_currentState!= animationState.none)
        {
            m_anim.ResetTrigger(m_currentState.ToString());
        }

        m_currentState = _state;        
        m_anim.SetTrigger(_state.ToString());
    }

    private void OnPlayerAttack()
    {
        if (controller.isGrounded)
        {
            ChangeState(animationState.attack);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        below = true;
        ChangeState(animationState.move);
    }

    [ContextMenu("fire")]
    public void OnFire()
    {
        if(prefabsBullet)
        {
            GameObject bullet = Instantiate(prefabsBullet) as GameObject;
            bullet.transform.position = m_trfPositionSpawnBullet.position;
            bullet.GetComponent<CBulletMove>().SetUp();
        }
    }
}
public enum animationState
{
    move,jump,die, doubleJump,none,attack
}
