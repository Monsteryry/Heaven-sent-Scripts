using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BaseStat.cs
/// 
/// Base class for all stats in game
/// </summary>


public class BaseStat : MonoBehaviour
{
    public const int STARTING_EXP_COST = 100;

    private int _baseValue;
    private int _buffValue;
    private int _expToLevel;
    private float _levelModifier;

    public BaseStat()
    {
        _baseValue = 0;
        _buffValue = 0;
        _expToLevel = STARTING_EXP_COST;
        _levelModifier = 1.1f;
    }
    #region Basic Setters and Getters
    public int BaseValue
    {
        get { return _baseValue; }
        set { _baseValue = value; }
    }
    public int BuffValue
    {
        get { return _buffValue; }
        set { _buffValue = value; }
    }
    public int ExpToLevel
    {
        get { return _expToLevel; }
        set { _expToLevel = value; }
    }
    public float LevelModifier
    {
        get { return _levelModifier; }
        set { _levelModifier = value; }
    }
    #endregion

    public int AdjustedBaseValue
    {
        get { return _baseValue + _buffValue; }

    }
    private int CalculateExpToLevel()
    {
        return (int)(_expToLevel * _levelModifier);
    }
    public void LevelUp()
    {
        _expToLevel = CalculateExpToLevel();
        _baseValue++;
    }
}
