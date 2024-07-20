using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class UIToWorldSpace : MonoBehaviour
{
    [SerializeField] List<Player> _players = new();
    [SerializeField] Canvas _mainCanvas;
    [SerializeField] HealthBar _healthBar;
    
    [Space(10)]
    [SerializeField] Vector3 _offsetProgressBarPosition;
    
    [FormerlySerializedAs("visibleDetection")]
    [Space(10)]
    [SerializeField] bool _visibleDetection;
    [SerializeField] bool _disable;

    [SerializeField] List<HealthBar> _healthBars = new();
    Camera _camera;

    int _screenWidth;
    int _screenHeight;
    
    void Start()
    {
        DeleteObjects();
        _players = FindObjectsOfType<Player>().ToList();
        CreateHealthBars();
        _camera = Camera.main;
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;
    }

    void Update()
    {
        if (_disable)
            return;
        
        for (var i = 0; i < _healthBars.Count; i++)
        {
            var healthBar = SetHealthBarPosition(i);
            SetVisibleDetection(healthBar, i);
        }
    }

    void CreateHealthBars()
    {
        foreach (var player in _players)
        {
            _healthBars.Add(Instantiate(_healthBar, _mainCanvas.transform));
        }
    }
    HealthBar SetHealthBarPosition(int i)
    {
        var healthBar = _healthBars[i];
        Vector3 position = _camera.WorldToScreenPoint(_players[i].transform.position + _offsetProgressBarPosition);
        healthBar.transform.position = position;
        return healthBar;
    }

    void SetVisibleDetection(HealthBar healthBar, int index)
    {
        if (_visibleDetection)
        {
            Vector3 uiObjectScreenPos = RectTransformUtility.WorldToScreenPoint(_camera, _players[index].transform.position);
            bool isVisible = uiObjectScreenPos.x > 0 && uiObjectScreenPos.x < _screenWidth &&
                uiObjectScreenPos.y > 0 && uiObjectScreenPos.y < _screenHeight;
            healthBar.FrontImage.enabled = isVisible;
            healthBar.BackImage.enabled = isVisible;
        }
    }
    void DeleteObjects()
    {
        _healthBars.Clear();
        _healthBars.Capacity = 0;
        _players.Clear();
        _players.Capacity = 0;
    }
}