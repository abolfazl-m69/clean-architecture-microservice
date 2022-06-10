using System;

namespace HumanResource.Framework.Core.Utilities
{
    public interface IClock
    {
        DateTime Now();
        DateTime Set(DateTime date);
        void SetClock(DateTime date);
        IClock SetClocks(DateTime date);
        DateTime GetDateTime();

    }
}