using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField] protected int Amount = 128;

    private List<GameObject> _pool = new List<GameObject>();

    protected virtual void Initialize(GameObject template)
    {
        for (int i = 0; i < Amount; i++)
        {
            var poolObject = Instantiate(template, transform);
            poolObject.SetActive(false);
            _pool.Add(poolObject);
        }
    }

    protected bool TryGetObject(out GameObject poolObject)
    {
        poolObject = _pool.FirstOrDefault(b => b.activeSelf == false);

        if (poolObject != null)
        {
            poolObject.SetActive(true);
            return true;
        }
        return false;
    }
}