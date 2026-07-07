/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using static Atomic.Entities.EntityNames;
using System.Runtime.CompilerServices;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using Atomic.Entities;
using Atomic.Elements;

namespace Game
{
#if UNITY_EDITOR
	[InitializeOnLoad]
#endif
	public static class PlayerContextAPI
	{
		///Values
		public static readonly int Character; // IValue<IEntity>

		static PlayerContextAPI()
		{
			//Values
			Character = NameToId(nameof(Character));
		}


		///Value Extensions

		#region Character

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<IEntity> GetCharacter(this IPlayerContext entity) => entity.GetValueUnsafe<IValue<IEntity>>(Character);

		public static ref IValue<IEntity> RefCharacter(this IPlayerContext entity) => ref entity.GetValueUnsafe<IValue<IEntity>>(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCharacter(this IPlayerContext entity, out IValue<IEntity> value) => entity.TryGetValueUnsafe(Character, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCharacter(this IPlayerContext entity, IValue<IEntity> value) => entity.AddValue(Character, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacter(this IPlayerContext entity) => entity.HasValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacter(this IPlayerContext entity) => entity.DelValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCharacter(this IPlayerContext entity, IValue<IEntity> value) => entity.SetValue(Character, value);

		#endregion
    }
}
