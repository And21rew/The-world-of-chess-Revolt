using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureSize : MonoBehaviour
{
    protected float size;

    public void SetSize(GameObject _gameObject, float _size)
    {
        this.size = _size;
        _gameObject.transform.localScale = new Vector3(_size, _size, _size);
    }

    public float GetSize()
    {
        return size;
    }
}
