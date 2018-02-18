using UnityEngine;
using System.Collections.Generic;
using Entitas;

public class MapAsteroidLevelToResourceSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public MapAsteroidLevelToResourceSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Asteroid);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAsteroid;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var setup = _contexts.game.gameSetup.value;
        foreach (var entity in entities)
        {
            entity.AddResource(MapAsteroidLevelToResource(entity.asteroid.level, setup));
            var randomAngle = Random.Range(0f, 2f);
            
            var speed = _contexts.game.gameSetup.value.asteroidSpeed;

            entity.AddAcceleration(new Vector3(
                speed * Mathf.Cos(randomAngle),
                speed * Mathf.Sin(randomAngle), 0f));
        }
    }

    private GameObject MapAsteroidLevelToResource(int level, GameSetup setup)
    {
        switch (level)
        {
            case 0:
                return setup.tinys[Random.Range(0, setup.tinys.Length)];
            case 1:
                return setup.smalls[Random.Range(0, setup.smalls.Length)];
            case 2:
                return setup.meds[Random.Range(0, setup.meds.Length)];
            default:
                return setup.bigs[Random.Range(0, setup.bigs.Length)];
        }
    }
}
