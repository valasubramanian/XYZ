using System;
using System.Collections.Generic;
using System.Text;

namespace X.Infrastructure
{
    public interface IFrameworkResponse
    {
        public string[] Errors { get; set; }

        public string[] Warnings { get; set; }
    }
}
