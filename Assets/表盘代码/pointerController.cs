using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointerController : MonoBehaviour
{
    /// <summary>
    /// 指针进入后开始逻辑处理
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("point"))
        {
            other.GetComponent<Item>().StartCoroutine();
        }
    }
    /// <summary>
    /// 指针出来后停止逻辑处理
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit2D(Collider2D other) {
       if(other.CompareTag("point"))
        {
            other.GetComponent<Item>().StopCoroutine();
        }   
    }

}
