using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] Slider bgmslider;
    AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        bgm=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bgmslider.value = bgm.time / bgm.clip.length;
    }
}
