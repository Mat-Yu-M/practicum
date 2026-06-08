namespace Api.Constants
{
    public enum EmployeeRoles
    {
        LoanApprover, //views request of loan and approves or rejects them
        ProductMaker, //creates the loan products and their details
        ProductApprover, //approves or rejects the loan products and their details
        EmployeeManager, //manages the employees and their details  
        EmployeeApprover, //approves or rejects the employees and their details
    }
}
