using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class VitalBar : MonoBehaviour
{
    public bool _isPlayerHealthBar;

    private int _maxBarLength;
    private int _curBarLength;
    private Sprite _display;

    // Start is called before the first frame update
    void Start()
    {
        _isPlayerHealthBar = true;

        _display = gameObject.GetComponent<Sprite>();

        _maxBarLength = (int)_display.rect.width;

        OnEnable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {
        if (_isPlayerHealthBar)
            Messenger<int, int>.AddListener("player health update", OnChangeHealthBarSize);
        else
            Messenger<int, int>.AddListener("mob health update", OnChangeHealthBarSize);
    }
    public void OnDisable()
    {
        if (_isPlayerHealthBar)
            Messenger<int, int>.RemoveListener("player health update", OnChangeHealthBarSize);
        else
            Messenger<int, int>.RemoveListener("mob health update", OnChangeHealthBarSize);

    }

    public void OnChangeHealthBarSize(int curHealth, int maxHealth)
    {
        // Debug.Log("We heard an event: curHealth = " + curHealth + " - maxHealth = " + maxHealth);
        _curBarLength = (int)(curHealth / (float)maxHealth) * _maxBarLength;

        //_display.rect = new Rect(_display.rect.x, _display.rect.x, _curBarLength, _display.rect.height);
    }

    public void SetPlayerHealthBar(bool b)
    {
        _isPlayerHealthBar = b;
    }
}
*/