using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxE : MonoBehaviour
{
    public float damage = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Hamachi hhealth))
        {
            hhealth.health -= damage;
        }
        if (other.TryGetComponent(out Ikura shealth))
        {
            shealth.health -= damage;
        }
    }
}
