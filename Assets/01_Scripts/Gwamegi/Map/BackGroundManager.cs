using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField] private Transform _backGround1, _backGround2, _backGround3;
    public float _point2, _point1, _startPosition;

    private void Awake()
    {
        _point1 = _backGround3.localPosition.x;//세개의 배경중 왼쪽의 배경
        _point2 = _backGround2.localPosition.x;//세개의 배경중 오른쪽의 배경
        _startPosition = _backGround1.localPosition.x;//세개의 배경중 중앙의 배경
    }

    private void Update()
    {
        if (Mathf.Approximately(_backGround2.localPosition.x, _startPosition))
        {
            _backGround3.localPosition = new Vector3(_point1, _backGround2.localPosition.y, _backGround2.localPosition.z);

            (_backGround3, _backGround1, _backGround2) = (_backGround1, _backGround2, _backGround3);
        }

        if (Mathf.Approximately(_backGround3.localPosition.x, _startPosition))
        {
            _backGround2.localPosition = new Vector3(_point2, _backGround3.localPosition.y, _backGround3.localPosition.z);
            (_backGround3, _backGround1, _backGround2) = (_backGround2, _backGround3, _backGround1);
        }

    }

}
