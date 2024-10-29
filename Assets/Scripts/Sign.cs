using UnityEngine;

public class Sign : MonoBehaviour
{
    [SerializeField] private Cloud _cloud;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _cloud.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _cloud.gameObject.SetActive(false);
        }
    }
}
