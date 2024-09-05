using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Transform _iteractiveObChecker;
    [SerializeField] Vector2 _checkerSize;
    [SerializeField] LayerMask _interactiveLayer;
    [SerializeField] GameObject _interactIconPrefab;

    private IInteractive _interactiveObject;
    private GameObject _interactiveIcon;
    private bool _isInteracting = false;

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
    private void Update()
    {
        if (_isInteracting)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.F))
            {
                Disconnect();
            }
        }
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
                _interactiveIcon.transform.position = collider.transform.position;
            }
            else
            {
                throw new System.Exception($"{collider.name}오브젝트에 IInteractive를 구현해주세요.");
            }
        }
        else
        {
            _interactiveObject = null;
        }
    }

    private void Interact()
    {
        if (_interactiveObject != null)
        {
            _isInteracting = true;
            _interactiveObject.OnInteract();
            _input.playerController.Disable();
            Time.timeScale = 0f;
        }
    }

    public void Disconnect()
    {
        _interactiveObject.OnDisconnect();
        _input.playerController.Enable();
        Time.timeScale = 1.0f;
        _isInteracting = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_iteractiveObChecker.position, _checkerSize);
    }
}
