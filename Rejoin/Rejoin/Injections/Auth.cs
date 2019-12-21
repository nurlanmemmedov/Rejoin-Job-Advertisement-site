using Rejoin.Models;
using Rejoin.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rejoin.Injections
{
    public interface IAuth
    {
        User User { get;}
    }
    public class Auth: IAuth
    {
        private readonly RejionDBContext _context;
        private readonly IHttpContextAccessor _accessor;
        public Auth(RejionDBContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        public User User
        {
            get
            {
                string token = string.Empty;
                bool hasHeader = this._accessor.HttpContext.Request.Cookies.TryGetValue("token", out token);

                if (!hasHeader)
                {
                    return null;
                }

                User user = _context.Users.Include("JobReviews")
                                    .Include("JobReviewReactions")
                                    .Include("JobReviewReplies")
                                    .Include("JobReviewReports")
                                    .Include("CompanyReviews")
                                    .Include("CompanyReviewReactions")
                                    .Include("CompanyReviewReplies")
                                    .Include("CompanyReviewReports")
                                    .Include("Company")
                                    .FirstOrDefault(c => c.Token == token);

                if (user == null)
                {
                    return null;
                }

                return user;
            }
        }

    }
}
