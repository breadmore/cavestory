using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        if (enemy is null)
            enemy = this.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.LogError(string.Format("HP: {0}, MaxHealth: {1}", player.HP, player.MaxHealth));
        healthBar.value = (enemy.HP / enemy.MaxHealth);
    }
}
