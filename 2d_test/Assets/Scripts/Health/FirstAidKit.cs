using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField, Min(0)] private int _healthRecovery;

    public void Use(Health playerHealth)
    {
        if (playerHealth != null)
        {
            playerHealth.Heal(_healthRecovery);
            gameObject.SetActive(false);
        }
    }
}