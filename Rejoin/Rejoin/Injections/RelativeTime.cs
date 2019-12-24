using Microsoft.AspNetCore.Http;
using Rejoin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.Injections
{
    public interface IRelativeTime
    {
        string Time(DateTime createdAt);
    }
    public class RelativeTime: IRelativeTime
    {
        private readonly RejionDBContext _context;
        private readonly IHttpContextAccessor _accessor;
        public RelativeTime(RejionDBContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }
      
        public string Time(DateTime createdAt)
        {

            int SECOND = 1;
            int MINUTE = 60 * SECOND;
            int HOUR = 60 * MINUTE;
            int DAY = 24 * HOUR;
            int MONTH = 30 * DAY;
            string Text = string.Empty;

            var ts = new TimeSpan(DateTime.Now.Ticks - createdAt.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
            {
                Text = ts.Seconds == 1 ? "1 saniyə əvvəl" : ts.Seconds + " saniyə əvvəl";
            }

            if (delta < 2 * MINUTE)
            {
                Text = "1 dəqiqə əvvəl";
            }



            if (delta < 45 * MINUTE)
            {
                Text = ts.Minutes + " dəqiqə əvvəl";
            }
            else if (delta < 90 * MINUTE)
            {
                Text = "1 saat əvvəl";
            }
            else if (delta < 24 * HOUR)
            {
                Text = ts.Hours + " saat əvvəl";
            }
            else if (delta < 48 * HOUR)
            {
                Text = "dünən";
            }
            else if (delta < 30 * DAY)
            {
                Text = ts.Days + " gün əvvəl";
            }
            else if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                Text = months <= 1 ? "1 ay əvvəl" : months + " ay əvvəl";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                Text = years <= 1 ? "1 il əvvəl" : years + " il əvvəl";
            }
            return Text;
        }
    }
}
