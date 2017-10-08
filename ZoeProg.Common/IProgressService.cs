using System;

namespace ZoeProg.Common
{
    public interface IProgressService : IProgressMonitor
    {
        event Action TaskStart;

        void Close();

        void Show();

        void Update();
    }
}