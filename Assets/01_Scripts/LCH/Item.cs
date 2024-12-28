using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 10f;
    public RequireItemType itemType;

    public void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }
}
