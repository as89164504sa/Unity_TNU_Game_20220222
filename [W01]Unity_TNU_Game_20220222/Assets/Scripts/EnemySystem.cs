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

        [SerializeField,Header("�����ʵe�Ѽ�")]
        private string parameterAttack ="Ĳ�o����";

        private Transform traPlayer;
        ///
        ///�������p�ɾ�
        ///
        private float timeAttack;
        private Animator ani;

        private void Awake()
        {
            ani = GetComponent<Animator>();
            //���a�����ܧ� = �C������.�M��(���a����W��).�ܧ�
            traPlayer = GameObject.Find(namePlayer).transform;

            //�{�Ѵ��� Lerp
           /** float result = Mathf.Lerp(0, 10, 0.5f);
            print("0 & 10 ��0.5���ȡG" + result);

            float result7 = Mathf.Lerp(0, 10, 0.7f);
            print("0 & 10 ��0.7���ȡG" + result);
           */
    
        }
        private void Start()
        {
            //2D���z.�����ϼh�I��(�ϼh1�A�ϼh2)
            Physics2D.IgnoreLayerCollision(7, 9);//�D��P�Ǫ� ���I��
        }        
        private void Update()
        {
            MoveToPlayer();
        }

        private void OnDrawGizmos()
        {

            Gizmos.color =new Color(1,0.3f,0,0.2f);
            Gizmos.DrawSphere(transform.position,date.stopDistance);
        }

        ///
        ///1.���ؼЪ��a���󲾰�
        ///
        private void MoveToPlayer()
        {
            Vector3 posEnemy = transform.position;
            Vector3 posPlayer = traPlayer.position;

            float dis =Vector3.Distance(posEnemy,posPlayer);
            //print("<color=yellow>�Z���G"+dis+"</color>");

            //�p�G �Z�� �p�� ����Z�� �N�B�z....
            if(dis<date.stopDistance)
            {
                Attack();

            }
            else
            {
             transform.position = Vector3.Lerp(posEnemy, posPlayer, 0.2f * date.speed * Time.deltaTime);

            //y�ھڼĤH�P���aX�y�нվ�
            //�ĤHx�j�� ���a�AY 180�_�h 0 
            float y = transform.position.x > traPlayer.position.x ? 180 : 0 ;
            transform.eulerAngles = new Vector3(0, y, 0);
            }
        }

        ///
        ///����
        ///
        private void Attack()
        {
            if (timeAttack < date.cd)
            {
                timeAttack += Time.deltaTime;
                //print("<color=red>�����p�ɾ��G"+timeAttack+"</color>");
            }
            else
            {
                ani.SetTrigger(parameterAttack);
                timeAttack=0;
            }
        }
    }
}
