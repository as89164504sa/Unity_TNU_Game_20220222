using UnityEngine;

namespace Yuemo
{
    ///
    ///武器：附加在武器上
    ///
  public class Weapon : MonoBehaviour
  {
      [HideInInspector]
      public float attack;

      private void OnCollisionEnter2D(Collision2D collision)
      {
          //如果 碰到物件的標籤 等於 敵人 就 造成傷害
          if(collision.gameObject.tag =="怪物")
          {
              collision.gameObject.GetComponent<HurtSyster>().GetHurt(attack);

          }



      }
  }


}

