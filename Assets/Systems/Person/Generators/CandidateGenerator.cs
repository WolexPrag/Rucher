
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UnityEngine;
using VContainer;

public class CandidateGenerator : MonoBehaviour
{
    [Inject,SerializeField] private NameGenerator _nameGenerator;
    [Inject,SerializeField] private StatsGenerator _statsGenerator;
    [SerializeField, Min(0)] private int _minCount;
    [SerializeField, Min(0)] private int _maxCount;
    public List<Person> GenerateList()
    {
        int count = Random.Range(_minCount, _maxCount);
        List<Person> _candidates = new(count);
        for (int i = 0; i < count; i++)
        {
            _candidates.Add(Generate());
        }
        return _candidates;
    }
    public Person Generate()
    {
        return new Person(GenerateName(), GenerateStats());
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

