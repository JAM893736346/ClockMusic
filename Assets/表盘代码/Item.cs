using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Item : MonoBehaviour
{

    bool IsClick = false;
    //输入正确的图片显示
    [SerializeField] Sprite Trueimage;
    //输入错误的图片显示
    [SerializeField] Sprite Falseimage;
    //获得图片组件
    SpriteRenderer idlesprit;
    //指针
    [SerializeField] GameObject pointer;
    Animator animator;
    private void Awake()
    {
        idlesprit = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        idlesprit.sprite = Trueimage;
        animator.Play("itemAnimation");
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    /// <summary>
    /// 指针进入开始执行协程
    /// </summary>
    public void StartCoroutine()
    {
        StartCoroutine(nameof(GetSpaceCoroutine));
    }
    /// <summary>
    /// 指针退出执行携程
    /// </summary>
    public void StopCoroutine()
    {
        //如果状态为未点击则更改图片的样式
        if (IsClick == false)
        {
            idlesprit.sprite = Falseimage;
        }
        StopCoroutine(nameof(GetSpaceCoroutine));
    }
    /// <summary>
    /// 指针和点数重叠的逻辑处理
    /// </summary>
    /// <returns></returns>
    IEnumerator GetSpaceCoroutine()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && gameObject.activeSelf)
            {
                IsClick = true;
                //播放伸缩动画
                pointer.GetComponent<bornpoint>().PlayerAnimation();
                gameObject.SetActive(false);
                
            }
            yield return null;
        }
    }
    
}
