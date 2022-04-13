using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public int WaveCount = 1;
    public int waveCountNext;
    [SerializeField] Transform pointer;
    [SerializeField] List<GameObject> items;

    [SerializeField] item_Data itemdata;
    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            items.Add(transform.GetChild(i).gameObject);
        }
        // pointer = GameObject.Find("Pointer").transform;
        waveCountNext = WaveCount + 1;

    }
    void Start()
    {
        StartCoroutine(nameof(WaveCountCoroutine));
        StartCoroutine(nameof(StartBornCoroutine));
        for (int i = 0; i < itemdata.itemDatas[1].statetable.Length; i++)
        {
           // print("进入循环");
            if (itemdata.itemDatas[1].statetable[i] == 1)
            {
                //print("进入条件");
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
