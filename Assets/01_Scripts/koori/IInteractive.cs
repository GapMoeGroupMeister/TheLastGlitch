using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractive
{
    /// <summary>
    /// 상호작용 시에 호출됨.
    /// </summary>
    public void OnInteract();
    /// <summary>
    /// 상호작용 종료 시에 호출됨.
    /// </summary>
    public void OnDisconnect();
}
