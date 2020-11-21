using AutoMapper;
using System;
using System.Linq;
using System.Reflection;
using Terkwaz.IssueTracker.Application.Features.Projects.Commands.Create;
using Terkwaz.IssueTracker.Application.Features.Users.Comands.Create;
using Terkwaz.IssueTracker.Application.Features.Users.Comands.Dtos;
using Terkwaz.IssueTracker.Domain.Entities;

namespace Terkwaz.IssueTracker.Application.Common.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<CreateUserCommand, User>().ReverseMap();

			CreateMap<LoginOutput, User>().ReverseMap();

			CreateMap<CreateProjectCommand, Project>().ReverseMap();
		}

	private void ApplyMappingsFromAssembly(Assembly assembly)
		{
			var types = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(i =>i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>))).ToList();
			foreach (var type in types)
			{
				var instance = Activator.CreateInstance(type);
				var methodInfo = type.GetMethod("Mapping");
				methodInfo?.Invoke(instance, new object[] { this });
			}
		}
	}
}