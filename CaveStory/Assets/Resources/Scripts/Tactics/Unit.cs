using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum UnitState { Run, Battle, Attack, Die }
    public enum ClassState { knight, warrior, heavy, magician, Priest }
    public UnitState unitState;
    public ClassState classState;
    RaycastHit hit;

    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float AttackSpeed = 1.0f;
    [SerializeField]
    private float dis = 3.0f;
    [SerializeField]
    private GameObject Target;
    private bool isAttack = true;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        switch(classState)
        {
            case ClassState.knight:
                break;
            case ClassState.warrior:
                dis = 10.0f;
                break;
            case ClassState.heavy:
                dis = 15.0f;
                break;
            case ClassState.magician:
                dis = 25.0f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        FindTarget();
        StateChange();
    }

    void Move()
    {
        if (!Target.activeSelf)
            unitState = UnitState.Run;
        if(Physics.Raycast(transform.position, transform.right, out hit, 1.0f))
        {
            if(hit.transform.CompareTag("Obstacle"))
            {
                return;
            }
        }
        else if (unitState == UnitState.Run)
            transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void FindTarget()
    {
        if (Physics.Raycast(transform.position, transform.right, out hit, dis))
        {
            Debug.DrawRay(transform.position, Vector3.right * 3.0f, Color.blue, 0.3f);
            if (hit.transform.tag == "Enemy")
            {
                Target = hit.transform.gameObject;
                unitState = UnitState.Battle;
                if (isAttack == true)
                    StartCoroutine(AttackCharge());
            }
        }
    }

    void StateChange()
    {
        switch(unitState)
        {
            case UnitState.Battle:
                break;
            case UnitState.Attack:
                break;
            case UnitState.Die:
                break;
        }
    }

    IEnumerator AttackCharge()
    {
        unitState = UnitState.Attack;
        Attack();
        yield return new WaitForSeconds(AttackSpeed);
        isAttack = true;
    }

    void Attack()
    {
        Target.GetComponent<Enemy>().DamageHP();
        unitState = UnitState.Battle;
        isAttack = false;
    }
}
