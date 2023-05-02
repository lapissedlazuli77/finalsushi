using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseKaniUnit : MonoBehaviour
{
    public float health = 1f;
    public float damage = 1f;
    public float speed = 1f;

    public Animator myAnim;
    public StateMachine stateMachine;

    public Detector detector;
    public HitboxE hitbox;

    public GameManager manager;

    void AssembleStateMachine()
    {
        stateMachine = new StateMachine(Advancing, Attacking);
        stateMachine.ChangeState("Advancing");
    }

    void Start()
    {
        myAnim = GetComponent<Animator>();

        SetHealth();
        SetDamage();
        SetSpeed();
    }

    // Start is called before the first frame update
    private void Awake()
    {
        AssembleStateMachine();
    }

    // Update is called once per frame
    void Update()
    {
        this.stateMachine.Execute();
        if (detector.inrange)
        {
            stateMachine.ChangeState("Attacking");
            myAnim.SetBool("isAttacking", true);
        } else
        {
            stateMachine.ChangeState("Advancing");
            myAnim.SetBool("isAttacking", false);
        }
        if (transform.position.x <= -4f)
        {
            Destroy(gameObject);
            GameManager.balance -= damage;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    #region states
    protected virtual void Advancing()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x -= speed;
        transform.position = currentPosition;
        hitbox.attacking = false;
    }
    protected virtual void Attacking()
    {
        Vector3 currentPosition = transform.position;
        transform.position = currentPosition;
        hitbox.attacking = true;
    }
    #endregion

    protected virtual void SetHealth()
    {
        health = 100f;
    }

    protected virtual void SetDamage()
    {
        damage = 100f;
        hitbox.damage = damage;
    }
    protected virtual void SetSpeed()
    {
        speed = 1f;
    }
}
