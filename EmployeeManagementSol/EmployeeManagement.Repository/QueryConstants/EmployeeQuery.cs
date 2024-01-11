namespace EmployeeManagement.Repository.QueryConstants
{
    public sealed class EmployeeQuery
    {
        public const string Employees = @"SELECT EmployeeId, EnrollNumber, FirstName, LastName, Email, Mobile, DateOfBirth, IsActive, IsDeleted, LastUpdatedBy, LastUpdatedOn FROM employee WHERE IsDeleted IS NOT TRUE";

        public const string AddNewEmployee = @"INSERT INTO employee(
                                                    EnrollNumber,
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
                                                    @EnrollNumber,
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

        public const string LastEnrollNumber = @"SELECT EnrollNumber FROM employee ORDER BY EmployeeId DESC LIMIT 1;";

        public const string ByEmail = @"SELECT
                                            EmployeeId,
                                            EnrollNumber,
                                            FirstName,
                                            LastName,
                                            Email,
                                            Mobile,
                                            DateOfBirth,
                                            IsActive,
                                            IsDeleted,
                                            LastUpdatedBy,
                                            LastUpdatedOn
                                        FROM
                                            employee
                                        WHERE
                                            Email = @Email AND IsDeleted IS NOT TRUE";

        public const string ByMobile = @"SELECT
                                             EmployeeId,
                                             EnrollNumber,
                                             FirstName,
                                             LastName,
                                             Email,
                                             Mobile,
                                             DateOfBirth,
                                             IsActive,
                                             IsDeleted,
                                             LastUpdatedBy,
                                             LastUpdatedOn
                                         FROM
                                             employee
                                         WHERE
                                             Mobile = @Mobile AND IsDeleted IS NOT TRUE";
    }
}
