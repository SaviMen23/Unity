using UnityEngine;

public class PusherKey : MonoBehaviour 
{
    [SerializeField] private KeyCode _key;

    public bool Renew()
    {
        return Input.GetKeyDown(_key);
    }
}

