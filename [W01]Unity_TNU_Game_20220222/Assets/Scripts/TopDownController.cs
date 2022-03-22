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
        private float h;
        private float V;
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
            Move();
            Rotate();
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
            //float h =***;- 區域變數:僅能在此結構(大括號)內存取 
            h = Input.GetAxis("Horizontal");
            //print()輸出:將()內訊息輸出至Unity Console 面板(Ctrl + shift + C)
            //print("水平倫向值:" + h);
            //--Vertical 垂直倫向
            V = Input.GetAxis("Vertical");
            //print("垂直倫向值:" + V);

        }
        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            //使用非靜態資料 non-static
            //語法:欄位名稱.非靜態屬性名稱
            rig.velocity = new Vector2(h, V)*speed; //剛體.加速器 = 二維向量*速度
            //水平or垂直 不等於0 ||=or
            ani.SetBool(parameterRun, h != 0 || V !=0); //動畫控制器.設定布林值(參數 , 布林值) - h不等於0 -只要水平軸不=0 就勾選 跑步參數

        }

        /// <summary>
        /// 旋轉
        /// 往右角度Y=0
        /// 往左角度Y=180
        /// </summary>
        private void Rotate() {
            //三元運算子
            //布林值 ? 布林值為true :布林值為 false
            //h > 0 ? 0 : 180 =當水平值 >=0 值為0,否則值為180
            transform.eulerAngles = new Vector3(0, h >= 0 ? 0 : 180, 0);
        }

        #endregion 方法結束
    }

}
