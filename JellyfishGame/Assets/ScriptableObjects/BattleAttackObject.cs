using UnityEngine;
[System.Serializable]
public class BattleAttackObject : ScriptableObject
{
    public BulletSequence bulletSequence;
    public bool isMoveTweeningEnabled = false;
    public Vector2 moveTweenStart;
    public Vector2 moveTweenDestination;
    public bool isRotationTweeningEnabled = false;
    public float minRotation;
    public float maxRotation;
} 