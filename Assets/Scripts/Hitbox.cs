using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float damage = 10f;
    public bool canattack = false;
    public bool attacking = false;

    float timer = 0;
    float timelimit = 0.75f;

    void Update()
    {
        if (attacking) {
            timer += Time.deltaTime;

            if (timer >= timelimit)
            {
                timer = 0;
                canattack = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (canattack && other.tag == "EnemyUnit")
        {
            canattack = false;
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
