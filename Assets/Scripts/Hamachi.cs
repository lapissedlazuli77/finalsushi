using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamachi : BaseSakanaUnit
{
    protected override void SetHealth()
    {
        health = 100f;
    }
    protected override void SetDamage()
    {
        damage = 15f;
        hitbox.damage = damage;
    }
    protected override void SetSpeed()
    {
        speed = 0.0016f;
    }
    public void Damaged(float dama)
    {
        health -= dama;
    }
}
