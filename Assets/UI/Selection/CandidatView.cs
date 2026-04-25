using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CandidateView : MonoBehaviour
{
    public event Action<Person> OnClicked;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Button _button;

    private Person _model;

    public void Bind(Person model)
    {
        _model = model;
        _nameText.text = model.Name;
    }

    private void Awake()
    {
        _button.onClick.AddListener(HandleClick);
    }
    
    private void HandleClick()
    {
        OnClicked?.Invoke(_model);
    }
}