using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kegani : BaseKaniUnit
{
    protected override void SetHealth()
    {
        health = 60f;
    }
    protected override void SetDamage()
    {
        damage = 12f;
        hitbox.damage = damage;
    }
    protected override void SetSpeed()
    {
        speed = 0.0018f;
    }
    public void Damaged(float dama)
    {
        health -= dama;
    }
}