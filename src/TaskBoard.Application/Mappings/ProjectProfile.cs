using AutoMapper;
using TaskBoard.Application.DTOs;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Mappings;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Project, ProjectDto>();
    }
}
