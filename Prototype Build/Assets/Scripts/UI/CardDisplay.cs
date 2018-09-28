using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

	public CardData card;

	public Text nameText;
	public Text descriptionText;

	public Image artworkImage;

	public Text staminaText;
	public Text attackText;
	public Text defenseText;
	public Text healingText;

	// Use this for initialization
	void Start () {
		nameText.text = card.name;
		descriptionText.text = card.description;

		//artworkImage.sprite = card.artwork;

		staminaText.text = card.staminaCost.ToString();
		attackText.text = card.attack.ToString();
		defenseText.text = card.defence.ToString();
		//healingText.text = card.healing.ToString();
	}
	
}
