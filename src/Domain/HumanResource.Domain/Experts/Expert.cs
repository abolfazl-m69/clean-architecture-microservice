using HumanResource.Domain.Shared.EventModels.Experts;
using HumanResource.Framework.Application.Claims;
using HumanResource.Framework.Core.Events;
using HumanResource.Framework.Core.Utilities;
using HumanResource.Framework.Domain;

namespace HumanResource.Domain.Experts;

public class Expert : AggregateRootBase<long>
{
    public string FirstName { get; }
    public string LastName { get; set; }
    public string CellPhone { get; }
    public long PictureId { get; }
    public string PictureUri { get; }

    protected Expert()
    {
    }
    public Expert(long id, string firstName, string lastname, string cellPhone,
         long pictureId, string pictureUri,
        IEventPublisher eventPublisher, IClaimHelper claimHelper, IClock clock) :
        base(id, clock, eventPublisher, claimHelper.GetUserId(), claimHelper.GetUserName())
    {
        Id = id;
        FirstName = firstName;
        LastName = lastname;
        CellPhone = CellPhone;
        PictureId = pictureId;
        PictureUri = pictureUri;

        Publish(new ExpertCreated(id,firstName,lastname,clock.Now(),claimHelper.GetUserId(),claimHelper.GetUserName()));
    }
}