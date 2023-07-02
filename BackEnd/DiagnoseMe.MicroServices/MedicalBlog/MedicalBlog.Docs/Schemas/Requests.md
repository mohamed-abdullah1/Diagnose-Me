## Schema 

--
### Note that those are request body only does not involve the query params
--

### AddAnswerRequest
```
{
    string PostId,
    string CommentId,
    string AnswerString
}
```

### AddCommentRequest
```
{
    string Content
}
```

### AskRequest
```
{
    string QuestionString
}
```

### CreatePostRequest
```
{
    string Title,
    string Content,
    List<string> Tags
}
```

### EditAnswerRequest
```
{
    string AnswerString
}
```

### EditCommentRequest
```
{
    string Content
}
```

### EditPostRequest
```
{
    string Title,
    string Content,
    List<string> Tags
}
```
### EditQuestionRequest
```
{
    string QuestionString
}
```

### GetPostsByTagsRequest
```
{
    int PageNumber,
    List<string> Tags
}
```
### RatePostRequest
```
{
    int Rating
}
```

### ReplyToCommentRequest
```
{
    string Content
}
```