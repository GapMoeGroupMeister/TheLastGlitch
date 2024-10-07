using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MGSYHpBar : MonoBehaviour
{
    [SerializeField] private Image healthBar; // ���λ� �� (ä������ �κ�)
    [SerializeField] private Image backgroundBar; // ȸ�� ��� ��
    private MGSY mgsy;

    private void Start()
    {
        // MGSY ��ũ��Ʈ�� HealthComponent ����
        mgsy = GameObject.Find("MGSY").GetComponent<MGSY>();


        // �ʱ� ü�� �� ���� ������Ʈ
        UpdateHealthBar();
    }

    private void Update()
    {
        // �� ������ ü�� �� ������Ʈ
        UpdateHealthBar();
        
    }

    private void UpdateHealthBar()
    {
        // ���� ü�� ���� ���
        float healthPercent = mgsy.HealthComponent.GetCurrentHP() / mgsy.HealthComponent.maxHealth;
        Debug.Log("MGSY HealthPercent is " + healthPercent.ToString());
        // ü�� ���� fillAmount�� ���� (0 ~ 1 ���� ����)
        healthBar.fillAmount = healthPercent;
    }
}
