using UnityEngine;
using Entitas;

public class ShootSystem : IExecuteSystem
{
	private Contexts _contexts;
	public ShootSystem(Contexts contexts)
	{
		_contexts = contexts;
	}

    public void Execute()
    {
        if (Input.GetButtonDown("Fire"))
        {
			var entity = _contexts.game.CreateEntity();
			var setup = _contexts.game.gameSetup.value;
			entity.AddResource(setup.laser);
			var playerTransform = _contexts.game.playerEntity.view.value.transform;
			var playerForward = playerTransform.up;
			entity.AddAcceleration(playerForward * setup.laserSpeed);
			entity.AddInitialPosition(playerTransform.position);
			entity.isLaser = true;
        }
    }
}
