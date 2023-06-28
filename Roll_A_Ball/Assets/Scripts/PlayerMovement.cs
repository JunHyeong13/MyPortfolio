using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 m_Movement;
    Animator m_Animator;
    public float turnSpeed= 20f;
    // Set-up the player wants to rotate
    Quaternion m_Rotation = Quaternion.identity;
    Rigidbody m_rb;
    AudioSource m_AudioSource;

   //public float level;
    void Start()
    {
        m_Animator = GetComponent<Animator>();   
        m_rb = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Input the player movement setting
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        // Also using 'Set' to set-up the player movement
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWaliking", isWalking);

        if(isWalking)
        {
            if(!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }


        // Set-up the player wants to go forward direction
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    void OnAnimatorMove()
    {
        // deltaPosition means '루트 모션으로 인한 프레임당 위치의 이동량'. 
        m_rb.MovePosition(m_rb.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_rb.MoveRotation(m_Rotation);
    }
}
