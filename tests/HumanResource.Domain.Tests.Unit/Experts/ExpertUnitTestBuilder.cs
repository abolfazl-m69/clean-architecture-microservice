using System;
using HumanResource.Domain.Experts;
using HumanResource.Framework.Application.Claims;
using HumanResource.Framework.Core.Events;
using HumanResource.Framework.Core.Utilities;
using HumanResource.Framework.Test.Utils;

namespace HumanResource.Domain.Tests.Unit.Experts;

public class ExpertUnitTestBuilder
{
    public long Id;
    public string FirstName;
    public string LastName;
    public string CellPhone;
    public long PictureId;
    public string PictureUri;
    public IEventPublisher EventPublisher;
    public IClock Clock;
    public IClaimHelper ClaimHelper;

    public ExpertUnitTestBuilder()
    {
        Id = GenerateRandomData.GenerateLongNumber();
        FirstName = GenerateRandomData.GenerateString();
        LastName = GenerateRandomData.GenerateString();
        CellPhone = GenerateRandomData.GenerateLongNumber().ToString();
        PictureId = GenerateRandomData.GenerateIntNumber();
        PictureUri = GenerateRandomData.GenerateString();
        EventPublisher = new FakeEventPublisher();
        Clock = new ClockStub(DateTime.Now);
        ClaimHelper = new ClaimHelperStub();
    }
    public Expert Build()
    {
        return new Expert(Id,FirstName,LastName,CellPhone,PictureId,PictureUri,EventPublisher,ClaimHelper,Clock);
    }
}