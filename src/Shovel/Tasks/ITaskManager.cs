using System;

namespace ShovelPack.Tasks
{
	public interface ITaskManager
	{
		ITask FindTask(string taskName);
		ITask NewTask(string taskName, Action<ITask> initializer);
		void RunTasks(params string[] taskNames);
	}
}