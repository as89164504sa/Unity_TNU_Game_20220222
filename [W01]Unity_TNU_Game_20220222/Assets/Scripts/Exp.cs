using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Yuemo
{

    public class Exp : MonoBehaviour
    {
        [HideInInspector]
        public TypeExp typeExp;
        [HideInInspector]
        public int exp;

        private SpriteRenderer spr;
        private Color colorSmall = new Color(0, 0, 1);
        private Color colorMiddle = new Color(0, 1, 0);
        private Color colorbig = new Color(1, 0, 0);

        private float rangeToPlayer = 2;
        private LayerMask layerPlayer = 1 << 3;
        private Transform traPlayer;
        private float speedToplayer=7.5f;
        private LevelManger levelManger;

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.2f, 0.1f, 0.3f);
            Gizmos.DrawSphere(transform.position, rangeToPlayer);
        }

        private void Awake()
        {
            spr = GetComponent<SpriteRenderer>();
            traPlayer = GameObject.Find("Skeleton Idle_0").transform;
            levelManger = GameObject.Find("等級管理").GetComponent<LevelManger>();
        }

        private void Start()
        {
            SettingType();
        }

        private void Update()
        {
            CheckPlayerInRange();
        }

        ///設定類型
        ///
        private void SettingType()
        {
            switch (typeExp)
            {
                case TypeExp.small:
                    spr.color = colorSmall;
                    exp = 20;
                    break;
                case TypeExp.middle:
                    spr.color = colorMiddle;
                    exp = 80;
                    break;
                case TypeExp.big:
                    spr.color = colorbig;
                    exp = 150;
                    break;



            }
        }

        ///檢查玩家是不是在範圍內
        ///
        private void CheckPlayerInRange()
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position,rangeToPlayer,layerPlayer);

            if (hit)
            {
                Vector3 posExp = transform.position;
                Vector3 posPlayer = traPlayer.position;

                posExp = Vector3.Lerp(posExp, posPlayer, speedToplayer * Time.deltaTime);

                transform.position = posExp;

                if (Vector3.Distance(posExp, posPlayer) < 0.2f)
                {
                    levelManger.GetExp(exp);
                    Destroy(gameObject);
                }

                //print("<color=yellow>玩家進入經驗值道具範圍</color>");
            }
        }

    }
}
