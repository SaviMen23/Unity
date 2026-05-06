using UnityEngine.UI;
using UnityEngine;

public class HillButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Health _characterHealth;
    [SerializeField, Min(0)] private int _numberOfHitPoints;

    private void OnEnable()
    {
        _button.onClick.AddListener(Heal);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Heal);
    }

    public void Heal()
    {
        if (_characterHealth.gameObject.activeSelf)
            _characterHealth.Heal(_numberOfHitPoints);
    }
}
