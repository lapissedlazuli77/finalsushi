using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public string tagseek;
    public bool inrange;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == tagseek)
        {
            Debug.Log("In range");
            inrange = true;
        }
    }
}
