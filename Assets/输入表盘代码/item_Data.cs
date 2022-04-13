using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newitem_data",menuName ="CreateData/Create New item_Data")]
public class item_Data : ScriptableObject
{
   public List<ItemData> itemDatas;
}

[System.Serializable]
public class ItemData
{
    public int wave;
    public float time;
    public int[] statetable;
    public ItemData()
    {}
    public ItemData(int wave,float time,int[] statetable)
    {
        this.wave=wave;
        this.time=time;
        this.statetable=statetable;
    }
}
