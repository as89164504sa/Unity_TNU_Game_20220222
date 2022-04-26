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

        private Transform traPlayer;

        private void Awake()
        {
            //玩家物件變形 = 遊戲物件.尋找(玩家物件名稱).變形
            traPlayer = GameObject.Find(namePlayer).transform;

            //認識插值 Lerp
           /** float result = Mathf.Lerp(0, 10, 0.5f);
            print("0 & 10 的0.5插值：" + result);

            float result7 = Mathf.Lerp(0, 10, 0.7f);
            print("0 & 10 的0.7插值：" + result);
           */

          
        }

        private void Update()
        {
            MoveToPlayer();
        }

        ///
        ///1.往目標玩家物件移動
        ///
        private void MoveToPlayer()
        {
            Vector3 posEnemy = transform.position;
            Vector3 posPlayer = transform.position;

            transform.position = Vector3.Lerp(posEnemy, posPlayer, 0.5f * date.speed * Time.deltaTime);

            //y根據敵人與玩家X座標調整
            //敵人x大於 玩家，Y 180否則 0 
            float y = transform.position.x > traPlayer.position.x ? 180 : 0 ;
            transform.eulerAngles = new Vector3(0, y, 0);
        }
    }
}
