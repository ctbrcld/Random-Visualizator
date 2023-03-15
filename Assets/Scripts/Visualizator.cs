using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Visualizator : MonoBehaviour
{
    [SerializeField] private RectTransform _spawnPoint;
    [SerializeField] private InputField _lifetimeFieldMin;
    [SerializeField] private InputField _lifetimeFieldMax;
    [SerializeField] private InputField _cooldownFieldMin;
    [SerializeField] private InputField _cooldownFieldMax;
    [SerializeField] private Figures _prefabTriangle;
    [SerializeField] private Figures _prefabCircle;
    [SerializeField] private Figures _prefabSquare;

    private const int MinSizeBorder = 75;

    private readonly List<FigureType> _spawnFigures = new List<FigureType>();
    private bool _useTriangle;
    private bool _useCircle;
    private bool _useSquare;

    private float _maxX;
    private float _maxY;
    private float _cooldown;



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

        if (_cooldown <= 0 && _spawnFigures.Count > 0)
        {
            Spawn();
            _cooldown = Random.Range(int.Parse(_cooldownFieldMin.text), int.Parse(_cooldownFieldMax.text));
        }
    }

    public void SpawnSquareSwitcher()
    {
        _useSquare = !_useSquare;

        if (_useSquare)
        {
            _spawnFigures.Add(FigureType.Square);
        }
        else
        {
            _spawnFigures.Remove(FigureType.Square);
        }
    }

    public void SpawnCircleSwitcher()
    {
        _useCircle = !_useCircle;

        if (_useCircle)
        {
            _spawnFigures.Add(FigureType.Circle);
        }
        else
        {
            _spawnFigures.Remove(FigureType.Circle);
        }
    }

    public void SpawnTriangleSwitcher()
    {
        _useTriangle = !_useTriangle;

        if (_useTriangle)
        {
            _spawnFigures.Add(FigureType.Triangle);
        }
        else
        {
            _spawnFigures.Remove(FigureType.Triangle);
        }
    }

    private void Spawn()
    {
        Figures _currentFigure = null;

        switch (_spawnFigures[Random.Range(0, _spawnFigures.Count)])
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
        var rect = _spawnPoint.rect;
        _maxX = rect.size.x;
        _maxY = rect.size.y;
        float randomX = Random.Range(MinSizeBorder, _maxX - MinSizeBorder);
        float randomY = Random.Range(MinSizeBorder, _maxY - MinSizeBorder);
        var newfigure = Instantiate(_currentFigure, transform);
        newfigure.transform.localPosition = new Vector2(randomX, randomY);
        newfigure.Initialize(lifeTime);
    }
}
