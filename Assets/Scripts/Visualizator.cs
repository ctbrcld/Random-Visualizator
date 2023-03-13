using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Visualizator : MonoBehaviour
{
    [SerializeField] private RectTransform spawnPoint;
    [SerializeField] private InputField _lifetimeFieldMin;
    [SerializeField] private InputField _lifetimeFieldMax;
    [SerializeField] private InputField _cooldownFieldMin;
    [SerializeField] private InputField _cooldownFieldMax;
    [SerializeField] private Figures _prefabTriangle;
    [SerializeField] private Figures _prefabCircle;
    [SerializeField] private Figures _prefabSquare;

    private readonly List<FigureType> _spawnedFigures = new List<FigureType>();

    private bool _usedTriangle;
    private bool _usedCircle;
    private bool _usedSquare;

    private float maxX;
    private float maxY;
    private float _cooldown;

    private Figures _currentFigure;
    private FigureType _figure;

    private void Start()
    {
        _lifetimeFieldMin.text = Random.Range(3, 6).ToString();
        _lifetimeFieldMax.text = Random.Range(7, 14).ToString();
        _cooldownFieldMin.text = Random.Range(2, 4).ToString();
        _cooldownFieldMax.text = Random.Range(4, 6).ToString();

        _cooldown = Random.Range(int.Parse(_cooldownFieldMin.text), int.Parse(_cooldownFieldMax.text));
    }

    private void Update()
    {
        _cooldown -= Time.deltaTime;

        if (_cooldown <= 0 && _spawnedFigures.Count > 0)
        {
            Spawn();
            _cooldown = Random.Range(int.Parse(_cooldownFieldMin.text), int.Parse(_cooldownFieldMax.text));
        }
    }

    public void SpawnSquare()
    {
        _usedSquare = !_usedSquare;

        if (_usedSquare)
        {
            _spawnedFigures.Add(FigureType.Square);
        }
        else
        {
            _spawnedFigures.Remove(FigureType.Square);
        }
    }

    public void SpawnCircle()
    {
        _usedCircle = !_usedCircle;

        if (_usedCircle)
        {
            _spawnedFigures.Add(FigureType.Circle);
        }
        else
        {
            _spawnedFigures.Remove(FigureType.Circle);
        }
    }

    public void SpawnTriangle()
    {
        _usedTriangle = !_usedTriangle;

        if (_usedTriangle)
        {
            _spawnedFigures.Add(FigureType.Triangle);
        }
        else
        {
            _spawnedFigures.Remove(FigureType.Triangle);
        }
    }

    public void Spawn()
    {
        _figure = _spawnedFigures[Random.Range(0, _spawnedFigures.Count)];

        switch (_figure)
        {
            case FigureType.Triangle:
                _currentFigure = _prefabTriangle;
                break;
            case FigureType.Square:
                _currentFigure = _prefabSquare;
                break;
            case FigureType.Circle:
                _currentFigure = _prefabCircle;
                break;
        }

        float lifeTime = Random.Range(float.Parse(_lifetimeFieldMin.text), float.Parse(_lifetimeFieldMax.text));
        maxX = spawnPoint.rect.size.x;
        maxY = spawnPoint.rect.size.y;
        float randomX = Random.Range(75, maxX - 75);
        float randomY = Random.Range(75, maxY - 75);
        var newfigure = Instantiate(_currentFigure, this.transform);
        newfigure.transform.localPosition = new Vector2(randomX, randomY);
        newfigure.Initialize(lifeTime);
    }
}
