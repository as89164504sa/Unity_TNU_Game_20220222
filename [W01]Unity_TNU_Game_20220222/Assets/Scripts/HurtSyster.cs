
using UnityEngine;

namespace Yuemo
{
    public class HurtSyster : MonoBehaviour
    {
        ///public 公開：所有類別可以存取
        ///private 私人：僅限此類別可以存取
        ///protected 保護：僅限此類別與子類別可存取
      [SerializeField,Header("血量"),Range(0,10000)]
      protected float hp;

    
    ///
    ///受到傷害
    ///
    ///<param name="damage">傷害值</param>
    ///virtual 虛擬 -允許子類別使用 override 覆寫
      public virtual void GetHurt(float damage)
      {
        if (hp<=0) return;
        
        hp -= damage;
        print("<color=pink>收到的傷害："+damage+"</color>");
           
        if(hp<=0) Dead();
    
      }


    ///
    ///死亡
    ///
      protected virtual void Dead()
      {
       hp =0;
       print("<color=pink>角色死亡："+gameObject+"</color>");
      }



    }

}

