using System;
using CleanArchitecture.Domain.Commands.Users.UpdateUser;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.Errors;
using Xunit;

namespace CleanArchitecture.Domain.Tests.CommandHandler.User.UpdateUser;

public sealed class UpdateUserCommandValidationTests :
    ValidationTestBase<UpdateUserCommand, UpdateUserCommandValidation>
{
    public UpdateUserCommandValidationTests() : base(new UpdateUserCommandValidation())
    {
    }
    
    [Fact]
    public void Should_Be_Valid()
    {
        var command = CreateTestCommand();
        
        ShouldBeValid(command);
    }
    
    [Fact]
    public void Should_Be_Invalid_For_Empty_User_Id()
    {
        var command = CreateTestCommand(userId: Guid.Empty);
        
        ShouldHaveSingleError(
            command, 
            DomainErrorCodes.UserEmptyId,
            "User id may not be empty");
    }
    
    [Fact]
    public void Should_Be_Invalid_For_Empty_Email()
    {
        var command = CreateTestCommand(email: string.Empty);
        
        ShouldHaveSingleError(
            command,
            DomainErrorCodes.UserInvalidEmail,
            "Email is not a valid email address");
    }
    
    [Fact]
    public void Should_Be_Invalid_For_Invalid_Email()
    {
        var command = CreateTestCommand(email: "not a email");
        
        ShouldHaveSingleError(
            command,
            DomainErrorCodes.UserInvalidEmail,
            "Email is not a valid email address");
    }
    
    [Fact]
    public void Should_Be_Invalid_For_Email_Exceeds_Max_Length()
    {
        var command = CreateTestCommand(email: new string('a', 320) + "@test.com");
        
        ShouldHaveSingleError(
            command,
            DomainErrorCodes.UserEmailExceedsMaxLength,
            "Email may not be longer than 320 characters");
    }
    
    [Fact]
    public void Should_Be_Invalid_For_Empty_Surname()
    {
        var command = CreateTestCommand(surName: "");
        
        ShouldHaveSingleError(
            command,
            DomainErrorCodes.UserEmptySurname,
            "Surname may not be empty");
    }
    
    [Fact]
    public void Should_Be_Invalid_For_Surname_Exceeds_Max_Length()
    {
        var command = CreateTestCommand(surName: new string('a', 101));
        
        ShouldHaveSingleError(
            command,
            DomainErrorCodes.UserSurnameExceedsMaxLength,
            "Surname may not be longer than 100 characters");
    }
    
    [Fact]
    public void Should_Be_Invalid_For_Empty_Given_Name()
    {
        var command = CreateTestCommand(givenName: "");
        
        ShouldHaveSingleError(
            command,
            DomainErrorCodes.UserEmptyGivenName,
            "Given name may not be empty");
    }
    
    [Fact]
    public void Should_Be_Invalid_For_Given_Name_Exceeds_Max_Length()
    {
        var command = CreateTestCommand(givenName: new string('a', 101));
        
        ShouldHaveSingleError(
            command,
            DomainErrorCodes.UserGivenNameExceedsMaxLength,
            "Given name may not be longer than 100 characters");
    }
    
    private static UpdateUserCommand CreateTestCommand(
        Guid? userId = null,
        string? email = null,
        string? surName = null,
        string? givenName = null,
        UserRole? role = null) => 
        new (
            userId ?? Guid.NewGuid(),
            email ?? "test@email.com",
            surName ?? "test",
            givenName ?? "email",
            role ?? UserRole.User);
}