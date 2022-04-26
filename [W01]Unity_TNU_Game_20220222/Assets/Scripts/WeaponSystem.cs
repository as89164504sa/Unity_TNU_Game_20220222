using UnityEngine;
using System.Collections.Generic;


namespace Yuemo
{
    /// <summary>
    /// �Z���t��
    /// 1.�x�s���a�֦����Z�����
    /// 2.�ھڪZ����ƥͦ��Z��
    /// 3.�ᤩ�Z��������ơA����t�סB�����O
    /// </summary>
    public class WeaponSystem : MonoBehaviour
    {
        [SerializeField, Header("�Z����ƲM��")]
        private List<DateWeapon> dateWaponList;

        private int _iDataIndex=0;//
        
        [SerializeField, Header("�Z�����")]
        private DateWeapon dateWeapon;

        //[SerializeField, Header("�Z���Z���R���ɶ�"), Range(0, 5)]
        //private float weaponDestoryTime = 3.5f;

        /*[SerializeField, Header("�Z�����2")]
        private DateWeapon dateWeapon2;

        [SerializeField, Header("�Z�����3")]
          private DateWeapon dateWeapon3;*/
        /// <summary>
        /// �p�ɾ�
        /// </summary>
        private float timer;
        private float T2=0;

        /// <summary>
        /// ø�s�ϥ�
        /// �@��:���s�边(Unity)ø�s�U�عϧλ��U�}�o
        /// ���|�A�����ɤ��X�{��
        /// </summary>
        private void OnDrawGizmos()
        {
            //1.�ϥ��C��
            //new color(���B��B�šB�z����)��0 - 1
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            //2.ø�s�ϥ�
            //�ϥ� �� ø�s���(�����I�A�b�|)
            //transform.position + dateWeapon.v2SpawnPoint[0] ����y�� + �ͦ���m
            //�ت��G�ͦ���m�|�ھڨ����m���۹ﲾ��
            
            //for �j��
            //(��l�ȡF����F�C�@���j�鵲������϶�)

            for (int i = 0; i < dateWeapon.v2SpawnPoint.Length; i++)
            {
                Gizmos.DrawSphere(transform.position + dateWeapon.v2SpawnPoint[i], 0.1f);

            }
        }

        private void Start()
        {
            //2D���z.�����ϼh�I��(�ϼh1�A�ϼh2)
            Physics2D.IgnoreLayerCollision(3, 6);//�Z���P���a ���I��
            Physics2D.IgnoreLayerCollision(6, 6);//�Z���P�Z�� ���I��
            Physics2D.IgnoreLayerCollision(6, 8);//�Z���P�Ů��� ���I��
        }
        private void Update()
        {
            SpawnWeapon();
            SpawnInput();


        }

        ///<summary>
        ///�ͦ��Z��
        ///�C�j�Z�����j�ɶ��N�ͦ��b�ͦ���m�W
        /// </summary>
        private void SpawnWeapon()
        {
           /* //print("�g�L�ɶ�:" + timer);
            //�p�G �p�ɾ� �j�󵥩� ���j�ɶ�
            if (timer >= dateWeapon.interval)
            {

                //�H���� = �H��.�d��(�̤p�ȡA�̤j��) ����Ƥ��]�t�̤j��
                int random = Random.Range(0, dateWeapon.v2SpawnPoint.Length);//���o�d��0-1-2
                //�y��
                Vector3 pos = transform.position + dateWeapon.v2SpawnPoint[random];
                //Quaternion �|�줸 - �������׸�T
                //Quaternion.identity �s����(0,0,0)
                //�ͦ�(����)
                GameObject temp = Instantiate(dateWeapon.goWeapon,pos,Quaternion.identity);
                //�Ȧs�Z��.���o����<����>().�K�[���O(��V * �t��)
                temp.GetComponent<Rigidbody2D>().AddForce(dateWeapon.v3Direction * dateWeapon.speedFly);
                //�p�ɾ� �k�s
                timer = 0;
            }
            //�_�h
            else
            {
                //�p�ɾ� �֥[ �@�Ӽv�檺�ɶ�
                timer += Time.deltaTime;
            }*/

            if(timer >= dateWaponList[_iDataIndex].interval)
            {
                int iCount=Random.Range(dateWaponList[_iDataIndex].counStart,dateWaponList[_iDataIndex].countmax);
                for(int i=0;i<iCount;i++)
                {
                    //�H���� = �H��.�d��(�̤p�ȡA�̤j��) ����Ƥ��]�t�̤j��
                    int random = Random.Range(0, dateWaponList[_iDataIndex].v2SpawnPoint.Length);//���o�d��0-1-2
                    //�y��
                    Vector3 pos = transform.position + dateWaponList[_iDataIndex].v2SpawnPoint[random];
                    //Quaternion �|�줸 - �������׸�T
                    //Quaternion.identity �s����(0,0,0)
                    //�ͦ�(����)
                    GameObject temp = Instantiate(dateWaponList[_iDataIndex].goWeapon,pos,Quaternion.identity);
                    //�Ȧs�Z��.���o����<����>().�K�[���O(��V * �t��)
                    temp.GetComponent<Rigidbody2D>().AddForce(dateWaponList[_iDataIndex].v3Direction * dateWaponList[_iDataIndex].speedFly);
                    //�R������(�C������,����ɶ�)
                    //Destroy(temp, weaponDestoryTime);
                }
               
                //�p�ɾ� �k�s
                timer = 0;

                
            }
            
            //�_�h
            else
            {
                //�p�ɾ� �֥[ �@�Ӽv�檺�ɶ�
                timer += Time.deltaTime;
            }

        }
        private void SpawnInput()
        {
            if (Input.GetKeyDown(KeyCode.E) && T2 >= 0.5f)
            {
                _iDataIndex+=1;
                if(_iDataIndex>=dateWaponList.Count)
                {
                    _iDataIndex=0;
                }
                T2=0;

            }
            else
            {
                T2+=Time.deltaTime;
            }

        }

    }
}

