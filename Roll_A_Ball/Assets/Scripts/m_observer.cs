using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_observer : MonoBehaviour
{
    public Transform player;
    public GameEnding Ending;
    // 플레이어가 해당하는 범위에 들어와 있는지 확안
    bool m_IsPlayerInRange;


    void OnTriggerEnter(Collider other)
    {
        if(other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(m_IsPlayerInRange)
        {
            // Vector3.up ==> (0,1,0) 값을 의미. 
            // 플레이어의 질량 값을 확인할 수 있도록 해주기 위해 Vector3.Up을 넣어줌.
            Vector3 direction = player.position - transform.position + Vector3.up;
            
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            if(Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.collider.transform == player)
                {
                    Ending.CaughtPlayer();
                }
            }
        }
    }
}
