using UnityEngine;
using Entitas;
using System.Collections.Generic;

public class RotateLaserSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public RotateLaserSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(
			GameMatcher.View, 
			GameMatcher.Laser,
			GameMatcher.Acceleration));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.isLaser && entity.hasAcceleration;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
			var view = entity.view.value.transform;
			var accel = entity.acceleration.value;
			view.transform.up = accel.normalized;
        }
    }
}
