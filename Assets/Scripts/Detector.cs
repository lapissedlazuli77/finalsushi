using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public string tagseek;
    public bool inrange;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == tagseek)
        {
            inrange = true;
        }
    }
}
