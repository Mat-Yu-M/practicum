namespace Api.Entities.Kycs;
public record CreateKycRequest(
int CustomerId,
 string FullName,
 string Country,
 string ZipCode ,
 string AddressLine,
 string DocumentType,
 string SubmittedBy,
 IFormFile DocumentFile
);

