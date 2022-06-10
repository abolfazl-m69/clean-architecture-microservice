using System;

namespace HumanResource.Framework.Core.Events.ConsumerRequestContext
{
    public class RequestContext : IRequestContext
    {
        private Guid _commandId;

        public Guid GetCommandId() => _commandId;
        public void ClearContext() => _commandId = Guid.Empty;
        public void SetCommandId(Guid commandId) => _commandId = commandId;
    }
}