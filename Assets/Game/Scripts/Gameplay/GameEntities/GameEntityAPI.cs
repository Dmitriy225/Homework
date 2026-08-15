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
	public static class GameEntityAPI
	{

		///Tags
		public static readonly int Character;
		public static readonly int Interactable;

		///Values
		public static readonly int Health; // Health
		public static readonly int Trigger; // TriggerEvents
		public static readonly int CollisionEvents; // CollisionEvents
		public static readonly int AnimEvents; // AnimationEvents
		public static readonly int Target; // IReactiveVariable<IGameEntity>
		public static readonly int Position; // IVariable<Vector3>
		public static readonly int Rotation; // IVariable<Quaternion>
		public static readonly int MoveRequest; // IRequest<Vector3>
		public static readonly int MoveCondition; // IExpression<Vector3, bool>
		public static readonly int MoveAction; // ICompositeAction<Vector3, float>
		public static readonly int MoveEvent; // IEvent<Vector3>
		public static readonly int MoveSpeed; // IValue<float>
		public static readonly int PostMoveCooldown; // ICooldown
		public static readonly int RotateRequest; // IRequest<Vector3>
		public static readonly int RotateCondition; // IExpression<Vector3, bool>
		public static readonly int RotateAction; // ICompositeAction<Vector3, float>
		public static readonly int RotateEvent; // IEvent<Vector3>
		public static readonly int RotateSpeed; // IValue<float>
		public static readonly int FireRequest; // IRequest
		public static readonly int FireCondition; // IExpression<bool>
		public static readonly int FireAction; // ICompositeAction
		public static readonly int FireEvent; // IEvent
		public static readonly int FireAnimDrivenEvent; // IEvent
		public static readonly int FireCooldown; // ICooldown
		public static readonly int AimRequest; // IRequest<Vector3>
		public static readonly int AimCondition; // IExpression<Vector3, bool>
		public static readonly int AimAction; // ICompositeAction<Vector3, float>
		public static readonly int AimEvent; // IEvent<Vector3>
		public static readonly int PostAimTimer; // ITimer
		public static readonly int Weapon; // IValue<IGameEntity>
		public static readonly int FirePosition; // IValue<Vector3>
		public static readonly int BulletPrefab; // IVariable<GameEntity>
		public static readonly int FireSpread; // IValue<float>
		public static readonly int Ammo; // IReactiveVariable<int>
		public static readonly int Damage; // IValue<int>
		public static readonly int InteractCondition; // IExpression<IGameEntity, bool>
		public static readonly int InteractAction; // ICompositeAction<IGameEntity>
		public static readonly int InteractEvent; // IEvent<IGameEntity>
		public static readonly int Animator; // Animator
		public static readonly int AudioSource; // AudioSource

		static GameEntityAPI()
		{
			//Tags
			Character = NameToId(nameof(Character));
			Interactable = NameToId(nameof(Interactable));

			//Values
			Health = NameToId(nameof(Health));
			Trigger = NameToId(nameof(Trigger));
			CollisionEvents = NameToId(nameof(CollisionEvents));
			AnimEvents = NameToId(nameof(AnimEvents));
			Target = NameToId(nameof(Target));
			Position = NameToId(nameof(Position));
			Rotation = NameToId(nameof(Rotation));
			MoveRequest = NameToId(nameof(MoveRequest));
			MoveCondition = NameToId(nameof(MoveCondition));
			MoveAction = NameToId(nameof(MoveAction));
			MoveEvent = NameToId(nameof(MoveEvent));
			MoveSpeed = NameToId(nameof(MoveSpeed));
			PostMoveCooldown = NameToId(nameof(PostMoveCooldown));
			RotateRequest = NameToId(nameof(RotateRequest));
			RotateCondition = NameToId(nameof(RotateCondition));
			RotateAction = NameToId(nameof(RotateAction));
			RotateEvent = NameToId(nameof(RotateEvent));
			RotateSpeed = NameToId(nameof(RotateSpeed));
			FireRequest = NameToId(nameof(FireRequest));
			FireCondition = NameToId(nameof(FireCondition));
			FireAction = NameToId(nameof(FireAction));
			FireEvent = NameToId(nameof(FireEvent));
			FireAnimDrivenEvent = NameToId(nameof(FireAnimDrivenEvent));
			FireCooldown = NameToId(nameof(FireCooldown));
			AimRequest = NameToId(nameof(AimRequest));
			AimCondition = NameToId(nameof(AimCondition));
			AimAction = NameToId(nameof(AimAction));
			AimEvent = NameToId(nameof(AimEvent));
			PostAimTimer = NameToId(nameof(PostAimTimer));
			Weapon = NameToId(nameof(Weapon));
			FirePosition = NameToId(nameof(FirePosition));
			BulletPrefab = NameToId(nameof(BulletPrefab));
			FireSpread = NameToId(nameof(FireSpread));
			Ammo = NameToId(nameof(Ammo));
			Damage = NameToId(nameof(Damage));
			InteractCondition = NameToId(nameof(InteractCondition));
			InteractAction = NameToId(nameof(InteractAction));
			InteractEvent = NameToId(nameof(InteractEvent));
			Animator = NameToId(nameof(Animator));
			AudioSource = NameToId(nameof(AudioSource));
		}


		///Tag Extensions

		#region Character

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacterTag(this IGameEntity entity) => entity.HasTag(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCharacterTag(this IGameEntity entity) => entity.AddTag(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacterTag(this IGameEntity entity) => entity.DelTag(Character);

		#endregion

		#region Interactable

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractableTag(this IGameEntity entity) => entity.HasTag(Interactable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddInteractableTag(this IGameEntity entity) => entity.AddTag(Interactable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractableTag(this IGameEntity entity) => entity.DelTag(Interactable);

		#endregion


		///Value Extensions

		#region Health

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Health GetHealth(this IGameEntity entity) => entity.GetValueUnsafe<Health>(Health);

		public static ref Health RefHealth(this IGameEntity entity) => ref entity.GetValueUnsafe<Health>(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealth(this IGameEntity entity, out Health value) => entity.TryGetValueUnsafe(Health, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddHealth(this IGameEntity entity, Health value) => entity.AddValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealth(this IGameEntity entity) => entity.HasValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealth(this IGameEntity entity) => entity.DelValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealth(this IGameEntity entity, Health value) => entity.SetValue(Health, value);

		#endregion

		#region Trigger

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TriggerEvents GetTrigger(this IGameEntity entity) => entity.GetValueUnsafe<TriggerEvents>(Trigger);

		public static ref TriggerEvents RefTrigger(this IGameEntity entity) => ref entity.GetValueUnsafe<TriggerEvents>(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTrigger(this IGameEntity entity, out TriggerEvents value) => entity.TryGetValueUnsafe(Trigger, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTrigger(this IGameEntity entity, TriggerEvents value) => entity.AddValue(Trigger, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTrigger(this IGameEntity entity) => entity.HasValue(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTrigger(this IGameEntity entity) => entity.DelValue(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTrigger(this IGameEntity entity, TriggerEvents value) => entity.SetValue(Trigger, value);

		#endregion

		#region CollisionEvents

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static CollisionEvents GetCollisionEvents(this IGameEntity entity) => entity.GetValueUnsafe<CollisionEvents>(CollisionEvents);

		public static ref CollisionEvents RefCollisionEvents(this IGameEntity entity) => ref entity.GetValueUnsafe<CollisionEvents>(CollisionEvents);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCollisionEvents(this IGameEntity entity, out CollisionEvents value) => entity.TryGetValueUnsafe(CollisionEvents, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddCollisionEvents(this IGameEntity entity, CollisionEvents value) => entity.AddValue(CollisionEvents, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCollisionEvents(this IGameEntity entity) => entity.HasValue(CollisionEvents);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCollisionEvents(this IGameEntity entity) => entity.DelValue(CollisionEvents);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCollisionEvents(this IGameEntity entity, CollisionEvents value) => entity.SetValue(CollisionEvents, value);

		#endregion

		#region AnimEvents

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AnimationEvents GetAnimEvents(this IGameEntity entity) => entity.GetValueUnsafe<AnimationEvents>(AnimEvents);

		public static ref AnimationEvents RefAnimEvents(this IGameEntity entity) => ref entity.GetValueUnsafe<AnimationEvents>(AnimEvents);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimEvents(this IGameEntity entity, out AnimationEvents value) => entity.TryGetValueUnsafe(AnimEvents, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAnimEvents(this IGameEntity entity, AnimationEvents value) => entity.AddValue(AnimEvents, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimEvents(this IGameEntity entity) => entity.HasValue(AnimEvents);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimEvents(this IGameEntity entity) => entity.DelValue(AnimEvents);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimEvents(this IGameEntity entity, AnimationEvents value) => entity.SetValue(AnimEvents, value);

		#endregion

		#region Target

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<IGameEntity> GetTarget(this IGameEntity entity) => entity.GetValueUnsafe<IReactiveVariable<IGameEntity>>(Target);

		public static ref IReactiveVariable<IGameEntity> RefTarget(this IGameEntity entity) => ref entity.GetValueUnsafe<IReactiveVariable<IGameEntity>>(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTarget(this IGameEntity entity, out IReactiveVariable<IGameEntity> value) => entity.TryGetValueUnsafe(Target, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddTarget(this IGameEntity entity, IReactiveVariable<IGameEntity> value) => entity.AddValue(Target, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTarget(this IGameEntity entity) => entity.HasValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTarget(this IGameEntity entity) => entity.DelValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTarget(this IGameEntity entity, IReactiveVariable<IGameEntity> value) => entity.SetValue(Target, value);

		#endregion

		#region Position

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<Vector3> GetPosition(this IGameEntity entity) => entity.GetValueUnsafe<IVariable<Vector3>>(Position);

		public static ref IVariable<Vector3> RefPosition(this IGameEntity entity) => ref entity.GetValueUnsafe<IVariable<Vector3>>(Position);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPosition(this IGameEntity entity, out IVariable<Vector3> value) => entity.TryGetValueUnsafe(Position, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPosition(this IGameEntity entity, IVariable<Vector3> value) => entity.AddValue(Position, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPosition(this IGameEntity entity) => entity.HasValue(Position);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPosition(this IGameEntity entity) => entity.DelValue(Position);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPosition(this IGameEntity entity, IVariable<Vector3> value) => entity.SetValue(Position, value);

		#endregion

		#region Rotation

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<Quaternion> GetRotation(this IGameEntity entity) => entity.GetValueUnsafe<IVariable<Quaternion>>(Rotation);

		public static ref IVariable<Quaternion> RefRotation(this IGameEntity entity) => ref entity.GetValueUnsafe<IVariable<Quaternion>>(Rotation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotation(this IGameEntity entity, out IVariable<Quaternion> value) => entity.TryGetValueUnsafe(Rotation, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotation(this IGameEntity entity, IVariable<Quaternion> value) => entity.AddValue(Rotation, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotation(this IGameEntity entity) => entity.HasValue(Rotation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotation(this IGameEntity entity) => entity.DelValue(Rotation);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotation(this IGameEntity entity, IVariable<Quaternion> value) => entity.SetValue(Rotation, value);

		#endregion

		#region MoveRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest<Vector3> GetMoveRequest(this IGameEntity entity) => entity.GetValueUnsafe<IRequest<Vector3>>(MoveRequest);

		public static ref IRequest<Vector3> RefMoveRequest(this IGameEntity entity) => ref entity.GetValueUnsafe<IRequest<Vector3>>(MoveRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveRequest(this IGameEntity entity, out IRequest<Vector3> value) => entity.TryGetValueUnsafe(MoveRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveRequest(this IGameEntity entity, IRequest<Vector3> value) => entity.AddValue(MoveRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveRequest(this IGameEntity entity) => entity.HasValue(MoveRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveRequest(this IGameEntity entity) => entity.DelValue(MoveRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveRequest(this IGameEntity entity, IRequest<Vector3> value) => entity.SetValue(MoveRequest, value);

		#endregion

		#region MoveCondition

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<Vector3, bool> GetMoveCondition(this IGameEntity entity) => entity.GetValueUnsafe<IExpression<Vector3, bool>>(MoveCondition);

		public static ref IExpression<Vector3, bool> RefMoveCondition(this IGameEntity entity) => ref entity.GetValueUnsafe<IExpression<Vector3, bool>>(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveCondition(this IGameEntity entity, out IExpression<Vector3, bool> value) => entity.TryGetValueUnsafe(MoveCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveCondition(this IGameEntity entity, IExpression<Vector3, bool> value) => entity.AddValue(MoveCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveCondition(this IGameEntity entity) => entity.HasValue(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveCondition(this IGameEntity entity) => entity.DelValue(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveCondition(this IGameEntity entity, IExpression<Vector3, bool> value) => entity.SetValue(MoveCondition, value);

		#endregion

		#region MoveAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction<Vector3, float> GetMoveAction(this IGameEntity entity) => entity.GetValueUnsafe<ICompositeAction<Vector3, float>>(MoveAction);

		public static ref ICompositeAction<Vector3, float> RefMoveAction(this IGameEntity entity) => ref entity.GetValueUnsafe<ICompositeAction<Vector3, float>>(MoveAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveAction(this IGameEntity entity, out ICompositeAction<Vector3, float> value) => entity.TryGetValueUnsafe(MoveAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveAction(this IGameEntity entity, ICompositeAction<Vector3, float> value) => entity.AddValue(MoveAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveAction(this IGameEntity entity) => entity.HasValue(MoveAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveAction(this IGameEntity entity) => entity.DelValue(MoveAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveAction(this IGameEntity entity, ICompositeAction<Vector3, float> value) => entity.SetValue(MoveAction, value);

		#endregion

		#region MoveEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<Vector3> GetMoveEvent(this IGameEntity entity) => entity.GetValueUnsafe<IEvent<Vector3>>(MoveEvent);

		public static ref IEvent<Vector3> RefMoveEvent(this IGameEntity entity) => ref entity.GetValueUnsafe<IEvent<Vector3>>(MoveEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveEvent(this IGameEntity entity, out IEvent<Vector3> value) => entity.TryGetValueUnsafe(MoveEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveEvent(this IGameEntity entity, IEvent<Vector3> value) => entity.AddValue(MoveEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveEvent(this IGameEntity entity) => entity.HasValue(MoveEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveEvent(this IGameEntity entity) => entity.DelValue(MoveEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveEvent(this IGameEntity entity, IEvent<Vector3> value) => entity.SetValue(MoveEvent, value);

		#endregion

		#region MoveSpeed

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetMoveSpeed(this IGameEntity entity) => entity.GetValueUnsafe<IValue<float>>(MoveSpeed);

		public static ref IValue<float> RefMoveSpeed(this IGameEntity entity) => ref entity.GetValueUnsafe<IValue<float>>(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveSpeed(this IGameEntity entity, out IValue<float> value) => entity.TryGetValueUnsafe(MoveSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddMoveSpeed(this IGameEntity entity, IValue<float> value) => entity.AddValue(MoveSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveSpeed(this IGameEntity entity) => entity.HasValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveSpeed(this IGameEntity entity) => entity.DelValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveSpeed(this IGameEntity entity, IValue<float> value) => entity.SetValue(MoveSpeed, value);

		#endregion

		#region PostMoveCooldown

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICooldown GetPostMoveCooldown(this IGameEntity entity) => entity.GetValueUnsafe<ICooldown>(PostMoveCooldown);

		public static ref ICooldown RefPostMoveCooldown(this IGameEntity entity) => ref entity.GetValueUnsafe<ICooldown>(PostMoveCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPostMoveCooldown(this IGameEntity entity, out ICooldown value) => entity.TryGetValueUnsafe(PostMoveCooldown, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPostMoveCooldown(this IGameEntity entity, ICooldown value) => entity.AddValue(PostMoveCooldown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPostMoveCooldown(this IGameEntity entity) => entity.HasValue(PostMoveCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPostMoveCooldown(this IGameEntity entity) => entity.DelValue(PostMoveCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPostMoveCooldown(this IGameEntity entity, ICooldown value) => entity.SetValue(PostMoveCooldown, value);

		#endregion

		#region RotateRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest<Vector3> GetRotateRequest(this IGameEntity entity) => entity.GetValueUnsafe<IRequest<Vector3>>(RotateRequest);

		public static ref IRequest<Vector3> RefRotateRequest(this IGameEntity entity) => ref entity.GetValueUnsafe<IRequest<Vector3>>(RotateRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateRequest(this IGameEntity entity, out IRequest<Vector3> value) => entity.TryGetValueUnsafe(RotateRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateRequest(this IGameEntity entity, IRequest<Vector3> value) => entity.AddValue(RotateRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateRequest(this IGameEntity entity) => entity.HasValue(RotateRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateRequest(this IGameEntity entity) => entity.DelValue(RotateRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateRequest(this IGameEntity entity, IRequest<Vector3> value) => entity.SetValue(RotateRequest, value);

		#endregion

		#region RotateCondition

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<Vector3, bool> GetRotateCondition(this IGameEntity entity) => entity.GetValueUnsafe<IExpression<Vector3, bool>>(RotateCondition);

		public static ref IExpression<Vector3, bool> RefRotateCondition(this IGameEntity entity) => ref entity.GetValueUnsafe<IExpression<Vector3, bool>>(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateCondition(this IGameEntity entity, out IExpression<Vector3, bool> value) => entity.TryGetValueUnsafe(RotateCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateCondition(this IGameEntity entity, IExpression<Vector3, bool> value) => entity.AddValue(RotateCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateCondition(this IGameEntity entity) => entity.HasValue(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateCondition(this IGameEntity entity) => entity.DelValue(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateCondition(this IGameEntity entity, IExpression<Vector3, bool> value) => entity.SetValue(RotateCondition, value);

		#endregion

		#region RotateAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction<Vector3, float> GetRotateAction(this IGameEntity entity) => entity.GetValueUnsafe<ICompositeAction<Vector3, float>>(RotateAction);

		public static ref ICompositeAction<Vector3, float> RefRotateAction(this IGameEntity entity) => ref entity.GetValueUnsafe<ICompositeAction<Vector3, float>>(RotateAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateAction(this IGameEntity entity, out ICompositeAction<Vector3, float> value) => entity.TryGetValueUnsafe(RotateAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateAction(this IGameEntity entity, ICompositeAction<Vector3, float> value) => entity.AddValue(RotateAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateAction(this IGameEntity entity) => entity.HasValue(RotateAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateAction(this IGameEntity entity) => entity.DelValue(RotateAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateAction(this IGameEntity entity, ICompositeAction<Vector3, float> value) => entity.SetValue(RotateAction, value);

		#endregion

		#region RotateEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<Vector3> GetRotateEvent(this IGameEntity entity) => entity.GetValueUnsafe<IEvent<Vector3>>(RotateEvent);

		public static ref IEvent<Vector3> RefRotateEvent(this IGameEntity entity) => ref entity.GetValueUnsafe<IEvent<Vector3>>(RotateEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateEvent(this IGameEntity entity, out IEvent<Vector3> value) => entity.TryGetValueUnsafe(RotateEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateEvent(this IGameEntity entity, IEvent<Vector3> value) => entity.AddValue(RotateEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateEvent(this IGameEntity entity) => entity.HasValue(RotateEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateEvent(this IGameEntity entity) => entity.DelValue(RotateEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateEvent(this IGameEntity entity, IEvent<Vector3> value) => entity.SetValue(RotateEvent, value);

		#endregion

		#region RotateSpeed

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetRotateSpeed(this IGameEntity entity) => entity.GetValueUnsafe<IValue<float>>(RotateSpeed);

		public static ref IValue<float> RefRotateSpeed(this IGameEntity entity) => ref entity.GetValueUnsafe<IValue<float>>(RotateSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateSpeed(this IGameEntity entity, out IValue<float> value) => entity.TryGetValueUnsafe(RotateSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddRotateSpeed(this IGameEntity entity, IValue<float> value) => entity.AddValue(RotateSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateSpeed(this IGameEntity entity) => entity.HasValue(RotateSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateSpeed(this IGameEntity entity) => entity.DelValue(RotateSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateSpeed(this IGameEntity entity, IValue<float> value) => entity.SetValue(RotateSpeed, value);

		#endregion

		#region FireRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest GetFireRequest(this IGameEntity entity) => entity.GetValueUnsafe<IRequest>(FireRequest);

		public static ref IRequest RefFireRequest(this IGameEntity entity) => ref entity.GetValueUnsafe<IRequest>(FireRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireRequest(this IGameEntity entity, out IRequest value) => entity.TryGetValueUnsafe(FireRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireRequest(this IGameEntity entity, IRequest value) => entity.AddValue(FireRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireRequest(this IGameEntity entity) => entity.HasValue(FireRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireRequest(this IGameEntity entity) => entity.DelValue(FireRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireRequest(this IGameEntity entity, IRequest value) => entity.SetValue(FireRequest, value);

		#endregion

		#region FireCondition

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<bool> GetFireCondition(this IGameEntity entity) => entity.GetValueUnsafe<IExpression<bool>>(FireCondition);

		public static ref IExpression<bool> RefFireCondition(this IGameEntity entity) => ref entity.GetValueUnsafe<IExpression<bool>>(FireCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireCondition(this IGameEntity entity, out IExpression<bool> value) => entity.TryGetValueUnsafe(FireCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireCondition(this IGameEntity entity, IExpression<bool> value) => entity.AddValue(FireCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireCondition(this IGameEntity entity) => entity.HasValue(FireCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireCondition(this IGameEntity entity) => entity.DelValue(FireCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireCondition(this IGameEntity entity, IExpression<bool> value) => entity.SetValue(FireCondition, value);

		#endregion

		#region FireAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction GetFireAction(this IGameEntity entity) => entity.GetValueUnsafe<ICompositeAction>(FireAction);

		public static ref ICompositeAction RefFireAction(this IGameEntity entity) => ref entity.GetValueUnsafe<ICompositeAction>(FireAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireAction(this IGameEntity entity, out ICompositeAction value) => entity.TryGetValueUnsafe(FireAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireAction(this IGameEntity entity, ICompositeAction value) => entity.AddValue(FireAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireAction(this IGameEntity entity) => entity.HasValue(FireAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireAction(this IGameEntity entity) => entity.DelValue(FireAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireAction(this IGameEntity entity, ICompositeAction value) => entity.SetValue(FireAction, value);

		#endregion

		#region FireEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetFireEvent(this IGameEntity entity) => entity.GetValueUnsafe<IEvent>(FireEvent);

		public static ref IEvent RefFireEvent(this IGameEntity entity) => ref entity.GetValueUnsafe<IEvent>(FireEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireEvent(this IGameEntity entity, out IEvent value) => entity.TryGetValueUnsafe(FireEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireEvent(this IGameEntity entity, IEvent value) => entity.AddValue(FireEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireEvent(this IGameEntity entity) => entity.HasValue(FireEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireEvent(this IGameEntity entity) => entity.DelValue(FireEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireEvent(this IGameEntity entity, IEvent value) => entity.SetValue(FireEvent, value);

		#endregion

		#region FireAnimDrivenEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetFireAnimDrivenEvent(this IGameEntity entity) => entity.GetValueUnsafe<IEvent>(FireAnimDrivenEvent);

		public static ref IEvent RefFireAnimDrivenEvent(this IGameEntity entity) => ref entity.GetValueUnsafe<IEvent>(FireAnimDrivenEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireAnimDrivenEvent(this IGameEntity entity, out IEvent value) => entity.TryGetValueUnsafe(FireAnimDrivenEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireAnimDrivenEvent(this IGameEntity entity, IEvent value) => entity.AddValue(FireAnimDrivenEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireAnimDrivenEvent(this IGameEntity entity) => entity.HasValue(FireAnimDrivenEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireAnimDrivenEvent(this IGameEntity entity) => entity.DelValue(FireAnimDrivenEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireAnimDrivenEvent(this IGameEntity entity, IEvent value) => entity.SetValue(FireAnimDrivenEvent, value);

		#endregion

		#region FireCooldown

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICooldown GetFireCooldown(this IGameEntity entity) => entity.GetValueUnsafe<ICooldown>(FireCooldown);

		public static ref ICooldown RefFireCooldown(this IGameEntity entity) => ref entity.GetValueUnsafe<ICooldown>(FireCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireCooldown(this IGameEntity entity, out ICooldown value) => entity.TryGetValueUnsafe(FireCooldown, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireCooldown(this IGameEntity entity, ICooldown value) => entity.AddValue(FireCooldown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireCooldown(this IGameEntity entity) => entity.HasValue(FireCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireCooldown(this IGameEntity entity) => entity.DelValue(FireCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireCooldown(this IGameEntity entity, ICooldown value) => entity.SetValue(FireCooldown, value);

		#endregion

		#region AimRequest

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IRequest<Vector3> GetAimRequest(this IGameEntity entity) => entity.GetValueUnsafe<IRequest<Vector3>>(AimRequest);

		public static ref IRequest<Vector3> RefAimRequest(this IGameEntity entity) => ref entity.GetValueUnsafe<IRequest<Vector3>>(AimRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAimRequest(this IGameEntity entity, out IRequest<Vector3> value) => entity.TryGetValueUnsafe(AimRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAimRequest(this IGameEntity entity, IRequest<Vector3> value) => entity.AddValue(AimRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAimRequest(this IGameEntity entity) => entity.HasValue(AimRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAimRequest(this IGameEntity entity) => entity.DelValue(AimRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAimRequest(this IGameEntity entity, IRequest<Vector3> value) => entity.SetValue(AimRequest, value);

		#endregion

		#region AimCondition

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<Vector3, bool> GetAimCondition(this IGameEntity entity) => entity.GetValueUnsafe<IExpression<Vector3, bool>>(AimCondition);

		public static ref IExpression<Vector3, bool> RefAimCondition(this IGameEntity entity) => ref entity.GetValueUnsafe<IExpression<Vector3, bool>>(AimCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAimCondition(this IGameEntity entity, out IExpression<Vector3, bool> value) => entity.TryGetValueUnsafe(AimCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAimCondition(this IGameEntity entity, IExpression<Vector3, bool> value) => entity.AddValue(AimCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAimCondition(this IGameEntity entity) => entity.HasValue(AimCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAimCondition(this IGameEntity entity) => entity.DelValue(AimCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAimCondition(this IGameEntity entity, IExpression<Vector3, bool> value) => entity.SetValue(AimCondition, value);

		#endregion

		#region AimAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction<Vector3, float> GetAimAction(this IGameEntity entity) => entity.GetValueUnsafe<ICompositeAction<Vector3, float>>(AimAction);

		public static ref ICompositeAction<Vector3, float> RefAimAction(this IGameEntity entity) => ref entity.GetValueUnsafe<ICompositeAction<Vector3, float>>(AimAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAimAction(this IGameEntity entity, out ICompositeAction<Vector3, float> value) => entity.TryGetValueUnsafe(AimAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAimAction(this IGameEntity entity, ICompositeAction<Vector3, float> value) => entity.AddValue(AimAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAimAction(this IGameEntity entity) => entity.HasValue(AimAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAimAction(this IGameEntity entity) => entity.DelValue(AimAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAimAction(this IGameEntity entity, ICompositeAction<Vector3, float> value) => entity.SetValue(AimAction, value);

		#endregion

		#region AimEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<Vector3> GetAimEvent(this IGameEntity entity) => entity.GetValueUnsafe<IEvent<Vector3>>(AimEvent);

		public static ref IEvent<Vector3> RefAimEvent(this IGameEntity entity) => ref entity.GetValueUnsafe<IEvent<Vector3>>(AimEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAimEvent(this IGameEntity entity, out IEvent<Vector3> value) => entity.TryGetValueUnsafe(AimEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAimEvent(this IGameEntity entity, IEvent<Vector3> value) => entity.AddValue(AimEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAimEvent(this IGameEntity entity) => entity.HasValue(AimEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAimEvent(this IGameEntity entity) => entity.DelValue(AimEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAimEvent(this IGameEntity entity, IEvent<Vector3> value) => entity.SetValue(AimEvent, value);

		#endregion

		#region PostAimTimer

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ITimer GetPostAimTimer(this IGameEntity entity) => entity.GetValueUnsafe<ITimer>(PostAimTimer);

		public static ref ITimer RefPostAimTimer(this IGameEntity entity) => ref entity.GetValueUnsafe<ITimer>(PostAimTimer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPostAimTimer(this IGameEntity entity, out ITimer value) => entity.TryGetValueUnsafe(PostAimTimer, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddPostAimTimer(this IGameEntity entity, ITimer value) => entity.AddValue(PostAimTimer, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPostAimTimer(this IGameEntity entity) => entity.HasValue(PostAimTimer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPostAimTimer(this IGameEntity entity) => entity.DelValue(PostAimTimer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPostAimTimer(this IGameEntity entity, ITimer value) => entity.SetValue(PostAimTimer, value);

		#endregion

		#region Weapon

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<IGameEntity> GetWeapon(this IGameEntity entity) => entity.GetValueUnsafe<IValue<IGameEntity>>(Weapon);

		public static ref IValue<IGameEntity> RefWeapon(this IGameEntity entity) => ref entity.GetValueUnsafe<IValue<IGameEntity>>(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWeapon(this IGameEntity entity, out IValue<IGameEntity> value) => entity.TryGetValueUnsafe(Weapon, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddWeapon(this IGameEntity entity, IValue<IGameEntity> value) => entity.AddValue(Weapon, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWeapon(this IGameEntity entity) => entity.HasValue(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWeapon(this IGameEntity entity) => entity.DelValue(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWeapon(this IGameEntity entity, IValue<IGameEntity> value) => entity.SetValue(Weapon, value);

		#endregion

		#region FirePosition

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<Vector3> GetFirePosition(this IGameEntity entity) => entity.GetValueUnsafe<IValue<Vector3>>(FirePosition);

		public static ref IValue<Vector3> RefFirePosition(this IGameEntity entity) => ref entity.GetValueUnsafe<IValue<Vector3>>(FirePosition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFirePosition(this IGameEntity entity, out IValue<Vector3> value) => entity.TryGetValueUnsafe(FirePosition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFirePosition(this IGameEntity entity, IValue<Vector3> value) => entity.AddValue(FirePosition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFirePosition(this IGameEntity entity) => entity.HasValue(FirePosition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFirePosition(this IGameEntity entity) => entity.DelValue(FirePosition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFirePosition(this IGameEntity entity, IValue<Vector3> value) => entity.SetValue(FirePosition, value);

		#endregion

		#region BulletPrefab

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<GameEntity> GetBulletPrefab(this IGameEntity entity) => entity.GetValueUnsafe<IVariable<GameEntity>>(BulletPrefab);

		public static ref IVariable<GameEntity> RefBulletPrefab(this IGameEntity entity) => ref entity.GetValueUnsafe<IVariable<GameEntity>>(BulletPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBulletPrefab(this IGameEntity entity, out IVariable<GameEntity> value) => entity.TryGetValueUnsafe(BulletPrefab, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddBulletPrefab(this IGameEntity entity, IVariable<GameEntity> value) => entity.AddValue(BulletPrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBulletPrefab(this IGameEntity entity) => entity.HasValue(BulletPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBulletPrefab(this IGameEntity entity) => entity.DelValue(BulletPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBulletPrefab(this IGameEntity entity, IVariable<GameEntity> value) => entity.SetValue(BulletPrefab, value);

		#endregion

		#region FireSpread

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetFireSpread(this IGameEntity entity) => entity.GetValueUnsafe<IValue<float>>(FireSpread);

		public static ref IValue<float> RefFireSpread(this IGameEntity entity) => ref entity.GetValueUnsafe<IValue<float>>(FireSpread);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireSpread(this IGameEntity entity, out IValue<float> value) => entity.TryGetValueUnsafe(FireSpread, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddFireSpread(this IGameEntity entity, IValue<float> value) => entity.AddValue(FireSpread, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireSpread(this IGameEntity entity) => entity.HasValue(FireSpread);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireSpread(this IGameEntity entity) => entity.DelValue(FireSpread);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireSpread(this IGameEntity entity, IValue<float> value) => entity.SetValue(FireSpread, value);

		#endregion

		#region Ammo

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetAmmo(this IGameEntity entity) => entity.GetValueUnsafe<IReactiveVariable<int>>(Ammo);

		public static ref IReactiveVariable<int> RefAmmo(this IGameEntity entity) => ref entity.GetValueUnsafe<IReactiveVariable<int>>(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAmmo(this IGameEntity entity, out IReactiveVariable<int> value) => entity.TryGetValueUnsafe(Ammo, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAmmo(this IGameEntity entity, IReactiveVariable<int> value) => entity.AddValue(Ammo, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAmmo(this IGameEntity entity) => entity.HasValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAmmo(this IGameEntity entity) => entity.DelValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAmmo(this IGameEntity entity, IReactiveVariable<int> value) => entity.SetValue(Ammo, value);

		#endregion

		#region Damage

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetDamage(this IGameEntity entity) => entity.GetValueUnsafe<IValue<int>>(Damage);

		public static ref IValue<int> RefDamage(this IGameEntity entity) => ref entity.GetValueUnsafe<IValue<int>>(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamage(this IGameEntity entity, out IValue<int> value) => entity.TryGetValueUnsafe(Damage, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddDamage(this IGameEntity entity, IValue<int> value) => entity.AddValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamage(this IGameEntity entity) => entity.HasValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamage(this IGameEntity entity) => entity.DelValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamage(this IGameEntity entity, IValue<int> value) => entity.SetValue(Damage, value);

		#endregion

		#region InteractCondition

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<IGameEntity, bool> GetInteractCondition(this IGameEntity entity) => entity.GetValueUnsafe<IExpression<IGameEntity, bool>>(InteractCondition);

		public static ref IExpression<IGameEntity, bool> RefInteractCondition(this IGameEntity entity) => ref entity.GetValueUnsafe<IExpression<IGameEntity, bool>>(InteractCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetInteractCondition(this IGameEntity entity, out IExpression<IGameEntity, bool> value) => entity.TryGetValueUnsafe(InteractCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddInteractCondition(this IGameEntity entity, IExpression<IGameEntity, bool> value) => entity.AddValue(InteractCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractCondition(this IGameEntity entity) => entity.HasValue(InteractCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractCondition(this IGameEntity entity) => entity.DelValue(InteractCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetInteractCondition(this IGameEntity entity, IExpression<IGameEntity, bool> value) => entity.SetValue(InteractCondition, value);

		#endregion

		#region InteractAction

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ICompositeAction<IGameEntity> GetInteractAction(this IGameEntity entity) => entity.GetValueUnsafe<ICompositeAction<IGameEntity>>(InteractAction);

		public static ref ICompositeAction<IGameEntity> RefInteractAction(this IGameEntity entity) => ref entity.GetValueUnsafe<ICompositeAction<IGameEntity>>(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetInteractAction(this IGameEntity entity, out ICompositeAction<IGameEntity> value) => entity.TryGetValueUnsafe(InteractAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddInteractAction(this IGameEntity entity, ICompositeAction<IGameEntity> value) => entity.AddValue(InteractAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractAction(this IGameEntity entity) => entity.HasValue(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractAction(this IGameEntity entity) => entity.DelValue(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetInteractAction(this IGameEntity entity, ICompositeAction<IGameEntity> value) => entity.SetValue(InteractAction, value);

		#endregion

		#region InteractEvent

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<IGameEntity> GetInteractEvent(this IGameEntity entity) => entity.GetValueUnsafe<IEvent<IGameEntity>>(InteractEvent);

		public static ref IEvent<IGameEntity> RefInteractEvent(this IGameEntity entity) => ref entity.GetValueUnsafe<IEvent<IGameEntity>>(InteractEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetInteractEvent(this IGameEntity entity, out IEvent<IGameEntity> value) => entity.TryGetValueUnsafe(InteractEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddInteractEvent(this IGameEntity entity, IEvent<IGameEntity> value) => entity.AddValue(InteractEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractEvent(this IGameEntity entity) => entity.HasValue(InteractEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractEvent(this IGameEntity entity) => entity.DelValue(InteractEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetInteractEvent(this IGameEntity entity, IEvent<IGameEntity> value) => entity.SetValue(InteractEvent, value);

		#endregion

		#region Animator

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Animator GetAnimator(this IGameEntity entity) => entity.GetValueUnsafe<Animator>(Animator);

		public static ref Animator RefAnimator(this IGameEntity entity) => ref entity.GetValueUnsafe<Animator>(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimator(this IGameEntity entity, out Animator value) => entity.TryGetValueUnsafe(Animator, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAnimator(this IGameEntity entity, Animator value) => entity.AddValue(Animator, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimator(this IGameEntity entity) => entity.HasValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimator(this IGameEntity entity) => entity.DelValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimator(this IGameEntity entity, Animator value) => entity.SetValue(Animator, value);

		#endregion

		#region AudioSource

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AudioSource GetAudioSource(this IGameEntity entity) => entity.GetValueUnsafe<AudioSource>(AudioSource);

		public static ref AudioSource RefAudioSource(this IGameEntity entity) => ref entity.GetValueUnsafe<AudioSource>(AudioSource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAudioSource(this IGameEntity entity, out AudioSource value) => entity.TryGetValueUnsafe(AudioSource, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddAudioSource(this IGameEntity entity, AudioSource value) => entity.AddValue(AudioSource, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAudioSource(this IGameEntity entity) => entity.HasValue(AudioSource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAudioSource(this IGameEntity entity) => entity.DelValue(AudioSource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAudioSource(this IGameEntity entity, AudioSource value) => entity.SetValue(AudioSource, value);

		#endregion
    }
}
