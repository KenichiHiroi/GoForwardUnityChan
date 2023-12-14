using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //�L���[�u�̈ړ����x
    private float speed = -12;

    //���ňʒu
    private float deadLine = -10;

    //�Փˉ�
    public AudioClip CollisionSound;
    private AudioSource ASComponent;
    //�Փˉ����o�͍ς݂��ۂ�
    private bool isCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        ASComponent = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //�L���[�u���ړ�������
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //��ʊO�ɏo����j������
        if(this.transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //���̃L���[�u���Փˉ����o�͂��Ă��Ȃ��ꍇ�A�Փ˃I�u�W�F�N�g�̔���ɐi��
        if(this.isCollided == false)
        {
            //�Փ˂����I�u�W�F�N�g���L���[�u���n�ʂ̏ꍇ�A�Փˉ����Đ�����
            if(collision.gameObject.tag == "CubeTag" || collision.gameObject.tag == "GroundTag")
            {
                //�Đ�
                ASComponent.PlayOneShot(CollisionSound);
            }

            //�Փˉ��̏o�͍ς݂�True�ɂ���
            this.isCollided = true;
        }
    }
}
