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
        // 미리 프리팹에서 콜라이더를 가져와 놓습니다.
        if (_shieldPrefab != null)
        {
            _shieldCollider = _shieldPrefab.GetComponent<CircleCollider2D>();
            _shieldCollider.enabled = false; // 비활성화 상태로 시작
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
        // 활성화된 실드가 이미 있다면 비활성화합니다.
        if (_activeShield != null)
        {
            _activeShield.SetActive(false);
            return; // 이미 활성화된 실드가 있다면 함수를 종료합니다.
        }

        // 실드 프리팹을 생성하고 활성화합니다.
        _activeShield = Instantiate(_shieldPrefab, transform.position, Quaternion.identity);
        _activeShield.SetActive(true);

        // 실드 크기를 초기화합니다.
        _activeShield.transform.localScale = Vector3.zero;

        // 실드 커지는 코루틴을 시작합니다.
        StartCoroutine(GrowShield());
    }

    private IEnumerator GrowShield()
    {
        if(_shieldCollider == null) 
        {
            Debug.LogError("Shield Collider is not assigned!");
            yield break; // 콜라이더가 없으면 코루틴 종료
        }
        
        _shieldCollider.enabled = true; // 콜라이더 활성화

        while (_activeShield.transform.localScale.x < _targetScale)
        {
            _activeShield.transform.localScale = Vector3.Lerp(_activeShield.transform.localScale, Vector3.one * _targetScale, Time.deltaTime * _growSpeed);

            // 콜라이더 크기를 실드 크기에 맞춥니다.
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