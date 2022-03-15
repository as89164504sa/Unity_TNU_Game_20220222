using UnityEngine;   // 引用 UnityEngine 命名空間(API)


namespace Yuemo //namespace+tap*2 以防不同人製作的產生衝突性
{
    /// <summary>
    /// "///"自動生成。
    /// 上下類型角色控制器
    /// 控制移動、動畫更新
    /// </summary>
    public class TopDownController : MonoBehaviour  //class=類別(腳本) 名稱與檔名完全相同(大小寫、不能空格及特殊字元)
    {
        #region 資料：保存例如移動速度、動畫參數名稱或元件等資料
        //欄位語法:修飾詞 資料類型 欄位名稱(指定 預設值);
        //[] 屬性 Attritube
        //SerializeField 序列化欄位 - 欄位可視化(出現在屬性面板 Inspector)
        //Header 標題
        //Range 範圍:※僅適用於數值類型資料,int、float
        [SerializeField,Header("移動速度"),Range(0,500)]
        private float speed = 1.5f;
        private string parameterRun = "開關_行走";
        private string parameterDead = "開關_死亡";
        private Animator ani;
        private Rigidbody2D rig;
        #endregion 資料結束

        #region 事件：程式的入口(Unity)
        //喚醒事件:播放遊戲時執行一次，處理初始值
        private void Awake()
        {
            //GetComponent<泛型>() - 泛型:指任何類型
            //動畫欄位 指定 取的元件<元件名稱> - 取的指定元件存放於欄位
            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();

        }
        //更新事件:約 60 FPS(Frame per second)
        //取得輸入資料可在此事件處裡
        private void Update()
        {
            GetInput();
        }
        #endregion 事件結束

        #region 方法：較複雜的行為，例如移動功能、更新動畫
        private void GetInput()
        {
            /// <summary>
            /// 取得輸入:水平與垂直
            /// </summary>
            //方法語法:修飾詞 傳回資料類型 方法名稱(參數){程式內容}
            //使用靜態資料
            //語法:類別名稱.靜態方法名稱(對應引數)
            //Horizontal 水平倫向
            //左:方向左鍵 A - 傳回 -1
            //右:方向左鍵 D - 傳回 +1
            float h = Input.GetAxis("Horizontal");
            //print()輸出:將()內訊息輸出至Unity Console 面板(Ctrl + shift + C)
            print("水平倫向值:" + h);
            //--Vertical 垂直倫向
            float V = Input.GetAxis("Vertical");
            //print("垂直倫向值:" + V);

        }

        #endregion 方法結束
    }

}
