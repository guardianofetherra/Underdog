using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "UnderdogProject/PlayerData" )]
public class PlayerData : ScriptableObject {
	public new string playerName;
	public float maxHealth;
	public float playerHealth;
	public int stamina;
	public float exp;
	public int level;


}
