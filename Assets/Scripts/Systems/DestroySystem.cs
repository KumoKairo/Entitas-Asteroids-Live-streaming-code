using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class DestroySystem : ReactiveSystem<GameEntity>
{
	private Contexts _contexts;
    public DestroySystem(Contexts contexts) : base(contexts.game)
    {
		_contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroy);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
		foreach(var entity in entities)
		{
			if(entity.hasView)
			{
				var view = entity.view.value;
				view.Unlink();
				Object.Destroy(view);
			}

			entity.Destroy();
		}
	}
}
