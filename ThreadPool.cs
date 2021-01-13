using System.Threading;

namespace FileMover {
    public class ThreadPool {

        public static void runAsync(ThreadStart threadStart) {
            new Thread(threadStart).Start();
        }

    }
}
