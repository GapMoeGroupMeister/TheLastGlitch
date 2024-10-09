using UnityEngine;

public class Stage : MonoBehaviour
{
    private void Awake()
    {
        Player2ActiveSkill.Instance.ErrorActive();

    }

    void Start()
    {
        GameManager.Instance.Player.gameObject.SetActive(true);
        GameManager.Instance.Player.GetComponent<PlayerDash>().DashBool();
        GameManager.Instance.Player.MovementComponent._canMove = true;
        WeaponCoolTime.instance._attack = false;

    }
}
