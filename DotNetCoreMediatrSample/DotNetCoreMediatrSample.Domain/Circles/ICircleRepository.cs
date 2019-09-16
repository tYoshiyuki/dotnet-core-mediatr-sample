using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreMediatrSample.Domain.Circles
{
    public interface ICircleRepository
    {
        Circle Find(CircleId id);
        void Save(Circle circle);

    }
}
