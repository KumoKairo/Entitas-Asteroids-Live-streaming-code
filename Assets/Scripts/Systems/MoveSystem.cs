using UnityEngine;
using Entitas;

public class MoveSystem : IExecuteSystem
{
	private Contexts _contexts;
	private IGroup<GameEntity> _group;
    public MoveSystem(Contexts contexts)
    {
        _contexts = contexts;
		_group = contexts.game.GetGroup(GameMatcher.AllOf(
			GameMatcher.Acceleration, GameMatcher.View));
    }

    public void Execute()
    {
		foreach(var entity in _group)
		{
			var view = entity.view.value;
			var acceleration = entity.acceleration.value;
			var position = view.transform.position;
			position += acceleration * Time.deltaTime;
			view.transform.position = position;
		}
    }
}
