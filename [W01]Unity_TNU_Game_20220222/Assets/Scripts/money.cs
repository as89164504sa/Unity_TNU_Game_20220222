using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{
    [Header("金幣生成範圍最小值")]
    public Vector2 _vRangMin=Vector2.zero;

    [Header("金幣生成範圍最大值")]
    public Vector2 _vRangMax=Vector2.zero;

    [Header("金幣預置物")]
    public GameObject oMoney;

    [Header("生成數量最小值"), Range(1,5)]
    public int _iCountMin;

    [Header("生成數量最大值"), Range(5,20)]
    public int _iCountMax;

    [Header("生成間隔時間")]
    public float _fInstanceTime=1f;

    private float _fTime=0;

    //01.最大值如果>=100
    //02.紀錄目前生成的數量
    //03.停止生成
    private float moneyMax =100;
    private float moneyCur =0;//當前$$$$$$數量

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoneyMoney();
    }

    private void MoneyMoney()
    {
        if(_fTime>=_fInstanceTime && moneyCur < moneyMax)
        {
            int iRange=Random.Range(_iCountMin,_iCountMax);//這個隨機數是每次會增加的金幣數量
            moneyCur+=iRange;
            //在這邊，讓moneyMin加上上述的隨機數
            for(int i=0;i<iRange;i++)
            {
                Vector2 vNewPos=new Vector2(Random.Range(_vRangMin.x,_vRangMax.x),Random.Range(_vRangMin.y,_vRangMax.y));
                Instantiate(oMoney,vNewPos,Quaternion.identity);
            }
            _fTime=0;

        }
        else
        {
            _fTime+=Time.deltaTime;
        }

        

    }
}
