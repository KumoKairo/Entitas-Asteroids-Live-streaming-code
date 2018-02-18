using UnityEngine;
using Entitas;

public class ReplaceAccelerationSystem : IExecuteSystem
{
    private Contexts _contexts;
    public ReplaceAccelerationSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
		var input = _contexts.game.input.value.y;
		var player = _contexts.game.playerEntity;
        var playerTransform = player.view.value.transform;
		var forward = playerTransform.up;
		var movementSpeed = _contexts.game.gameSetup.value.playerMovementSpeed;

		var acceleration = player.acceleration.value;
		
		player.ReplaceAcceleration(acceleration 
			+ input * forward * movementSpeed * Time.deltaTime);
    }
}
