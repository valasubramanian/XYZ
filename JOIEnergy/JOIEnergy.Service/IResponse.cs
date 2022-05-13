using System;

namespace JOIEnergy.Service
{
    public interface IResponse<T>
    {
         string[] Errors { get; set; }

         T Result { get; set; }
    }
}
