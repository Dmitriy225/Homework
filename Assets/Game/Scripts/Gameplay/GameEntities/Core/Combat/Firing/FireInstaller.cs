using Atomic.Elements;
using Atomic.Entities;
using Event = Atomic.Elements.Event;

namespace Game
{
    public sealed class FireInstaller : IEntityInstaller<IGameEntity>
    {
        public void Install(IGameEntity entity)
        {
            entity.AddFireRequest(new Request());
            entity.AddFireCondition(new AndExpression());
            entity.AddFireAction(new CompositeAction());
            entity.AddFireEvent(new Event());
            entity.AddBehaviour<FireBehaviour>();
        }
    }
}