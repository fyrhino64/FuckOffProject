using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace FuckOffProject.Models
{
    public interface IResultModel<T>
    {
        bool IsSuccessStatusCode { get; set; }
        T Result { get; set; }
        HttpStatusCode StatusCode { get; set; }
    }

    public class ResultModel<T> : IResultModel<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccessStatusCode { get; set; }
        public T Result { get; set; }
        public void AssertStatusCode(HttpStatusCode status)
        {
            this.StatusCode.Should().Be(status);
        }
    }
}
