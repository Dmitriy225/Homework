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
	public static class GameContextAPI
	{
		///Values
		public static readonly int Character; // IValue<IGameEntity>
		public static readonly int BulletPool; // IPrefabEntityPool<GameEntity>
		public static readonly int Score; // IReactiveVariable<int>

		static GameContextAPI()
		{
			//Values
			Character = NameToId(nameof(Character));
			BulletPool = NameToId(nameof(BulletPool));
			Score = NameToId(nameof(Score));
		}


		///Value Extensions

		#region Character

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<IGameEntity> GetCharacter(this IGameContext entity) => entity.GetValueUnsafe<IValue<IGameEntity>>(Character);

		public static ref IValue<IGameEntity> RefCharacter(this IGameContext entity) => ref entity.GetValueUnsafe<IValue<IGameEntity>>(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCharacter(this IGameContext entity, out IValue<IGameEntity> value) => entity.TryGetValueUnsafe(Character, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCharacter(this IGameContext entity, IValue<IGameEntity> value) => entity.AddValue(Character, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacter(this IGameContext entity) => entity.HasValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacter(this IGameContext entity) => entity.DelValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCharacter(this IGameContext entity, IValue<IGameEntity> value) => entity.SetValue(Character, value);

		#endregion

		#region BulletPool

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IPrefabEntityPool<GameEntity> GetBulletPool(this IGameContext entity) => entity.GetValueUnsafe<IPrefabEntityPool<GameEntity>>(BulletPool);

		public static ref IPrefabEntityPool<GameEntity> RefBulletPool(this IGameContext entity) => ref entity.GetValueUnsafe<IPrefabEntityPool<GameEntity>>(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBulletPool(this IGameContext entity, out IPrefabEntityPool<GameEntity> value) => entity.TryGetValueUnsafe(BulletPool, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddBulletPool(this IGameContext entity, IPrefabEntityPool<GameEntity> value) => entity.AddValue(BulletPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBulletPool(this IGameContext entity) => entity.HasValue(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBulletPool(this IGameContext entity) => entity.DelValue(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBulletPool(this IGameContext entity, IPrefabEntityPool<GameEntity> value) => entity.SetValue(BulletPool, value);

		#endregion

		#region Score

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetScore(this IGameContext entity) => entity.GetValueUnsafe<IReactiveVariable<int>>(Score);

		public static ref IReactiveVariable<int> RefScore(this IGameContext entity) => ref entity.GetValueUnsafe<IReactiveVariable<int>>(Score);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetScore(this IGameContext entity, out IReactiveVariable<int> value) => entity.TryGetValueUnsafe(Score, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddScore(this IGameContext entity, IReactiveVariable<int> value) => entity.AddValue(Score, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasScore(this IGameContext entity) => entity.HasValue(Score);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelScore(this IGameContext entity) => entity.DelValue(Score);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetScore(this IGameContext entity, IReactiveVariable<int> value) => entity.SetValue(Score, value);

		#endregion
    }
}
