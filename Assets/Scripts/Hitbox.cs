using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float damage = 10f;
    public int attacklimit = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyUnit" && attacklimit <= 0 && (other.GetComponent("Kegani") as Kegani) != null)
        {
            attacklimit++;
            Kegani.Damaged(damage);
            Debug.Log("attacked");
        }
    }
}
