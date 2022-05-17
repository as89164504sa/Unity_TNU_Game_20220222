using UnityEngine;
using UnityEngine.UI;


namespace Yuemo
{

    /// <summary>
    /// 等級管理器
    /// 等級、經驗值資料介面更新
    /// </summary>
    public class LevelManger : MonoBehaviour
    {
        [SerializeField, Header("經驗值")]
        private Image imgExp;
        [SerializeField, Header("等級")]
        private Text textLv;

        private int exp;
        private int expMax;
        private int lv = 1;

        [SerializeField]
        private int[] expNeed;

        [SerializeField, Header("要升級的武器資料")]
        private DateWeapon dateWeapon;

        ///
        ///設定經驗值要求
        ///
        [ContextMenu("Setting Exp Need")]
        private void SettingExpNeed()
        {
            expNeed = new int[50];

            for (int i = 0; i < expNeed.Length; i++)
            {
                expNeed[i] = (i + 1) * 30;
            }
        }

        /// <summary>
        /// 獲得經驗值
        /// </summary>
        /// <param name="getExp">獲得經驗值</param>
        public void GetExp(int getExp)
        {
            exp += getExp;
            expMax = expNeed[lv - 1];

            while (exp >= expMax)
            {
                lv++;
                exp -= expMax;
                expMax = expNeed[lv - 1];

                Levelup();
            }

            imgExp.fillAmount = (float)exp / (float)expMax;
            textLv.text = lv.ToString();

            
        }

        ///
        ///等級提升
        ///
        private void Levelup()
        {
            dateWeapon.attack += 10;
            dateWeapon.interval -= 0.02f;
        }

    }

}