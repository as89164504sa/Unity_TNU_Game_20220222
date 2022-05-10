using UnityEngine;
using UnityEngine.UI;
using System.Collections; //引用 系統.集合(資料結構、協同程序，控制時間)

namespace Yuemo
{
    ///
    ///受傷數值效果
    ///淡入淡出、放大縮小、位移
    ///
    public class HurtNumberEffect : MonoBehaviour
    {
        [SerializeField,Header("淡入淡出每一個值"),Range(0,0.3f)]
        private float valueFade=0.1f;
        [SerializeField,Header("放大縮小每一個值"),Range(0,0.1f)]
        private float valueScale=0.001f;
        [SerializeField,Header("位移每一個值"),Range(0,100)]
        private float valueOffset=0.1f;

        private CanvasGroup group;
        private RectTransform rect;
        private Text textDamage;
    // Start is called before the first frame update

        private void Awake()
        {
            textDamage =transform.Find("傷害值").GetComponent<Text>();
        } 
       void Start()
       {
           //啟動協同程序(協同程序方法())
        //StartCoroutine(Test());
        group = GetComponent<CanvasGroup>();
        rect = GetComponent<RectTransform>();

        StartCoroutine(Fade());
        StartCoroutine(Scale());
        StartCoroutine(offset());

        StartCoroutine(Fade(-1,1f));
        StartCoroutine(Scale(-1,1f));
        StartCoroutine(offset(-1,1f));
        
       }

       ///更新傷害值
       ///<param name="getDamage">取得傷害值</param>
       public void UpdateDamage(float getDamage)
       {
           textDamage.text =getDamage.ToString();
       }
       private IEnumerator Test()
       {
           print("我是第一行");

           //讓步 傳回 等待秒數
           yield return new WaitForSeconds(2);

           print("我是第二行");
       }

       //淡入淡出      
       private IEnumerator Fade(float add =1,float wait=0)
       {
           yield return new WaitForSeconds(wait);

           for(int i = 0;i<100;i++)
           {
               group.alpha +=valueFade * add;
               yield return new WaitForSeconds(0.02f);
           }
       }

       //縮放

       private IEnumerator Scale(float add =1,float wait=0)
       {
           yield return new WaitForSeconds(wait);

           for(int i = 0;i<10;i++)
           {
               rect.localScale +=new Vector3(valueScale,valueScale,0)*add;
               yield return new WaitForSeconds(0.02f);
           } 


       }

       //位移

       private IEnumerator offset(float add =1,float wait=0)
       {
           yield return new WaitForSeconds(wait);

           for(int i =0; i<10;i++)
           {
               rect.anchoredPosition+=Vector2.up *valueOffset*add;
               yield return new WaitForSeconds(0.02f);

           }

       }
       
    }

}


