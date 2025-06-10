using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private List<GameObject> _hearts;

    private CompositeDisposable _compositeDisposable;
    public int HealthAmount { get; private set; } = 3;

    private void OnEnable()
    {
        _compositeDisposable = new CompositeDisposable();
        
        MessageBrokerHolder.GameActions
            .Receive<M_Answer>()
            .Subscribe(message => HandleAnswer(message.IsCorrect))
            .AddTo(_compositeDisposable);
    }

    private void OnDisable()
    {
        _compositeDisposable.Dispose();
    }

    private void Start()
    {
        ShowHealth();
    }

    private void TakeDamage()
    {
        HealthAmount--;
        
        ShowHealth();

        if(HealthAmount <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
    }

    private void HandleAnswer(bool isCorrect)
    {
        if (isCorrect == false)
            TakeDamage();
    }
    
    private void ShowHealth()
    {
        for (int i = 0; i < _hearts.Count; i++)
        {
            if(i + 1 > HealthAmount)
            {
                _hearts[i].gameObject.SetActive(false);
            }
            else
            {
                _hearts[i].gameObject.SetActive(true);
            }
        }
    }
}
