using ErrorOr;
using MediatR;
using MedicalBlog.Application.Authentication.Helpers;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.Common.Interfaces.Persistence.IUnitOfWork;
using MedicalBlog.Application.Common.Interfaces.Services;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common.Errors;


namespace MedicalBlog.Application.MedicalBlog.Posts.Commands.EditPost;

public class EditPostCommandHandler : IRequestHandler<EditPostCommand, ErrorOr<CommandResponse>>
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITagRepository _tagRepository;
    private readonly IFileHandler _fileHandler;

    public EditPostCommandHandler(IPostRepository postRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        ITagRepository tagRepository,
        IFileHandler fileHandler)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _tagRepository = tagRepository;
        _fileHandler = fileHandler;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(EditPostCommand command, CancellationToken cancellationToken)
    {
        var post = (await _postRepository.Get(
            predicate: x => x.Id == command.PostId,
            include: "Tags"))
            .FirstOrDefault();

        if (post == null)
            return Errors.Post.NotFound;

        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user == null)
            return Errors.User.NotFound;

        if (post.AuthorId != user.Id)   
            return Errors.User.YouCanNotDoThis;

        var tags = await _tagRepository.Get(x => command.Tags.Contains(x.TagName));
        var nonExistingTags = command.Tags.Except(tags.Select(x => x.TagName));
        var newTags = nonExistingTags.Select(x => new Tag{TagName = x});
        var allTags = tags.Concat(newTags).ToList();

        post.Title = command.Title;
        post.Content = command.Content;
        post.Tags = allTags;
        post.ModifiedOn = DateTime.UtcNow;

        post.PostImages = post.PostImages
            .Where(x => !command.RemovedImagesUrls.Contains(x.ImageUrl))
            .ToList();
        
        var postImages = new List<PostImage>();
        var result = new ErrorOr<string>();
        foreach(var base64Image in command.Base64Images){
            result = SaveFile.SavePicture(base64Image,_fileHandler);

            if(result.IsError)
                return result.Errors;
            
            postImages.Add(new PostImage{
                PostId = post.Id!,
                ImageUrl = result.Value
            });
        };

        post.PostImages = post.PostImages.Concat(postImages).ToList();
        await _postRepository.Edit(post);

        if (await _unitOfWork.Save() == 0)
            return Errors.Post.CreationFailed;

        
        return new CommandResponse(
            true,
            "Post edited successfully",
            $"posts/{post.Id}");
    }
}