namespace EmployeeManagement.Repository.QueryConstants
{
    public sealed class EmployeeQuery
    {
        public const string Employees = @"SELECT EmployeeId, FirstName, LastName, Email, Mobile, DateOfBirth, IsActive, IsDeleted, LastUpdatedBy, LastUpdatedOn FROM employee WHERE IsDeleted IS NOT TRUE";

        public const string AddNewEmployee = @"INSERT INTO employee(
                                                    FirstName,
                                                    LastName,
                                                    Email,
                                                    Mobile,
                                                    DateOfBirth,
                                                    IsActive,
                                                    IsDeleted,
                                                    LastUpdatedBy,
                                                    LastUpdatedOn
                                                )
                                                VALUES(
                                                    @FirstName,
                                                    @LastName,
                                                    @Email,
                                                    @Mobile,
                                                    @DateOfBirth,
                                                    @IsActive,
                                                    @IsDeleted,
                                                    @LastUpdatedBy,
                                                    @LastUpdatedOn); 
                                                SELECT LAST_INSERT_ID();";

        public const string UpdateEmployee = @"UPDATE
                                                   employee
                                               SET
                                                   FirstName = @FirstName,
                                                   LastName = @LastName,
                                                   Email = @Email,
                                                   Mobile = @Mobile,
                                                   DateOfBirth = @DateOfBirth,
                                                   IsActive = @IsActive,
                                                   IsDeleted = @IsDeleted,
                                                   LastUpdatedBy = @LastUpdatedBy,
                                                   LastUpdatedOn = @LastUpdatedOn
                                               WHERE
                                                   EmployeeId = @EmployeeId";
    }
}
