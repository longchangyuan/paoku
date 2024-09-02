using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgControl : MonoBehaviour
{
    // Start is called before the first frame update

    //将私有属性显示在组件中
    [SerializeField]
    private float _speed = 0.2f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControl.IsDie) return;
        //遍历子物体
        foreach (Transform child in transform)
        {
            //获取子物体位置
            Vector3 pos = child.position;
            //移动子物体
            pos.x -= _speed * Time.deltaTime;
            if (pos.x <= -7.15f)
            {
                pos.x = 7.15f;
            }
            child.position = pos;

        }

    }
}
