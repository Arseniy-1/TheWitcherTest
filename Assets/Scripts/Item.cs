using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private Cloud _cloud;
    [SerializeField] private GameObject _test;

    public void Interact()
    {
        _test.gameObject.SetActive(true);
        Destroy(gameObject);
    }

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
