using System;

namespace HumanResource.Framework.Core.Utilities
{
    public class SystemClock : IClock
    {
        private DateTime? _date;
        public DateTime Now()
        {
            return DateTime.Now;
        }

        public DateTime Set(DateTime date)
        {
            _date = date;
            return _date.Value;
        }

        public void SetClock(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IClock SetClocks(DateTime date)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime()
        {
            throw new NotImplementedException();
        }
    }
}

