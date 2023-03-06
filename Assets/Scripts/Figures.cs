using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Figures : MonoBehaviour

{
    private float _lifeTime;

    public void Initialize(float lifeTime)
    {
        _lifeTime = lifeTime;
    } 

    private void Update()
    {
        if (_lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        gameObject.GetComponentInChildren<Text>().text = _lifeTime.ToString("F1");
        _lifeTime -= Time.deltaTime;
    }
}
