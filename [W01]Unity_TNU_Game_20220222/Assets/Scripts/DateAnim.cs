
using UnityEngine;

namespace Yuemo
{
    /// <summary>
    /// 敵人資料
    /// 1.移動速度
    /// 2.攻擊力
    /// 3.攻擊冷卻
    /// 4.血量
    /// 5.掉落經驗值機率
    /// 6.掉落經驗值大小-小中大(藍綠紅)
    /// </summary>
    [CreateAssetMenu(menuName ="Yuemo/Date Anime",fileName ="Date Anime")]
    public class DateAnim : ScriptableObject
    {
        [Header("移動速度"), Range(0, 3500)]
        public float speed = 30;

        [Header("攻擊力"), Range(0, 500)]
        public float attack=10;

        [Header("攻擊冷卻"), Range(0, 5)]
        public float cd = 3.5f;

        [Header("血量"), Range(0, 5000)]
        public float hp = 100;

        [Header("掉落經驗機率"), Range(0, 1)]
        public float expDropProbability = 100;

        [Header("掉落經驗類型")]
        public TypeExp typeExp;

        [Header("靠近目標後停止距離"),Range(0,30)]
        public float stopDistance = 3;
    }
    /// <summary>
    /// 經驗值類型
    /// </summary>
    public enum TypeExp
    {
        smallmmiddle,big
    }

}
