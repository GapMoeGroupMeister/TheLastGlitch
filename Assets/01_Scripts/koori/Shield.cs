using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private float _shieldHP;
    [SerializeField] private float _shieldMaxHP;
    [SerializeField] private GameObject _shieldPrefab;
    [SerializeField] private float _growSpeed = 5f;
    [SerializeField] private float _targetScale = 4f;
    [SerializeField] private float _pushForce = 10f;

    private GameObject _activeShield;
    private CircleCollider2D _shieldCollider;

    private void Awake()
    {
        // �̸� �����տ��� �ݶ��̴��� ������ �����ϴ�.
        if (_shieldPrefab != null)
        {
            _shieldCollider = _shieldPrefab.GetComponent<CircleCollider2D>();
            _shieldCollider.enabled = false; // ��Ȱ��ȭ ���·� ����
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Use();
        }
    }

    private void Use()
    {
        // Ȱ��ȭ�� �ǵ尡 �̹� �ִٸ� ��Ȱ��ȭ�մϴ�.
        if (_activeShield != null)
        {
            _activeShield.SetActive(false);
            return; // �̹� Ȱ��ȭ�� �ǵ尡 �ִٸ� �Լ��� �����մϴ�.
        }

        // �ǵ� �������� �����ϰ� Ȱ��ȭ�մϴ�.
        _activeShield = Instantiate(_shieldPrefab, transform.position, Quaternion.identity);
        _activeShield.SetActive(true);

        // �ǵ� ũ�⸦ �ʱ�ȭ�մϴ�.
        _activeShield.transform.localScale = Vector3.zero;

        // �ǵ� Ŀ���� �ڷ�ƾ�� �����մϴ�.
        StartCoroutine(GrowShield());
    }

    private IEnumerator GrowShield()
    {
        if(_shieldCollider == null) 
        {
            Debug.LogError("Shield Collider is not assigned!");
            yield break; // �ݶ��̴��� ������ �ڷ�ƾ ����
        }
        
        _shieldCollider.enabled = true; // �ݶ��̴� Ȱ��ȭ

        while (_activeShield.transform.localScale.x < _targetScale)
        {
            _activeShield.transform.localScale = Vector3.Lerp(_activeShield.transform.localScale, Vector3.one * _targetScale, Time.deltaTime * _growSpeed);

            // �ݶ��̴� ũ�⸦ �ǵ� ũ�⿡ ����ϴ�.
            _shieldCollider.radius = _activeShield.transform.localScale.x * 0.5f;

            PushBackEnemies();
            yield return null;
        }
    }

    private void PushBackEnemies()
    {
        if (_shieldCollider == null) return;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _shieldCollider.radius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Rigidbody2D enemyRigidbody = collider.GetComponent<Rigidbody2D>();
                if (enemyRigidbody != null)
                {
                    Vector2 pushDirection = (collider.transform.position - transform.position).normalized;
                    enemyRigidbody.AddForce(pushDirection * _pushForce, ForceMode2D.Impulse);
                }
            }
        }
    }
}