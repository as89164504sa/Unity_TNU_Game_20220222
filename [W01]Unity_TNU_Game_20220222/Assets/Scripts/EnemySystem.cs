using UnityEngine;


namespace Yuemo
{
    ///
    ///�ĤH�t��(�B�̼ĤH�欰)
    ///1.�l�ܪ��a
    ///2.����
    ///
    ///

    public class EnemySystem : MonoBehaviour
    {
        [SerializeField, Header("�ĤH���")]
        private DateAnim date;

        [SerializeField, Header("���a����W��")]
        private string namePlayer = "Skeleton Idle_0";//���W���a�W��

        private Transform traPlayer;

        private void Awake()
        {
            //���a�����ܧ� = �C������.�M��(���a����W��).�ܧ�
            traPlayer = GameObject.Find(namePlayer).transform;

            //�{�Ѵ��� Lerp
           /** float result = Mathf.Lerp(0, 10, 0.5f);
            print("0 & 10 ��0.5���ȡG" + result);

            float result7 = Mathf.Lerp(0, 10, 0.7f);
            print("0 & 10 ��0.7���ȡG" + result);
           */

          
        }

        private void Update()
        {
            MoveToPlayer();
        }

        ///
        ///1.���ؼЪ��a���󲾰�
        ///
        private void MoveToPlayer()
        {
            Vector3 posEnemy = transform.position;
            Vector3 posPlayer = transform.position;

            transform.position = Vector3.Lerp(posEnemy, posPlayer, 0.5f * date.speed * Time.deltaTime);

            //y�ھڼĤH�P���aX�y�нվ�
            //�ĤHx�j�� ���a�AY 180�_�h 0 
            float y = transform.position.x > traPlayer.position.x ? 180 : 0 ;
            transform.eulerAngles = new Vector3(0, y, 0);
        }
    }
}
