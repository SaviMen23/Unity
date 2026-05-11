using UnityEngine;

public class StealHealthBinder : MonoBehaviour
{
    [SerializeField] private StealerHealth _stealerHealth;
    [SerializeField] private StealHealthView _stealerHealthView;
    [SerializeField] private PusherKey _pusherKey;

    private void Awake()
    {
        _stealerHealth.Initialize();
        _stealerHealthView.Initialize();
    }

    private void Update()
    {
        if (_pusherKey.GetState())
            _stealerHealth.Work();

        _stealerHealthView.UpdateView();
    }
}


