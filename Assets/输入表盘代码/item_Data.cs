using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newitem_data",menuName ="CreateData/Create New item_Data")]
public class item_Data : ScriptableObject
{
    //表盘上的点数集合
   public List<ItemData> itemDatas;
}

[System.Serializable]
public class ItemData
{
    //波数
    public int wave;
    //时间暂时未用上
    public float time;
    //该波数的状态表0表示隐藏，1表示应该出现。
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
