using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BulletSequence", order = 1)]
public class BulletSequence : ScriptableObject
{
    [SerializeField]
    public SequenceData[] sequenceData;

    [System.Serializable]
    public class SequenceData
    {
        public BulletSpawn bulletSpawn;
        public float timeToWaitAfter;
    }
}
