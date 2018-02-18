using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour
{
	public GameSetup gameSetup;
	private Systems _systems;

    private void Start()
    {
		var contexts = Contexts.sharedInstance;

		contexts.game.SetGameSetup(gameSetup);

		_systems = CreateSystems(contexts);
		_systems.Initialize();
    }

    private void Update()
    {
		_systems.Execute();
    }

	private Systems CreateSystems(Contexts contexts)
	{
		return new Feature("Game")
			.Add(new InitializePlayerSystem(contexts))
			.Add(new InitializeAsteroidsSystem(contexts))

			.Add(new HelloWorldSystem())
			.Add(new InputSystem(contexts))
			.Add(new ShootSystem(contexts))
			.Add(new HitAsteroidSystem(contexts))

			.Add(new MapAsteroidLevelToResourceSystem(contexts))

			.Add(new InstantiateViewSystem(contexts))

			.Add(new RotateLaserSystem(contexts))

			.Add(new RotatePlayerSystem(contexts))
			.Add(new ReplaceAccelerationSystem(contexts))
			.Add(new MoveSystem(contexts))

			.Add(new DestroySystem(contexts))
		;
	}
}
