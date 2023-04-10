namespace Infrastructure
{
    public static class MimeTypes
    {
        public static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".pdf", "application/pdf" },
                {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" }
            };
        }
    }
}


