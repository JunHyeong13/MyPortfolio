using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    // Ground  오브젝트 아래 자식 오브젝트 
    public GameObject rangeObj;
    BoxCollider rangeCollider;
    public GameObject item;

    private void Awake()
    {
        rangeCollider = rangeObj.GetComponent<BoxCollider>();
    }

    // 게임 플레이가 시작되었을 때, Coroutine 구문이 시작될 수 있도록 함.
    private void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }

    // Coruotine 구문을 통해서 Spawn시킴
    IEnumerator RandomRespawn_Coroutine()
    {
        while(true)
        {
            // 1초 정도 기다릴 수 있도록 함.
            yield return new WaitForSeconds(1f);

            // 위에서 형성한 아이템을 ReturnPosition 구문에 값을 할당.
            GameObject instantitem = Instantiate(item, Return_RandomPosition(), Quaternion.identity);
        }
    }

    Vector3 Return_RandomPosition()
    {
        Vector3 originPos = rangeObj.transform.position;
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPos + RandomPostion;
        return respawnPosition;
    }

    void Update()
    {
        
    }
}
