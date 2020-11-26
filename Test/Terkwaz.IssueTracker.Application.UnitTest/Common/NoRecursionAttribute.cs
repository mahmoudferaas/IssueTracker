#region Usings

using AutoFixture;
using AutoFixture.Xunit2;

#endregion Usings

namespace Terkwaz.IssueTracker.Application.UnitTest.Common
{
    public class NoRecursionAttribute : AutoDataAttribute
    {
        public NoRecursionAttribute() : base(() =>
           {
               var fixture = new Fixture();
               //fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
               fixture.Behaviors.Add(new OmitOnRecursionBehavior());
               return fixture;
           })
        {
        }
    }
}