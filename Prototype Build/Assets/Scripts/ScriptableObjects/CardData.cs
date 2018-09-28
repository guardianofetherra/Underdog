using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "UnderdogProject/CardData" )]
public class CardData : ScriptableObject {
	public new string name;
	public Sprite artwork;
	public string description;
	public int staminaCost;
	public int attack;
	public int defence;
	public int healing;


}
