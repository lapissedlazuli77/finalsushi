using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float damage = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Kegani khealth))
        {
            khealth.health -= damage;
        }
        if (collision.transform.TryGetComponent(out Kurage jhealth))
        {
            jhealth.health -= damage;
        }
    }
}
