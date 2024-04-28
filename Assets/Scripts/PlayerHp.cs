using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 10;
    private float currentHP;
    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;

    public float MaxHP => maxHP;
    public float CurrentHp
    {
        set => currentHP = Mathf.Clamp(value, 0, maxHP);
        get => currentHP;
    }
    public float CurrentHP => currentHP;
    private void Awake()
    {
        currentHP = maxHP; //���� ü�� �ִ� ä���̶� ����
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        if(currentHP <= 0)
        {
            playerController.OnDie();
        }
    }
    
    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
}
