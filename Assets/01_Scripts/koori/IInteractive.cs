using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractive
{
    /// <summary>
    /// ��ȣ�ۿ� �ÿ� ȣ���.
    /// </summary>
    public void OnInteract();
    /// <summary>
    /// ��ȣ�ۿ� ���� �ÿ� ȣ���.
    /// </summary>
    public void OnDisconnect();
}
