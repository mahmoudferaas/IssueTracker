using AutoMapper;
using System;
using System.Linq;
using System.Reflection;
using Terkwaz.IssueTracker.Application.Common.Dtos;
using Terkwaz.IssueTracker.Application.Features.IsseTypes.Commands.Create;
using Terkwaz.IssueTracker.Application.Features.IsseTypes.Commands.Update;
using Terkwaz.IssueTracker.Application.Features.Issues.Commands.Create;
using Terkwaz.IssueTracker.Application.Features.Issues.Commands.Update;
using Terkwaz.IssueTracker.Application.Features.Issues.Dtos;
using Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Command.Create;
using Terkwaz.IssueTracker.Application.Features.ProjectParticipants.Command.Update;
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
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<IssueDto, Issue>().ReverseMap();
            CreateMap<IssueTypeDto, IssueType>().ReverseMap();
            CreateMap<ProjectDto, Project>().ReverseMap();
            CreateMap<ProjectParticipantsDto, ProjectParticipants>().ReverseMap();

            CreateMap<CreateUserCommand, User>().ReverseMap();
            CreateMap<UserOutput, User>().ReverseMap();

            CreateMap<LoginOutput, User>().ReverseMap();

            CreateMap<CreateProjectCommand, Project>().ReverseMap();
            CreateMap<ProjectDto, Project>().ReverseMap();

            CreateMap<CreateProjectParticipantsCommand, ProjectParticipants>().ReverseMap();
            CreateMap<UpdateProjectParticipantsCommand, ProjectParticipants>().ReverseMap();

            CreateMap<CreateIssueCommand, Issue>().ReverseMap();
            CreateMap<UpdateIssueCommand, Issue>().ReverseMap();

            CreateMap<Issue, IssueOutputDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.IssueType.Name))
                .ForMember(dest => dest.Assignee, opt => opt.MapFrom(src => src.Assignee.FullName))
                .ReverseMap();

            CreateMap<CreateIssueTypeCommand, IssueType>().ReverseMap();
            CreateMap<UpdateIssueTypeCommand, IssueType>().ReverseMap();
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>))).ToList();
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}