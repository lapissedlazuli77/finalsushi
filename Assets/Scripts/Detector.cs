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
            inrange = true;
        } if (other == null)
        {
            inrange = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == tagseek)
        {
            inrange = false;
        }
    }
}
