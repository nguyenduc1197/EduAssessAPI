using Application.DTOs;
using Domain.Entities;
using Mapster;

namespace Application.Common.Mappings
{
    public class MapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Question, QuestionDto>();
            config.NewConfig<Choice, ChoiceDto>();
            config.NewConfig<Exam, ExamDto>();
            config.NewConfig<SchoolClass, ClassDto>();
        }
    }
}
