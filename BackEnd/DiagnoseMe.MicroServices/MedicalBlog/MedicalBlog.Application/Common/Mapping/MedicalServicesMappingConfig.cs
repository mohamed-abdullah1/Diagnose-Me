
using Mapster;
using MedicalBlog.Application.MedicalBlog.Answers.Common;
using MedicalBlog.Application.MedicalBlog.Comments.Common;
using MedicalBlog.Application.MedicalBlog.Posts.Common;
using MedicalBlog.Application.MedicalBlog.Questions.Common;

namespace MedicalBlog.Api.Common.Mapping;

public class MedicalBlogMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {        
        config.NewConfig<Post ,PostResponse>().
            Map(dest => dest.ViewsCount, src => src.ViewingUsers.Count).
            Map(dest => dest.CommentsCount, src => src.Comments.Count).
            Map(dest => dest.RatingCount, src => src.RatingUsers.Count).
            Map(dest => dest.Tags, src => src.Tags.Select(x => x.TagName).ToList()).
            Map(dest => dest, src => src);


        
        config.NewConfig<Question, QuestionResponse>().
            Map(dest => dest.AnswersCount, src => src.Answers.Count).
            Map(dest => dest.Tags, src => src.Tags.Select(x => x.TagName).ToList()).
            Map(dest => dest.DisagreementCount, src => (src.AgreementCount - src.AgreeingUsers.Count)).
            Map(dest => dest, src => src);
            
        config.NewConfig<Answer, AnswerResponse>().
            Map(dest => dest.DisagreementCount, src => (src.AgreementCount - src.AgreeingUsers.Count)).
            Map(dest => dest, src => src);

        config.NewConfig<Comment, CommentResponse>().
            Map(dest => dest.ChildCommentsCount, src => src.ChildComments.Count).
            Map(dest => dest.DisagreementCount, src => (src.AgreementCount - src.AgreeingUsers.Count)).
            Map(dest => dest, src => src);
    }
}