using Shop.Domain.Entities.CommentAgg;
using Shop.Domain.Entities.CommentAgg.Repository;
using Shop.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.CommentAgg
{
    internal class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ShopContext context) : base(context)
        {
        }
    }
}
