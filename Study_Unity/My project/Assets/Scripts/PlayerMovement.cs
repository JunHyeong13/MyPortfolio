using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //public GameObject player;
    private Rigidbody m_rigidbody;
    public float MoveSpeed = 10f;
    public float Jump = 10f;
    private float movementx;
    private float movementy;
    bool isJumping;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        isJumping = false;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementx = movementVector.x;
        movementy = movementVector.y;
    }

    // Make a player jump on the plane
    void playerJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!isJumping)
            {
                m_rigidbody.AddForce(Vector3.up * Jump, ForceMode.Impulse);
            }
            else
            {
                Debug.Log("Jump Function is malfunctioned!");
                return;
            }
        }
    }


    void FixedUpdate()
    {
        // movement �ʵ忡 x,y �� ���� �־���. 
        Vector3 movement = new Vector3(movementx, 0.0f, movementy);
        m_rigidbody.AddForce(movement * MoveSpeed);
        playerJump();
    }

    private void OnTriggerEnter(Collider other)
    {
        // ������ tag�� �ٸ� ������Ʈ�� �ε����� ���,�ν�X
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }

        // ���� ��� �ִ� ���� �ƴ϶��, ������ ��� ���� ���ϵ��� ��.
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
