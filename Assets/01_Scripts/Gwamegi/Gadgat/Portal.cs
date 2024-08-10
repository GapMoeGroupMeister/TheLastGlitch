using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject _teleportingPortal;

    public bool isMy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("��");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (collision.gameObject.GetComponent<PortalPlayer>().isTeleporting)
            {
                Debug.Log("�̵�");
                Debug.Log(collision.gameObject.transform.position);
                _teleportingPortal.gameObject.GetComponent<Portal>().isMy = true;
                collision.gameObject.GetComponent<PortalPlayer>().isTeleporting = false;
                collision.gameObject.transform.position = _teleportingPortal.transform.position;
                Debug.Log(collision.gameObject.transform.position);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && isMy)
        {
            Debug.Log("�� ����");
            collision.gameObject.GetComponent<PortalPlayer>().isTeleporting = true;
            isMy = false;
        }
    }


}
