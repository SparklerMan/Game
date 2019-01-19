using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new enemy", menuName = "enemy")]
public class enemies : ScriptableObject {
    public float health, damage;
    public Sprite look;

}
