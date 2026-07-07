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
	public static class EntityAPI
	{
		///Values
		public static readonly int Position; // IVariable<Vector3>
		public static readonly int Rotation; // IVariable<Quaternion>
		public static readonly int Health; // Health
		public static readonly int MoveRequest; // IRequest<Vector3>
		public static readonly int MoveCondition; // IExpression<Vector3, bool>
		public static readonly int MoveAction; // ICompositeAction<Vector3, float>
		public static readonly int MoveEvent; // IEvent<Vector3>
		public static readonly int MoveSpeed; // IValue<float>
		public static readonly int RotateRequest; // IRequest<Vector3>
		public static readonly int RotateCondition; // IExpression<Vector3, bool>
		public static readonly int RotateAction; // ICompositeAction<Vector3, float>
		public static readonly int RotateEvent; // IEvent<Vector3>
		public static readonly int RotateSpeed; // IValue<float>

		static EntityAPI()
		{
			//Values
			Position = NameToId(nameof(Position));
			Rotation = NameToId(nameof(Rotation));
			Health = NameToId(nameof(Health));
			MoveRequest = NameToId(nameof(MoveRequest));
			MoveCondition = NameToId(nameof(MoveCondition));
			MoveAction = NameToId(nameof(MoveAction));
			MoveEvent = NameToId(nameof(MoveEvent));
			MoveSpeed = NameToId(nameof(MoveSpeed));
			RotateRequest = NameToId(nameof(RotateRequest));
			RotateCondition = NameToId(nameof(RotateCondition));
			RotateAction = NameToId(nameof(RotateAction));
			RotateEvent = NameToId(nameof(RotateEvent));
			RotateSpeed = NameToId(nameof(RotateSpeed));
		}


		///Value Extensions

		#region Position

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<Vector3> GetPosition(this IEntity entity) => entity.GetValueUnsafe<IVariable<Vector3>>(Position);

		public static ref IVariable<Vector3> RefPosition(this IEntity entity) => ref entity.GetValueUnsafe<IVariable<Vector3>>(Position);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPosition(this IEntity entity, out IVariable<Vector3> value) => entity.TryGetValueUnsafe(Position, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPosition(this IEntity entity, IVariable<Vector3> value) => entity.AddValue(Position, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPosition(this IEntity entity) => entity.HasValue(Position);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPosition(this IEntity entity) => entity.DelValue(Position);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPosition(this IEntity entity, IVariable<Vector3> value) => entity.SetValue(Position, value);

		#endregion

		#region Rotation

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<Quaternion> GetRotation(this IEntity entity) => entity.GetValueUnsafe<IVariable<Quaternion>>(Rotation);

		public static ref IVariable<Quaternion> RefRotation(this IEntity entity) => ref entity.GetValueUnsafe<IVariable<Quaternion>>(Rotation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotation(this IEntity entity, out IVariable<Quaternion> value) => entity.TryGetValueUnsafe(Rotation, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotation(this IEntity entity, IVariable<Quaternion> value) => entity.AddValue(Rotation, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotation(this IEntity entity) => entity.HasValue(Rotation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotation(this IEntity entity) => entity.DelValue(Rotation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotation(this IEntity entity, IVariable<Quaternion> value) => entity.SetValue(Rotation, value);

		#endregion

		#region Health

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Health GetHealth(this IEntity entity) => entity.GetValueUnsafe<Health>(Health);

		public static ref Health RefHealth(this IEntity entity) => ref entity.GetValueUnsafe<Health>(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealth(this IEntity entity, out Health value) => entity.TryGetValueUnsafe(Health, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddHealth(this IEntity entity, Health value) => entity.AddValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealth(this IEntity entity) => entity.HasValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealth(this IEntity entity) => entity.DelValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealth(this IEntity entity, Health value) => entity.SetValue(Health, value);

		#endregion

		#region MoveRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest<Vector3> GetMoveRequest(this IEntity entity) => entity.GetValueUnsafe<IRequest<Vector3>>(MoveRequest);

		public static ref IRequest<Vector3> RefMoveRequest(this IEntity entity) => ref entity.GetValueUnsafe<IRequest<Vector3>>(MoveRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveRequest(this IEntity entity, out IRequest<Vector3> value) => entity.TryGetValueUnsafe(MoveRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveRequest(this IEntity entity, IRequest<Vector3> value) => entity.AddValue(MoveRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveRequest(this IEntity entity) => entity.HasValue(MoveRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveRequest(this IEntity entity) => entity.DelValue(MoveRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveRequest(this IEntity entity, IRequest<Vector3> value) => entity.SetValue(MoveRequest, value);

		#endregion

		#region MoveCondition

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<Vector3, bool> GetMoveCondition(this IEntity entity) => entity.GetValueUnsafe<IExpression<Vector3, bool>>(MoveCondition);

		public static ref IExpression<Vector3, bool> RefMoveCondition(this IEntity entity) => ref entity.GetValueUnsafe<IExpression<Vector3, bool>>(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveCondition(this IEntity entity, out IExpression<Vector3, bool> value) => entity.TryGetValueUnsafe(MoveCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveCondition(this IEntity entity, IExpression<Vector3, bool> value) => entity.AddValue(MoveCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveCondition(this IEntity entity) => entity.HasValue(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveCondition(this IEntity entity) => entity.DelValue(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveCondition(this IEntity entity, IExpression<Vector3, bool> value) => entity.SetValue(MoveCondition, value);

		#endregion

		#region MoveAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction<Vector3, float> GetMoveAction(this IEntity entity) => entity.GetValueUnsafe<ICompositeAction<Vector3, float>>(MoveAction);

		public static ref ICompositeAction<Vector3, float> RefMoveAction(this IEntity entity) => ref entity.GetValueUnsafe<ICompositeAction<Vector3, float>>(MoveAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveAction(this IEntity entity, out ICompositeAction<Vector3, float> value) => entity.TryGetValueUnsafe(MoveAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveAction(this IEntity entity, ICompositeAction<Vector3, float> value) => entity.AddValue(MoveAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveAction(this IEntity entity) => entity.HasValue(MoveAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveAction(this IEntity entity) => entity.DelValue(MoveAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveAction(this IEntity entity, ICompositeAction<Vector3, float> value) => entity.SetValue(MoveAction, value);

		#endregion

		#region MoveEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<Vector3> GetMoveEvent(this IEntity entity) => entity.GetValueUnsafe<IEvent<Vector3>>(MoveEvent);

		public static ref IEvent<Vector3> RefMoveEvent(this IEntity entity) => ref entity.GetValueUnsafe<IEvent<Vector3>>(MoveEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveEvent(this IEntity entity, out IEvent<Vector3> value) => entity.TryGetValueUnsafe(MoveEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveEvent(this IEntity entity, IEvent<Vector3> value) => entity.AddValue(MoveEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveEvent(this IEntity entity) => entity.HasValue(MoveEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveEvent(this IEntity entity) => entity.DelValue(MoveEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveEvent(this IEntity entity, IEvent<Vector3> value) => entity.SetValue(MoveEvent, value);

		#endregion

		#region MoveSpeed

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetMoveSpeed(this IEntity entity) => entity.GetValueUnsafe<IValue<float>>(MoveSpeed);

		public static ref IValue<float> RefMoveSpeed(this IEntity entity) => ref entity.GetValueUnsafe<IValue<float>>(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveSpeed(this IEntity entity, out IValue<float> value) => entity.TryGetValueUnsafe(MoveSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveSpeed(this IEntity entity, IValue<float> value) => entity.AddValue(MoveSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveSpeed(this IEntity entity) => entity.HasValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveSpeed(this IEntity entity) => entity.DelValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveSpeed(this IEntity entity, IValue<float> value) => entity.SetValue(MoveSpeed, value);

		#endregion

		#region RotateRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest<Vector3> GetRotateRequest(this IEntity entity) => entity.GetValueUnsafe<IRequest<Vector3>>(RotateRequest);

		public static ref IRequest<Vector3> RefRotateRequest(this IEntity entity) => ref entity.GetValueUnsafe<IRequest<Vector3>>(RotateRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateRequest(this IEntity entity, out IRequest<Vector3> value) => entity.TryGetValueUnsafe(RotateRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateRequest(this IEntity entity, IRequest<Vector3> value) => entity.AddValue(RotateRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateRequest(this IEntity entity) => entity.HasValue(RotateRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateRequest(this IEntity entity) => entity.DelValue(RotateRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateRequest(this IEntity entity, IRequest<Vector3> value) => entity.SetValue(RotateRequest, value);

		#endregion

		#region RotateCondition

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<Vector3, bool> GetRotateCondition(this IEntity entity) => entity.GetValueUnsafe<IExpression<Vector3, bool>>(RotateCondition);

		public static ref IExpression<Vector3, bool> RefRotateCondition(this IEntity entity) => ref entity.GetValueUnsafe<IExpression<Vector3, bool>>(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateCondition(this IEntity entity, out IExpression<Vector3, bool> value) => entity.TryGetValueUnsafe(RotateCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateCondition(this IEntity entity, IExpression<Vector3, bool> value) => entity.AddValue(RotateCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateCondition(this IEntity entity) => entity.HasValue(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateCondition(this IEntity entity) => entity.DelValue(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateCondition(this IEntity entity, IExpression<Vector3, bool> value) => entity.SetValue(RotateCondition, value);

		#endregion

		#region RotateAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction<Vector3, float> GetRotateAction(this IEntity entity) => entity.GetValueUnsafe<ICompositeAction<Vector3, float>>(RotateAction);

		public static ref ICompositeAction<Vector3, float> RefRotateAction(this IEntity entity) => ref entity.GetValueUnsafe<ICompositeAction<Vector3, float>>(RotateAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateAction(this IEntity entity, out ICompositeAction<Vector3, float> value) => entity.TryGetValueUnsafe(RotateAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateAction(this IEntity entity, ICompositeAction<Vector3, float> value) => entity.AddValue(RotateAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateAction(this IEntity entity) => entity.HasValue(RotateAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateAction(this IEntity entity) => entity.DelValue(RotateAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateAction(this IEntity entity, ICompositeAction<Vector3, float> value) => entity.SetValue(RotateAction, value);

		#endregion

		#region RotateEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<Vector3> GetRotateEvent(this IEntity entity) => entity.GetValueUnsafe<IEvent<Vector3>>(RotateEvent);

		public static ref IEvent<Vector3> RefRotateEvent(this IEntity entity) => ref entity.GetValueUnsafe<IEvent<Vector3>>(RotateEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateEvent(this IEntity entity, out IEvent<Vector3> value) => entity.TryGetValueUnsafe(RotateEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateEvent(this IEntity entity, IEvent<Vector3> value) => entity.AddValue(RotateEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateEvent(this IEntity entity) => entity.HasValue(RotateEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateEvent(this IEntity entity) => entity.DelValue(RotateEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateEvent(this IEntity entity, IEvent<Vector3> value) => entity.SetValue(RotateEvent, value);

		#endregion

		#region RotateSpeed

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetRotateSpeed(this IEntity entity) => entity.GetValueUnsafe<IValue<float>>(RotateSpeed);

		public static ref IValue<float> RefRotateSpeed(this IEntity entity) => ref entity.GetValueUnsafe<IValue<float>>(RotateSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateSpeed(this IEntity entity, out IValue<float> value) => entity.TryGetValueUnsafe(RotateSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateSpeed(this IEntity entity, IValue<float> value) => entity.AddValue(RotateSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateSpeed(this IEntity entity) => entity.HasValue(RotateSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateSpeed(this IEntity entity) => entity.DelValue(RotateSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateSpeed(this IEntity entity, IValue<float> value) => entity.SetValue(RotateSpeed, value);

		#endregion
    }
}
