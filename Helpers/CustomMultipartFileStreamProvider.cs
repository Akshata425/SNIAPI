using SNIAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SNIAPI.Helpers
{
    public class CustomMultipartFileStreamProvider : MultipartMemoryStreamProvider
    {
        public List<UploadExamViewModel> uploadExamDetails { get; set; }

        public CustomMultipartFileStreamProvider()
        {
            uploadExamDetails = new List<UploadExamViewModel>();
        }
        public override Task ExecutePostProcessingAsync()
        {
            foreach (var file in Contents)
            {
                var parameters = file.Headers.ContentDisposition.Parameters;
                var data = new UploadExamViewModel
                {
                     CourseID = int.Parse(GetNameHeaderValue(parameters, "CourseID")),
                     ExamName = GetNameHeaderValue(parameters, "ExamName"),
                     NumberOfQuestions = int.Parse(GetNameHeaderValue(parameters, "NumberOfQuestions")),
                     PassingMarks = int.Parse(GetNameHeaderValue(parameters, "PassingMarks")),
                     Examtime = int.Parse(GetNameHeaderValue(parameters, "Examtime")),
                     ExamtypeID = int.Parse(GetNameHeaderValue(parameters, "ExamtypeID")),
                     InstitueID = int.Parse(GetNameHeaderValue(parameters, "InstitueID")),
                     CreatedBy = int.Parse(GetNameHeaderValue(parameters, "CreatedBy"))

                };

                uploadExamDetails.Add(data);
            }

            return base.ExecutePostProcessingAsync();
        }
        private static string GetNameHeaderValue(ICollection<NameValueHeaderValue> headerValues, string name)
        {
            var nameValueHeader = headerValues.FirstOrDefault(
                x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            return nameValueHeader != null ? nameValueHeader.Value : null;
        }


    }
}