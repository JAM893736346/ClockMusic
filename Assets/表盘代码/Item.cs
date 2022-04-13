using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Item : MonoBehaviour
{

    bool IsClick = false;
    [SerializeField] Sprite Trueimage;
    [SerializeField] Sprite Falseimage;
    SpriteRenderer idlesprit;
    [SerializeField] GameObject pointer;
    //  public static UnityAction ButtonEvent = delegate { };
    Animator animator;
    private void Awake()
    {
        idlesprit = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        //pointer = GameObject.Find("Pointer");
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
    // Update is called once per frame
    public void StartCoroutine()
    {
        StartCoroutine(nameof(GetSpaceCoroutine));
    }
    public void StopCoroutine()
    {
        if (IsClick == false)
        {
            idlesprit.sprite = Falseimage;
        }
        StopCoroutine(nameof(GetSpaceCoroutine));
    }
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
