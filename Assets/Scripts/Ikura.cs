using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ikura : BaseSakanaUnit
{
    protected override void SetHealth()
    {
        health = 48f;
    }
    protected override void SetDamage()
    {
        damage = 20f;
    }
    protected override void SetSpeed()
    {
        speed = 0.0021f;
    }
}
