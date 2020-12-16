using System;

namespace FlowMetrics.Infra.Base
{
    public interface ITransaction : IDisposable
    {
        void Commit();
    }
}
