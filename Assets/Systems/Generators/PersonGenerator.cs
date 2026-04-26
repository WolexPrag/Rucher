using System.Collections.Generic;
using UnityEngine;
using VContainer;
public class PersonGenerator : MonoBehaviour
{
    [Inject, SerializeField] private NameGenerator _nameGenerator;
    [Inject, SerializeField] private StatsGenerator _statsGenerator;
    [SerializeField, Min(0)] private int _minCount;
    [SerializeField, Min(0)] private int _maxCount;
    public List<Person> GenerateList(string role)
    {
        int count = Random.Range(_minCount, _maxCount);
        List<Person> _candidates = new(count);
        for (int i = 0; i < count; i++)
        {
            _candidates.Add(Generate(role));
        }
        return _candidates;
    }
    public Person Generate(string role)
    {
        return new Person()
        {
            Name = GenerateName(),
            Role = role,
            Age = GenerateAge(),
            Stats = GenerateStats()
        };
    }
    public int GenerateAge()
    {
        return Random.Range(18, 70);
    }
    private Stats GenerateStats()
    {
        return _statsGenerator.Generate();
    }

    private string GenerateName()
    {
        return _nameGenerator.Generate();
    }
}

