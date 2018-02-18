using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class ViewComponent : IComponent
{
	[EntityIndex]
	public GameObject value;
}
