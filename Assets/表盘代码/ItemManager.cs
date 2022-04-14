using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public int WaveCount = 1;
    public int waveCountNext;
    [SerializeField] Transform pointer;
    //包含的指针集合
    [SerializeField] List<GameObject> items;
    //指针回放的ScriptObject文件
    [SerializeField] item_Data itemdata;
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            items.Add(transform.GetChild(i).gameObject);
        }
        //更新波数逻辑
        waveCountNext = WaveCount + 1;

    }
    void Start()
    {
        StartCoroutine(nameof(WaveCountCoroutine));
        StartCoroutine(nameof(StartBornCoroutine));
        for (int i = 0; i < itemdata.itemDatas[1].statetable.Length; i++)
        {
            if (itemdata.itemDatas[1].statetable[i] == 1)
            {
                if (!items[i].gameObject.activeSelf)
                {
                    items[i].gameObject.SetActive(true);
                }
            }
        }
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    /// <summary>
    /// 即将结束时要将表盘上的指针清除
    /// </summary>
    /// <returns></returns>
    IEnumerator WaveCountCoroutine()
    {
        while (true)
        {
            if (TransformRotation.Instance.GetInspectorRotationValueMethod(pointer).z == -10)
            {
                WaveCount = waveCountNext;
                //清场
                foreach (var item in items)
                {
                    if (item.activeSelf)
                    {
                        item.SetActive(false);
                    }
                }

                yield return new WaitForSeconds(0.7f);
            }
            yield return null;
        }

    }
    /// <summary>
    /// 加载本次表盘上相应位置出现的点数
    /// </summary>
    /// <returns></returns>
    IEnumerator StartBornCoroutine()
    {
        while (!(WaveCount >= itemdata.itemDatas.Count))
        {

            if (TransformRotation.Instance.GetInspectorRotationValueMethod(pointer).z == 0)
            {
                for (int i = 0; i < itemdata.itemDatas[WaveCount].statetable.Length; i++)
                {
                    if (itemdata.itemDatas[WaveCount].statetable[i] == 1)
                    {
                        items[i].gameObject.SetActive(true);
                    }
                    yield return new WaitForSeconds(0.1f);
                }
                waveCountNext++;
            }
            yield return new WaitUntil(() => WaveCount == waveCountNext);
        }

    }

}
