using UnityEngine;

public abstract class TrashFactory : MonoBehaviour
{
    public abstract GameObject Generate(Vector2 position, Quaternion rotation);
}
