using Atomic.Elements;
using Atomic.Entities;

namespace Game
{
    public sealed class InteractInstaller : IEntityInstaller<IGameEntity>
    {
        public void Install(IGameEntity entity)
        {
            entity.AddInteractableTag();
            entity.AddInteractCondition(new AndExpression<IGameEntity>());
            entity.AddInteractAction(new CompositeAction<IGameEntity>());
            entity.AddInteractEvent(new Event<IGameEntity>());
        }
    }
}