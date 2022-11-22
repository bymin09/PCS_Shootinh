using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //일정시간마다 적을 생성후 EnemyManager위치로 적 이동
    //일정시간 == 생성시간(현재시간, 적 프리펩 필요)
    //1. 시간이 흐르고 2. 현재 시간이 일정시간이 되면 3. 적 생성 4. EnemyManager위치로 이동

    //현재시간
    float currentTime;
    //생성시간
    public float createTime;
    //적 프리펩
    public GameObject enemyFactory;

    //적 생성 시간을 랜덤으로 하고싶어 도라에몽 최소시간과 최대시간

    //최소시간
    float minTime = 1f;
    float maxTime = 5f;
    void Start()
    {
        createTime = Random.Range(minTime, maxTime);    
    }
    void Update()
    {
        //시간이 흐름
        currentTime += Time.deltaTime;
        //만약 현재시간이 생성시간이 되면
        if(currentTime > createTime)
        {
            //적 생성 후 EnemyManager위치로 이동
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;
            currentTime = 0;
            createTime = Random.Range(minTime, maxTime);
        }
    }
}