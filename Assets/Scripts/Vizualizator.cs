using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vizualizator : MonoBehaviour
{
    public RectTransform spawnPoint;
    public GameObject figure;
    public float maxX;
    public float maxY;


    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("SpawnFigure", 0.5f, 0.5f);
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void SpawnFigure()
    {
        maxX = spawnPoint.rect.size.x;
        maxY = spawnPoint.rect.size.y;
        float randomX = Random.Range(75, maxX - 75);
        float randomY = Random.Range(75, maxY - 75); 
        var newfigure = Instantiate(figure, this.transform);
        newfigure.transform.localPosition = new Vector2(randomX, randomY);
    }

}
