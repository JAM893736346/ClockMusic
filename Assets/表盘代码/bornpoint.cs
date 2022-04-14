using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bornpoint : MonoBehaviour
{
    //ָ����ת�ٶ�
    [SerializeField] float Speed = 10;
    WaitForSeconds waitForSeconds;
    //ָ��ͣ��ʱ��
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
    /// ָ����תЭ��
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
    //����ָ�����Ŷ���
    public void PlayerAnimation()
    {
        animator.Play("Scale");
    }
}
