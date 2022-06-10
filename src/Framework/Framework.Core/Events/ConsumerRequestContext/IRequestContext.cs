using System;

namespace HumanResource.Framework.Core.Events.ConsumerRequestContext
{
    public interface IRequestContext
    {
        Guid GetCommandId();
        void ClearContext();
        void SetCommandId(Guid commandId);
    }
}