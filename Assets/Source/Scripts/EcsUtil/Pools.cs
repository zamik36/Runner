using Leopotam.EcsLite;
using Source.Scripts.Components.Events;
using Source.Scripts.Components.Life;
using Source.Scripts.Components.Move;
using Source.Scripts.Components.View;

namespace Source.Scripts.EcsUtil
{
    public class Pools
    {
        //world components
        public readonly EcsPool<BaseViewComponent> View;
        public readonly EcsPool<Direction> Dir;
        public readonly EcsPool<Speed> Speed;
        public readonly EcsPool<MaxSpeed> MaxSpeed;
        public readonly EcsPool<RigidbodyComponent> Rb;
        //public readonly EcsPool<Hp> Hp;
        public readonly EcsPool<AnimComponent> Anim;
        public readonly EcsPool<DeadTag> DeadTag;

        //event world components
        public readonly EcsPool<SoundEvent> SoundEvent;

        public Pools(EcsWorld world, EcsWorld eventWorld)
        {
            //world components
            View = world.GetPool<BaseViewComponent>();
            Dir = world.GetPool<Direction>();
            Speed = world.GetPool<Speed>();
            MaxSpeed = world.GetPool<MaxSpeed>();
            Rb = world.GetPool<RigidbodyComponent>();
            //Hp = world.GetPool<Hp>();
            Anim = world.GetPool<AnimComponent>();
            DeadTag = world.GetPool<DeadTag>();

            //event world components
            SoundEvent = eventWorld.GetPool<SoundEvent>();


        }
    }
}