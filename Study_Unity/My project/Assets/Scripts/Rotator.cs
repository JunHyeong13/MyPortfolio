using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Update()
    {
        // 오브젝트가 게임 플레이 진행 상황동안 실시간으로 돌아가는 과정을 보여줌.
        transform.Rotate(new Vector3 (15,30, 45) * Time.deltaTime);
    }
}
