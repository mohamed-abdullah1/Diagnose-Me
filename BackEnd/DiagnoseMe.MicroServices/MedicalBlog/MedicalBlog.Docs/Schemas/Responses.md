## Schema 

### UserData
```
{
	string Id,
    string Name,
    string FullName,
    string ProfilePictureUrl
}
```

### QuestionResponse
```
{
	string Id,
    string QuestionString,
    UserData AskingUser,
    string CreatedOn,
    string? ModifiedOn,
    List<AnswerResponse>? Answers,
    int AnswersCount
}
```

### AnswerResponse

```
{
	string Id,
    string AnswerString,
    UserData AnsweringDoctor,
    string CreatedOn,
    string? ModifiedOn,
    int AnswerAgreementsCount,
    List<UserData> AnswerAgreementUsers
}
```
### PostResponse
```
{
	string Id,
    string Title,
    string Content,
    UserData AuthorData,
    List<string> Tags,
    string CreatedOn,
    string? ModifiedOn,
    int CommentsCount,
    int RatingCount,
    List<UserData> RatingUsers,
    List<CommentResponse>? Comments,
    int ViewsCount,
    List<UserData> ViewingUsers,
    double AvgRating
}
```

### CommentResponse
```
{
	string Id,
    string ParentId,
    string Content,
    UserData AuthorData,
    string CreatedOn,
    string? ModifiedOn,
    int ComentAgreementsCount,
    List<UserData> CommentAgreementUsers
}
```

### CommandResponse
```
{
	bool Success,
    string Message,
    string Path
}
```
