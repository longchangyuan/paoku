
using UnityEngine;

public class GroundControl : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.5f;

    public GameObject[] randomGround;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControl.IsDie) return;
        foreach (Transform child in transform)
        {
            Vector3 pos = child.position;
            pos.x -= _speed * Time.deltaTime;
            if (pos.x < -7.55f)
            {
                //创建新的地面
                Transform newTransform = Instantiate(randomGround[Random.Range(0, randomGround.Length)], transform).transform;

                //获取新地面位置
                Vector2 newPos = newTransform.transform.position;
                newPos.x = 7.55f;
                newTransform.transform.position = newPos;

                //销毁旧的地面
                Destroy(child.gameObject);

            }
            child.position = pos;

        }

    }
}
