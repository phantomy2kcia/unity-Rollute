using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public GameObject rullet;
    public float rotspeed;
    Coroutine coroutine;
    public static Rotate instance;
    public bool on_rotate = false;
    public void Awake()
    {
        instance = this;
        rotspeed = 0;
    }
    public void Update()
    {
        Onclick();
        if (on_rotate&&rotspeed<0.01&&rotspeed>0)
        {
            rotspeed = 0;
            on_rotate = false;
            StopCoroutine(coroutine);
        }
    }
    public void Onclick()
    {
        if (Input.GetMouseButtonUp(0) && !on_rotate && IPointer.instance.first)
        {
            on_rotate = true;
            coroutine = StartCoroutine(rotate());
        }
    }  
    IEnumerator rotate()
    {
        while (true)
        {
            rullet.transform.Rotate(0, 0, rotspeed);
            rotspeed *= 0.99f;
            yield return 0.1f;
        }
    }
}