using UnityEngine;


namespace Yuemo
{
    ///
    ///敵人系統(處裡敵人行為)
    ///1.追蹤玩家
    ///2.攻擊
    ///
    ///

    public class EnemySystem : MonoBehaviour
    {
        [SerializeField, Header("敵人資料")]
        private DateAnim date;

        [SerializeField, Header("玩家物件名稱")]
        private string namePlayer = "Skeleton Idle_0";//場上玩家名稱

        [SerializeField,Header("攻擊動畫參數")]
        private string parameterAttack ="觸發攻擊";

        private Transform traPlayer;
        ///
        ///攻擊的計時器
        ///
        private float timeAttack;
        private Animator ani;

        private void Awake()
        {
            ani = GetComponent<Animator>();
            //玩家物件變形 = 遊戲物件.尋找(玩家物件名稱).變形
            traPlayer = GameObject.Find(namePlayer).transform;

            //認識插值 Lerp
           /** float result = Mathf.Lerp(0, 10, 0.5f);
            print("0 & 10 的0.5插值：" + result);

            float result7 = Mathf.Lerp(0, 10, 0.7f);
            print("0 & 10 的0.7插值：" + result);
           */
    
        }
        private void Start()
        {
            //2D物理.忽略圖層碰撞(圖層1，圖層2)
            Physics2D.IgnoreLayerCollision(7, 9);//道具與怪物 不碰撞
        }        
        private void Update()
        {
            MoveToPlayer();
        }

        private void OnDrawGizmos()
        {

            Gizmos.color =new Color(1,0.3f,0,0.2f);
            Gizmos.DrawSphere(transform.position,date.stopDistance);
        }

        ///
        ///1.往目標玩家物件移動
        ///
        private void MoveToPlayer()
        {
            Vector3 posEnemy = transform.position;
            Vector3 posPlayer = traPlayer.position;

            float dis =Vector3.Distance(posEnemy,posPlayer);
            //print("<color=yellow>距離："+dis+"</color>");

            //如果 距離 小於 停止距離 就處理....
            if(dis<date.stopDistance)
            {
                Attack();

            }
            else
            {
             transform.position = Vector3.Lerp(posEnemy, posPlayer, 0.2f * date.speed * Time.deltaTime);

            //y根據敵人與玩家X座標調整
            //敵人x大於 玩家，Y 180否則 0 
            float y = transform.position.x > traPlayer.position.x ? 180 : 0 ;
            transform.eulerAngles = new Vector3(0, y, 0);
            }
        }

        ///
        ///攻擊
        ///
        private void Attack()
        {
            if (timeAttack < date.cd)
            {
                timeAttack += Time.deltaTime;
                //print("<color=red>攻擊計時器："+timeAttack+"</color>");
            }
            else
            {
                ani.SetTrigger(parameterAttack);
                timeAttack=0;
            }
        }
    }
}
