using UnityEngine;
using System.Collections.Generic;


namespace Yuemo
{
    /// <summary>
    /// 武器系統
    /// 1.儲存玩家擁有的武器資料
    /// 2.根據武器資料生成武器
    /// 3.賦予武器相關資料，飛行速度、攻擊力
    /// </summary>
    public class WeaponSystem : MonoBehaviour
    {
        [SerializeField, Header("武器資料清單")]
        private List<DateWeapon> dateWaponList;

        private int _iDataIndex=0;//
        
        [SerializeField, Header("武器資料")]
        private DateWeapon dateWeapon;

        //[SerializeField, Header("武器武器刪除時間"), Range(0, 5)]
        //private float weaponDestoryTime = 3.5f;

        /*[SerializeField, Header("武器資料2")]
        private DateWeapon dateWeapon2;

        [SerializeField, Header("武器資料3")]
          private DateWeapon dateWeapon3;*/
        /// <summary>
        /// 計時器
        /// </summary>
        private float timer;
        private float T2=0;

        /// <summary>
        /// 繪製圖示
        /// 作用:做編輯器(Unity)繪製各種圖形輔助開發
        /// 不會再執行檔內出現的
        /// </summary>
        private void OnDrawGizmos()
        {
            //1.圖示顏色
            //new color(紅、綠、藍、透明度)值0 - 1
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            //2.繪製圖示
            //圖示 的 繪製圓形(中心點，半徑)
            //transform.position + dateWeapon.v2SpawnPoint[0] 角色座標 + 生成位置
            //目的：生成位置會根據角色位置做相對移動
            
            //for 迴圈
            //(初始值；條件；每一次迴圈結束執行區塊)

            for (int i = 0; i < dateWeapon.v2SpawnPoint.Length; i++)
            {
                Gizmos.DrawSphere(transform.position + dateWeapon.v2SpawnPoint[i], 0.1f);

            }
        }

        private void Start()
        {
            //2D物理.忽略圖層碰撞(圖層1，圖層2)
            Physics2D.IgnoreLayerCollision(3, 6);//武器與玩家 不碰撞
            Physics2D.IgnoreLayerCollision(6, 6);//武器與武器 不碰撞
            Physics2D.IgnoreLayerCollision(6, 8);//武器與空氣牆 不碰撞
        }
        private void Update()
        {
            SpawnWeapon();
            SpawnInput();


        }

        ///<summary>
        ///生成武器
        ///每隔武器間隔時間就生成在生成位置上
        /// </summary>
        private void SpawnWeapon()
        {
           /* //print("經過時間:" + timer);
            //如果 計時器 大於等於 間隔時間
            if (timer >= dateWeapon.interval)
            {

                //隨機值 = 隨機.範圍(最小值，最大值) ※整數不包含最大值
                int random = Random.Range(0, dateWeapon.v2SpawnPoint.Length);//取得範圍0-1-2
                //座標
                Vector3 pos = transform.position + dateWeapon.v2SpawnPoint[random];
                //Quaternion 四位元 - 紀錄角度資訊
                //Quaternion.identity 零角度(0,0,0)
                //生成(物件)
                GameObject temp = Instantiate(dateWeapon.goWeapon,pos,Quaternion.identity);
                //暫存武器.取得元件<剛體>().添加推力(方向 * 速度)
                temp.GetComponent<Rigidbody2D>().AddForce(dateWeapon.v3Direction * dateWeapon.speedFly);
                //計時器 歸零
                timer = 0;
            }
            //否則
            else
            {
                //計時器 累加 一個影格的時間
                timer += Time.deltaTime;
            }*/

            if(timer >= dateWaponList[_iDataIndex].interval)
            {
                int iCount=Random.Range(dateWaponList[_iDataIndex].counStart,dateWaponList[_iDataIndex].countmax);
                for(int i=0;i<iCount;i++)
                {
                    //隨機值 = 隨機.範圍(最小值，最大值) ※整數不包含最大值
                    int random = Random.Range(0, dateWaponList[_iDataIndex].v2SpawnPoint.Length);//取得範圍0-1-2
                    //座標
                    Vector3 pos = transform.position + dateWaponList[_iDataIndex].v2SpawnPoint[random];
                    //Quaternion 四位元 - 紀錄角度資訊
                    //Quaternion.identity 零角度(0,0,0)
                    //生成(物件)
                    GameObject temp = Instantiate(dateWaponList[_iDataIndex].goWeapon,pos,Quaternion.identity);
                    //暫存武器.取得元件<剛體>().添加推力(方向 * 速度)
                    temp.GetComponent<Rigidbody2D>().AddForce(dateWaponList[_iDataIndex].v3Direction * dateWaponList[_iDataIndex].speedFly);
                    //刪除物件(遊戲物件,延遲時間)
                    //Destroy(temp, weaponDestoryTime);
                    //取的武器.攻擊力 = 武器資料.攻擊力
                    temp.GetComponent<Weapon>().attack=dateWeapon.attack;
                }
               
                //計時器 歸零
                timer = 0;

                
            }
            
            //否則
            else
            {
                //計時器 累加 一個影格的時間
                timer += Time.deltaTime;
            }

        }
        private void SpawnInput()
        {
            if (Input.GetKeyDown(KeyCode.E) && T2 >= 0.5f)
            {
                _iDataIndex+=1;
                if(_iDataIndex>=dateWaponList.Count)
                {
                    _iDataIndex=0;
                }
                T2=0;

            }
            else
            {
                T2+=Time.deltaTime;
            }

        }

    }
}

