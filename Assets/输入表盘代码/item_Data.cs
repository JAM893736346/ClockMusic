using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newitem_data",menuName ="CreateData/Create New item_Data")]
public class item_Data : ScriptableObject
{
    //�����ϵĵ�������
   public List<ItemData> itemDatas;
}

[System.Serializable]
public class ItemData
{
    //����
    public int wave;
    //ʱ����ʱδ����
    public float time;
    //�ò�����״̬��0��ʾ���أ�1��ʾӦ�ó��֡�
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
