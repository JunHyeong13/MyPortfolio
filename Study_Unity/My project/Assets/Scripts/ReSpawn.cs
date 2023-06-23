using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    // Ground  ������Ʈ �Ʒ� �ڽ� ������Ʈ 
    public GameObject rangeObj;
    BoxCollider rangeCollider;
    public GameObject item;

    private void Awake()
    {
        rangeCollider = rangeObj.GetComponent<BoxCollider>();
    }

    // ���� �÷��̰� ���۵Ǿ��� ��, Coroutine ������ ���۵� �� �ֵ��� ��.
    private void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }

    // Coruotine ������ ���ؼ� Spawn��Ŵ
    IEnumerator RandomRespawn_Coroutine()
    {
        while(true)
        {
            // 1�� ���� ��ٸ� �� �ֵ��� ��.
            yield return new WaitForSeconds(1f);

            // ������ ������ �������� ReturnPosition ������ ���� �Ҵ�.
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
