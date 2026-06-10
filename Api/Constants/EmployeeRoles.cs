namespace Api.Constants
{
    public enum EmployeeRoles
    {
        LoanApprover, //views request of loan and approves or rejects them
        LoanMaker, //creates the loan request and their details
        LoanProductMaker, //creates the loan products and their details
        LoanProductApprover, //approves or rejects the loan products and their details
        EmployeeMaker, //creates the employees and their details  
        EmployeeApprover, //approves or rejects the employees and their details
        EmployeeRoleApprover, //approves or rejects the employee roles and their details
        EmployeeRoleMaker, //creates the employee roles and their details
        UserMaker, //creates the users and their details
        UserApprover, //approves or rejects the users and their details
    }
}
