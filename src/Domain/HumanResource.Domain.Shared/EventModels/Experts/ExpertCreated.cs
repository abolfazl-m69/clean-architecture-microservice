using System;
using HumanResource.Framework.Core.Events;
using HumanResource.Framework.Core.Events.UserInfo;

namespace HumanResource.Domain.Shared.EventModels.Experts;

public class ExpertCreated : DomainEvent, IUserInfo
{
    public ExpertCreated(long id, string firstName,string lastName, DateTime actionDateTime,long actionUserId,string userName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        ActionDateTime = actionDateTime;
        ActionUserId = actionUserId;
        UserName = userName;
    }

    public long Id { get;private set; }
    public string FirstName { get;private set; }
    public string LastName { get; set; }
    public DateTime ActionDateTime { get;private set; }
    public long ActionUserId { get; set; }
    public string UserName { get; set; }
}