using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MGSYHpBar : MonoBehaviour
{
    [SerializeField] private Image healthBar; // 연두색 바 (채워지는 부분)
    [SerializeField] private Image backgroundBar; // 회색 배경 바
    private MGSY mgsy;

    private void Start()
    {
        // MGSY 스크립트의 HealthComponent 참조
        mgsy = GameObject.Find("MGSY").GetComponent<MGSY>();


        // 초기 체력 바 상태 업데이트
        UpdateHealthBar();
    }

    private void Update()
    {
        // 매 프레임 체력 바 업데이트
        UpdateHealthBar();
        
    }

    private void UpdateHealthBar()
    {
        // 현재 체력 비율 계산
        float healthPercent = mgsy.HealthComponent.GetCurrentHP() / mgsy.HealthComponent.maxHealth;
        Debug.Log("MGSY HealthPercent is " + healthPercent.ToString());
        // 체력 바의 fillAmount로 적용 (0 ~ 1 사이 비율)
        healthBar.fillAmount = healthPercent;
    }
}
