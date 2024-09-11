using UnityEngine;

public class DamageTextFeedBack : Feedback
{
    [SerializeField] private GameObject _damageText;
    public override void PlayFeedback()
    {
        
    }

    public void PlayFeedbacks(int damage)
    {
        Agent parent = GetComponentInParent<Agent>();
        GameObject damageText = Instantiate(_damageText, parent.gameObject.transform.position, Quaternion.identity);
        damageText.GetComponent<DamageText>().Initialized(damage, parent);
    }

    public override void StopFeedback()
    {

    }
}
