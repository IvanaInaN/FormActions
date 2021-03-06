using AutoMapper;
using FormActions.Domain.Models;
using FormActions.Structures.Dtos;
using System;
using System.Collections.Generic;

namespace FormActions.Services.AutoMapper
{
    public class MapperFormAction : Profile
    {
        public MapperFormAction()
        {
            CreateMap<Candidate, CandidateDto>();
            CreateMap<CandidateDto, Candidate>();
            CreateMap<List<Candidate>, List<CandidateDto>>();

            CreateMap<Form, FormDto>();
            CreateMap<FormDto, Form>();
            CreateMap<List<Form>, List<FormDto>>();

            CreateMap<FormAction, FormActionDto>()
                .ForMember(des => des.WaitingTimeMin, x => x.MapFrom(src => CalculateWaitingTime(src.ActionOn)));
            CreateMap<FormActionDto, FormAction>();
        }

        private int CalculateWaitingTime(DateTime start)
        {
            var end = DateTime.UtcNow;
            return (int)end.Subtract(start).TotalMinutes;
        }
    }
}
