using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Visualizator : MonoBehaviour
{

    [SerializeField] private InputField _lifetimeFieldMin;
    [SerializeField] private InputField _lifetimeFieldMax;
    [SerializeField] private InputField _cooldownFieldMin;
    [SerializeField] private InputField _cooldownFieldMax;
    [SerializeField] private Button _squreButton;
    [SerializeField] private Button _circleButton;
    [SerializeField] private Button _triangleButton;

    public RectTransform spawnPoint;
    public Figures figure;
    public Figures circle;
    public Figures triangle;
    public Figures square;
    private float maxX;
    private float maxY;
    private float _cooldown;


    private void Start()
    {
        _lifetimeFieldMin.text = Random.Range(2, 3).ToString();
        _lifetimeFieldMax.text = Random.Range(2, 3).ToString();
        _cooldownFieldMin.text = Random.Range(2, 3).ToString();
        _cooldownFieldMax.text = Random.Range(2, 3).ToString();
        _cooldown = Random.Range(int.Parse(_cooldownFieldMin.text), int.Parse(_cooldownFieldMax.text));

    }

    private void Update()
    {
        if (_cooldown > 0)
        {
            _cooldown -= Time.deltaTime;

            if (_cooldown <= 0)
            {
                SpawnSquare();
                _cooldown = Random.Range(int.Parse(_cooldownFieldMin.text), int.Parse(_cooldownFieldMax.text)); 
            }
        }
    }

    public void SpawnSquare()
    {
        float lifeTime = Random.Range(float.Parse(_lifetimeFieldMin.text), float.Parse(_lifetimeFieldMax.text));
        maxX = spawnPoint.rect.size.x;
        maxY = spawnPoint.rect.size.y;
        float randomX = Random.Range(75, maxX - 75);
        float randomY = Random.Range(75, maxY - 75);
        var newfigure = Instantiate(square, this.transform);
        newfigure.transform.localPosition = new Vector2(randomX, randomY);
        newfigure.Initialize(lifeTime);
    }


}
