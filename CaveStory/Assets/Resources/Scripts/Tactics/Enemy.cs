using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP = 3;
    public float MaxHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageHP()
    {
        HP--;
        if(HP < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
