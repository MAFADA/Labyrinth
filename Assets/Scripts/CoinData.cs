using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Coin Data", menuName = "Custom Asset/Coin Data")]
public class CoinData : ScriptableObject
{
    [SerializeField] public int value;
    [SerializeField] public Material material;

}
