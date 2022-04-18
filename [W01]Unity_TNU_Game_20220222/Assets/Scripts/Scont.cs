using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scont : MonoBehaviour
{
    //我是計分器
    /// <summary>
    /// 計分器
    ///1.碰撞後錢錢消失
    ///2.text+分
    /// </summary>
    public GameObject MM;
    public Text T1;

    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "玩家" )
        {
            Destroy(this.gameObject);
        }
        
    }



    
}
