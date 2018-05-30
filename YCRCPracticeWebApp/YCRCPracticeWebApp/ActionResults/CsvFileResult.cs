using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace YCRCPracticeWebApp.ActionResults
{
    /// <summary>
    /// Class CsvFileResult. This class cannot be inherited.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Web.Mvc.FileResult" />
    public sealed class CsvFileResult<T> : FileResult
        where T : class, new()
    {
        /// <summary>
        /// The data
        /// </summary>
        private readonly IEnumerable<T> _data;

        /// <summary>
        /// The separator
        /// </summary>
        private readonly char _separator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvFileResult{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="fileDownloadName">Name of the file download.</param>
        /// <param name="separator">The separator.</param>
        public CsvFileResult(IEnumerable<T> data, string fileDownloadName, char separator = ',')
        : base("text/csv")
        {
            _data = data;
            FileDownloadName = fileDownloadName;
            _separator = separator;
        }

        /// <summary>
        /// 將檔案寫入至回應。
        /// </summary>
        /// <param name="response">回應。</param>
        protected override void WriteFile(HttpResponseBase response)
        {
            var stream = response.OutputStream;
            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream, Encoding.Default))
            {
                this.WriteHeaderLine(writer);
                this.WriteBodyLines(writer);
                writer.Flush();
                stream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
        }

        /// <summary>
        /// Writes the header line.
        /// </summary>
        /// <param name="writer">The writer.</param>
        private void WriteHeaderLine(TextWriter writer)
        {
            var headerNames = typeof(T).GetProperties().Select(property => property.Name);
            var header = string.Join(_separator.ToString(), headerNames);
            writer.WriteLine(header);
        }

        /// <summary>
        /// Writes the body lines.
        /// </summary>
        /// <param name="writer">The writer.</param>
        private void WriteBodyLines(TextWriter writer)
        {
            var properies = typeof(T).GetProperties();

            foreach (var item in _data)
            {
                var values = properies.Select(property => GetProperyValue(property, item));
                var bodyLine = string.Join(_separator.ToString(), values);
                writer.WriteLine(bodyLine);
            }
        }

        /// <summary>
        /// Gets the propery value.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="item">The item.</param>
        /// <returns>System.String.</returns>
        private static string GetProperyValue(PropertyInfo property, T item)
        {
            return @"""" + (property.GetValue(item) ?? "") + @"""";
        }
    }
}