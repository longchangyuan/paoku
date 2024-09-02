using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //刚体组件
    private Rigidbody2D rigiBody;

    private Animator animator;

    //当前是否碰到地面
    private bool isGround = true;

    public static bool IsDie = false;

    void Start()
    {
        rigiBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
    //跳跃
    public void Jump()
    {
        if (!isGround) return;
        rigiBody.AddForce(Vector2.up * 400);
        //播放跳跃声音
        AudioManager.Instance.playAudio("Jump");
    }

    // Update is called once per frame
    void Update()
    {

        //如果在地面上允许跳跃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //如果是地面
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
            animator.SetBool("IsJump", false);
        }
        else if (collision.gameObject.tag == "Die")
        {
            IsDie = true;
            //播放死亡声音
            AudioManager.Instance.playAudio("BossDie");
            //播放死亡动画
            animator.SetBool("IsDie", true);
            //禁用刚体
            rigiBody.isKinematic = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
            animator.SetBool("IsJump", true);
        }


    }




}
