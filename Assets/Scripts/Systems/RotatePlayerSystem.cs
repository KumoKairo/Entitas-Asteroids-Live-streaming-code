using UnityEngine;
using Entitas;

public class RotatePlayerSystem : IExecuteSystem
{
	private Contexts _contexts;
	public RotatePlayerSystem(Contexts contexts)
	{
		_contexts = contexts;
	}

    public void Execute()
    {
		var input = _contexts.game.input.value.x;
        var playerTransform = _contexts.game.playerEntity.view.value.transform;
        var playerRotation = playerTransform.rotation.eulerAngles;
        playerRotation.z -= input * _contexts.game.gameSetup.value.rotationSpeed 
            * Time.deltaTime;

        playerTransform.rotation = Quaternion.Euler(playerRotation);
    }
}
