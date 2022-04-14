using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointerController : MonoBehaviour
{
    /// <summary>
    /// ָ������ʼ�߼�����
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("point"))
        {
            other.GetComponent<Item>().StartCoroutine();
        }
    }
    /// <summary>
    /// ָ�������ֹͣ�߼�����
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit2D(Collider2D other) {
       if(other.CompareTag("point"))
        {
            other.GetComponent<Item>().StopCoroutine();
        }   
    }

}
