using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxE : MonoBehaviour
{
    public float damage = 10f;
    public bool canattack = false;
    public bool attacking = false;

    float timer = 0;
    float timelimit = 0.5f;

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
        if (canattack && other.tag == "PlayerUnit")
        {
            canattack = false;
            if ((other.GetComponent("Hamachi") as Hamachi) != null)
            {
                other.GetComponent<Hamachi>().Damaged(damage);
            } else if ((other.GetComponent("Ikura") as Ikura) != null)
            {
                other.GetComponent<Ikura>().Damaged(damage);
            }
        }
    }
}
