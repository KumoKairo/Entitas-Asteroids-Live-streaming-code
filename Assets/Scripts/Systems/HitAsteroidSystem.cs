using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class HitAsteroidSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public HitAsteroidSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Collision);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCollision;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var first = entity.collision.first;
            var second = entity.collision.second;

            var firstEntity = _contexts.game.GetEntitiesWithView(first).SingleEntity();
            var secondEntity = _contexts.game.GetEntitiesWithView(second).SingleEntity();

            if (secondEntity.asteroid.level > 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    var newEntity = _contexts.game.CreateEntity();
                    newEntity.AddAsteroid(secondEntity.asteroid.level - 1);

                    newEntity.AddInitialPosition(
                        second.transform.position +
                        new Vector3(Random.Range(-0.05f, 0.05f),
                            Random.Range(-0.05f, 0.05f), 0f));
                }
            }

            firstEntity.isDestroy = true;
            secondEntity.isDestroy = true;
        }
    }
}
