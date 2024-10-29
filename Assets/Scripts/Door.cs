using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _door;
    [SerializeField] private Sprite _openSprite;
    [SerializeField] private Cloud _cloud;

    private bool _isOpen;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (_isOpen == false)
                _cloud.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (_isOpen == false)
                _cloud.gameObject.SetActive(false);
        }
    }

    public void Interact()
    {
        _renderer.sprite = _openSprite;
        _isOpen = true;
        _cloud.gameObject.SetActive(false);
        _door.gameObject.SetActive(false);
    }
}
