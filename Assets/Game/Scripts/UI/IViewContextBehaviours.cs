using Atomic.Entities;

/**
 * Created by Entity Domain Generator.
 */

namespace Game.UI
{
    /// <summary>
    /// Provides initialization logic for the strongly-typed <see cref="IViewContext"/> entity.
    /// </summary>
    /// <remarks>
    /// Automatically invoked when an <see cref="IViewContext"/> instance is created and enters the initialization phase.
    /// Typically used to set up component references, register event listeners, or assign default values.
    /// </remarks>
    public interface IViewContextInit : IEntityInit<IViewContext>
    {
    }
    /// <summary>
    /// Handles enable-time logic for the strongly-typed <see cref="IViewContext"/> entity.
    /// </summary>
    /// <remarks>
    /// Automatically invoked when an <see cref="IViewContext"/> instance becomes active or enabled.
    /// Commonly used to re-enable systems or resume behavior execution.
    /// </remarks>
    public interface IViewContextEnable : IEntityEnable<IViewContext>
    {
    }
    /// <summary>
    /// Handles disable-time logic for the strongly-typed <see cref="IViewContext"/> entity.
    /// </summary>
    /// <remarks>
    /// Automatically invoked when an <see cref="IViewContext"/> instance becomes inactive or disabled.
    /// Useful for pausing updates or temporarily suspending logic without disposing the entity.
    /// </remarks>
    public interface IViewContextDisable : IEntityDisable<IViewContext>
    {
    }
    /// <summary>
    /// Provides cleanup logic for the strongly-typed <see cref="IViewContext"/> entity.
    /// </summary>
    /// <remarks>
    /// Automatically called when an <see cref="IViewContext"/> instance is destroyed or disposed.
    /// Used to release resources, unsubscribe from events, or reset state.
    /// </remarks>
    public interface IViewContextDispose : IEntityDispose<IViewContext>
    {
    }
    /// <summary>
    /// Handles per-frame update logic for the strongly-typed <see cref="IViewContext"/> entity.
    /// </summary>
    /// <remarks>
    /// Automatically invoked during the main update loop.
    /// Typically used for time-dependent gameplay logic such as movement, state updates, or input processing.
    /// </remarks>
    public interface IViewContextTick : IEntityTick<IViewContext>
    {
    }
    /// <summary>
    /// Handles fixed update logic for the strongly-typed <see cref="IViewContext"/> entity.
    /// </summary>
    /// <remarks>
    /// Automatically invoked during Unity’s fixed update cycle, synchronized with the physics system.
    /// Commonly used for deterministic or physics-based updates.
    /// </remarks>
    public interface IViewContextFixedTick : IEntityFixedTick<IViewContext>
    {
    }
    /// <summary>
    /// Handles late update logic for the strongly-typed <see cref="IViewContext"/> entity.
    /// </summary>
    /// <remarks>
    /// Automatically invoked after all standard update calls within the frame.
    /// Typically used for camera adjustments, cleanup, or visual synchronization logic.
    /// </remarks>
    public interface IViewContextLateTick : IEntityLateTick<IViewContext>
    {
    }
    /// <summary>
    /// Provides editor visualization logic for the strongly-typed <see cref="IViewContext"/> entity.
    /// </summary>
    /// <remarks>
    /// Automatically invoked when the entity is visible in the Unity Editor Scene view.
    /// Commonly used to draw debug information, wireframes, or gizmo markers.
    /// </remarks>
    public interface IViewContextGizmos : IEntityGizmos<IViewContext>
    {
    }
}
