namespace Core.Enums;

public enum ResponseMessageEnum
{
    None = 0,
    Success = 1,
    SuccessWithData = 2,
    Error = 3,
    ErrorWithMessage = 4,
    ErrorWithData = 5,
    UpdateSuccess = 6,
    UpdateSuccessWithData = 7,
    UpdateError = 8,
    UpdateErrorWithMessage = 9,
    DeleteSuccess = 10,
    DeleteSuccessWithData = 11,
    DeleteError = 12,
    NotFound = 13,
    DeleteErrorWithMessage = 14
}
