using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class miusicData : MonoBehaviour
{
    public float[] spectrum = new float[256];
    // public float sum;
    // public int m = 0;
    // public float add;
    public List<Transform> cubes;
    public float StepCount;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            cubes.Add(transform.GetChild(i));
        }
    }
    float timeCount;
    void Update()
    {
        // float[] spectrum = new float[256]; 
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        timeCount -= Time.deltaTime;
        if (timeCount <= 0)
        {
            for (int i = 0; i < cubes.Count; i++)
            {
                cubes[i].transform.localScale = new Vector3(cubes[i].localScale.x, spectrum[i] * StepCount, cubes[i].localScale.z);
            }
            timeCount=0.1f;
        }

        // for (int i = 0; i < spectrum.Length-1; i++)
        // {

        // }
        // m++;
        // if (Pingjun(spectrum)>0.035f)
        // {
        //     print(true);
        // }
        // sum += Pingjun(spectrum);

    }

    // float Pingjun(float[] data)
    // {
    //     float a = 0;
    //     foreach (var item in data)
    //     {
    //         a += item;
    //     }
    //     return a / data.Length;
    // }
}
