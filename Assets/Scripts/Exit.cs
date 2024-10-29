using TMPro;
using UnityEngine;

public class Exit : MonoBehaviour, IInteractable
{
    [SerializeField] private Cloud _cloud;
    [SerializeField] private TextMeshProUGUI _text;

    public void Interact()
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _cloud.gameObject.SetActive(true);
            _text.text = player.MoneyCount.ToString() + "/10";
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