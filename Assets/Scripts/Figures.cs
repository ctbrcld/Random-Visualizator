using UnityEngine;
using UnityEngine.UI;

public class Figures : MonoBehaviour

{
    private float _lifeTime;
    [SerializeField] private Text _lifeTimeLabel;
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
        _lifeTimeLabel.text = _lifeTime.ToString("F1");
        _lifeTime -= Time.deltaTime;
    }
}
