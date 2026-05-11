using UnityEngine;

public class PusherKey : MonoBehaviour 
{
    [SerializeField] private KeyCode _key;

    public bool GetState()
    {
        return Input.GetKeyDown(_key);
    }
}

