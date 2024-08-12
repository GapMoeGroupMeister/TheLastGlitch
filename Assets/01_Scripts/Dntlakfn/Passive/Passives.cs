using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Passives : MonoBehaviour
{
    /* Todo
     * 
     * �÷��̾� �ϼ��Ǹ� ��ú� ���� 3�� �����ϱ�
     */



    private Player player;

    private void Awake()
    {
        player = FindAnyObjectByType<Player>();
    }

    public bool _isEquipped = false;

    public abstract void ActivePassive();

    public abstract void InactivePassive();


}
