using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MGSYHpBar : MonoBehaviour
{
    [SerializeField] private Image healthBar; // ���λ� �� (ä������ �κ�)
    [SerializeField] private Image backgroundBar; // ȸ�� ��� ��
    private MGSY mgsy;

    private void Awake()
    {
        // MGSY ��ũ��Ʈ�� HealthComponent ����
        mgsy = GameObject.Find("MGSY").GetComponent<MGSY>();
    }

    private void Start()
    {
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

        // ü�� ���� width�� ü�� ������ ���� ����
        RectTransform healthBarRect = healthBar.GetComponent<RectTransform>();
        healthBarRect.sizeDelta = new Vector2(backgroundBar.rectTransform.sizeDelta.x * healthPercent, healthBarRect.sizeDelta.y);
    }
}
