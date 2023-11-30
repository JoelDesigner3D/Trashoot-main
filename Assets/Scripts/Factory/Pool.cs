using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pool : MonoBehaviour
{
    public abstract GameObject Get(Vector2 position);
    public abstract void Release(GameObject gameObject);
}
