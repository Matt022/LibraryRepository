using Library.Core.Abstractions.Repositories;
using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Data.Repositories
{
    public class MemberRepository : IMemberRepository
    {

        private readonly LibraryContext _context;
        public MemberRepository(LibraryContext context)
        {
            this._context = context;
        }
        public Member Create(Member entity)
        {
            var member = this._context.Members.Add(entity);

            this._context.SaveChanges();

            return member.Entity;
        }

        public Member Delete(int id)
        {
            var member = this.GetById(id);
            if (member is null) return null;

            var result = this._context.Members.Remove(member);

            this._context.SaveChanges();
            return result.Entity;
        }

        public IEnumerable<Member> GetAll()
        {
            return this._context.Members;
        }

        public Member GetById(int id)
        {
            var result = this._context.Members.FirstOrDefault(x => x.Id == id);

            return result;
        }

        public void Update(int id, Member entity)
        {
            this._context.Members.Update(entity);

            this._context.SaveChanges();
        }
        public IEnumerable<Member> Find(Expression<Func<Member, bool>> expression)
        {
            return this._context.Members.Where(expression);
        }

    }
}
