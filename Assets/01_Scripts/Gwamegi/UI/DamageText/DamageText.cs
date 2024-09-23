using System.Collections;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [SerializeField] private float _destroyTime;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private TextMeshPro _textMeshPro;
    private int _damage;
    private Agent _onwer;


    public void Initialized(int damage, Agent onwer)
    {
        _damage = damage;
        _onwer = onwer;
        StartCoroutine(DestroyGameObject());
        SetText(_damage);
    }

    private void Update()
    {
        MoveText();
    }

    public void SetText(int damage)
    {
        _textMeshPro.SetText(damage.ToString());
    }

    private void MoveText()
    {
        transform.position += new Vector3(0f,1,0) * _moveSpeed * Time.deltaTime;
    }

    private IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(_destroyTime);
        Destroy(gameObject);
    }
}
