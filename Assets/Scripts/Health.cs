using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private List<GameObject> _hearts;
    [SerializeField] private List<Question> _questions;

    public int HealthAmount { get; private set; } = 3;

    private void OnEnable()
    {
        foreach (var question in _questions)
        {
            question.WrongAnswer += TakeDamage;
        }
    }

    private void OnDisable()
    {
        foreach (var question in _questions)
        {
            question.WrongAnswer -= TakeDamage;
        }
    }

    private void Start()
    {
        ShowHealth();
    }

    public void TakeDamage()
    {
        HealthAmount--;
        
        ShowHealth();

        if(HealthAmount <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }

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
