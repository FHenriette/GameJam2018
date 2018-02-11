using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIControl : MonoBehaviour {
	public GameObject MenuButtons;
	public Text Level, Health, Mana, MovementPoints, Attack, Armor, AttackPoints;
	public Image WinPanel, GameOverPanel, InGameUI, ControlsOverview, Credits;
	public Canvas MainMenu;
	public Player player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Level.text = player.currentLevel.ToString();
		Health.text = player.currentHealth.ToString ();
		Mana.text = player.currentMana.ToString ();
		MovementPoints.text = player.currentMP.ToString ();
		Attack.text = player.currentAttack.ToString ();
		Armor.text = player.currentArmor.ToString ();
		AttackPoints.text = player.currentAP.ToString();
		
	}
}
