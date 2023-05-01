using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float damage = 10f;
    public bool hasattacked = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "EnemyUnit" && !hasattacked)
        {
            hasattacked = true;
            if ((other.GetComponent("Kegani") as Kegani) != null)
            {
                other.GetComponent<Kegani>().Damaged(damage);
            } else if ((other.GetComponent("Kurage") as Kurage) != null)
            {
                other.GetComponent<Kurage>().Damaged(damage);
            }
        }
    }
}
