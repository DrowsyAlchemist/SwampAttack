using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BulletDeactiver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet))
            bullet.gameObject.SetActive(false);
    }

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
}
