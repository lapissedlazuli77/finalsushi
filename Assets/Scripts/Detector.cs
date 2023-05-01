using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public string tagseek;
    public bool inrange;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagseek)
        {
            inrange = true;
        }
    }
}
