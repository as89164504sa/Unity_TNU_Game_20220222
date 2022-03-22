using UnityEngine;   // �ޥ� UnityEngine �R�W�Ŷ�(API)


namespace Yuemo //namespace+tap*2 �H�����P�H�s�@�����ͽĬ��
{
    /// <summary>
    /// "///"�۰ʥͦ��C
    /// �W�U�������ⱱ�
    /// ����ʡB�ʵe��s
    /// </summary>
    public class TopDownController : MonoBehaviour  //class=���O(�}��) �W�ٻP�ɦW�����ۦP(�j�p�g�B����Ů�ίS��r��)
    {
        #region ��ơG�O�s�Ҧp���ʳt�סB�ʵe�ѼƦW�٩Τ��󵥸��
        //���y�k:�׹��� ������� ���W��(���w �w�]��);
        //[] �ݩ� Attritube
        //SerializeField �ǦC����� - ���i����(�X�{�b�ݩʭ��O Inspector)
        //Header ���D
        //Range �d��:���ȾA�Ω�ƭ��������,int�Bfloat
        [SerializeField,Header("���ʳt��"),Range(0,500)]
        private float speed = 1.5f;
        private string parameterRun = "�}��_�樫";
        private string parameterDead = "�}��_���`";
        private Animator ani;
        private Rigidbody2D rig;
        private float h;
        private float V;
        #endregion ��Ƶ���

        #region �ƥ�G�{�����J�f(Unity)
        //����ƥ�:����C���ɰ���@���A�B�z��l��
        private void Awake()
        {
            //GetComponent<�x��>() - �x��:����������
            //�ʵe��� ���w ��������<����W��> - �������w����s������
            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();

        }
        //��s�ƥ�:�� 60 FPS(Frame per second)
        //���o��J��ƥi�b���ƥ�B��
        private void Update()
        {
            GetInput();
            Move();
            Rotate();
        }
        #endregion �ƥ󵲧�

        #region ��k�G���������欰�A�Ҧp���ʥ\��B��s�ʵe
        private void GetInput()
        {
            /// <summary>
            /// ���o��J:�����P����
            /// </summary>
            //��k�y�k:�׹��� �Ǧ^������� ��k�W��(�Ѽ�){�{�����e}
            //�ϥ��R�A���
            //�y�k:���O�W��.�R�A��k�W��(�����޼�)
            //Horizontal �����ۦV
            //��:��V���� A - �Ǧ^ -1
            //�k:��V���� D - �Ǧ^ +1
            //float h =***;- �ϰ��ܼ�:�ȯ�b�����c(�j�A��)���s�� 
            h = Input.GetAxis("Horizontal");
            //print()��X:�N()���T����X��Unity Console ���O(Ctrl + shift + C)
            //print("�����ۦV��:" + h);
            //--Vertical �����ۦV
            V = Input.GetAxis("Vertical");
            //print("�����ۦV��:" + V);

        }
        /// <summary>
        /// ����
        /// </summary>
        private void Move()
        {
            //�ϥΫD�R�A��� non-static
            //�y�k:���W��.�D�R�A�ݩʦW��
            rig.velocity = new Vector2(h, V)*speed; //����.�[�t�� = �G���V�q*�t��
            //����or���� ������0 ||=or
            ani.SetBool(parameterRun, h != 0 || V !=0); //�ʵe���.�]�w���L��(�Ѽ� , ���L��) - h������0 -�u�n�����b��=0 �N�Ŀ� �]�B�Ѽ�

        }

        /// <summary>
        /// ����
        /// ���k����Y=0
        /// ��������Y=180
        /// </summary>
        private void Rotate() {
            //�T���B��l
            //���L�� ? ���L�Ȭ�true :���L�Ȭ� false
            //h > 0 ? 0 : 180 =������� >=0 �Ȭ�0,�_�h�Ȭ�180
            transform.eulerAngles = new Vector3(0, h >= 0 ? 0 : 180, 0);
        }

        #endregion ��k����
    }

}
