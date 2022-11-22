using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    float curDelay = 0;
    float maxDelay = 0.1f;
    //ÃÑ¾Ë »ý¼ºÇÒ °øÀå
    public GameObject bulletFactory;
    //ÃÑ±¸
    public GameObject firePosition;
    void Update()
    {
        curDelay += Time.deltaTime;
        if (curDelay >= maxDelay)
        {
            if (Input.GetButton("Fire1"))
            {
                //ÃÑ¾Ë »ý¼º
                GameObject bullet = Instantiate(bulletFactory);
                bullet.transform.position = transform.position;
                curDelay = 0;
            }
        }
    }
}