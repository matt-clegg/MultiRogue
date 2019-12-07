using Toolbox.Rng;

namespace MultiRogue.Core.World.Generation
{
    public abstract class BaseGenerator<T>
    {
        protected IRandom Random { get; }

        public BaseGenerator(IRandom random)
        {
            Random = random;
        }

        public abstract T Build();
        protected abstract void Reset();
        protected abstract bool IsValid();
        protected abstract void DoGeneration();

        public BaseGenerator<T> Generate()
        {
            do
            {
                Reset();
                DoGeneration();
            } while (!IsValid());

            return this;
        }
    }
}
