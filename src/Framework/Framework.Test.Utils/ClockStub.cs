using HumanResource.Framework.Core.Utilities;
using System;

namespace HumanResource.Framework.Test.Utils
{
    public class ClockStub : IClock
    {
        private DateTime _date;

        public ClockStub(DateTime date) => this._date = date;

        public void SetClock(DateTime date) => this._date = date;

        public IClock SetClocks(DateTime date)
        {
            _date = date;
            return this;
        }

        public DateTime GetDateTime() => _date;

        public void Set(int year, int month, int day) => _date = new DateTime(year, month, day);

        public DateTime Now()
        {
            var year = _date.Year;
            var dateTime = _date;
            var month = dateTime.Month;
            dateTime = _date;
            var day = dateTime.Day;
            dateTime = _date;
            var hour = dateTime.Hour;
            dateTime = _date;
            var minute = dateTime.Minute;
            dateTime = _date;
            var second = dateTime.Second;
            return new DateTime(year, month, day, hour, minute, second);
        }

        DateTime IClock.Set(DateTime date)
        {
            _date = date;
            return _date;
        }

        public DateTime SomePastDate() => this.Now().AddYears(-1);

        public DateTime SomeFutureDate() => this.Now().AddYears(1);
    }
}