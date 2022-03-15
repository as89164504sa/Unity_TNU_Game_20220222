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
            float h = Input.GetAxis("Horizontal");
            //print()��X:�N()���T����X��Unity Console ���O(Ctrl + shift + C)
            print("�����ۦV��:" + h);
            //--Vertical �����ۦV
            float V = Input.GetAxis("Vertical");
            //print("�����ۦV��:" + V);

        }

        #endregion ��k����
    }

}
