using UnityEngine;
using UnityEngine.Events;
public interface IHittable
{
    UnityEvent OnGetHit { get; set; }
    void GetHit(int damge, GameObject damgeDealer);
}
