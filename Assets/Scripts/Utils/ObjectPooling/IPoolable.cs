using System;

public interface IPoolable<T>
{
	public void Initialize(Action<T> returnAction);
	public void ReturnToPool();
}