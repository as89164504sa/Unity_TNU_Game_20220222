using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destry : MonoBehaviour
{
    //我是刪除

    [Header("刪除時間")]
    public float _fDelete=0.3f;

    void Start()
    {
        Destroy(gameObject,_fDelete);
    }
   
}
