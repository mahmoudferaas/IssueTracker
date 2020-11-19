using AutoMapper;
namespace Terkwaz.IssueTracker.Application.Common.Mappings
{
	public interface IMapFrom<T>
	{
		void Mapping(Profile profile);
	}
}