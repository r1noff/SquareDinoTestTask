namespace SquareDino.RechkinTestTask.ObjectPool
{
    public interface IObjectPool<out T> where T : IPooledObject
    {
        T GetObject();
    }
}