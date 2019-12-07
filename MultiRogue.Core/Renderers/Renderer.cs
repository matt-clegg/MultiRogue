namespace MultiRogue.Core.Renderers
{
    public abstract class Renderer
    {
        protected abstract void DoRender();

        public void Render()
        {
            DoRender();
        }
    }
}
