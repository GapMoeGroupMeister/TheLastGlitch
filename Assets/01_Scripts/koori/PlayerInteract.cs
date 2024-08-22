using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Transform _iteractiveObChecker;
    [SerializeField] Vector2 _checkerSize;
    [SerializeField] LayerMask _interactiveLayer;
    [SerializeField] GameObject _interactIconPrefab;

    private IInteractive _interactiveObject;
    private GameObject _interactiveIcon;
    private bool _isInteractive;

    [SerializeField] InputReader _input;

    private void Start()
    {
        _interactiveIcon = Instantiate(_interactIconPrefab);

        _interactiveIcon.name = _interactIconPrefab.name;
        _interactiveIcon.SetActive(false);
    }
    private void Awake()
    {
        _input.OnInteractionEvent += Interact;
    }
    private void FixedUpdate()
    {
        CheckIteractiveObject();
    }
    private void CheckIteractiveObject()
    {
        Collider2D collider = Physics2D.OverlapBox(_iteractiveObChecker.position, _checkerSize, 0, _interactiveLayer);
        _interactiveIcon.SetActive(collider != null);
        if (collider != null)
        {
            if (collider.TryGetComponent(out IInteractive component))
            {
                _interactiveObject = component;
                _isInteractive = true;
            }
            _interactiveIcon.transform.position = collider.transform.position;
        }
        else
        {
            _isInteractive = false;
            _interactiveObject = null;
        }
    }

    private void Interact()
    {
        if (_isInteractive)
        {
            _interactiveObject.OnInteract();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_iteractiveObChecker.position, _checkerSize);
    }
}
