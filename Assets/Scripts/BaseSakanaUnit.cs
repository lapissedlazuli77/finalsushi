using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSakanaUnit : MonoBehaviour
{
    public float health;
    public float damage;
    public float speed;

    public StateMachine stateMachine;

    public Animator myAnim;
    public Detector detector;
    public Hitbox hitbox;

    [SerializeField]
    GameManager manager;

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
        manager = FindObjectOfType<GameManager>();
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
        if (transform.position.x >= 4f)
        {
            manager.balance += damage;
            Destroy(gameObject);
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
        currentPosition.x += speed;
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
