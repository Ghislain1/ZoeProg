namespace ZoeProg.ViewModels

{
    using System;
    using ZoeProg.Common;

    public class NullProgressMonitor : IProgressMonitor
    {
        public bool IsCanceled => throw new NotImplementedException();

        public bool IsCancellable => throw new NotImplementedException();

        public bool IsGeneric => throw new NotImplementedException();

        public string TaskName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void BeginTask(string name, int totalWork, bool isCancellable, bool isGeneric)
        {
            throw new NotImplementedException();
        }

        public void BeginTask(string name, int totalWork)
        {
            throw new NotImplementedException();
        }

        public void Done()
        {
            throw new NotImplementedException();
        }

        public void InternalWorked(double work)
        {
            throw new NotImplementedException();
        }

        public void Worked(int work)
        {
            throw new NotImplementedException();
        }
    }
}