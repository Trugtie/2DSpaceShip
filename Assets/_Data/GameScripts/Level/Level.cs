using UnityEngine;

public class Level : BaseMonobehaviour
{
    [Header(" Level Settings ")]
    [SerializeField] protected int _currentLevel = 0;
    [SerializeField] protected int _maxLevel = 99;

    public int CurrentLevel => _currentLevel;
    public int MaxLevel => _maxLevel;

    public virtual void LevelUp()
    {
        _currentLevel += 1;
        LimitLevel();
    }

    public virtual void LevelSet(int newLevel)
    {
        _currentLevel = newLevel;
        LimitLevel();
    }

    protected virtual void LimitLevel()
    {
        if (_currentLevel > _maxLevel) _currentLevel = _maxLevel;
        if (_currentLevel < 1) _currentLevel = 1;
    }
}
