using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrinfScript : MonoBehaviour
{
    [SerializeField] float Speed = 10;
    WaitForSeconds waitForSeconds;
    [SerializeField] float time = 0.5f;
    public item_Data items;
    public int wave = 0;
    float wavenexttime;
    float wavetime = 0;
    int statetable_count = 0;
    public int[] statetable = new int[36];

    public AudioSource bgm;
    public Slider bgmslider;

    private void Awake()
    {
        Array.Clear(statetable, 0, statetable.Length - 1);
        waitForSeconds = new WaitForSeconds(time);
        wavenexttime = wavetime;
    }
    void Start()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        StartCoroutine(nameof(pointerCoroutine));
        StartCoroutine(nameof(StatetAction));

    }
    private void Update()
    {
        //音乐进度条
        OnClick();
        bgmslider.value = bgm.time / bgm.clip.length;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (statetable[statetable_count] != 1)
            {
                statetable[statetable_count] = 1;
            }
        }
    }
    /// <summary>
    /// 游戏暂停
    /// </summary>
    void OnClick()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (bgm.isPlaying)
            {
                StopCoroutine(nameof(pointerCoroutine));
                bgm.Pause();
            }
            else
            {
                bgm.Play();
                StartCoroutine(nameof(pointerCoroutine));
                
            }
        }
    }
    /// <summary>
    /// 指针索引动态更新
    /// </summary>
    /// <returns></returns>
    IEnumerator pointerCoroutine()
    {
        while (true)
        {
            yield return waitForSeconds;
            statetable_count += 1;
            statetable_count = statetable_count % 35;
            transform.Rotate(new Vector3(0, 0, Speed));
        }
    }
    /// <summary>
    /// 每经过一轮自动更新
    /// </summary>
    /// <returns></returns>
    IEnumerator StatetAction()
    {
        while (true)
        {
            if (TransformRotation.Instance.GetInspectorRotationValueMethod(transform).z == 0)
            {
                wavetime = wavenexttime;
                ItemData pnode = new ItemData();
                pnode.wave = wave;
                pnode.time = wavetime;
                int[] pnodeInt = new int[statetable.Length];
                for (int i = 0; i < statetable.Length; i++)
                {
                    pnodeInt[i] = statetable[i];
                }
                pnode.statetable=pnodeInt;
                items.itemDatas.Add(pnode);
                wavenexttime = bgm.time;
                wave++;
                Array.Clear(statetable, 0, statetable.Length - 1);
                yield return new WaitForSeconds(0.7f);
            }
            yield return null;
        }

    }
}
