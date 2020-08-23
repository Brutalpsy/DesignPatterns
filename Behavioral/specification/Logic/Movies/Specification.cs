using System;
using System.Linq;
using System.Linq.Expressions;

namespace Logic.Movies
{
    internal sealed class IdentitySpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            return x => true;
        }
    }

    public abstract class Specification<T>
    {
        public static readonly Specification<T> All = new IdentitySpecification<T>();

        public bool IsSatisfiedBy(T entity)
        {
            return ToExpression().Compile()(entity);
        }

        public abstract Expression<Func<T, bool>> ToExpression();

        public Specification<T> And (Specification<T> specification)
        {
            if(specification == All)
            {
                return this;
            }

            if(this == All)
            {
                return specification;
            }

            return new AndSpecification<T>(this, specification);
        }

        public Specification<T> Or(Specification<T> specification)
        {
            if(this == All || specification == All)
            {
                return All;
            }

            return new OrSpecification<T>(this, specification);
        }

        public Specification<T> Not()
        {
            return new NotSpecification<T>(this);
        }
    }

    internal sealed class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;
        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            _left = left;
            _right = right;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = _left.ToExpression();
            Expression<Func<T, bool>> rightExpression = _right.ToExpression();

            BinaryExpression andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
            return Expression.Lambda<Func<T, bool>>(andExpression, leftExpression.Parameters.Single());
        }
    }

    internal sealed class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;

        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            _left = left;
            _right = right;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = _left.ToExpression();
            Expression<Func<T, bool>> rightExpression = _right.ToExpression();

            BinaryExpression orExpression = Expression.OrElse(leftExpression.Body, rightExpression.Body);
            return Expression.Lambda<Func<T, bool>>(orExpression, leftExpression.Parameters.Single());
        }
    }

    internal sealed class NotSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _specification;

        public NotSpecification(Specification<T> specification)
        {
            _specification = specification;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> expression = _specification.ToExpression();
            UnaryExpression notExpression = Expression.Not(expression.Body);

            return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters.Single());
        }
    }

    public sealed class MovieForKidsSpecification : Specification<Movie>
    {
        public override Expression<Func<Movie, bool>> ToExpression()
        {
            return movie => movie.MpaaRating <= MpaaRating.PG;
        }
    }

    public sealed class AvailableOnCdSpecification : Specification<Movie>
    {
        private const int MONTHS_BEFORE_DVD_IS_OUT = 6;
        public override Expression<Func<Movie, bool>> ToExpression()
        {
            return movie => movie.ReleaseDate <= DateTime.Now.AddMonths(-MONTHS_BEFORE_DVD_IS_OUT);
        }
    }

    public sealed class MovieDirectedBySpecification : Specification<Movie>
    {
        private readonly string _name;
        public MovieDirectedBySpecification(string name)
        {
            _name = name;
        }
        public override Expression<Func<Movie, bool>> ToExpression()
        {
            return m => m.Director.Name == _name;
        }
    }
}
