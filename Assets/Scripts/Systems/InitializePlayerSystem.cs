using UnityEngine;
using Entitas;

public class InitializePlayerSystem : IInitializeSystem
{
    private Contexts _contexts;
    public InitializePlayerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.isPlayer = true;
        entity.AddResource(_contexts.game.gameSetup.value.player);
        entity.AddInitialPosition(Vector3.zero);
				entity.AddAcceleration(Vector3.zero);
    }
}
