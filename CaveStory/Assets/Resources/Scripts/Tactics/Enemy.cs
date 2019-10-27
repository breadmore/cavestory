using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public enum ClassState { knight, warrior, heavy, magician, Priest }
    public ClassState classState;
    public float HP = 3;
    public float MaxHealth = 3;

    public GameObject hpBarPrefab;
    public Vector3 hpBarOffset = new Vector3(0, 2.2f, 0);
    private Canvas uiCanvas;
    private Image hpBarImage;
    // Start is called before the first frame update
    void Start()
    {
        SetHpBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetHpBar()
    {
        uiCanvas = GameObject.Find("UI Canvas").GetComponent<Canvas>();
        GameObject hpBar = Instantiate<GameObject>(hpBarPrefab, uiCanvas.transform);
        hpBarImage = hpBar.GetComponentsInChildren<Image>()[1];

        var _hpBar = hpBar.GetComponent<EnemyHpBar>();
        _hpBar.targetTr = this.gameObject.transform;
        _hpBar.offset = hpBarOffset;
    }

    public void DamageHP()
    {
        HP--;
        hpBarImage.fillAmount = HP / MaxHealth;
        if(HP <= 0)
        {
            hpBarImage.transform.parent.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
