using UnityEngine;
using UnityEngine.UI;


namespace Yuemo
{

    /// <summary>
    /// ���ź޲z��
    /// ���šB�g��ȸ�Ƥ�����s
    /// </summary>
    public class LevelManger : MonoBehaviour
    {
        [SerializeField, Header("�g���")]
        private Image imgExp;
        [SerializeField, Header("����")]
        private Text textLv;

        private int exp;
        private int expMax;
        private int lv = 1;

        [SerializeField]
        private int[] expNeed;

        [SerializeField, Header("�n�ɯŪ��Z�����")]
        private DateWeapon dateWeapon;

        ///
        ///�]�w�g��ȭn�D
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
        /// ��o�g���
        /// </summary>
        /// <param name="getExp">��o�g���</param>
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
        ///���Ŵ���
        ///
        private void Levelup()
        {
            dateWeapon.attack += 10;
            dateWeapon.interval -= 0.02f;
        }

    }

}