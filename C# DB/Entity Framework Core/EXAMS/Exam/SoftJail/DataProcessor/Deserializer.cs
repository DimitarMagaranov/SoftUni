namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var departmentDtos = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            List<Department> departments = new List<Department>();

            foreach (var depDto in departmentDtos)
            {
                if (IsValid(depDto) == false)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }


                Department department = new Department()
                {
                    Name = depDto.Name
                };

                foreach (var cell in depDto.Cells)
                {
                    Cell cell1 = new Cell()
                    {
                        CellNumber = cell.CellNumber,
                        HasWindow = cell.HasWindow
                    };

                    department.Cells.Add(cell1);
                }

                if (department.Cells.Any(c => c.CellNumber < 1 || c.CellNumber > 1000))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (depDto.Cells.Count() == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                departments.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var prisonerDtos = JsonConvert.DeserializeObject<ImportPrisonersMailsDto[]>(jsonString);

            var prisoners = new List<Prisoner>();

            foreach (var prisDto in prisonerDtos)
            {
                var prisDtoMailsCount = prisDto.Mails.Length;

                if (IsValid(prisDto) == false)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime incarcerationDate;

                bool isIncarcerationDateValid = DateTime.TryParseExact(prisDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out incarcerationDate);

                if (isIncarcerationDateValid == false)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime? releaseDate;

                if (String.IsNullOrEmpty(prisDto.ReleaseDate) == false)
                {
                    DateTime releaseDateValue;

                    bool isReleaseDateValid = DateTime.TryParseExact(prisDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out releaseDateValue);

                    if (isReleaseDateValid == false)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    releaseDate = releaseDateValue;
                }
                else
                {
                    releaseDate = null;
                }

                Prisoner prisoner = new Prisoner()
                {
                    FullName = prisDto.FullName,
                    Nickname = prisDto.Nickname,
                    Age = prisDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisDto.Bail,
                    CellId = prisDto.CellId
                };

                foreach (var mail in prisDto.Mails)
                {
                    if (IsValid(mail) == false)
                    {
                        continue;
                    }

                    prisoner.Mails.Add(new Mail { Description = mail.Description, Address = mail.Address, Sender = mail.Sender });
                }

                if (prisDtoMailsCount != prisoner.Mails.Count)
                {
                    continue;
                }

                prisoners.Add(prisoner);

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}