using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointerController : MonoBehaviour
{
    // Start is called before the first frame update
        private void Awake()
    {

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("point"))
        {
            other.GetComponent<Item>().StartCoroutine();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
       if(other.CompareTag("point"))
        {
            other.GetComponent<Item>().StopCoroutine();
        }   
    }

}
