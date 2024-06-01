using MediatR;

namespace PersonalCookBook.Tests
{
    public abstract class RequestHandlerTestBase<T>
    {
        public abstract T PrepareTestSubject();
    }
}
