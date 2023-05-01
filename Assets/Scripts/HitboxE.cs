using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxE : MonoBehaviour
{
    public float damage = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Hamachi hhealth))
        {
            hhealth.health -= damage;
        }
        if (collision.transform.TryGetComponent(out Ikura shealth))
        {
            shealth.health -= damage;
        }
    }
}
