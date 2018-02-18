using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class InputComponent : IComponent
{
	public Vector3 value;
}
