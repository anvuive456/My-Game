using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Foe", menuName = "Foe/Thêm kẻ thù")]
public class FoeBase : ScriptableObject
{
    [SerializeField] private string foeName;
    [TextArea] [SerializeField] private string description;
    [SerializeField] private Sprite sprite;

    public string FoeName => foeName;
    public string Description => description;
   
}