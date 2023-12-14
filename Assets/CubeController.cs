using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -12;

    //消滅位置
    private float deadLine = -10;

    //衝突音
    public AudioClip CollisionSound;
    private AudioSource ASComponent;
    //衝突音を出力済みか否か
    private bool isCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        ASComponent = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら破棄する
        if(this.transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //このキューブが衝突音を出力していない場合、衝突オブジェクトの判定に進む
        if(this.isCollided == false)
        {
            //衝突したオブジェクトがキューブか地面の場合、衝突音を再生する
            if(collision.gameObject.tag == "CubeTag" || collision.gameObject.tag == "GroundTag")
            {
                //再生
                ASComponent.PlayOneShot(CollisionSound);
            }

            //衝突音の出力済みをTrueにする
            this.isCollided = true;
        }
    }
}
