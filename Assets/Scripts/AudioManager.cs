using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager Instance;

    private AudioSource player;
    void Start()
    {
        Instance = this;
        player = GetComponent<AudioSource>();

    }



    public void playAudio(string name)
    {
        //通过名称获取音频片段
        AudioClip clip = Resources.Load<AudioClip>(name);
        if (!clip)
        {
            Debug.LogError("找不到音频片段" + name);
            return;
        }
        //播放音频片段
        Debug.Log(clip.name);
        player.PlayOneShot(clip);

    }


}
