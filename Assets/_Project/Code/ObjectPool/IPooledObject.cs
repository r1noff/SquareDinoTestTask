namespace SquareDino.RechkinTestTask.ObjectPool
{
    public interface IPooledObject
    {
        bool IsFree();

        void ReturnToPool();

        void Take();
    }
}