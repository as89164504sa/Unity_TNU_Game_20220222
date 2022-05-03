using UnityEngine;

namespace Yuemo
{
    ///
    ///敵人受傷,彈出傷害
    ///
    ///EnemyHurt：HurtSystem -繼承
    ///EnemyHurt：子類別
    ///HurtSyster：父類別
  public class EnemyHurt : HurtSyster
  {
    [SerializeField,Header("敵人資料")]
    private DateAnim date;

    private void Awake()
    {
        hp=date.hp;
    }
  }



}
