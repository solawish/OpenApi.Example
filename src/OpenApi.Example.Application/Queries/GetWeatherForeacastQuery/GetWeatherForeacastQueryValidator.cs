using FluentValidation;

namespace OpenApi.Example.Application.Queries.GetWeatherForeacastQuery;

public class GetWeatherForeacastQueryValidator : AbstractValidator<GetWeatherForeacastQuery>
{
    public GetWeatherForeacastQueryValidator()
    {
        RuleFor(x => x.Day)
            .NotEmpty()
            .WithMessage("日期不可為空");
        RuleFor(x => x.City)
            .NotEmpty()
            .WithMessage("城市不可為空");
        RuleFor(x => x.Days)
            .NotEmpty()
            .WithMessage("未來幾天不可為空")
            .LessThanOrEqualTo(7)
            .WithMessage("不可超過7天");
    }
}