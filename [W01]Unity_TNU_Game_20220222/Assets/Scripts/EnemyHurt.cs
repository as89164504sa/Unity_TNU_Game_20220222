using UnityEngine;

namespace Yuemo
{
    ///
    ///敵人受傷,彈出傷害
    ///
    ///EnemyHurt：HurtSystem -繼承
    ///EnemyHurt：子類別
    ///HurtSyster：父類別
  public class EnemyHurt : HurtSyster
  {
        [SerializeField,Header("敵人資料")]
        private DateAnim date;

        [SerializeField,Header("畫布傷害數值")]
        private GameObject goCanvasHurt;

        [SerializeField, Header("經驗值道具")]
        private GameObject goExp;


        private string parameterDead ="觸發死亡";
        private Animator ani;
        private EnemySystem enemySystem;

        private void Awake()
        {
            ani = GetComponent<Animator>();
            enemySystem = GetComponent<EnemySystem>();

            hp = date.hp;
        }

        //override 覆寫，覆寫覆類別有 virtual 的成員

        public override void GetHurt(float damage)
        {
            base.GetHurt(damage);

            GameObject temp =Instantiate(goCanvasHurt,transform.position,Quaternion.identity);
            temp.GetComponent<HurtNumberEffect>().UpdateDamage(damage);
        }

        protected override void Dead()
        {
            base.Dead();

            ani.SetTrigger(parameterDead);

            enemySystem.enabled =false;
            GetComponent<Collider2D>().enabled =false;
            Destroy(gameObject,1.5f);

            DropExp();

         }

        ///掉落經驗值道具
        ///
        private void DropExp()
        {
            float random = Random.value;

            if (random <= date.expDropProbability)
            {
                GameObject tempExp =Instantiate(goExp, transform.position, Quaternion.identity);
                tempExp.AddComponent<Exp>().typeExp = date.typeExp;
            }

        }



  }
    

}
