using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private InputReader _reader;
    private Player _player;
    private float dir;
    private void Start()
    {
        _player = GameManager.Instance.Player;
    }

    private void Update()
    {
        dir = _reader.Movement.x;
    }

    private void LateUpdate()
    {
        transform.localPosition += new Vector3(-(dir * _speed),0,0) * Time.deltaTime;
    }
}
