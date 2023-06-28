using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackEffect : MonoBehaviour
{
    public float KnockBack = 0.5f;
    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "South_Wall")
        {
            Vector3 reactVec = transform.position - collision.transform.position;
            StartCoroutine(OnReached(reactVec));
           
            //collision.transform.position += -Vector3.forward * KnockBack;
        }
    }
    IEnumerator OnReached(Vector3 reactVec)
    {


        yield return new WaitForSeconds(0.1f);
        
        reactVec = reactVec.normalized;
        rigid.AddForce(reactVec * 5, ForceMode.Impulse);

    }
}