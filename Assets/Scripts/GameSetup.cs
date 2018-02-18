using UnityEngine;
using Entitas.CodeGeneration.Attributes;

[CreateAssetMenu]
[Game, Unique]
public class GameSetup : ScriptableObject
{
	public GameObject player;
	public GameObject laser;
	public float rotationSpeed = 180f;
	public float playerMovementSpeed = 5f;
	public float laserSpeed = 10f;
	public float asteroidSpeed = 0.3f;

	public GameObject[] bigs;
	public GameObject[] meds;
	public GameObject[] smalls;
	public GameObject[] tinys;

}
