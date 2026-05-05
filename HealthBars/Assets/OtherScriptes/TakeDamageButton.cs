using UnityEngine;
using UnityEngine.UI;

public class TakeDamageButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Health _characterHealth;
    [SerializeField, Min(0)] private int _damage;

    private void OnEnable()
    {
        _button.onClick.AddListener(TakeDamage);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(TakeDamage);
    }

    private void TakeDamage()
    {
        if (_characterHealth.gameObject.activeSelf)
            _characterHealth.TakeDamage(_damage);
    }
}
