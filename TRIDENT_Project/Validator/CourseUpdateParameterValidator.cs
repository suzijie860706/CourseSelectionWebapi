using FluentValidation;
using TRIDENT_Project.Paramenters;

namespace TRIDENT_Project.Validator
{
    /// <summary>
    ///  CourseUpdateParameter 的驗證器
    /// </summary>
    public class CourseUpdateParameterValidator : AbstractValidator<CourseUpdateParamenter>
    {
        public CourseUpdateParameterValidator()
        {
            //RuleFor(x => x.CourseId).GreaterThan(0).WithMessage("路由 ID 必須大於 0");
            
            //RuleFor(x => x.Title).NotEmpty().MaximumLength(100).WithMessage("標題不能為空且不能超過 100 個字符");
            //RuleFor(x => x.Description).MaximumLength(500).WithMessage("描述不能超過 500 個字符");

            //// 添加 ID 匹配驗證
            //RuleFor(x => x)
            //    .Must(x => x.RouteId == x.CourseId)
            //    .WithMessage("路由 ID 與課程 ID 不匹配");
        }
    }
}
