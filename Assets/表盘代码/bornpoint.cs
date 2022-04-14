using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bornpoint : MonoBehaviour
{
    //指针旋转速度
    [SerializeField] float Speed = 10;
    WaitForSeconds waitForSeconds;
    //指针停留时间
    [SerializeField] float time = 0.5f;
    Animator animator;
    private void Awake()
    {
        waitForSeconds = new WaitForSeconds(time);
        animator = GetComponent<Animator>();
    }
    void OnEnable()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        StartCoroutine(nameof(pointerCoroutine));
    }
    /// <summary>
    /// 指针旋转协程
    /// </summary>
    /// <returns></returns>
    IEnumerator pointerCoroutine()
    {
        while (true)
        {
            yield return waitForSeconds;
            transform.Rotate(new Vector3(0, 0, Speed));

        }
    }
    //播放指针缩放动画
    public void PlayerAnimation()
    {
        animator.Play("Scale");
    }
}
